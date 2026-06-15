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
    public partial class card : UserControl
    {
        public DataRow CardDDD { get; set; }
        public card(DataRow DR)
        {
            InitializeComponent(); 
            CardDDD = DR;
        }

        private void card_Load(object sender, EventArgs e)
        {
            name_label.Text = "Наименование:" + CardDDD["Name"].ToString();
            measure_label.Text = "Единица измерения:" + CardDDD["Measurement"].ToString();
            describe_label.Text = "Описание:" + CardDDD["Description"].ToString();
            count_label.Text = "Количество:" + CardDDD["Count"].ToString();
            price_label.Text = "Цена:" + CardDDD["Price"].ToString();
            sale_label.Text = "Скидка:" + CardDDD["Discount"].ToString();

            MainDataSetTableAdapters.categoryTableAdapter category_dr = new MainDataSetTableAdapters.categoryTableAdapter();
            var category_table = category_dr.GetData();
            foreach (DataRow row in category_table)
            {
                if (row[0].ToString() == CardDDD["Category"].ToString())
                {
                    category_label.Text = "Категория:" + row[1].ToString();
                }
            }

            MainDataSetTableAdapters.manufacturerTableAdapter manufact_dr = new MainDataSetTableAdapters.manufacturerTableAdapter();
            var manufacturer_table = manufact_dr.GetData();
            foreach (DataRow row in manufacturer_table)
            {
                if (row[0].ToString() == CardDDD["Manufacturer"].ToString())
                {
                    manuf_label.Text = "Производитель:" + row[1].ToString();
                }
            }

            MainDataSetTableAdapters.supplierTableAdapter supplier_dr = new MainDataSetTableAdapters.supplierTableAdapter();
            var supplier_table = supplier_dr.GetData();
            foreach (DataRow row in supplier_table)
            {
                if (row[0].ToString() == CardDDD["Supplier"].ToString())
                {
                    supplier_label.Text = "Поставщик:" + row[1].ToString();
                }
            }

            try
            {
                string imagePath = System.IO.Path.Combine(Application.StartupPath, "images", CardDDD["Photo"].ToString());
                if (System.IO.File.Exists(imagePath))
                {
                    using (System.IO.FileStream st = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        Main_Picture.Image = Image.FromStream(st);
                    }
                }
                else
                {
                    Main_Picture.Image = Properties.Resources.picture;
                }
            }
            catch
            {
                Main_Picture.Image = Properties.Resources.picture;
            }

            if (int.Parse(CardDDD["Discount"].ToString()) >= 17)
            {
                this.BackColor = ColorTranslator.FromHtml("#FFDEAD");
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is goods_view mainForm)
            {
                mainForm.DeleteGoods(CardDDD["Articul"].ToString());
            }
        }

        // DELETE FROM orders WHERE Number = @Number Клик по самой карточке открывает редактирование (только для Админа, RoleID = 1)
        private void card_Click(object sender, EventArgs e)
        {
            if (CurrentUser.RoleID == 1 && this.ParentForm is goods_view mainForm)
            {
                goods_edit editForm = new goods_edit(CardDDD["Articul"].ToString());
                editForm.ShowDialog();
                mainForm.LoadGoods(); // Обновляем список после редактирования
            }
        }

        private void Main_Picture_Click(object sender, EventArgs e)
        {
            card_Click(sender, e);
        }
    }
}
