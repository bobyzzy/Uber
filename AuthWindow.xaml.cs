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
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = mainLogin.Text.Trim();
            string pass = mainPass.Password.Trim();

            if (login.Length < 5)
            {
                mainLogin.ToolTip = "Это поле введено некорректно";
                mainLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 5)
            {
                mainPass.ToolTip = "Это поле введено некорректно";
                mainPass.Background = Brushes.Red;
            }
            else
            {
                mainLogin.ToolTip = "";
                mainLogin.Background = Brushes.Transparent;
                mainPass.ToolTip = "";
                mainPass.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext db = new ApplicationContext()) 
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                { 
                    MessageBox.Show("Пользователь Авторизирован");
                    UserCabinet userCabinet = new UserCabinet();
                    userCabinet.Show();
                    Hide();
                }

                else
                    MessageBox.Show("вы ввели что-то некорректно");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
