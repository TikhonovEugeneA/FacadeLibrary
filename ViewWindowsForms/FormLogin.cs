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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace ViewWindowsForms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            buttonLogin.Enabled=false;
            buttonRegistration.Enabled=false;
        }
        public static string connectionString = "Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway";
        DBFacade _dbFacade = DBFacade.GetInstance(connectionString); 

        // о входе
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            User user = _dbFacade.Login(textBoxPhone.Text,textBoxPassword.Text);
            if (user.role_name == "customer")
            {
                this.Hide();
                using (var customerForm = new FormCustomerMain(user, _dbFacade))
                {
                    customerForm.ShowDialog();
                }
                this.Show();
                textBoxPassword.Clear();
            }
            if (user.role_name == "seller")
            {
                this.Hide();
                using (var sellerForm = new FormSellerOrders(user, _dbFacade))
                {
                    sellerForm.ShowDialog();
                }
                this.Show();
                textBoxPassword.Clear();
            }
            else if (user.role_name == "warehouser")
            {
                this.Hide();
                using (var warehouserForm = new FormWarehouserMain(user, _dbFacade))
                {
                    warehouserForm.ShowDialog();
                }
                this.Show();
                textBoxPassword.Clear();
            }
            else
            {
                MessageBox.Show("Введены некорректные данные");
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) && textBoxPhone.Text.Length == 0)
            {
                e.Handled = true;
            }
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) && textBoxPassword.Text.Length == 0)
            {
                e.Handled = true;
            }
        }

        private void CheckFields()
        {
            buttonLogin.Enabled = !string.IsNullOrWhiteSpace(textBoxPhone.Text)
                           && !string.IsNullOrWhiteSpace(textBoxPassword.Text);
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e) => CheckFields();

        private void textBoxPassword_TextChanged(object sender, EventArgs e) => CheckFields();

        // о регистрации
        
        private void textBoxFirstNameReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) && textBoxFirstNameReg.Text.Length == 0)
            {
                e.Handled = true;
            }
        }

        private void textBoxLastNameReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) && textBoxLastNameReg.Text.Length == 0)
            {
                e.Handled = true;
            }
        }

        private void textBoxPhoneReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBoxPasswordReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) && textBoxPasswordReg.Text.Length == 0)
            {
                e.Handled = true;
            }
        }

        private void textBoxRepeatPassordReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) && textBoxRepeatPasswordReg.Text.Length == 0)
            {
                e.Handled = true;
            }
        }

        private void CheckFieldsReg()
        {
            buttonRegistration.Enabled = !string.IsNullOrWhiteSpace(textBoxFirstNameReg.Text)
                           && !string.IsNullOrWhiteSpace(textBoxLastNameReg.Text)
                           && !string.IsNullOrWhiteSpace(textBoxPhoneReg.Text)
                           && !string.IsNullOrWhiteSpace(textBoxPasswordReg.Text)
                           && !string.IsNullOrWhiteSpace(textBoxRepeatPasswordReg.Text);
        }
        
        private void textBoxFirstNameReg_TextChanged(object sender, EventArgs e) => CheckFieldsReg();

        private void textBoxLastNameReg_TextChanged(object sender, EventArgs e) => CheckFieldsReg();

        private void textBoxPhoneReg_TextChanged(object sender, EventArgs e) => CheckFieldsReg();

        private void textBoxPasswordReg_TextChanged(object sender, EventArgs e) => CheckFieldsReg();

        private void textBoxRepeatPassordReg_TextChanged(object sender, EventArgs e) => CheckFieldsReg();
        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if(textBoxPasswordReg.Text == textBoxRepeatPasswordReg.Text)
            {
                _dbFacade.RegistrationCustomer(textBoxFirstNameReg.Text, textBoxLastNameReg.Text, textBoxPhoneReg.Text, textBoxPasswordReg.Text);
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }

        }
    }
}
