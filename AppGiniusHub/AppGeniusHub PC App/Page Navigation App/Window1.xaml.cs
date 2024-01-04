using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

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

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = nameReg.Text;
            string email = emailReg.Text;
            string password = passReg.Password;

            if ((nameReg.Text == "") || (emailReg.Text == "") || (passReg.Password == "") || (!emailReg.Text.Contains("@")))
            {
                MessageBox.Show("Ошибка заполнения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string apiUrl = "http://192.168.1.5:5000/data";
                string jsonData = $"{{\"Name\": \"{name}\", \"Email\": \"{email}\", \"Password\": \"{password}\"}}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        SharedData.Name = name;
                        SharedData.Email = email;

                        string responseData = await response.Content.ReadAsStringAsync();
                        dynamic jsonResponse = JsonConvert.DeserializeObject(responseData);
                        SharedData.Id = jsonResponse.UserId;

                        // Используйте Dispatcher.Invoke для открытия нового окна из асинхронного метода
                        this.Dispatcher.Invoke(() =>
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        });
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при отправке данных: {response.StatusCode}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
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
