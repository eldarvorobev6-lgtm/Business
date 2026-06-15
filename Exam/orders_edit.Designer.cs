namespace Exam
{
    partial class orders_edit
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
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.cmbArticul = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbPVZ = new System.Windows.Forms.ComboBox();
            this.dtpDateOrder = new System.Windows.Forms.DateTimePicker();
            this.dtpDateArrived = new System.Windows.Forms.DateTimePicker();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblArticul = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPVZ = new System.Windows.Forms.Label();
            this.lblDateOrder = new System.Windows.Forms.Label();
            this.lblDateArrived = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmbLogin = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(48, 54);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(103, 16);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Номер заказа:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(169, 48);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(192, 22);
            this.txtNumber.TabIndex = 1;
            // 
            // cmbArticul
            // 
            this.cmbArticul.FormattingEnabled = true;
            this.cmbArticul.Location = new System.Drawing.Point(169, 100);
            this.cmbArticul.Name = "cmbArticul";
            this.cmbArticul.Size = new System.Drawing.Size(192, 24);
            this.cmbArticul.TabIndex = 3;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(169, 155);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(192, 24);
            this.cmbStatus.TabIndex = 4;
            // 
            // cmbPVZ
            // 
            this.cmbPVZ.FormattingEnabled = true;
            this.cmbPVZ.Location = new System.Drawing.Point(169, 200);
            this.cmbPVZ.Name = "cmbPVZ";
            this.cmbPVZ.Size = new System.Drawing.Size(192, 24);
            this.cmbPVZ.TabIndex = 5;
            // 
            // dtpDateOrder
            // 
            this.dtpDateOrder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOrder.Location = new System.Drawing.Point(169, 254);
            this.dtpDateOrder.Name = "dtpDateOrder";
            this.dtpDateOrder.Size = new System.Drawing.Size(200, 22);
            this.dtpDateOrder.TabIndex = 6;
            // 
            // dtpDateArrived
            // 
            this.dtpDateArrived.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateArrived.Location = new System.Drawing.Point(169, 298);
            this.dtpDateArrived.Name = "dtpDateArrived";
            this.dtpDateArrived.Size = new System.Drawing.Size(200, 22);
            this.dtpDateArrived.TabIndex = 7;
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(169, 435);
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(120, 22);
            this.numCount.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(63, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 48);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(226, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 48);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblArticul
            // 
            this.lblArticul.AutoSize = true;
            this.lblArticul.Location = new System.Drawing.Point(86, 108);
            this.lblArticul.Name = "lblArticul";
            this.lblArticul.Size = new System.Drawing.Size(65, 16);
            this.lblArticul.TabIndex = 12;
            this.lblArticul.Text = "Артикул:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(54, 163);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(106, 16);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Статус заказа:";
            // 
            // lblPVZ
            // 
            this.lblPVZ.AutoSize = true;
            this.lblPVZ.Location = new System.Drawing.Point(9, 203);
            this.lblPVZ.Name = "lblPVZ";
            this.lblPVZ.Size = new System.Drawing.Size(151, 16);
            this.lblPVZ.TabIndex = 14;
            this.lblPVZ.Text = "Адрес пункта выдачи:";
            // 
            // lblDateOrder
            // 
            this.lblDateOrder.AutoSize = true;
            this.lblDateOrder.Location = new System.Drawing.Point(68, 254);
            this.lblDateOrder.Name = "lblDateOrder";
            this.lblDateOrder.Size = new System.Drawing.Size(92, 16);
            this.lblDateOrder.TabIndex = 15;
            this.lblDateOrder.Text = "Дата заказа:";
            // 
            // lblDateArrived
            // 
            this.lblDateArrived.AutoSize = true;
            this.lblDateArrived.Location = new System.Drawing.Point(60, 304);
            this.lblDateArrived.Name = "lblDateArrived";
            this.lblDateArrived.Size = new System.Drawing.Size(94, 16);
            this.lblDateArrived.TabIndex = 16;
            this.lblDateArrived.Text = "Дата выдачи:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Логин:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 394);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Код получения:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(63, 435);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(88, 16);
            this.lblCount.TabIndex = 19;
            this.lblCount.Text = "Количество:";
            // 
            // cmbLogin
            // 
            this.cmbLogin.FormattingEnabled = true;
            this.cmbLogin.Location = new System.Drawing.Point(169, 344);
            this.cmbLogin.Name = "cmbLogin";
            this.cmbLogin.Size = new System.Drawing.Size(192, 24);
            this.cmbLogin.TabIndex = 20;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(169, 391);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(192, 22);
            this.txtCode.TabIndex = 21;
            // 
            // orders_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 584);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.cmbLogin);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDateArrived);
            this.Controls.Add(this.lblDateOrder);
            this.Controls.Add(this.lblPVZ);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblArticul);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numCount);
            this.Controls.Add(this.dtpDateArrived);
            this.Controls.Add(this.dtpDateOrder);
            this.Controls.Add(this.cmbPVZ);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbArticul);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblNumber);
            this.Name = "orders_edit";
            this.Text = "orders_edit";
            this.Load += new System.EventHandler(this.orders_edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ComboBox cmbArticul;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbPVZ;
        private System.Windows.Forms.DateTimePicker dtpDateOrder;
        private System.Windows.Forms.DateTimePicker dtpDateArrived;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblArticul;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPVZ;
        private System.Windows.Forms.Label lblDateOrder;
        private System.Windows.Forms.Label lblDateArrived;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox cmbLogin;
        private System.Windows.Forms.TextBox txtCode;
    }
}