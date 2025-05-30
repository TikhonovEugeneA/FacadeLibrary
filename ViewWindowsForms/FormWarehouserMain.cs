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
        public FormWarehouserMain(User _currentUser,IWarehouserFacade _dbFacade)
        {
            InitializeComponent();
        }
    }
}
