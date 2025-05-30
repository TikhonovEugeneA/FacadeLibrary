namespace ViewWindowsForms
{
    partial class FormSellerOrders
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
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.buttonTransfered = new System.Windows.Forms.Button();
            this.buttonReturnOrder = new System.Windows.Forms.Button();
            this.buttonRequestOrder = new System.Windows.Forms.Button();
            this.buttonGiveOut = new System.Windows.Forms.Button();
            this.dataGridViewOrderListForEmployes = new System.Windows.Forms.DataGridView();
            this.ColumnGetOrderInfoForSeller = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnOrderIdForSeller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserLastNameInOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserFirstNameInOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPhoneUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderListForEmployes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOrders);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(958, 571);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.buttonTransfered);
            this.tabPageOrders.Controls.Add(this.buttonReturnOrder);
            this.tabPageOrders.Controls.Add(this.buttonRequestOrder);
            this.tabPageOrders.Controls.Add(this.buttonGiveOut);
            this.tabPageOrders.Controls.Add(this.dataGridViewOrderListForEmployes);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 25);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(950, 542);
            this.tabPageOrders.TabIndex = 0;
            this.tabPageOrders.Text = "Заказы";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // buttonTransfered
            // 
            this.buttonTransfered.Location = new System.Drawing.Point(521, 496);
            this.buttonTransfered.Name = "buttonTransfered";
            this.buttonTransfered.Size = new System.Drawing.Size(200, 23);
            this.buttonTransfered.TabIndex = 4;
            this.buttonTransfered.Text = "Передан";
            this.buttonTransfered.UseVisualStyleBackColor = true;
            this.buttonTransfered.Click += new System.EventHandler(this.buttonTransfered_Click);
            // 
            // buttonReturnOrder
            // 
            this.buttonReturnOrder.Location = new System.Drawing.Point(727, 496);
            this.buttonReturnOrder.Name = "buttonReturnOrder";
            this.buttonReturnOrder.Size = new System.Drawing.Size(200, 23);
            this.buttonReturnOrder.TabIndex = 3;
            this.buttonReturnOrder.Text = "Вернуть";
            this.buttonReturnOrder.UseVisualStyleBackColor = true;
            this.buttonReturnOrder.Click += new System.EventHandler(this.buttonReturnOrder_Click);
            // 
            // buttonRequestOrder
            // 
            this.buttonRequestOrder.Location = new System.Drawing.Point(315, 496);
            this.buttonRequestOrder.Name = "buttonRequestOrder";
            this.buttonRequestOrder.Size = new System.Drawing.Size(200, 23);
            this.buttonRequestOrder.TabIndex = 2;
            this.buttonRequestOrder.Text = "Запросить";
            this.buttonRequestOrder.UseVisualStyleBackColor = true;
            this.buttonRequestOrder.Click += new System.EventHandler(this.buttonRequestOrder_Click);
            // 
            // buttonGiveOut
            // 
            this.buttonGiveOut.Location = new System.Drawing.Point(109, 496);
            this.buttonGiveOut.Name = "buttonGiveOut";
            this.buttonGiveOut.Size = new System.Drawing.Size(200, 23);
            this.buttonGiveOut.TabIndex = 1;
            this.buttonGiveOut.Text = "Выдать";
            this.buttonGiveOut.UseVisualStyleBackColor = true;
            this.buttonGiveOut.Click += new System.EventHandler(this.buttonGiveOut_Click);
            // 
            // dataGridViewOrderListForEmployes
            // 
            this.dataGridViewOrderListForEmployes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrderListForEmployes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderListForEmployes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnGetOrderInfoForSeller,
            this.ColumnOrderIdForSeller,
            this.ColumnUserLastNameInOrder,
            this.ColumnUserFirstNameInOrder,
            this.ColumnPhoneUser,
            this.ColumnOrderDate,
            this.ColumnOrderCost,
            this.ColumnOrderStatus});
            this.dataGridViewOrderListForEmployes.Location = new System.Drawing.Point(7, 4);
            this.dataGridViewOrderListForEmployes.Name = "dataGridViewOrderListForEmployes";
            this.dataGridViewOrderListForEmployes.ReadOnly = true;
            this.dataGridViewOrderListForEmployes.RowHeadersWidth = 51;
            this.dataGridViewOrderListForEmployes.RowTemplate.Height = 24;
            this.dataGridViewOrderListForEmployes.Size = new System.Drawing.Size(937, 458);
            this.dataGridViewOrderListForEmployes.TabIndex = 0;
            this.dataGridViewOrderListForEmployes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderListForEmployes_CellContentClick);
            // 
            // ColumnGetOrderInfoForSeller
            // 
            this.ColumnGetOrderInfoForSeller.HeaderText = "";
            this.ColumnGetOrderInfoForSeller.MinimumWidth = 6;
            this.ColumnGetOrderInfoForSeller.Name = "ColumnGetOrderInfoForSeller";
            this.ColumnGetOrderInfoForSeller.ReadOnly = true;
            this.ColumnGetOrderInfoForSeller.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnGetOrderInfoForSeller.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnGetOrderInfoForSeller.Text = "О заказе";
            this.ColumnGetOrderInfoForSeller.UseColumnTextForButtonValue = true;
            // 
            // ColumnOrderIdForSeller
            // 
            this.ColumnOrderIdForSeller.DataPropertyName = "OrderId";
            this.ColumnOrderIdForSeller.HeaderText = "ID";
            this.ColumnOrderIdForSeller.MinimumWidth = 6;
            this.ColumnOrderIdForSeller.Name = "ColumnOrderIdForSeller";
            this.ColumnOrderIdForSeller.ReadOnly = true;
            // 
            // ColumnUserLastNameInOrder
            // 
            this.ColumnUserLastNameInOrder.DataPropertyName = "UserLastName";
            this.ColumnUserLastNameInOrder.HeaderText = "Фамилия заказчика";
            this.ColumnUserLastNameInOrder.MinimumWidth = 6;
            this.ColumnUserLastNameInOrder.Name = "ColumnUserLastNameInOrder";
            this.ColumnUserLastNameInOrder.ReadOnly = true;
            // 
            // ColumnUserFirstNameInOrder
            // 
            this.ColumnUserFirstNameInOrder.DataPropertyName = "UserFirstName";
            this.ColumnUserFirstNameInOrder.HeaderText = "Имя заказчика";
            this.ColumnUserFirstNameInOrder.MinimumWidth = 6;
            this.ColumnUserFirstNameInOrder.Name = "ColumnUserFirstNameInOrder";
            this.ColumnUserFirstNameInOrder.ReadOnly = true;
            // 
            // ColumnPhoneUser
            // 
            this.ColumnPhoneUser.DataPropertyName = "UserPhone";
            this.ColumnPhoneUser.HeaderText = "Телефон";
            this.ColumnPhoneUser.MinimumWidth = 6;
            this.ColumnPhoneUser.Name = "ColumnPhoneUser";
            this.ColumnPhoneUser.ReadOnly = true;
            // 
            // ColumnOrderDate
            // 
            this.ColumnOrderDate.DataPropertyName = "OrderDate";
            this.ColumnOrderDate.HeaderText = "Дата";
            this.ColumnOrderDate.MinimumWidth = 6;
            this.ColumnOrderDate.Name = "ColumnOrderDate";
            this.ColumnOrderDate.ReadOnly = true;
            // 
            // ColumnOrderCost
            // 
            this.ColumnOrderCost.DataPropertyName = "OrderCost";
            this.ColumnOrderCost.HeaderText = "Стоимость";
            this.ColumnOrderCost.MinimumWidth = 6;
            this.ColumnOrderCost.Name = "ColumnOrderCost";
            this.ColumnOrderCost.ReadOnly = true;
            // 
            // ColumnOrderStatus
            // 
            this.ColumnOrderStatus.DataPropertyName = "Status";
            this.ColumnOrderStatus.HeaderText = "Статус";
            this.ColumnOrderStatus.MinimumWidth = 6;
            this.ColumnOrderStatus.Name = "ColumnOrderStatus";
            this.ColumnOrderStatus.ReadOnly = true;
            // 
            // FormSellerOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 596);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormSellerOrders";
            this.Text = "FormSellerOrders";
            this.tabControl1.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderListForEmployes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrderListForEmployes;
        private System.Windows.Forms.Button buttonReturnOrder;
        private System.Windows.Forms.Button buttonRequestOrder;
        private System.Windows.Forms.Button buttonGiveOut;
        private System.Windows.Forms.Button buttonTransfered;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnGetOrderInfoForSeller;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderIdForSeller;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserLastNameInOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserFirstNameInOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPhoneUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderStatus;
    }
}