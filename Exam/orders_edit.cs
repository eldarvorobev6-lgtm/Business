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
                txtNumber.ReadOnly = true;
                var ta = new MainDataSetTableAdapters.ordersTableAdapter();
                var table = ta.GetData();
                int maxNumber = table.Rows.Count > 0
                    ? table.AsEnumerable().Max(r => Convert.ToInt32(r["Number"]))
                    : 0;
                txtNumber.Text = (maxNumber + 1).ToString();

                dtpDateOrder.Value = DateTime.Now;
                dtpDateArrived.Value = DateTime.Now.AddDays(30);
            }
            else
            {
                txtNumber.ReadOnly = true;
                LoadOrderData();
            }
        }

        private void LoadComboBoxes()
        {
            // Артикул товара
            var goodsTA = new MainDataSetTableAdapters.goodsTableAdapter();
            cmbArticul.DataSource = goodsTA.GetData();
            cmbArticul.DisplayMember = "Articul";
            cmbArticul.ValueMember = "Articul";

            // Статус заказа
            var statusTA = new MainDataSetTableAdapters.statusTableAdapter();
            cmbStatus.DataSource = statusTA.GetData();
            cmbStatus.DisplayMember = "name";
            cmbStatus.ValueMember = "id";

            // Адрес ПВЗ
            var pvzTA = new MainDataSetTableAdapters.PVZTableAdapter();
            cmbPVZ.DataSource = pvzTA.GetData();
            cmbPVZ.DisplayMember = "address";
            cmbPVZ.ValueMember = "id";

            // Логин пользователя (из таблицы users)
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
                cmbArticul.SelectedValue = row["Articul"];
                numCount.Value = Convert.ToDecimal(row["Count"]);
                cmbStatus.SelectedValue = row["Status"];
                cmbPVZ.SelectedValue = row["Address_PVZ"];
                cmbLogin.SelectedValue = row["Login"];
                txtCode.Text = row["Code"].ToString();

                if (DateTime.TryParse(row["Date_order"].ToString(), out DateTime d1))
                    dtpDateOrder.Value = d1;
                if (DateTime.TryParse(row["Date_arrived"].ToString(), out DateTime d2))
                    dtpDateArrived.Value = d2;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация кода (должен быть числом)
            if (!int.TryParse(txtCode.Text, out int code) || code < 0)
            {
                MessageBox.Show("Код получения должен быть положительным числом!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbArticul.SelectedValue == null || cmbStatus.SelectedValue == null ||
                cmbPVZ.SelectedValue == null || cmbLogin.SelectedValue == null)
            {
                MessageBox.Show("Заполните все выпадающие списки!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ta = new MainDataSetTableAdapters.ordersTableAdapter();
            var table = ta.GetData();

            if (!_currentNumber.HasValue)
            {
                DataRow newRow = table.NewRow();
                newRow["Number"] = Convert.ToInt32(txtNumber.Text);
                newRow["Articul"] = cmbArticul.SelectedValue;
                newRow["Count"] = (int)numCount.Value;
                newRow["Date_order"] = dtpDateOrder.Value.ToString("M/d/yy");
                newRow["Date_arrived"] = dtpDateArrived.Value.ToString("M/d/yy");
                newRow["Address_PVZ"] = cmbPVZ.SelectedValue;
                newRow["Login"] = cmbLogin.SelectedValue;
                newRow["Code"] = code;
                newRow["Status"] = cmbStatus.SelectedValue;
                table.Rows.Add(newRow);
            }
            else
            {
                DataRow row = table.Select($"Number = {_currentNumber}")[0];
                row["Articul"] = cmbArticul.SelectedValue;
                row["Count"] = (int)numCount.Value;
                row["Date_order"] = dtpDateOrder.Value.ToString("M/d/yy");
                row["Date_arrived"] = dtpDateArrived.Value.ToString("M/d/yy");
                row["Address_PVZ"] = cmbPVZ.SelectedValue;
                row["Login"] = cmbLogin.SelectedValue;
                row["Code"] = code;
                row["Status"] = cmbStatus.SelectedValue;
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