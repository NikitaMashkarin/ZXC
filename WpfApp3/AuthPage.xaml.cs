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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = masterEntities.GetContext();

            var user = context.User.FirstOrDefault(u => u.Login == loginText.Text);

            if (user == null) MessageBox.Show("Пользователь не найден");

            if (user != null && user.Password != passwordText.Text) MessageBox.Show("Пароль не верный");

            Manager.MainFrame.Navigate(new ManagerPage());
        }
    }
}
