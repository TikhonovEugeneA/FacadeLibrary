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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        public static string connectionString = "Server=localhost;Port=5432;Database=dbshop;User Id=postgres;Password=controlway";
        DBFacade dbFacade = DBFacade.GetInstance(connectionString); 
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            User user = dbFacade.Login(textBoxPhone.Text,textBoxPassword.Text);
            if (user.Role == "customer")
            {

            }
            else if(user.Role == "seller")
            {

            }
            else if (user.Role == "warehouser")
            {

            }

        }
    }
}
