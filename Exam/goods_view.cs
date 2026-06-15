using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Exam
{
    public partial class goods_view : Form
    {
        public goods_view()
        {
            InitializeComponent();
        }

        private void goods_view_Load(object sender, EventArgs e)
        {
            this.Text = "Список товаров";
            lblUserInfo.Text = $"{CurrentUser.FIO}\n({CurrentUser.RoleName})";

            SetupInterfaceByRole();
            LoadSuppliersFilter();
            LoadSortOptions();
            LoadGoods();
        }

        private void SetupInterfaceByRole()
        {
            if (CurrentUser.RoleID >= 3)
            {
                searchTextBox.Visible = false;
                lblSearch.Visible = false;
                filterComboBox.Visible = false;
                lblFilter.Visible = false;
                sortPriceComboBox.Visible = false;
                lblSortPrice.Visible = false;
                sortCountComboBox.Visible = false;
                lblSortCount.Visible = false;
                btnAdd.Visible = false;
                btnOrders.Visible = false;
            }
            else if (CurrentUser.RoleID == 2)
            {
                btnAdd.Visible = false;
            }
        }

        private void LoadSuppliersFilter()
        {
            MainDataSetTableAdapters.supplierTableAdapter supTA = new MainDataSetTableAdapters.supplierTableAdapter();
            var supTable = supTA.GetData();

            DataTable filterTable = new DataTable();
            filterTable.Columns.Add("id", typeof(int));
            filterTable.Columns.Add("name", typeof(string));

            filterTable.Rows.Add(0, "Все поставщики");

            foreach (DataRow row in supTable.Rows)
            {
                filterTable.Rows.Add(row["id"], row["name"]);
            }

            filterComboBox.DataSource = filterTable;
            filterComboBox.DisplayMember = "name";
            filterComboBox.ValueMember = "id";
            filterComboBox.SelectedIndex = 0;
        }

        private void LoadSortOptions()
        {
            string[] sortOptions = { "Не сортировать", "По возрастанию", "По убыванию" };

            sortPriceComboBox.Items.AddRange(sortOptions);
            sortPriceComboBox.SelectedIndex = 0;

            sortCountComboBox.Items.AddRange(sortOptions);
            sortCountComboBox.SelectedIndex = 0;
        }

        public void LoadGoods()
        {
            Main_Panel.Controls.Clear();

            MainDataSetTableAdapters.goodsTableAdapter ta = new MainDataSetTableAdapters.goodsTableAdapter();
            var table = ta.GetData();
            DataView dv = table.DefaultView;

            string filter = "";

            if (!string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                string search = searchTextBox.Text.Replace("'", "''");
                filter = $"(Name LIKE '%{search}%') OR " +
                         $"(Description LIKE '%{search}%') OR " +
                         $"(Measurement LIKE '%{search}%') OR " +
                         $"(Articul LIKE '%{search}%')";
            }

            if (filterComboBox.SelectedIndex > 0)
            {
                DataRowView selectedRow = (DataRowView)filterComboBox.SelectedItem;
                int supplierId = Convert.ToInt32(selectedRow["id"]);

                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"Supplier = {supplierId}";
            }

            dv.RowFilter = filter;

            List<string> sortParts = new List<string>();

            if (sortPriceComboBox.SelectedIndex == 1)
                sortParts.Add("Price ASC");
            else if (sortPriceComboBox.SelectedIndex == 2)
                sortParts.Add("Price DESC");

            if (sortCountComboBox.SelectedIndex == 1)
                sortParts.Add("Count ASC");
            else if (sortCountComboBox.SelectedIndex == 2)
                sortParts.Add("Count DESC");

            dv.Sort = string.Join(", ", sortParts);

            foreach (DataRowView item in dv)
            {
                Main_Panel.Controls.Add(new card(item.Row));
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e) => LoadGoods();
        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e) => LoadGoods();
        private void sortPriceComboBox_SelectedIndexChanged(object sender, EventArgs e) => LoadGoods();
        private void sortCountComboBox_SelectedIndexChanged(object sender, EventArgs e) => LoadGoods();

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CurrentUser.Logout();
                this.Close();
            }
        }



        private void goods_view_FormClosing(object sender, FormClosingEventArgs e)
        {
            CurrentUser.Logout();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CurrentUser.Logout();
                this.Close();
            }
        }


        // Метод удаления товара (вызывается из карточки)
        public void DeleteGoods(string articul)
        {
            var result = MessageBox.Show($"Вы действительно хотите удалить товар с артикулом {articul}?\nЭто действие необратимо!",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 1. Проверяем, есть ли товар в заказах
                    var ordTA = new MainDataSetTableAdapters.ordersTableAdapter();
                    var ordersTable = ordTA.GetData();
                    DataRow[] foundInOrders = ordersTable.Select($"Articul = '{articul}'");

                    if (foundInOrders.Length > 0)
                    {
                        MessageBox.Show("Нельзя удалить товар, который присутствует в заказе!\nСначала удалите или измените соответствующие заказы.",
                            "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Получаем имя файла фото, чтобы удалить его с диска
                    var goodsTA = new MainDataSetTableAdapters.goodsTableAdapter();
                    var goodsTable = goodsTA.GetData();
                    DataRow[] goodsRow = goodsTable.Select($"Articul = '{articul}'");

                    if (goodsRow.Length > 0)
                    {
                        string photoName = goodsRow[0]["Photo"].ToString();
                        if (!string.IsNullOrEmpty(photoName) && photoName != "picture.png")
                        {
                            string imagePath = Path.Combine(Application.StartupPath, "images", photoName);
                            if (File.Exists(imagePath))
                            {
                                File.Delete(imagePath);
                            }
                        }
                    }

                    // 3. Удаляем из БД (Убедитесь, что в goodsTableAdapter есть запрос DeleteQuery)
                    goodsTA.DeleteQuery(articul);

                    MessageBox.Show("Товар успешно удалён!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGoods(); // Обновляем список
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            orders_view ov = new orders_view();
            ov.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            goods_edit addForm = new goods_edit();
            addForm.ShowDialog(); // Модальное окно
            LoadGoods(); // Обновляем список после закрытия окна
        }
    }
}