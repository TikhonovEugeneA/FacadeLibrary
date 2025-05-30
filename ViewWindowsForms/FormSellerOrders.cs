using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacadeLibrary;

namespace ViewWindowsForms
{
    public partial class FormSellerOrders : Form
    {
        private readonly ISellerFacade _dbFacade;
        private readonly User _currentUser; 
        public FormSellerOrders(User user,ISellerFacade dbFacade)
        {
            InitializeComponent();

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _currentUser = user;

            if (dbFacade == null)
            {
                throw new ArgumentNullException(nameof(_dbFacade));
            }
            _dbFacade = dbFacade;

            InitializeSellerForm();

            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            LoadData(_dbFacade.GetOrderListForEmployes(),dataGridViewOrderListForEmployes);
        }
        private void InitializeSellerForm()
        {
            this.Text = $"Продавец: {_currentUser.first_name} {_currentUser.last_name}";
        }
        private void LoadData<T>(T objects, DataGridView currentDataGridView)
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
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageOrders)
            {
                LoadData(_dbFacade.GetOrderListForEmployes(), dataGridViewOrderListForEmployes);
            }
        }

        private void buttonGiveOut_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderListForEmployes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dataGridViewOrderListForEmployes.SelectedRows[0].Cells["ColumnOrderId"].Value);

            try
            {
                _dbFacade.UpdateOrderStatus(orderId, "Выдан", _currentUser.role_name);
                MessageBox.Show("Статус заказа изменен на 'Выдан'", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(_dbFacade.GetOrderListForEmployes(), dataGridViewOrderListForEmployes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRequestOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderListForEmployes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dataGridViewOrderListForEmployes.SelectedRows[0].Cells["ColumnOrderId"].Value);

            try
            {
                _dbFacade.UpdateOrderStatus(orderId, "Запрошен",_currentUser.role_name);
                MessageBox.Show("Статус заказа изменен на 'Запрошен'", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(_dbFacade.GetOrderListForEmployes(), dataGridViewOrderListForEmployes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReturnOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderListForEmployes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dataGridViewOrderListForEmployes.SelectedRows[0].Cells["ColumnOrderId"].Value);

            try
            {
                _dbFacade.UpdateOrderStatus(orderId, "Возврат", _currentUser.role_name);
                MessageBox.Show("Статус заказа изменен на 'Возврат'", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(_dbFacade.GetOrderListForEmployes(), dataGridViewOrderListForEmployes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTransfered_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderListForEmployes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dataGridViewOrderListForEmployes.SelectedRows[0].Cells["ColumnOrderId"].Value);

            try
            {
                _dbFacade.UpdateOrderStatus(orderId, "Передан", _currentUser.role_name);
                MessageBox.Show("Статус заказа изменен на 'Возврат'", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(_dbFacade.GetOrderListForEmployes(), dataGridViewOrderListForEmployes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewOrderListForEmployes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewOrderListForEmployes.Columns["ColumnGetOrderInfoForSeller"].Index && e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dataGridViewOrderListForEmployes.Rows[e.RowIndex].Cells["ColumnOrderIdForSeller"].Value);

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
    }
}
