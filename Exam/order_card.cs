using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class order_card : UserControl
    {
        public DataRow OrderData { get; set; }

        public order_card(DataRow DR)
        {
            InitializeComponent();
            OrderData = DR;
        }



        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is orders_view mainForm)
            {
                int number = Convert.ToInt32(OrderData["Number"]);
                mainForm.DeleteOrder(number);
            }
        }

        private void lblArticul_Click(object sender, EventArgs e)
        {
            if (CurrentUser.RoleID == 1 && this.ParentForm is orders_view mainForm)
            {
                int number = Convert.ToInt32(OrderData["Number"]);
                mainForm.EditOrder(number);
            }
        }

        private void order_card_Load(object sender, EventArgs e)
        {
            lblArticul.Text = "Артикул заказа: " + OrderData["Articul"].ToString();
            lblDateOrder.Text = "Дата заказа: " + OrderData["Date_order"].ToString();
            lblDateArrived.Text = "Дата доставки: " + OrderData["Date_arrived"].ToString();

            try
            {
                var statusTA = new MainDataSetTableAdapters.statusTableAdapter();
                var statusTable = statusTA.GetData();
                int statusId = Convert.ToInt32(OrderData["Status"]);
                DataRow[] statusRow = statusTable.Select($"id = {statusId}");
                if (statusRow.Length > 0)
                {
                    lblStatus.Text = "Статус заказа: " + statusRow[0]["name"].ToString();
                }
            }
            catch
            {
                lblStatus.Text = "Статус заказа: ошибка";
            }

            try
            {
                var pvzTA = new MainDataSetTableAdapters.PVZTableAdapter();
                var pvzTable = pvzTA.GetData();
                int pvzId = Convert.ToInt32(OrderData["Address_PVZ"]);
                DataRow[] pvzRow = pvzTable.Select($"id = {pvzId}");
                if (pvzRow.Length > 0)
                {
                    lblPVZ.Text = "Адрес пункта выдачи: " + pvzRow[0]["address"].ToString();
                }
            }
            catch
            {
                lblPVZ.Text = "Адрес пункта выдачи: ошибка";
            }

            if (CurrentUser.RoleID != 1)
            {
                btnDeleteOrder.Visible = false;
            }
        }
    }
}
