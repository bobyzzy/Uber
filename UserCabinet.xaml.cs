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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserCabinet.xaml
    /// </summary>
    public partial class UserCabinet : Window
    {
        public UserCabinet()
        {
            InitializeComponent();

            ApplicationContext db = new ApplicationContext();
            List<User> users = db.Users.ToList();

            listOfUsers.ItemsSource = users; 

        }

        private void Button_User_Click(object sender, RoutedEventArgs e)
        {
            OrderPage orderPage = new OrderPage();
            orderPage.Show();
            Hide();
        }
    }
}
