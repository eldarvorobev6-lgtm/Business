using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Exam
{
    public partial class GoodsEdit : Form
    {
        private string _currentArticul;
        private string _oldPhotoName;
        private bool _isImageChanged = false;

        public GoodsEdit(string articul = null)
        {
            if (Application.OpenForms.OfType<GoodsEdit>().Count() > 1)
            {
                MessageBox.Show("Окно редактирования уже открыто!\nЗакройте его перед открытием нового.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }

            InitializeComponent();
            _currentArticul = articul;
            this.Text = string.IsNullOrEmpty(_currentArticul) ? "Добавление товара" : "Редактирование товара";
        }

        private void goods_edit_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();

            if (string.IsNullOrEmpty(_currentArticul))
            {
                txtArticul.ReadOnly = false;
                txtArticul.Clear();
                txtArticul.Focus();
                picProduct.Image = Properties.Resources.picture; 
            }
            else
            {

                txtArticul.ReadOnly = true;
                LoadGoodsData();
            }
        }

        private void LoadComboBoxes()
        {
            var catTA = new MainDataSetTableAdapters.categoryTableAdapter();
            cmbCategory.DataSource = catTA.GetData();
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";

            var manTA = new MainDataSetTableAdapters.manufacturerTableAdapter();
            cmbManufacturer.DataSource = manTA.GetData();
            cmbManufacturer.DisplayMember = "name";
            cmbManufacturer.ValueMember = "id";

            var supTA = new MainDataSetTableAdapters.supplierTableAdapter();
            cmbSupplier.DataSource = supTA.GetData();
            cmbSupplier.DisplayMember = "name";
            cmbSupplier.ValueMember = "id";
        }

        private void LoadGoodsData()
        {
            var ta = new MainDataSetTableAdapters.goodsTableAdapter();
            var table = ta.GetData();
            DataRow[] rows = table.Select($"Articul = '{_currentArticul}'");

            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                txtArticul.Text = row["Articul"].ToString();
                txtName.Text = row["Name"].ToString();
                cmbCategory.SelectedValue = row["Category"];
                txtDescription.Text = row["Description"].ToString();
                cmbManufacturer.SelectedValue = row["Manufacturer"];
                cmbSupplier.SelectedValue = row["Supplier"];
                txtPrice.Text = row["Price"].ToString();
                txtMeasurement.Text = row["Measurement"].ToString();
                numCount.Value = Convert.ToDecimal(row["Count"]);
                numDiscount.Value = Convert.ToDecimal(row["Discount"]);
                _oldPhotoName = row["Photo"].ToString();

                string imagePath = Path.Combine(Application.StartupPath, "images", _oldPhotoName);
                if (File.Exists(imagePath))
                {
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        picProduct.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    picProduct.Image = Properties.Resources.picture;
                }
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image originalImage = Image.FromFile(ofd.FileName);
                    picProduct.Image = new Bitmap(originalImage, new Size(300, 200));
                    originalImage.Dispose();
                    _isImageChanged = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArticul.Text))
            {
                MessageBox.Show("Введите артикул товара!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Цена должна быть числом и не может быть отрицательной!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ta = new MainDataSetTableAdapters.goodsTableAdapter();
            var table = ta.GetData();

            string newPhotoName = _oldPhotoName;

            // Обработка изображения
            if (_isImageChanged && picProduct.Image != null)
            {
                 if (!string.IsNullOrEmpty(_oldPhotoName) && _oldPhotoName != "picture.png")
                {
                    string oldPath = Path.Combine(Application.StartupPath, "images", _oldPhotoName);
                    if (File.Exists(oldPath))
                    {
                        try { File.Delete(oldPath); }
                        catch { }
                    }
                }

                newPhotoName = txtArticul.Text + ".png";
                string savePath = Path.Combine(Application.StartupPath, "images", newPhotoName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                // Сохраняем изображение
                try
                {
                    picProduct.Image.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изображения: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (string.IsNullOrEmpty(_oldPhotoName))
            {
                newPhotoName = "picture.png";
                string savePath = Path.Combine(Application.StartupPath, "images", newPhotoName);
                if (!File.Exists(savePath))
                {
                    Properties.Resources.picture.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            // Добавление и редактирование
            if (string.IsNullOrEmpty(_currentArticul))
            {
                if (table.Select($"Articul = '{txtArticul.Text}'").Length > 0)
                {
                    MessageBox.Show("Товар с таким артикулом уже существует!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow newRow = table.NewRow();
                newRow["Articul"] = txtArticul.Text;
                newRow["Name"] = txtName.Text;
                newRow["Category"] = cmbCategory.SelectedValue;
                newRow["Description"] = txtDescription.Text;
                newRow["Manufacturer"] = cmbManufacturer.SelectedValue;
                newRow["Supplier"] = cmbSupplier.SelectedValue;
                newRow["Price"] = price;
                newRow["Measurement"] = txtMeasurement.Text;
                newRow["Count"] = (int)numCount.Value;
                newRow["Discount"] = (int)numDiscount.Value;
                newRow["Photo"] = newPhotoName;
                table.Rows.Add(newRow);
            }
            else
            {
                DataRow row = table.Select($"Articul = '{_currentArticul}'")[0];
                row["Name"] = txtName.Text;
                row["Category"] = cmbCategory.SelectedValue;
                row["Description"] = txtDescription.Text;
                row["Manufacturer"] = cmbManufacturer.SelectedValue;
                row["Supplier"] = cmbSupplier.SelectedValue;
                row["Price"] = price;
                row["Measurement"] = txtMeasurement.Text;
                row["Count"] = (int)numCount.Value;
                row["Discount"] = (int)numDiscount.Value;
                row["Photo"] = newPhotoName;
            }

            ta.Update(table);
            MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
     (sender as TextBox).Text.IndexOf('.') > -1 ||
     (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }
    }
}