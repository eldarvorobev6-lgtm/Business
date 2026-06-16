using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Exam
{
    public partial class GoodsView : Form
    {
        private int _currentSupplierId = 0;
        private bool _isFilterLoading = false;

        public GoodsView()
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
            _isFilterLoading = true;

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
            _currentSupplierId = 0;

            _isFilterLoading = false;
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

            List<string> filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                string search = searchTextBox.Text.Replace("'", "''");
                filters.Add(
                    $"((Name LIKE '%{search}%') OR " +
                    $"(Description LIKE '%{search}%') OR " +
                    $"(Measurement LIKE '%{search}%') OR " +
                    $"(Articul LIKE '%{search}%'))");
            }

            if (_currentSupplierId > 0)
            {
                filters.Add($"Supplier = {_currentSupplierId}");
            }

            dv.RowFilter = string.Join(" AND ", filters);

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
                Main_Panel.Controls.Add(new Card(item.Row));
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e) => LoadGoods();

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFilterLoading) return;

            if (filterComboBox.SelectedItem != null && filterComboBox.SelectedIndex >= 0)
            {
                try
                {
                    DataRowView selectedRow = (DataRowView)filterComboBox.SelectedItem;
                    _currentSupplierId = Convert.ToInt32(selectedRow["id"]);
                }
                catch
                {
                    _currentSupplierId = 0;
                }
            }
            else
            {
                _currentSupplierId = 0;
            }
            LoadGoods();
        }

        private void sortPriceComboBox_SelectedIndexChanged(object sender, EventArgs e) => LoadGoods();
        private void sortCountComboBox_SelectedIndexChanged(object sender, EventArgs e) => LoadGoods();

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

        public void DeleteGoods(string articul)
        {
            var result = MessageBox.Show($"Вы действительно хотите удалить товар с артикулом {articul}?\nЭто действие необратимо!",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var ordTA = new MainDataSetTableAdapters.ordersTableAdapter();
                    var ordersTable = ordTA.GetData();
                    DataRow[] foundInOrders = ordersTable.Select($"Articul = '{articul}'");

                    if (foundInOrders.Length > 0)
                    {
                        MessageBox.Show("Нельзя удалить товар, который присутствует в заказе!\nСначала удалите или измените соответствующие заказы.",
                            "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

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

                    goodsTA.DeleteQuery(articul);

                    MessageBox.Show("Товар успешно удалён!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGoods();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersView ov = new OrdersView();
            ov.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GoodsEdit addForm = new GoodsEdit();
            addForm.ShowDialog();
            LoadGoods();
        }
    }
}