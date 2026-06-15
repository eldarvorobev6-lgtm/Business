namespace Exam
{
    partial class order_card
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
            this.lblArticul = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPVZ = new System.Windows.Forms.Label();
            this.lblDateOrder = new System.Windows.Forms.Label();
            this.lblDateArrived = new System.Windows.Forms.Label();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblArticul
            // 
            this.lblArticul.AutoSize = true;
            this.lblArticul.Location = new System.Drawing.Point(55, 25);
            this.lblArticul.Name = "lblArticul";
            this.lblArticul.Size = new System.Drawing.Size(44, 16);
            this.lblArticul.TabIndex = 0;
            this.lblArticul.Text = "label1";
            this.lblArticul.Click += new System.EventHandler(this.lblArticul_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(55, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "label2";
            this.lblStatus.Click += new System.EventHandler(this.lblArticul_Click);
            // 
            // lblPVZ
            // 
            this.lblPVZ.AutoSize = true;
            this.lblPVZ.Location = new System.Drawing.Point(55, 87);
            this.lblPVZ.Name = "lblPVZ";
            this.lblPVZ.Size = new System.Drawing.Size(44, 16);
            this.lblPVZ.TabIndex = 2;
            this.lblPVZ.Text = "label3";
            this.lblPVZ.Click += new System.EventHandler(this.lblArticul_Click);
            // 
            // lblDateOrder
            // 
            this.lblDateOrder.AutoSize = true;
            this.lblDateOrder.Location = new System.Drawing.Point(55, 120);
            this.lblDateOrder.Name = "lblDateOrder";
            this.lblDateOrder.Size = new System.Drawing.Size(44, 16);
            this.lblDateOrder.TabIndex = 3;
            this.lblDateOrder.Text = "label4";
            this.lblDateOrder.Click += new System.EventHandler(this.lblArticul_Click);
            // 
            // lblDateArrived
            // 
            this.lblDateArrived.AutoSize = true;
            this.lblDateArrived.Location = new System.Drawing.Point(591, 68);
            this.lblDateArrived.Name = "lblDateArrived";
            this.lblDateArrived.Size = new System.Drawing.Size(44, 16);
            this.lblDateArrived.TabIndex = 4;
            this.lblDateArrived.Text = "label5";
            this.lblDateArrived.Click += new System.EventHandler(this.lblArticul_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(313, 109);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(95, 27);
            this.btnDeleteOrder.TabIndex = 5;
            this.btnDeleteOrder.Text = "Удалить";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // order_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.lblDateArrived);
            this.Controls.Add(this.lblDateOrder);
            this.Controls.Add(this.lblPVZ);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblArticul);
            this.Name = "order_card";
            this.Size = new System.Drawing.Size(712, 147);
            this.Load += new System.EventHandler(this.order_card_Load);
            this.Click += new System.EventHandler(this.lblArticul_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArticul;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPVZ;
        private System.Windows.Forms.Label lblDateOrder;
        private System.Windows.Forms.Label lblDateArrived;
        private System.Windows.Forms.Button btnDeleteOrder;
    }
}
