using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Page_Navigation_App.View
{
    

    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public int Id { get; set; }
    }

    public partial class Products : UserControl
    {
        public ObservableCollection<Product> Product { get; set; } = new ObservableCollection<Product>();

        public Products()
        {
            InitializeComponent();
            LoadProductsAsync(); // Вызываем метод для загрузки продуктов
        }

        private async Task LoadProductsAsync()
        {
            int x = 1;

            // Запрос на сервер для получения списка ProductId, которые уже есть у пользователя
            string getUserProductsUrl = $"http://192.168.1.5:5000/get_products";
            string jsonData = $"{{\"UserId\": \"{SharedData.Id}\"}}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage userProductsResponse = await client.PostAsync(getUserProductsUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                if (userProductsResponse.IsSuccessStatusCode)
                {
                    string userProductsData = await userProductsResponse.Content.ReadAsStringAsync();
                    Console.WriteLine(userProductsData); // Отладочный вывод

                    dynamic userProductsJson = JsonConvert.DeserializeObject(userProductsData);

                    // Создаем HashSet для быстрого поиска существующих ProductId
                    HashSet<int> userProductIds = new HashSet<int>(userProductsJson.ProductIds.ToObject<IEnumerable<int>>());

                    // Добавление продуктов в окно, с проверкой наличия ProductId у пользователя
                    Product = new ObservableCollection<Product>();


                    if (!userProductIds.Contains(x))
                        
                        Product.Add(new Product { Id = x, Name = "Database", Price = 100, ImagePath = "https://i.imgur.com/JbuHHBC.png" });
                    

                    x++;

                    if (!userProductIds.Contains(x))
                        Product.Add(new Product { Id = x, Name = "Optimization", Price = 200, ImagePath = "https://i.imgur.com/YQG7iDH.png" });

                    x++;

                    if (!userProductIds.Contains(x))
                        Product.Add(new Product { Id = x, Name = "Server", Price = 300, ImagePath = "https://i.imgur.com/J93ezh3.png" });

                    x++;

                    if (!userProductIds.Contains(x))
                        Product.Add(new Product { Id = x, Name = "Protection", Price = 400, ImagePath = "https://i.imgur.com/XzUjkZ3.png" });

                    x++;

                    if (!userProductIds.Contains(x))
                        Product.Add(new Product { Id = x, Name = "Scale", Price = 500, ImagePath = "https://i.imgur.com/yHnw1pX.png" });

                    x++;

                    if (!userProductIds.Contains(x))
                        Product.Add(new Product { Id = x, Name = "Convenience", Price = 666, ImagePath = "https://i.imgur.com/fRaDe9y.png" });

                    DataContext = this;
                }
                else
                {
                    MessageBox.Show($"Ошибка при получении данных о товарах пользователя: {userProductsResponse.StatusCode}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void BuyButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            //удаление продукта с окна и занесение его данных в базу
            var button = (Button)sender;
            var product = (Product)button.Tag;

            int productId = product.Id;
            string productName = product.Name;
            string productImagePath = product.ImagePath;
            int productPrice = product.Price;
            Product.Remove(product);
            string apiUrl = "http://192.168.1.5:5000/UserCart";
            string jsonData = $"{{\"UserId\": \"{SharedData.Id}\", \"ProductId\": \"{productId}\", \"ProductName\": \"{productName}\", \"ProductPrice\": \"{productPrice}\", \"ProductImagePath\": \"{productImagePath}\"}}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {

                    string responseData = await response.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseData);
                }
                else
                {
                    MessageBox.Show($"Ошибка при отправке данных: {response.StatusCode}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
