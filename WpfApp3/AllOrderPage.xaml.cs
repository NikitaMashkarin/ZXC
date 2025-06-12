using System.Linq;
using System.Windows.Controls;

namespace WpfApp3
{
    public partial class AllOrderPage : Page
    {
        public AllOrderPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var context = masterEntities.GetContext();
            var orders = context.Order.ToList();  

            All.ItemsSource = orders; 
        }
    }
}
