using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            // Заполняем основные данные товара
            name_label.Text = "Наименование: " + CardDDD["Name"].ToString();
            measure_label.Text = "Единица измерения: " + CardDDD["Measurement"].ToString();
            describe_label.Text = "Описание: " + CardDDD["Description"].ToString();

            int count = Convert.ToInt32(CardDDD["Count"]);
            count_label.Text = "Количество: " + count.ToString();

            decimal price = Convert.ToDecimal(CardDDD["Price"]);
            int discount = Convert.ToInt32(CardDDD["Discount"]);
            sale_label.Text = "Скидка: " + discount + "%";

            // Сбрасываем стили перед применением логики цен
            this.BackColor = Color.White;
            price_label.ForeColor = Color.Black;
            price_label.Font = new Font(price_label.Font, price_label.Font.Style & ~FontStyle.Strikeout);
            if (final_price_label != null) final_price_label.Text = "";

            // Если есть скидка 
            if (discount > 0)
            {
                price_label.Text = "Цена: " + price.ToString("F2") + " руб.";
                price_label.ForeColor = Color.Red;
                price_label.Font = new Font(price_label.Font, FontStyle.Strikeout);

                decimal finalPrice = price * (100 - discount) / 100;
                if (final_price_label != null)
                {
                    final_price_label.Text = "Итого: " + finalPrice.ToString("F2") + " руб.";
                    final_price_label.ForeColor = Color.Black;
                    final_price_label.Font = new Font(final_price_label.Font, FontStyle.Bold);
                }
            }
            else
            {
                // Без скидки - обычная цена
                price_label.Text = "Цена: " + price.ToString("F2") + " руб.";
            }

            try
            {
                MainDataSetTableAdapters.categoryTableAdapter category_dr =
                    new MainDataSetTableAdapters.categoryTableAdapter();
                var category_table = category_dr.GetData();
                foreach (DataRow row in category_table)
                {
                    if (row[0].ToString() == CardDDD["Category"].ToString())
                    {
                        category_label.Text = "Категория: " + row[1].ToString();
                        break;
                    }
                }
            }
            catch { category_label.Text = "Категория: ошибка загрузки"; }

             try
            {
                MainDataSetTableAdapters.manufacturerTableAdapter manufact_dr =
                    new MainDataSetTableAdapters.manufacturerTableAdapter();
                var manufacturer_table = manufact_dr.GetData();
                foreach (DataRow row in manufacturer_table)
                {
                    if (row[0].ToString() == CardDDD["Manufacturer"].ToString())
                    {
                        manuf_label.Text = "Производитель: " + row[1].ToString();
                        break;
                    }
                }
            }
            catch { manuf_label.Text = "Производитель: ошибка загрузки"; }

            try
            {
                MainDataSetTableAdapters.supplierTableAdapter supplier_dr =
                    new MainDataSetTableAdapters.supplierTableAdapter();
                var supplier_table = supplier_dr.GetData();
                foreach (DataRow row in supplier_table)
                {
                    if (row[0].ToString() == CardDDD["Supplier"].ToString())
                    {
                        supplier_label.Text = "Поставщик: " + row[1].ToString();
                        break;
                    }
                }
            }
            catch { supplier_label.Text = "Поставщик: ошибка загрузки"; }

            try
            {
                string imagePath = Path.Combine(Application.StartupPath, "images", CardDDD["Photo"].ToString());
                if (File.Exists(imagePath))
                {
                    using (FileStream st = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
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

            if (count == 0)
            {
                this.BackColor = Color.LightBlue;
            }
            else if (discount >= 17)
            {
                this.BackColor = ColorTranslator.FromHtml("#FFDEAD");
            }

            if (CurrentUser.RoleID >= 3)
            {
                if (btnDeleteCard != null) btnDeleteCard.Visible = false;
            }
        }

        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is goods_view mainForm)
            {
                mainForm.DeleteGoods(CardDDD["Articul"].ToString());
            }
        }

        private void card_Click(object sender, EventArgs e)
        {
            if (CurrentUser.RoleID == 1 && this.ParentForm is goods_view mainForm)
            {
                goods_edit editForm = new goods_edit(CardDDD["Articul"].ToString());
                editForm.ShowDialog();
                mainForm.LoadGoods();
            }
        }

        private void Main_Picture_Click(object sender, EventArgs e)
        {
            card_Click(sender, e);
        }
    }
}