namespace ViewWindowsForms
{
    partial class FormCustomerMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.ColumnProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConditionWholesale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaveInCart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPageCart = new System.Windows.Forms.TabPage();
            this.buttonSendOrder = new System.Windows.Forms.Button();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.ColumnDeleteProductFromCart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCartProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCartProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCartProductCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCartManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCartUnitePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCartConditionWholesale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCartDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCartProductInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCartProductCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.ColumnOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonCancelOrder = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.tabPageCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.tabPageOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageProducts);
            this.tabControl1.Controls.Add(this.tabPageCart);
            this.tabControl1.Controls.Add(this.tabPageOrders);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(958, 571);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
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
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProductId,
            this.ColumnProductName,
            this.ColumnProductCategory,
            this.ColumnManufacturer,
            this.ColumnProductCount,
            this.ColumnConditionWholesale,
            this.ColumnDiscount,
            this.ColumnUnitPrice,
            this.ColumnSaveInCart});
            this.dataGridViewProducts.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.RowTemplate.Height = 24;
            this.dataGridViewProducts.Size = new System.Drawing.Size(938, 443);
            this.dataGridViewProducts.TabIndex = 0;
            this.dataGridViewProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellContentClick);
            // 
            // ColumnProductId
            // 
            this.ColumnProductId.DataPropertyName = "ProductId";
            this.ColumnProductId.HeaderText = "ID";
            this.ColumnProductId.MinimumWidth = 6;
            this.ColumnProductId.Name = "ColumnProductId";
            this.ColumnProductId.Visible = false;
            // 
            // ColumnProductName
            // 
            this.ColumnProductName.DataPropertyName = "ProductName";
            this.ColumnProductName.HeaderText = "Название";
            this.ColumnProductName.MinimumWidth = 6;
            this.ColumnProductName.Name = "ColumnProductName";
            this.ColumnProductName.ReadOnly = true;
            // 
            // ColumnProductCategory
            // 
            this.ColumnProductCategory.DataPropertyName = "CategoryName";
            this.ColumnProductCategory.HeaderText = "Категория";
            this.ColumnProductCategory.MinimumWidth = 6;
            this.ColumnProductCategory.Name = "ColumnProductCategory";
            this.ColumnProductCategory.ReadOnly = true;
            // 
            // ColumnManufacturer
            // 
            this.ColumnManufacturer.DataPropertyName = "Manufacturer";
            this.ColumnManufacturer.HeaderText = "Производитель";
            this.ColumnManufacturer.MinimumWidth = 6;
            this.ColumnManufacturer.Name = "ColumnManufacturer";
            this.ColumnManufacturer.ReadOnly = true;
            // 
            // ColumnProductCount
            // 
            this.ColumnProductCount.DataPropertyName = "ProductCount";
            this.ColumnProductCount.HeaderText = "В наличии";
            this.ColumnProductCount.MinimumWidth = 6;
            this.ColumnProductCount.Name = "ColumnProductCount";
            this.ColumnProductCount.ReadOnly = true;
            // 
            // ColumnConditionWholesale
            // 
            this.ColumnConditionWholesale.DataPropertyName = "ConditionWholesale";
            this.ColumnConditionWholesale.HeaderText = "Условия скидки";
            this.ColumnConditionWholesale.MinimumWidth = 6;
            this.ColumnConditionWholesale.Name = "ColumnConditionWholesale";
            this.ColumnConditionWholesale.ReadOnly = true;
            // 
            // ColumnDiscount
            // 
            this.ColumnDiscount.DataPropertyName = "Discount";
            this.ColumnDiscount.HeaderText = "Скидка";
            this.ColumnDiscount.MinimumWidth = 6;
            this.ColumnDiscount.Name = "ColumnDiscount";
            this.ColumnDiscount.ReadOnly = true;
            // 
            // ColumnUnitPrice
            // 
            this.ColumnUnitPrice.DataPropertyName = "UnitPrice";
            this.ColumnUnitPrice.HeaderText = "Цена";
            this.ColumnUnitPrice.MinimumWidth = 6;
            this.ColumnUnitPrice.Name = "ColumnUnitPrice";
            this.ColumnUnitPrice.ReadOnly = true;
            // 
            // ColumnSaveInCart
            // 
            this.ColumnSaveInCart.HeaderText = "";
            this.ColumnSaveInCart.MinimumWidth = 6;
            this.ColumnSaveInCart.Name = "ColumnSaveInCart";
            this.ColumnSaveInCart.ReadOnly = true;
            this.ColumnSaveInCart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSaveInCart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSaveInCart.Text = "Добавить";
            this.ColumnSaveInCart.UseColumnTextForButtonValue = true;
            // 
            // tabPageCart
            // 
            this.tabPageCart.Controls.Add(this.buttonSendOrder);
            this.tabPageCart.Controls.Add(this.dataGridViewCart);
            this.tabPageCart.Location = new System.Drawing.Point(4, 25);
            this.tabPageCart.Name = "tabPageCart";
            this.tabPageCart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCart.Size = new System.Drawing.Size(950, 542);
            this.tabPageCart.TabIndex = 1;
            this.tabPageCart.Text = "Корзина";
            this.tabPageCart.UseVisualStyleBackColor = true;
            // 
            // buttonSendOrder
            // 
            this.buttonSendOrder.Location = new System.Drawing.Point(365, 496);
            this.buttonSendOrder.Name = "buttonSendOrder";
            this.buttonSendOrder.Size = new System.Drawing.Size(200, 23);
            this.buttonSendOrder.TabIndex = 1;
            this.buttonSendOrder.Text = "Оформить заказ";
            this.buttonSendOrder.UseVisualStyleBackColor = true;
            this.buttonSendOrder.Click += new System.EventHandler(this.buttonSendOrder_Click);
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDeleteProductFromCart,
            this.ColumnCartProductId,
            this.ColumnCartProductName,
            this.ColumnCartProductCategory,
            this.ColumnCartManufacturer,
            this.ColumnCartUnitePrice,
            this.ColumnCartConditionWholesale,
            this.ColumnCartDiscount,
            this.ColumnCartProductInStock,
            this.ColumnCartProductCount});
            this.dataGridViewCart.Location = new System.Drawing.Point(3, 6);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.RowHeadersWidth = 51;
            this.dataGridViewCart.RowTemplate.Height = 24;
            this.dataGridViewCart.Size = new System.Drawing.Size(937, 461);
            this.dataGridViewCart.TabIndex = 0;
            this.dataGridViewCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCart_CellContentClick);
            this.dataGridViewCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCart_CellValueChanged);
            // 
            // ColumnDeleteProductFromCart
            // 
            this.ColumnDeleteProductFromCart.HeaderText = "";
            this.ColumnDeleteProductFromCart.MinimumWidth = 6;
            this.ColumnDeleteProductFromCart.Name = "ColumnDeleteProductFromCart";
            this.ColumnDeleteProductFromCart.ReadOnly = true;
            this.ColumnDeleteProductFromCart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDeleteProductFromCart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnDeleteProductFromCart.Text = "Удалить";
            this.ColumnDeleteProductFromCart.UseColumnTextForButtonValue = true;
            // 
            // ColumnCartProductId
            // 
            this.ColumnCartProductId.DataPropertyName = "product_id";
            this.ColumnCartProductId.HeaderText = "ID";
            this.ColumnCartProductId.MinimumWidth = 6;
            this.ColumnCartProductId.Name = "ColumnCartProductId";
            this.ColumnCartProductId.Visible = false;
            // 
            // ColumnCartProductName
            // 
            this.ColumnCartProductName.DataPropertyName = "product_name";
            this.ColumnCartProductName.HeaderText = "Название";
            this.ColumnCartProductName.MinimumWidth = 6;
            this.ColumnCartProductName.Name = "ColumnCartProductName";
            this.ColumnCartProductName.ReadOnly = true;
            // 
            // ColumnCartProductCategory
            // 
            this.ColumnCartProductCategory.DataPropertyName = "category_name";
            this.ColumnCartProductCategory.HeaderText = "Категория";
            this.ColumnCartProductCategory.MinimumWidth = 6;
            this.ColumnCartProductCategory.Name = "ColumnCartProductCategory";
            this.ColumnCartProductCategory.ReadOnly = true;
            // 
            // ColumnCartManufacturer
            // 
            this.ColumnCartManufacturer.DataPropertyName = "manufacturer";
            this.ColumnCartManufacturer.HeaderText = "Производитель";
            this.ColumnCartManufacturer.MinimumWidth = 6;
            this.ColumnCartManufacturer.Name = "ColumnCartManufacturer";
            this.ColumnCartManufacturer.ReadOnly = true;
            // 
            // ColumnCartUnitePrice
            // 
            this.ColumnCartUnitePrice.DataPropertyName = "unit_price";
            this.ColumnCartUnitePrice.HeaderText = "Цена";
            this.ColumnCartUnitePrice.MinimumWidth = 6;
            this.ColumnCartUnitePrice.Name = "ColumnCartUnitePrice";
            this.ColumnCartUnitePrice.ReadOnly = true;
            // 
            // ColumnCartConditionWholesale
            // 
            this.ColumnCartConditionWholesale.DataPropertyName = "condition_wholesale";
            this.ColumnCartConditionWholesale.HeaderText = "Скида от";
            this.ColumnCartConditionWholesale.MinimumWidth = 6;
            this.ColumnCartConditionWholesale.Name = "ColumnCartConditionWholesale";
            this.ColumnCartConditionWholesale.ReadOnly = true;
            // 
            // ColumnCartDiscount
            // 
            this.ColumnCartDiscount.DataPropertyName = "discount";
            this.ColumnCartDiscount.HeaderText = "Скидка";
            this.ColumnCartDiscount.MinimumWidth = 6;
            this.ColumnCartDiscount.Name = "ColumnCartDiscount";
            this.ColumnCartDiscount.ReadOnly = true;
            // 
            // ColumnCartProductInStock
            // 
            this.ColumnCartProductInStock.DataPropertyName = "product_count";
            this.ColumnCartProductInStock.HeaderText = "В наличии";
            this.ColumnCartProductInStock.MinimumWidth = 6;
            this.ColumnCartProductInStock.Name = "ColumnCartProductInStock";
            this.ColumnCartProductInStock.ReadOnly = true;
            // 
            // ColumnCartProductCount
            // 
            this.ColumnCartProductCount.DataPropertyName = "product_count_in_cart";
            this.ColumnCartProductCount.HeaderText = "Количество";
            this.ColumnCartProductCount.MinimumWidth = 6;
            this.ColumnCartProductCount.Name = "ColumnCartProductCount";
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.buttonCancelOrder);
            this.tabPageOrders.Controls.Add(this.dataGridViewOrders);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 25);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Size = new System.Drawing.Size(950, 542);
            this.tabPageOrders.TabIndex = 2;
            this.tabPageOrders.Text = "Заказы";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOrderId,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.ColumnOrderStatus,
            this.ColumnOrderInfo});
            this.dataGridViewOrders.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.RowTemplate.Height = 24;
            this.dataGridViewOrders.Size = new System.Drawing.Size(937, 461);
            this.dataGridViewOrders.TabIndex = 1;
            this.dataGridViewOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellContentClick);
            // 
            // ColumnOrderId
            // 
            this.ColumnOrderId.DataPropertyName = "OrderID";
            this.ColumnOrderId.HeaderText = "ID";
            this.ColumnOrderId.MinimumWidth = 6;
            this.ColumnOrderId.Name = "ColumnOrderId";
            this.ColumnOrderId.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UserLastName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Фамилия заказчика";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "UserFirstName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Имя заказчика";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UserPhone";
            this.dataGridViewTextBoxColumn4.HeaderText = "Телефон заказчика";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "OrderDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "OrderCost";
            this.dataGridViewTextBoxColumn6.HeaderText = "Стоимость";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // ColumnOrderStatus
            // 
            this.ColumnOrderStatus.DataPropertyName = "Status";
            this.ColumnOrderStatus.HeaderText = "Статус";
            this.ColumnOrderStatus.MinimumWidth = 6;
            this.ColumnOrderStatus.Name = "ColumnOrderStatus";
            // 
            // ColumnOrderInfo
            // 
            this.ColumnOrderInfo.HeaderText = "";
            this.ColumnOrderInfo.MinimumWidth = 6;
            this.ColumnOrderInfo.Name = "ColumnOrderInfo";
            this.ColumnOrderInfo.ReadOnly = true;
            this.ColumnOrderInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnOrderInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnOrderInfo.Text = "О заказе";
            this.ColumnOrderInfo.UseColumnTextForButtonValue = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 24);
            this.menuStrip1.TabIndex = 2;
            // 
            // buttonCancelOrder
            // 
            this.buttonCancelOrder.Location = new System.Drawing.Point(357, 494);
            this.buttonCancelOrder.Name = "buttonCancelOrder";
            this.buttonCancelOrder.Size = new System.Drawing.Size(200, 23);
            this.buttonCancelOrder.TabIndex = 2;
            this.buttonCancelOrder.Text = "Отменить заказ";
            this.buttonCancelOrder.UseVisualStyleBackColor = true;
            this.buttonCancelOrder.Click += new System.EventHandler(this.buttonCancelOrder_Click);
            // 
            // FormCustomerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 596);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormCustomerMain";
            this.Text = "FormCustomerMain";
            this.tabControl1.ResumeLayout(false);
            this.tabPageProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.tabPageCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.tabPageOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.TabPage tabPageCart;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConditionWholesale;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitPrice;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSaveInCart;
        private System.Windows.Forms.Button buttonSendOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderStatus;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnOrderInfo;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDeleteProductFromCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCartProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCartProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCartProductCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCartManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCartUnitePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCartConditionWholesale;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCartDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCartProductInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCartProductCount;
        private System.Windows.Forms.Button buttonCancelOrder;
    }
}