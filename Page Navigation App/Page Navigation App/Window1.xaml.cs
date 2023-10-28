﻿using Microsoft.Data.Sqlite;
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
using System.Security.Cryptography;


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

            using (var context = new ApplicationDbContext())
            {
                // Проверка наличия имени пользователя в базе данных
                if (context.Users.Any(u => u.Name == name))
                {
                    // Имя пользователя уже существует, обработайте ошибку или выведите сообщение
                    MessageBox.Show("Данный пользователь уже зарегистрирован.");
                    return; // Завершите метод
                }

                // Проверка наличия email в базе данных
                if (context.Users.Any(u => u.Email == email))
                {
                    // Email уже существует, обработайте ошибку или выведите сообщение
                    MessageBox.Show("Данный email уже зарегистрирован.");
                    return; // Завершите метод
                }

                int id;
                do
                {
                    // Генерируем случайный ID и проверяем его уникальность
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
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                Window2 window2 = new Window2();
                window2.Show();
                this.Close();
        }   
    }
}
