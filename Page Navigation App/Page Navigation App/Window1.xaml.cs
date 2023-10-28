using System;
using System.Linq;
using System.Windows;


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

            if ((nameReg.Text == "") || (emailReg.Text == "") || (passReg.Password == "") || (!emailReg.Text.Contains("@")))
            {
                MessageBox.Show("Ошибка заполнения данных","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                using (var context = new ApplicationDbContext())
                {

                    if (context.Users.Any(u => u.Name == name))
                    {
                        // Имя пользователя уже существует, обработайте ошибку или выведите сообщение
                        MessageBox.Show("Данный пользователь уже зарегистрирован.");
                        return;
                    }


                    if (context.Users.Any(u => u.Email == email))
                    {
                        // Email уже существует, обработайте ошибку или выведите сообщение
                        MessageBox.Show("Данный email уже зарегистрирован.");
                        return;
                    }

                    int id;
                    do
                    {
                        // Генерируем случайный ID + уникальность
                        Random random = new Random();
                        id = random.Next(1, 999999999);
                    }
                    while (context.Users.Any(u => u.Id == id));

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
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                Window2 window2 = new Window2();
                window2.Show();
                this.Close();
        }   
    }
}
