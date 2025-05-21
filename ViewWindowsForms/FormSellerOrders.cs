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
        private readonly DBFacade _dbFacade;
        private readonly User _currentUser; // Добавляем поле для хранения пользователя
        public FormSellerOrders(/*user, _dbFacade*/)
        {
            //InitializeComponent();
            //// Проверка user на null с помощью явного условия
            //if (user is null)
            //{
            //    throw new ArgumentNullException(nameof(user));
            //}
            //_currentUser = user;

            //// Проверка dbFacade на null
            //if (dbFacade == null)
            //{
            //    throw new ArgumentNullException(nameof(dbFacade));
            //}
            //_dbFacade = dbFacade;

            //// Инициализация формы
            //InitializeCustomerForm();

            //// Подписываемся на событие переключения вкладок
            //tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            //// Первоначальная загрузка данных
            //LoadProductsData();
        }

    }
}
