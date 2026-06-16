using System;
using System.Data;
using System.Windows.Forms;

namespace Exam
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(full_name_textbox.Text) ||
                string.IsNullOrWhiteSpace(login_textbox.Text) ||
                string.IsNullOrWhiteSpace(password_textbox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MainDataSetTableAdapters.usersTableAdapter adapters = new MainDataSetTableAdapters.usersTableAdapter();
            var table = adapters.GetData();

            // Проверяем, существует ли уже такой логин
            DataRow[] existingUser = table.Select($"Login = '{login_textbox.Text}'");
            if (existingUser.Length > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow dr = table.NewRow();
            dr["Role"] = 1; // По умолчанию - клиент
            dr["FIO"] = full_name_textbox.Text;
            dr["Login"] = login_textbox.Text;
            dr["Password"] = password_textbox.Text;

            table.Rows.Add(dr);
            adapters.Update(table);

            MessageBox.Show("Регистрация успешно завершена!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}