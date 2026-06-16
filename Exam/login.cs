using System;
using System.Data;
using System.Windows.Forms;

namespace Exam
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Registr_label_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog(); // Модальное окно, чтобы не открывать 100 форм регистрации
        }

        private void Auth_button_Click(object sender, EventArgs e)
        {
            // Валидация пустых полей
            if (string.IsNullOrWhiteSpace(Login_Textbox.Text) ||
                string.IsNullOrWhiteSpace(Password_Textbox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MainDataSetTableAdapters.usersTableAdapter tb = new MainDataSetTableAdapters.usersTableAdapter();
            var table = tb.GetData();

            // Ищем пользователя по логину и паролю
            DataRow[] foundUsers = table.Select($"Login = '{Login_Textbox.Text}' AND Password = '{Password_Textbox.Text}'");

            if (foundUsers.Length > 0)
            {
                DataRow user = foundUsers[0];

                // Сохраняем данные пользователя
                CurrentUser.Login = user["Login"].ToString();
                CurrentUser.FIO = user["FIO"].ToString();
                CurrentUser.RoleID = int.Parse(user["Role"].ToString());

                // Получаем название роли
                MainDataSetTableAdapters.RolesTableAdapter rolesTA = new MainDataSetTableAdapters.RolesTableAdapter();
                var rolesTable = rolesTA.GetData();
                DataRow[] roleRow = rolesTable.Select($"id = {CurrentUser.RoleID}");
                if (roleRow.Length > 0)
                {
                    CurrentUser.RoleName = roleRow[0]["name"].ToString();
                }

                MessageBox.Show($"Успешная авторизация!\nДобро пожаловать, {CurrentUser.FIO}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // !!! КЛЮЧЕВОЕ ИЗМЕНЕНИЕ: используем ShowDialog() !!!
                this.Hide(); // Скрываем форму входа

                GoodsView gv = new GoodsView();
                gv.ShowDialog(); // Код ниже НЕ выполнится, пока goods_view не закроется

                this.Show(); // Когда goods_view закрылась — снова показываем форму входа

                // Очищаем поля для следующего входа
                Login_Textbox.Clear();
                Password_Textbox.Clear();
                Login_Textbox.Focus();
            }
            else
            {
                MessageBox.Show("Неправильный логин и/или пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guest_button_Click(object sender, EventArgs e)
        {
            // Вход в роли гостя
            CurrentUser.Logout();
            CurrentUser.RoleID = 4;
            CurrentUser.RoleName = "Гость";
            CurrentUser.FIO = "Гость";

            this.Hide();
            GoodsView gv = new GoodsView();
            gv.ShowDialog();
            this.Show();
        }

        // Обработчик FormClosing больше не нужен!
        // Форма login — главная форма приложения (запущена через Application.Run в Program.cs),
        // поэтому при её закрытии приложение само завершится.
    }
}