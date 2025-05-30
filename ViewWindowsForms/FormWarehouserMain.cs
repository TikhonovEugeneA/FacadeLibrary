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
    public partial class FormWarehouserMain : Form
    {
        private readonly IWarehouserFacade _dbFacade;
        private readonly User _currentUser;
        public FormWarehouserMain(User user,IWarehouserFacade dbFacade)
        {
            InitializeComponent();
            if(user is null)
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

            tabControlWarehouser.SelectedIndexChanged += tabControlWarehouser_SelectedIndexChanged;

            LoadData(_dbFacade.GetProductList(), dataGridViewProducts);
        }
        private void InitializeSellerForm()
        {
            this.Text = $"Кладовщик: {_currentUser.first_name} {_currentUser.last_name}";
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

        private void tabControlWarehouser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlWarehouser.SelectedTab == tabPageOrders)
            {
                LoadData(_dbFacade.GetOrderListForEmployes(), dataGridViewOrdersForWarehouser);
            }
            if (tabControlWarehouser.SelectedTab == tabPageProducts)
            {
                LoadData(_dbFacade.GetOrderListForEmployes(), dataGridViewProducts);
            }
            if(tabControlWarehouser.SelectedTab == tabPageShipments)
            {
                LoadData(_dbFacade.GetOrderListForEmployes(), dataGridViewShipments);
            }
        }
    }
}
