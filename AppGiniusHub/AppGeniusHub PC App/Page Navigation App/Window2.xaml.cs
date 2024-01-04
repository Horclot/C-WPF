using System;
using System.Windows;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Page_Navigation_App
{
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = emailLogin.Text;
            string password = passLogin.Password;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || !email.Contains("@"))
            {
                MessageBox.Show("Ошибка заполнения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string apiUrl = "http://192.168.1.5:5000/authenticate";
                string jsonData = $"{{\"Email\": \"{email}\", \"Password\": \"{password}\"}}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {

                        string responseData = await response.Content.ReadAsStringAsync();
                        dynamic jsonResponse = JsonConvert.DeserializeObject(responseData);

                        SharedData.Name = jsonResponse.Name;
                        SharedData.Email = email;
                        SharedData.Id = jsonResponse.UserId;

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при проверке данных: {response.StatusCode}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
