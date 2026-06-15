using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Exam
{
    public partial class orders_view : Form
    {
        public orders_view()
        {
            InitializeComponent();
        }


        public void LoadOrders()
        {
            ordersPanel.Controls.Clear();

            var ta = new MainDataSetTableAdapters.ordersTableAdapter();
            var table = ta.GetData();

            foreach (DataRow row in table.Rows)
            {
                order_card card = new order_card(row);
                ordersPanel.Controls.Add(card);
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {

        }

        public void EditOrder(int number)
        {
            if (Application.OpenForms.OfType<orders_edit>().Any())
            {
                MessageBox.Show("Окно редактирования заказа уже открыто!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            orders_edit editForm = new orders_edit(number);
            editForm.ShowDialog();
            LoadOrders();
        }

        public void DeleteOrder(int number)
        {
            var result = MessageBox.Show($"Вы действительно хотите удалить заказ №{number}?\nЭто действие необратимо!",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var ta = new MainDataSetTableAdapters.ordersTableAdapter();
                    ta.DeleteQuery(number);
                    MessageBox.Show("Заказ успешно удалён!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void orders_view_Load_1(object sender, EventArgs e)
        {
            this.Text = "Список заказов";
            lblUserInfo.Text = $"{CurrentUser.FIO}\n({CurrentUser.RoleName})";

            if (CurrentUser.RoleID != 1)
            {
                btnAddOrder.Visible = false;
            }

            LoadOrders();
        }
    }
}