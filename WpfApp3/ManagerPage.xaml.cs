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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegPage());
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            int idUser = int.Parse(userIdRemoveText.Text);

            var context = masterEntities.GetContext();

            var user = context.User.FirstOrDefault(x => x.Id == idUser);

            if(user != null)
            {
                context.User.Remove(user);
                context.SaveChanges();
                MessageBox.Show("Сотрудик уволен");
            }

            MessageBox.Show("Сотрудник не найден");
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            int idUser = int.Parse(userIdShiftText.Text);

            DateTime? date = DateText.SelectedDate;

            var context = masterEntities.GetContext();

            var user = context.User.FirstOrDefault(x => x.Id == idUser);

            if (user == null)
            {
                MessageBox.Show("Сотрудник не найден");
                return;
            }

            Shift shift = new Shift
            {
                Date = date ?? DateTime.Now
            };

            shift.User.Add(user);
            context.Shift.Add(shift);

            context.SaveChanges();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AllOrderPage());
        }
    }
}
