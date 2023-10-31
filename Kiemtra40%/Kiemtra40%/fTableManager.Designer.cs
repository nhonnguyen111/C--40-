namespace Kiemtra40_
{
    partial class fTableManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lswBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbtotalPrice = new System.Windows.Forms.TextBox();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.btnTable = new System.Windows.Forms.Button();
            this.mnDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numberFood = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbFoods = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.pnTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnDiscount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberFood)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1064, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiKhoảnCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(182, 29);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // tàiKhoảnCáNhânToolStripMenuItem
            // 
            this.tàiKhoảnCáNhânToolStripMenuItem.Name = "tàiKhoảnCáNhânToolStripMenuItem";
            this.tàiKhoảnCáNhânToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.tàiKhoảnCáNhânToolStripMenuItem.Text = "Tài khoản cá nhân";
            this.tàiKhoảnCáNhânToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmMónToolStripMenuItem,
            this.thanhToánToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(113, 29);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // thêmMónToolStripMenuItem
            // 
            this.thêmMónToolStripMenuItem.Name = "thêmMónToolStripMenuItem";
            this.thêmMónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.thêmMónToolStripMenuItem.Size = new System.Drawing.Size(265, 34);
            this.thêmMónToolStripMenuItem.Text = "Thêm món";
            this.thêmMónToolStripMenuItem.Click += new System.EventHandler(this.thêmMónToolStripMenuItem_Click);
            // 
            // thanhToánToolStripMenuItem
            // 
            this.thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            this.thanhToánToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.thanhToánToolStripMenuItem.Size = new System.Drawing.Size(265, 34);
            this.thanhToánToolStripMenuItem.Text = "Thanh toán";
            this.thanhToánToolStripMenuItem.Click += new System.EventHandler(this.thanhToánToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lswBill);
            this.panel2.Location = new System.Drawing.Point(598, 122);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(452, 330);
            this.panel2.TabIndex = 2;
            // 
            // lswBill
            // 
            this.lswBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lswBill.GridLines = true;
            this.lswBill.HideSelection = false;
            this.lswBill.Location = new System.Drawing.Point(2, 0);
            this.lswBill.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lswBill.Name = "lswBill";
            this.lswBill.Size = new System.Drawing.Size(450, 329);
            this.lswBill.TabIndex = 0;
            this.lswBill.UseCompatibleStateImageBehavior = false;
            this.lswBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 93;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 97;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 94;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 144;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbtotalPrice);
            this.panel3.Controls.Add(this.cbTable);
            this.panel3.Controls.Add(this.btnTable);
            this.panel3.Controls.Add(this.mnDiscount);
            this.panel3.Controls.Add(this.btnDiscount);
            this.panel3.Controls.Add(this.btnCheckout);
            this.panel3.Location = new System.Drawing.Point(598, 460);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(452, 74);
            this.panel3.TabIndex = 3;
            // 
            // txbtotalPrice
            // 
            this.txbtotalPrice.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtotalPrice.ForeColor = System.Drawing.Color.Blue;
            this.txbtotalPrice.Location = new System.Drawing.Point(223, 18);
            this.txbtotalPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbtotalPrice.Name = "txbtotalPrice";
            this.txbtotalPrice.ReadOnly = true;
            this.txbtotalPrice.Size = new System.Drawing.Size(134, 32);
            this.txbtotalPrice.TabIndex = 7;
            this.txbtotalPrice.Text = "0";
            this.txbtotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(3, 40);
            this.cbTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(105, 27);
            this.cbTable.TabIndex = 4;
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(2, 7);
            this.btnTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(106, 31);
            this.btnTable.TabIndex = 6;
            this.btnTable.Text = "Chuyển bàn";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // mnDiscount
            // 
            this.mnDiscount.Location = new System.Drawing.Point(112, 42);
            this.mnDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mnDiscount.Name = "mnDiscount";
            this.mnDiscount.Size = new System.Drawing.Size(102, 27);
            this.mnDiscount.TabIndex = 4;
            this.mnDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(110, 7);
            this.btnDiscount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(106, 31);
            this.btnDiscount.TabIndex = 5;
            this.btnDiscount.Text = "Giảm giá";
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(357, 6);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(92, 64);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "Thanh toán";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numberFood);
            this.panel4.Controls.Add(this.btnAddFood);
            this.panel4.Controls.Add(this.cbFoods);
            this.panel4.Controls.Add(this.cbCategory);
            this.panel4.Location = new System.Drawing.Point(598, 37);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(452, 78);
            this.panel4.TabIndex = 4;
            // 
            // numberFood
            // 
            this.numberFood.Location = new System.Drawing.Point(396, 24);
            this.numberFood.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numberFood.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numberFood.Name = "numberFood";
            this.numberFood.Size = new System.Drawing.Size(48, 27);
            this.numberFood.TabIndex = 3;
            this.numberFood.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(297, 4);
            this.btnAddFood.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(92, 64);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbFoods
            // 
            this.cbFoods.FormattingEnabled = true;
            this.cbFoods.Location = new System.Drawing.Point(3, 39);
            this.cbFoods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFoods.Name = "cbFoods";
            this.cbFoods.Size = new System.Drawing.Size(286, 27);
            this.cbFoods.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(3, 4);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(286, 27);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // pnTable
            // 
            this.pnTable.AutoScroll = true;
            this.pnTable.Location = new System.Drawing.Point(14, 37);
            this.pnTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnTable.Name = "pnTable";
            this.pnTable.Size = new System.Drawing.Size(578, 496);
            this.pnTable.TabIndex = 5;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 547);
            this.Controls.Add(this.pnTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fTableManager";
            this.Text = "Phần mềm quản lý cà phê";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnDiscount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numberFood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lswBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbFoods;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.NumericUpDown numberFood;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.FlowLayoutPanel pnTable;
        private System.Windows.Forms.NumericUpDown mnDiscount;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txbtotalPrice;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmMónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToánToolStripMenuItem;
    }
}