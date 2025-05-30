using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacadeLibrary;

namespace ViewWindowsForms
{
    public partial class FormWarehouserMain : Form
    {
        private readonly IWarehouserFacade _dbFacade;
        private readonly User _currentUser;

        public FormWarehouserMain(User user, IWarehouserFacade dbFacade)
        {
            InitializeComponent();
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            _dbFacade = dbFacade ?? throw new ArgumentNullException(nameof(dbFacade));

            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = $"Кладовщик: {_currentUser.first_name} {_currentUser.last_name}";
            LoadStatusList();
            LoadProducts();
            tabControlWarehouser.SelectedIndexChanged += TabControlWarehouser_SelectedIndexChanged;
        }

        private void LoadProducts()
        {
            var products = _dbFacade.GetProductList();
            LoadData(products, dataGridViewProducts);
        }

        private void LoadData<T>(IEnumerable<T> objects, DataGridView currentDataGridView)
        {
            if (objects == null || !objects.Any())
            {
                currentDataGridView.DataSource = null;
                MessageBox.Show("Нет данных для отображения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            currentDataGridView.DataSource = objects.ToList();
        }

        private void LoadStatusList()
        {
            var statusList = _dbFacade.GetStatusList().ToList();
            ColumnNewOrderStatus.DataSource = statusList;
            ColumnNewOrderStatus.DisplayMember = "status_name";
            ColumnNewOrderStatus.ValueMember = "status_name";
        }

        private void TabControlWarehouser_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlWarehouser.SelectedTab)
            {
                case var tab when tab == tabPageOrders:
                    LoadOrdersForEmployees();
                    break;
                case var tab when tab == tabPageProducts:
                    LoadProducts();
                    break;
                case var tab when tab == tabPageShipments:
                    LoadShipments();
                    break;
            }
        }

        private void LoadOrdersForEmployees()
        {
            var orders = _dbFacade.GetOrderListForEmployes();
            LoadData(orders, dataGridViewOrdersForWarehouser);
            SetUpStatusComboBox();
        }

        private void LoadShipments()
        {
            var shipments = _dbFacade.GetShipmentList();
            LoadData(shipments, dataGridViewShipments);
        }

        private void SetUpStatusComboBox()
        {
            var statusList = _dbFacade.GetStatusList().ToList();

            foreach (DataGridViewRow row in dataGridViewOrdersForWarehouser.Rows)
            {
                if (row.IsNewRow) continue;

                var statusCell = row.Cells["ColumnNewOrderStatus"] as DataGridViewComboBoxCell;
                if (statusCell != null)
                {
                    statusCell.DataSource = statusList;
                    var currentStatus = row.Cells["statusDataGridViewTextBoxColumn"].Value?.ToString();
                    if (currentStatus != null)
                    {
                        statusCell.Value = currentStatus;
                    }
                }
            }
        }

        private void buttonUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrdersForWarehouser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для изменения статуса", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var selectedRow = dataGridViewOrdersForWarehouser.SelectedRows[0];
                int orderId = (int)selectedRow.Cells["orderIdDataGridViewTextBoxColumn"].Value;
                var statusComboBox = (DataGridViewComboBoxCell)selectedRow.Cells["ColumnNewOrderStatus"];

                if (statusComboBox.Value == null)
                {
                    MessageBox.Show("Выберите новый статус из списка", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string newStatus = statusComboBox.Value.ToString();
                _dbFacade.UpdateOrderStatus(orderId, newStatus, _currentUser.role_name);
                LoadOrdersForEmployees();
                MessageBox.Show("Статус заказа успешно изменен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка изменения статуса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddShipment_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateShipments()) return;

                foreach (DataGridViewRow row in dataGridViewShipments.Rows)
                {
                    if (row.IsNewRow) continue;

                    int productId = GetProductId(row);
                    int shipperId = GetShipperId(row);
                    int productCount = GetProductCount(row);

                    if (productCount > 0)
                    {
                        _dbFacade.AddShipment(productId, shipperId, productCount);
                    }
                }

                MessageBox.Show("Поставки успешно добавлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении поставок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateShipments()
        {
            foreach (DataGridViewRow row in dataGridViewShipments.Rows)
            {
                if (row.IsNewRow) continue;

                if (!IsSupplierSelected(row) || !IsQuantityValid(row))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSupplierSelected(DataGridViewRow row)
        {
            var supplierCell = row.Cells["comboBoxSuppliers"] as DataGridViewComboBoxCell;
            if (supplierCell?.Value == null)
            {
                MessageBox.Show("Выберите поставщика для всех товаров.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool IsQuantityValid(DataGridViewRow row)
        {
            var quantityCell = row.Cells["ColumnQuantity"] as DataGridViewTextBoxCell;
            if (quantityCell != null && int.TryParse(quantityCell.Value?.ToString(), out int productCount) && productCount > 0)
            {
                return true;
            }

            MessageBox.Show("Введите корректное количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private int GetProductId(DataGridViewRow row)
        {
            return (int)row.Cells["productIdDataGridViewTextBoxColumn"].Value;
        }

        private int GetShipperId(DataGridViewRow row)
        {
            var supplierCell = row.Cells["ColumnSupplier"] as DataGridViewComboBoxCell;
            return (int)supplierCell.Value;
        }

        private int GetProductCount(DataGridViewRow row)
        {
            var quantityCell = row.Cells["ColumnQuantity"] as DataGridViewTextBoxCell;
            return int.TryParse(quantityCell.Value?.ToString(), out int count) ? count : 0;
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewProducts.Rows.Count)
                return; 
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dataGridViewProducts.Columns.Count)
                return; 

            var cell = dataGridViewProducts.Rows[e.RowIndex].Cells["productIdDataGridViewTextBoxColumn"];

            if (cell?.Value != null)
            {
                try
                {
                    var productId = (int)cell.Value;
                    MessageBox.Show($"ID продукта: {productId}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Ошибка приведения типа. Убедитесь, что ID продукта является числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Не удалось получить ID продукта. Проверьте данные в таблице.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridViewOrdersForWarehouser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewOrdersForWarehouser.Columns["ColumnGetOrderInfo"].Index && e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dataGridViewOrdersForWarehouser.Rows[e.RowIndex].Cells["orderIdDataGridViewTextBoxColumn"].Value);

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
