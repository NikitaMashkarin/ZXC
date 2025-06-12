using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent(); 
            LoadRoles();
        }

        private void LoadRoles()
        {
            var context = masterEntities.GetContext();
            RoleComboBox.ItemsSource = context.Role.ToList();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var context = masterEntities.GetContext();

            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string lastName = LastNameBox.Text.Trim();
            string firstName = FirstNameBox.Text.Trim();
            string middleName = MiddleNameBox.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            if (RoleComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль");
                return;
            }

            if (context.User.Any(u => u.Login == login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }

            var selectedRoleId = (int)RoleComboBox.SelectedValue;

            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Login = login,
                Password = password,
                RoleId = selectedRoleId,
                IsFired = false
            };

            context.User.Add(newUser);
            context.SaveChanges();

            MessageBox.Show("Пользователь зарегистрирован!");
        }
    }
}
