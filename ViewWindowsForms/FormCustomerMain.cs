using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacadeLibrary;

namespace ViewWindowsForms
{
    public partial class FormCustomerMain : Form
    {
        private readonly ICustomerFacade _dbFacade;
        private readonly User _currentUser;
        public FormCustomerMain(User user, ICustomerFacade dbFacade)
        {
            InitializeComponent();

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _currentUser = user;

            if (dbFacade == null)
            {
                throw new ArgumentNullException(nameof(dbFacade));
            }
            _dbFacade = dbFacade;

            InitializeCustomerForm();

            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            LoadData(_dbFacade.GetProductList(),dataGridViewProducts);
        }
        private void InitializeCustomerForm()
        {
            this.Text = $"Покупатель: {_currentUser.first_name} {_currentUser.last_name}";
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageProducts)
            {
                LoadData(_dbFacade.GetProductList(), dataGridViewProducts);
            }
            else if (tabControl1.SelectedTab == tabPageCart)
            {
                LoadData(_dbFacade.GetProductsFromCart(_currentUser.user_id),dataGridViewCart);
            }
            else if (tabControl1.SelectedTab == tabPageOrders)
            {
                LoadData(_dbFacade.GetOrderListForCustomer(_currentUser.user_id), dataGridViewOrders);
            }
        }
        private void LoadData<T>(T objects,DataGridView currentDataGridView)
        {
            try
            {
                if (objects == null)
                {
                    currentDataGridView.DataSource = null;
                    MessageBox.Show("Нет данных для отображения", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                currentDataGridView.DataSource = objects;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продуктов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewProducts.Columns["ColumnSaveInCart"].Index && e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dataGridViewProducts.Rows[e.RowIndex].Cells["ColumnProductId"].Value);
                int productCount = Convert.ToInt32(dataGridViewProducts.Rows[e.RowIndex].Cells["ColumnProductCount"].Value);
                if (productCount <= 0)
                {
                    MessageBox.Show("Товар отсутствует на складе", "Ошибка");
                    return;
                }
                _dbFacade.SaveProductInCart(_currentUser.user_id, productId);
                MessageBox.Show("Товар добавлен в корзину", "Успех");
            }
        }
        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewCart.Columns["ColumnDeleteProductFromCart"].Index && e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dataGridViewCart.Rows[e.RowIndex].Cells["ColumnCartProductId"].Value);
                _dbFacade.DeleteProductFromCart(_currentUser.user_id,productId);
                MessageBox.Show("Товар удален из корзины", "Успех");
            }
            LoadData(_dbFacade.GetProductsFromCart(_currentUser.user_id), dataGridViewCart);
        }
        private void buttonSendOrder_Click(object sender, EventArgs e)
        {
            try
            {
                List<Cart> cartProducts = _dbFacade.GetProductsFromCart(_currentUser.user_id);

                if (cartProducts == null || cartProducts.Count == 0)
                {
                    MessageBox.Show("Ваша корзина пуста. Добавьте товары перед оформлением заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<int> productIds = cartProducts.Select(p => p.product_id).ToList();
                List<int> productCounts = cartProducts.Select(p => p.product_count_in_cart).ToList();

                foreach (var item in cartProducts)
                {
                    if (item.product_count_in_cart > item.product_count)
                    {
                        throw new Exception($"Товара '{item.product_name}' недостаточно на складе. Доступно: {item.product_count}, запрошено: {item.product_count_in_cart}");
                    }
                }

                _dbFacade.CreateOrder(_currentUser.user_id, productIds, productCounts);

                MessageBox.Show("Заказ успешно оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _dbFacade.ClearCartAfterCalculateOrderCost(_currentUser.user_id);
                LoadData(_dbFacade.GetProductsFromCart(_currentUser.user_id), dataGridViewCart);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка оформления заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewOrders.Columns["ColumnOrderInfo"].Index && e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dataGridViewOrders.Rows[e.RowIndex].Cells["ColumnOrderId"].Value);

                List<Product> orderProducts = _dbFacade.GetProductListInOrder(orderId);

                StringBuilder message = new StringBuilder();
                message.AppendLine($"Товары в заказе #{orderId}:");
                message.AppendLine("----------------------------");

                decimal totalOrderSum = 0;

                foreach (var product in orderProducts)
                {
                    decimal pricePerItem = product.UnitPrice;
                    decimal discountAmount = 0;
                    bool hasDiscount = false;

                    if (product.ConditionWholesale <= product.ProductCount && product.Discount > 0)
                    {
                        discountAmount = product.UnitPrice * (product.Discount / 100m);
                        pricePerItem = product.UnitPrice - discountAmount;
                        hasDiscount = true;
                    }

                    decimal productTotal = pricePerItem * product.ProductCount;
                    totalOrderSum += productTotal;

                    message.AppendLine($"{product.ProductName} - {product.ProductCount} шт.");

                    if (hasDiscount)
                    {
                        message.AppendLine($"Цена без скидки: {product.UnitPrice:C}");
                        message.AppendLine($"Скидка: {product.Discount}% ({discountAmount:C} на шт.)");
                    }

                    message.AppendLine($"Цена за шт.: {pricePerItem:C}");
                    message.AppendLine($"Сумма: {productTotal:C}");
                    message.AppendLine("----------------------------------");
                }

                message.AppendLine("----------------------------");
                message.AppendLine($"Итого: {totalOrderSum:C}");

                MessageBox.Show(message.ToString(), "Состав заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dataGridViewCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewCart.Columns[e.ColumnIndex].Name == "ColumnCartProductCount")
            {
                try
                {
                    var cell = dataGridViewCart.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    int newCount;

                    if (!int.TryParse(cell.Value?.ToString(), out newCount) || newCount < 0)
                    {
                        MessageBox.Show("Введите корректное неотрицательное число для количества.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData(_dbFacade.GetProductsFromCart(_currentUser.user_id), dataGridViewCart);
                        return;
                    }
                    int productId = Convert.ToInt32(dataGridViewCart.Rows[e.RowIndex].Cells["ColumnCartProductId"].Value);

                    _dbFacade.UpdateProductCountInCart(_currentUser.user_id, productId, newCount);

                    LoadData(_dbFacade.GetProductsFromCart(_currentUser.user_id), dataGridViewCart);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка обновления количества товара в корзине: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancelOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells["ColumnOrderId"].Value);

            try
            {
                _dbFacade.UpdateOrderStatus(orderId, "Отменен", _currentUser.role_name);
                MessageBox.Show("Статус заказа изменен на 'Отменен'", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(_dbFacade.GetOrderListForCustomer(_currentUser.user_id), dataGridViewOrders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
