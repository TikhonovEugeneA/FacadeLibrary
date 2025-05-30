namespace ViewWindowsForms
{
    partial class FormWarehouserMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlWarehouser = new System.Windows.Forms.TabControl();
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.tabPageShipments = new System.Windows.Forms.TabPage();
            this.dataGridViewShipments = new System.Windows.Forms.DataGridView();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.dataGridViewOrdersForWarehouser = new System.Windows.Forms.DataGridView();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnGetOrderInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userFirstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNewOrderStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conditionWholesaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlWarehouser.SuspendLayout();
            this.tabPageProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.tabPageShipments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShipments)).BeginInit();
            this.tabPageOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdersForWarehouser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlWarehouser
            // 
            this.tabControlWarehouser.Controls.Add(this.tabPageProducts);
            this.tabControlWarehouser.Controls.Add(this.tabPageOrders);
            this.tabControlWarehouser.Controls.Add(this.tabPageShipments);
            this.tabControlWarehouser.Location = new System.Drawing.Point(12, 13);
            this.tabControlWarehouser.Name = "tabControlWarehouser";
            this.tabControlWarehouser.SelectedIndex = 0;
            this.tabControlWarehouser.Size = new System.Drawing.Size(958, 571);
            this.tabControlWarehouser.TabIndex = 2;
            this.tabControlWarehouser.SelectedIndexChanged += new System.EventHandler(this.tabControlWarehouser_SelectedIndexChanged);
            // 
            // tabPageProducts
            // 
            this.tabPageProducts.Controls.Add(this.dataGridViewProducts);
            this.tabPageProducts.Location = new System.Drawing.Point(4, 25);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProducts.Size = new System.Drawing.Size(950, 542);
            this.tabPageProducts.TabIndex = 0;
            this.tabPageProducts.Text = "Главная";
            this.tabPageProducts.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AutoGenerateColumns = false;
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIdDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.categoryNameDataGridViewTextBoxColumn,
            this.unitPriceDataGridViewTextBoxColumn,
            this.conditionWholesaleDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.productCountDataGridViewTextBoxColumn});
            this.dataGridViewProducts.DataSource = this.productBindingSource;
            this.dataGridViewProducts.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.RowTemplate.Height = 24;
            this.dataGridViewProducts.Size = new System.Drawing.Size(938, 443);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // tabPageShipments
            // 
            this.tabPageShipments.Controls.Add(this.dataGridViewShipments);
            this.tabPageShipments.Location = new System.Drawing.Point(4, 25);
            this.tabPageShipments.Name = "tabPageShipments";
            this.tabPageShipments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShipments.Size = new System.Drawing.Size(950, 542);
            this.tabPageShipments.TabIndex = 1;
            this.tabPageShipments.Text = "Поставка";
            this.tabPageShipments.UseVisualStyleBackColor = true;
            // 
            // dataGridViewShipments
            // 
            this.dataGridViewShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShipments.Location = new System.Drawing.Point(7, 7);
            this.dataGridViewShipments.Name = "dataGridViewShipments";
            this.dataGridViewShipments.RowHeadersWidth = 51;
            this.dataGridViewShipments.RowTemplate.Height = 24;
            this.dataGridViewShipments.Size = new System.Drawing.Size(937, 461);
            this.dataGridViewShipments.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.dataGridViewOrdersForWarehouser);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 25);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Size = new System.Drawing.Size(950, 542);
            this.tabPageOrders.TabIndex = 2;
            this.tabPageOrders.Text = "Заказы";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOrdersForWarehouser
            // 
            this.dataGridViewOrdersForWarehouser.AutoGenerateColumns = false;
            this.dataGridViewOrdersForWarehouser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrdersForWarehouser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrdersForWarehouser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnGetOrderInfo,
            this.orderIdDataGridViewTextBoxColumn,
            this.userLastNameDataGridViewTextBoxColumn,
            this.userFirstNameDataGridViewTextBoxColumn,
            this.userPhoneDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.orderCostDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.ColumnNewOrderStatus});
            this.dataGridViewOrdersForWarehouser.DataSource = this.orderBindingSource;
            this.dataGridViewOrdersForWarehouser.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOrdersForWarehouser.Name = "dataGridViewOrdersForWarehouser";
            this.dataGridViewOrdersForWarehouser.RowHeadersWidth = 51;
            this.dataGridViewOrdersForWarehouser.RowTemplate.Height = 24;
            this.dataGridViewOrdersForWarehouser.Size = new System.Drawing.Size(929, 459);
            this.dataGridViewOrdersForWarehouser.TabIndex = 0;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(FacadeLibrary.Order);
            // 
            // ColumnGetOrderInfo
            // 
            this.ColumnGetOrderInfo.HeaderText = "Информация о заказе";
            this.ColumnGetOrderInfo.MinimumWidth = 6;
            this.ColumnGetOrderInfo.Name = "ColumnGetOrderInfo";
            this.ColumnGetOrderInfo.ReadOnly = true;
            this.ColumnGetOrderInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnGetOrderInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnGetOrderInfo.Text = "О заказе";
            this.ColumnGetOrderInfo.UseColumnTextForButtonValue = true;
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "ID";
            this.orderIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            // 
            // userLastNameDataGridViewTextBoxColumn
            // 
            this.userLastNameDataGridViewTextBoxColumn.DataPropertyName = "UserLastName";
            this.userLastNameDataGridViewTextBoxColumn.HeaderText = "Фамилия заказчика";
            this.userLastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userLastNameDataGridViewTextBoxColumn.Name = "userLastNameDataGridViewTextBoxColumn";
            // 
            // userFirstNameDataGridViewTextBoxColumn
            // 
            this.userFirstNameDataGridViewTextBoxColumn.DataPropertyName = "UserFirstName";
            this.userFirstNameDataGridViewTextBoxColumn.HeaderText = "Имя заказчика";
            this.userFirstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userFirstNameDataGridViewTextBoxColumn.Name = "userFirstNameDataGridViewTextBoxColumn";
            // 
            // userPhoneDataGridViewTextBoxColumn
            // 
            this.userPhoneDataGridViewTextBoxColumn.DataPropertyName = "UserPhone";
            this.userPhoneDataGridViewTextBoxColumn.HeaderText = "Телефон заказчика";
            this.userPhoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userPhoneDataGridViewTextBoxColumn.Name = "userPhoneDataGridViewTextBoxColumn";
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.orderDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            // 
            // orderCostDataGridViewTextBoxColumn
            // 
            this.orderCostDataGridViewTextBoxColumn.DataPropertyName = "OrderCost";
            this.orderCostDataGridViewTextBoxColumn.HeaderText = "Стоимость";
            this.orderCostDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderCostDataGridViewTextBoxColumn.Name = "orderCostDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnNewOrderStatus
            // 
            this.ColumnNewOrderStatus.HeaderText = "Новый статус";
            this.ColumnNewOrderStatus.MinimumWidth = 6;
            this.ColumnNewOrderStatus.Name = "ColumnNewOrderStatus";
            this.ColumnNewOrderStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnNewOrderStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(FacadeLibrary.Product);
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "ProductId";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "ProductId";
            this.productIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            this.productIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.productNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            // 
            // categoryNameDataGridViewTextBoxColumn
            // 
            this.categoryNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.categoryNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            this.unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            this.unitPriceDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.unitPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            // 
            // conditionWholesaleDataGridViewTextBoxColumn
            // 
            this.conditionWholesaleDataGridViewTextBoxColumn.DataPropertyName = "ConditionWholesale";
            this.conditionWholesaleDataGridViewTextBoxColumn.HeaderText = "Условия скидки";
            this.conditionWholesaleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.conditionWholesaleDataGridViewTextBoxColumn.Name = "conditionWholesaleDataGridViewTextBoxColumn";
            // 
            // discountDataGridViewTextBoxColumn
            // 
            this.discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
            this.discountDataGridViewTextBoxColumn.HeaderText = "Скидка";
            this.discountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            // 
            // productCountDataGridViewTextBoxColumn
            // 
            this.productCountDataGridViewTextBoxColumn.DataPropertyName = "ProductCount";
            this.productCountDataGridViewTextBoxColumn.HeaderText = "В наличии";
            this.productCountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productCountDataGridViewTextBoxColumn.Name = "productCountDataGridViewTextBoxColumn";
            // 
            // FormWarehouserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 596);
            this.Controls.Add(this.tabControlWarehouser);
            this.Name = "FormWarehouserMain";
            this.Text = "FormWarehouserMain";
            this.tabControlWarehouser.ResumeLayout(false);
            this.tabPageProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.tabPageShipments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShipments)).EndInit();
            this.tabPageOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdersForWarehouser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlWarehouser;
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.TabPage tabPageShipments;
        private System.Windows.Forms.DataGridView dataGridViewShipments;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrdersForWarehouser;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnGetOrderInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnNewOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conditionWholesaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource productBindingSource;
    }
}