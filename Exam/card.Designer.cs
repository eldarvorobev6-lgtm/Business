namespace Exam
{
    partial class card
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(card));
            this.Main_Picture = new System.Windows.Forms.PictureBox();
            this.category_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.describe_label = new System.Windows.Forms.Label();
            this.manuf_label = new System.Windows.Forms.Label();
            this.supplier_label = new System.Windows.Forms.Label();
            this.price_label = new System.Windows.Forms.Label();
            this.measure_label = new System.Windows.Forms.Label();
            this.count_label = new System.Windows.Forms.Label();
            this.sale_label = new System.Windows.Forms.Label();
            this.btnDeleteCard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_Picture
            // 
            this.Main_Picture.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Main_Picture.ErrorImage")));
            this.Main_Picture.Location = new System.Drawing.Point(16, 43);
            this.Main_Picture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Main_Picture.Name = "Main_Picture";
            this.Main_Picture.Size = new System.Drawing.Size(271, 243);
            this.Main_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Main_Picture.TabIndex = 0;
            this.Main_Picture.TabStop = false;
            this.Main_Picture.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // category_label
            // 
            this.category_label.AutoSize = true;
            this.category_label.Location = new System.Drawing.Point(304, 17);
            this.category_label.Name = "category_label";
            this.category_label.Size = new System.Drawing.Size(75, 16);
            this.category_label.TabIndex = 1;
            this.category_label.Text = "Категория";
            this.category_label.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // name_label
            // 
            this.name_label.Location = new System.Drawing.Point(555, 17);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(270, 58);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "Название";
            this.name_label.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // describe_label
            // 
            this.describe_label.Location = new System.Drawing.Point(304, 86);
            this.describe_label.Name = "describe_label";
            this.describe_label.Size = new System.Drawing.Size(459, 109);
            this.describe_label.TabIndex = 3;
            this.describe_label.Text = "Описание";
            this.describe_label.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // manuf_label
            // 
            this.manuf_label.AutoSize = true;
            this.manuf_label.Location = new System.Drawing.Point(304, 205);
            this.manuf_label.Name = "manuf_label";
            this.manuf_label.Size = new System.Drawing.Size(111, 16);
            this.manuf_label.TabIndex = 4;
            this.manuf_label.Text = "Производитель";
            this.manuf_label.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // supplier_label
            // 
            this.supplier_label.AutoSize = true;
            this.supplier_label.Location = new System.Drawing.Point(304, 230);
            this.supplier_label.Name = "supplier_label";
            this.supplier_label.Size = new System.Drawing.Size(79, 16);
            this.supplier_label.TabIndex = 5;
            this.supplier_label.Text = "Поставщик";
            this.supplier_label.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // price_label
            // 
            this.price_label.AutoSize = true;
            this.price_label.Location = new System.Drawing.Point(304, 254);
            this.price_label.Name = "price_label";
            this.price_label.Size = new System.Drawing.Size(40, 16);
            this.price_label.TabIndex = 6;
            this.price_label.Text = "Цена";
            this.price_label.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // measure_label
            // 
            this.measure_label.AutoSize = true;
            this.measure_label.Location = new System.Drawing.Point(304, 278);
            this.measure_label.Name = "measure_label";
            this.measure_label.Size = new System.Drawing.Size(62, 16);
            this.measure_label.TabIndex = 7;
            this.measure_label.Text = "Ед. Изм.";
            this.measure_label.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // count_label
            // 
            this.count_label.AutoSize = true;
            this.count_label.Location = new System.Drawing.Point(304, 304);
            this.count_label.Name = "count_label";
            this.count_label.Size = new System.Drawing.Size(61, 16);
            this.count_label.TabIndex = 8;
            this.count_label.Text = "Остаток";
            this.count_label.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // sale_label
            // 
            this.sale_label.AutoSize = true;
            this.sale_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sale_label.Location = new System.Drawing.Point(866, 125);
            this.sale_label.Name = "sale_label";
            this.sale_label.Size = new System.Drawing.Size(173, 52);
            this.sale_label.TabIndex = 9;
            this.sale_label.Text = "Скидка";
            this.sale_label.Click += new System.EventHandler(this.Main_Picture_Click);
            // 
            // btnDeleteCard
            // 
            this.btnDeleteCard.Location = new System.Drawing.Point(620, 246);
            this.btnDeleteCard.Name = "btnDeleteCard";
            this.btnDeleteCard.Size = new System.Drawing.Size(117, 40);
            this.btnDeleteCard.TabIndex = 10;
            this.btnDeleteCard.Text = "Удалить";
            this.btnDeleteCard.UseVisualStyleBackColor = true;
            this.btnDeleteCard.Click += new System.EventHandler(this.btnDeleteCard_Click);
            // 
            // card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnDeleteCard);
            this.Controls.Add(this.sale_label);
            this.Controls.Add(this.count_label);
            this.Controls.Add(this.measure_label);
            this.Controls.Add(this.price_label);
            this.Controls.Add(this.supplier_label);
            this.Controls.Add(this.manuf_label);
            this.Controls.Add(this.describe_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.category_label);
            this.Controls.Add(this.Main_Picture);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "card";
            this.Size = new System.Drawing.Size(1107, 335);
            this.Load += new System.EventHandler(this.card_Load);
            this.Click += new System.EventHandler(this.Main_Picture_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Main_Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Main_Picture;
        private System.Windows.Forms.Label category_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label describe_label;
        private System.Windows.Forms.Label manuf_label;
        private System.Windows.Forms.Label supplier_label;
        private System.Windows.Forms.Label price_label;
        private System.Windows.Forms.Label measure_label;
        private System.Windows.Forms.Label count_label;
        private System.Windows.Forms.Label sale_label;
        private System.Windows.Forms.Button btnDeleteCard;
    }
}
