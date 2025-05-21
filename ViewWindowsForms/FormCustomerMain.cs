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
    public partial class FormCustomerMain : Form
    {
        private readonly DBFacade _dbFacade;
        private readonly User _currentUser; // Добавляем поле для хранения пользователя
        public FormCustomerMain(User user, DBFacade dbFacade)
        {
            InitializeComponent();

            // Проверка user на null с помощью явного условия
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _currentUser = user;

            // Проверка dbFacade на null
            if (dbFacade == null)
            {
                throw new ArgumentNullException(nameof(dbFacade));
            }
            _dbFacade = dbFacade;

            // Инициализация формы
            InitializeCustomerForm();

            // Подписываемся на событие переключения вкладок
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            // Первоначальная загрузка данных
            LoadProductsData();
        }
        private void InitializeCustomerForm()
        {
            // Настройка заголовка формы
            this.Text = $"Покупатель: {_currentUser.FirstName} {_currentUser.LastName}";

            // Дополнительные настройки формы
            ConfigureDataGridViewFormat();
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При переключении вкладок обновляем данные
            if (tabControl1.SelectedTab == tabPage1)
            {
                LoadProductsData();
            }
            // Можно добавить обработку других вкладок
        }
        private void LoadProductsData()
        {
            try
            {
                var products = _dbFacade.GetProductList();

                if (products == null || products.Count == 0)
                {
                    dataGridViewProducts.DataSource = null;
                    MessageBox.Show("Нет данных для отображения", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridViewProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продуктов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViewFormat()
        {
            dataGridViewProducts.AutoGenerateColumns = false;

            // Настраиваем привязку данных для каждой колонки
            ColumnProductName.DataPropertyName = "ProductName";
            ColumnManufacturer.DataPropertyName = "Manufacturer";
            ColumnUnitPrice.DataPropertyName = "UnitPrice";
            ColumnConditionWholesale.DataPropertyName = "ConditionWholesale";
            ColumnDiscount.DataPropertyName = "Discount";
            ColumnProductCount.DataPropertyName = "ProductCount";
            ColumnProductCategory.DataPropertyName = "CategoryName";

            // Автоматическое изменение ширины колонок
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void buttonAddProductInCart_Click(object sender, EventArgs e)
        {

        }
    }
}
