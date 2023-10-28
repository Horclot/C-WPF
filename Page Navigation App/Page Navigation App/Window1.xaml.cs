using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace Page_Navigation_App
{
   
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = nameReg.Text;
            string email = emailReg.Text;
            string password = passReg.Password;
            int id = 0;
            Random random = new Random(); 
            random.NextInt64();
            id = random.Next(1,10000);
            using (var context = new ApplicationDbContext())
            {
                var newUser = new User
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    Password = password
                };

                context.Users.Add(newUser);
                context.SaveChanges();
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                Window2 window2 = new Window2();
                window2.Show();
                this.Close();
        }   
    }
}
