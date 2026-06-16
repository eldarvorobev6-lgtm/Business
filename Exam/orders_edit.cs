using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Exam
{
    public partial class orders_edit : Form
    {
        private int? _currentNumber;

        public orders_edit(int? number = null)
        {
            if (Application.OpenForms.OfType<orders_edit>().Count() > 1)
            {
                MessageBox.Show("Окно редактирования заказа уже открыто!\nЗакройте его перед открытием нового.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }

            InitializeComponent();
            _currentNumber = number;
            this.Text = _currentNumber.HasValue ? "Редактирование заказа" : "Добавление заказа";
        }

        private void orders_edit_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

            if (!_currentNumber.HasValue)
            {
                // РЕЖИМ ДОБАВЛЕНИЯ
                // Скрываем номер заказа и его label
                txtNumber.Visible = false;
                if (lblNumber != null) lblNumber.Visible = false;

                // Сбрасываем ComboBox'ы
                cmbArticul.SelectedIndex = -1;
                cmbStatus.SelectedIndex = -1;
                cmbPVZ.SelectedIndex = -1;
                cmbLogin.SelectedIndex = -1;
                numCount.Value = 1;
                txtCode.Text = "";

                dtpDateOrder.Value = DateTime.Now;
                dtpDateArrived.Value = DateTime.Now.AddDays(30);
            }
            else
            {
                // РЕЖИМ РЕДАКТИРОВАНИЯ
                // Показываем номер заказа, он только для чтения
                txtNumber.Visible = true;
                if (lblNumber != null) lblNumber.Visible = true;
                txtNumber.ReadOnly = true;
                LoadOrderData();
            }
        }

        private void LoadComboBoxes()
        {
            var goodsTA = new MainDataSetTableAdapters.goodsTableAdapter();
            cmbArticul.DataSource = goodsTA.GetData();
            cmbArticul.DisplayMember = "Articul";
            cmbArticul.ValueMember = "Articul";

            var statusTA = new MainDataSetTableAdapters.statusTableAdapter();
            cmbStatus.DataSource = statusTA.GetData();
            cmbStatus.DisplayMember = "name";
            cmbStatus.ValueMember = "id";

            var pvzTA = new MainDataSetTableAdapters.PVZTableAdapter();
            cmbPVZ.DataSource = pvzTA.GetData();
            cmbPVZ.DisplayMember = "address";
            cmbPVZ.ValueMember = "id";

            var usersTA = new MainDataSetTableAdapters.usersTableAdapter();
            cmbLogin.DataSource = usersTA.GetData();
            cmbLogin.DisplayMember = "Login";
            cmbLogin.ValueMember = "Login";
        }

        private void LoadOrderData()
        {
            var ta = new MainDataSetTableAdapters.ordersTableAdapter();
            var table = ta.GetData();
            DataRow[] rows = table.Select($"Number = {_currentNumber}");

            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                txtNumber.Text = row["Number"].ToString();

                cmbArticul.SelectedValue = row["Articul"].ToString();
                numCount.Value = Convert.ToDecimal(row["Count"]);
                cmbStatus.SelectedValue = row["Status"];
                cmbPVZ.SelectedValue = row["Address_PVZ"];
                cmbLogin.SelectedValue = row["Login"].ToString();
                txtCode.Text = row["Code"].ToString();

                string dateOrder = row["Date_order"].ToString();
                string dateArrived = row["Date_arrived"].ToString();

                if (TryParseDate(dateOrder, out DateTime d1))
                    dtpDateOrder.Value = d1;
                else
                    dtpDateOrder.Value = DateTime.Now;

                if (TryParseDate(dateArrived, out DateTime d2))
                    dtpDateArrived.Value = d2;
                else
                    dtpDateArrived.Value = DateTime.Now.AddDays(30);
            }
        }

        private bool TryParseDate(string dateStr, out DateTime result)
        {
            string[] formats = {
                "M/d/yy", "MM/dd/yy", "d/M/yy", "dd/MM/yy",
                "M/d/yyyy", "MM/dd/yyyy", "d/M/yyyy", "dd/MM/yyyy",
                "yyyy-MM-dd", "dd.MM.yyyy", "d.MM.yyyy"
            };

            return DateTime.TryParseExact(dateStr, formats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out result) ||
                DateTime.TryParse(dateStr, out result);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCode.Text, out int code) || code < 0)
            {
                MessageBox.Show("Код получения должен быть положительным числом!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbArticul.SelectedIndex < 0 || cmbStatus.SelectedIndex < 0 ||
                cmbPVZ.SelectedIndex < 0 || cmbLogin.SelectedIndex < 0)
            {
                MessageBox.Show("Заполните все выпадающие списки!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ta = new MainDataSetTableAdapters.ordersTableAdapter();
            var table = ta.GetData();

            string articul = cmbArticul.SelectedValue.ToString();
            int statusId = Convert.ToInt32(cmbStatus.SelectedValue);
            int pvzId = Convert.ToInt32(cmbPVZ.SelectedValue);
            string login = cmbLogin.SelectedValue.ToString();

            if (!_currentNumber.HasValue)
            {
                // При добавлении — номер вычисляется автоматически как max + 1
                int maxNumber = table.Rows.Count > 0
                    ? table.AsEnumerable().Max(r => Convert.ToInt32(r["Number"]))
                    : 0;

                DataRow newRow = table.NewRow();
                newRow["Number"] = maxNumber + 1;
                newRow["Articul"] = articul;
                newRow["Count"] = (int)numCount.Value;
                newRow["Date_order"] = dtpDateOrder.Value.ToString("M/d/yy");
                newRow["Date_arrived"] = dtpDateArrived.Value.ToString("M/d/yy");
                newRow["Address_PVZ"] = pvzId;
                newRow["Login"] = login;
                newRow["Code"] = code;
                newRow["Status"] = statusId;
                table.Rows.Add(newRow);
            }
            else
            {
                DataRow row = table.Select($"Number = {_currentNumber}")[0];
                row["Articul"] = articul;
                row["Count"] = (int)numCount.Value;
                row["Date_order"] = dtpDateOrder.Value.ToString("M/d/yy");
                row["Date_arrived"] = dtpDateArrived.Value.ToString("M/d/yy");
                row["Address_PVZ"] = pvzId;
                row["Login"] = login;
                row["Code"] = code;
                row["Status"] = statusId;
            }

            ta.Update(table);
            MessageBox.Show("Заказ успешно сохранён!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}