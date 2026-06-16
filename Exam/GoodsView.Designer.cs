namespace Exam
{
    partial class GoodsView
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
            this.Main_Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.sortPriceComboBox = new System.Windows.Forms.ComboBox();
            this.sortCountComboBox = new System.Windows.Forms.ComboBox();
            this.lblSortPrice = new System.Windows.Forms.Label();
            this.lblSortCount = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Main_Panel
            // 
            this.Main_Panel.AutoScroll = true;
            this.Main_Panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Main_Panel.Location = new System.Drawing.Point(12, 84);
            this.Main_Panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Main_Panel.Name = "Main_Panel";
            this.Main_Panel.Size = new System.Drawing.Size(1209, 587);
            this.Main_Panel.TabIndex = 0;
            this.Main_Panel.WrapContents = false;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Location = new System.Drawing.Point(1263, 94);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(71, 16);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "lblUserInfo";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(105, 30);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(454, 22);
            this.searchTextBox.TabIndex = 2;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(21, 33);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 16);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = " Поиск";
            // 
            // filterComboBox
            // 
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(1248, 33);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(237, 24);
            this.filterComboBox.TabIndex = 5;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(1275, 161);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(154, 40);
            this.btnOrders.TabIndex = 9;
            this.btnOrders.Text = "Заказы";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1257, 262);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(154, 40);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // sortPriceComboBox
            // 
            this.sortPriceComboBox.FormattingEnabled = true;
            this.sortPriceComboBox.Location = new System.Drawing.Point(635, 33);
            this.sortPriceComboBox.Name = "sortPriceComboBox";
            this.sortPriceComboBox.Size = new System.Drawing.Size(237, 24);
            this.sortPriceComboBox.TabIndex = 12;
            this.sortPriceComboBox.SelectedIndexChanged += new System.EventHandler(this.sortPriceComboBox_SelectedIndexChanged);
            // 
            // sortCountComboBox
            // 
            this.sortCountComboBox.FormattingEnabled = true;
            this.sortCountComboBox.Location = new System.Drawing.Point(925, 33);
            this.sortCountComboBox.Name = "sortCountComboBox";
            this.sortCountComboBox.Size = new System.Drawing.Size(237, 24);
            this.sortCountComboBox.TabIndex = 13;
            this.sortCountComboBox.SelectedIndexChanged += new System.EventHandler(this.sortCountComboBox_SelectedIndexChanged);
            // 
            // lblSortPrice
            // 
            this.lblSortPrice.AutoSize = true;
            this.lblSortPrice.Location = new System.Drawing.Point(632, 9);
            this.lblSortPrice.Name = "lblSortPrice";
            this.lblSortPrice.Size = new System.Drawing.Size(140, 16);
            this.lblSortPrice.TabIndex = 14;
            this.lblSortPrice.Text = "Сортировка по цене";
            // 
            // lblSortCount
            // 
            this.lblSortCount.AutoSize = true;
            this.lblSortCount.Location = new System.Drawing.Point(922, 9);
            this.lblSortCount.Name = "lblSortCount";
            this.lblSortCount.Size = new System.Drawing.Size(185, 16);
            this.lblSortCount.TabIndex = 15;
            this.lblSortCount.Text = "Сортировка по количеству";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(1254, 14);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(196, 16);
            this.lblFilter.TabIndex = 17;
            this.lblFilter.Text = "Фильтрация по поставщикам";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1296, 354);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(154, 40);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // goods_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1859, 682);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblSortCount);
            this.Controls.Add(this.lblSortPrice);
            this.Controls.Add(this.sortCountComboBox);
            this.Controls.Add(this.sortPriceComboBox);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.Main_Panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "goods_view";
            this.Text = "goods_view";
            this.Load += new System.EventHandler(this.goods_view_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MainDataSet mainDataSet;
        private System.Windows.Forms.BindingSource goodsBindingSource;
        private MainDataSetTableAdapters.goodsTableAdapter goodsTableAdapter;
        private System.Windows.Forms.FlowLayoutPanel Main_Panel;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox sortPriceComboBox;
        private System.Windows.Forms.ComboBox sortCountComboBox;
        private System.Windows.Forms.Label lblSortPrice;
        private System.Windows.Forms.Label lblSortCount;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnAdd;
    }
}