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
using System.Xml.Linq;

namespace Page_Navigation_App
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = emailLogin.Text;
            string password = passLogin.Password;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || !email.Contains("@"))
            {
                MessageBox.Show("Ошибка заполнения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (var context = new ApplicationDbContext())
                {
                    if (context.Users.Any(u => u.Email == email && u.Password == password))
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный email или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }
    }
}
