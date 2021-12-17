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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            ApplicationContext db;
        public MainWindow()
        {

            InitializeComponent();

            db = new ApplicationContext();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = mainLogin.Text.Trim();
            string pass = mainPass.Password.Trim();
            string pass1 = mainPass1.Password.Trim();
            string email = mainEmail.Text.Trim().ToLower();

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
            else if (pass != pass1)
            {
                mainPass1.ToolTip = "Это поле введено некорректно";
                mainPass1.Background = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                mainEmail.ToolTip = "Это поле введено некорректно";
                mainEmail.Background = Brushes.Red;
            }
            else
            {
                mainLogin.ToolTip = "";
                mainLogin.Background = Brushes.Transparent;
                mainPass.ToolTip = "";
                mainPass.Background = Brushes.Transparent;
                mainPass1.ToolTip = "";
                mainPass1.Background = Brushes.Transparent;
                mainEmail.ToolTip = "";
                mainEmail.Background = Brushes.Transparent;

                MessageBox.Show("Пользователь Зарегистрирован");
                User user = new User(login, email, pass);
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();

            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
