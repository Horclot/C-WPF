using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Page_Navigation_App.View
{

    public partial class Shipments : UserControl
    {   int y = 0;
        int product1 = 100;
        int product2 = 200;
        int product3 = 300;
        int product4 = 400;
        int product5 = 500;
        int product6 = 666;

        int allPrice = 0;
        public ObservableCollection<Product> Product { get; set; } = new ObservableCollection<Product>();
        public Shipments()
        {

            InitializeComponent();
            LoadProductsAsync();
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


                    if (userProductIds.Contains(x))
                    {
                        allPrice += product1;
                        Product.Add(new Product { Id = x, Name = "Database", Price = 100, ImagePath = "https://i.imgur.com/JbuHHBC.png" });
                        y++;
                    }

                    x++;

                    if (userProductIds.Contains(x))
                    {
                        allPrice += product2;
                        Product.Add(new Product { Id = x, Name = "Optimization", Price = 200, ImagePath = "https://i.imgur.com/YQG7iDH.png" });
                        y++;
                    }
                    x++;

                    if (userProductIds.Contains(x)) 
                    {
                        allPrice += product3;
                        Product.Add(new Product { Id = x, Name = "Server", Price = 300, ImagePath = "https://i.imgur.com/J93ezh3.png" });
                        y++;
                    }

                    x++;

                    if (userProductIds.Contains(x))
                    {
                        allPrice += product4;
                        Product.Add(new Product { Id = x, Name = "Protection", Price = 400, ImagePath = "https://i.imgur.com/XzUjkZ3.png" });
                        y++;
                    }
                    x++;

                    if (userProductIds.Contains(x))
                    {
                        allPrice += product5;
                        Product.Add(new Product { Id = x, Name = "Scale", Price = 500, ImagePath = "https://i.imgur.com/yHnw1pX.png" });
                        y++;
                    }
                    x++;

                    if (userProductIds.Contains(x))
                    {
                        allPrice += product6;
                        Product.Add(new Product { Id = x, Name = "Convenience", Price = 666, ImagePath = "https://i.imgur.com/fRaDe9y.png" });
                        y++;
                    }
                    DataContext = this;
                }
                else
                {
                    MessageBox.Show($"Ошибка при получении данных о товарах пользователя: {userProductsResponse.StatusCode}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (y == 0)
                {
                    AcceptButton.Visibility = Visibility.Collapsed;
                } 
            }
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int userId = SharedData.Id;
            string userName = SharedData.Name;

            string apiUrl = "http://192.168.1.5:5000/Checkout";
            string jsonData = $"{{\"UserId\": \"{userId}\", \"UserName\": \"{userName}\", \"AllPrice\": \"{allPrice}\"}}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    Buy buy = new Buy();
                    buy.Show();

                    Window mainWindow = Window.GetWindow(this);
                    mainWindow.Close();
                }
                else { MessageBox.Show($"Ошибка покупки, повторите запрос позже: {response.StatusCode}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }


        private async void BuyButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var product = (Product)button.Tag;

            int userId = SharedData.Id;
            int productId = product.Id;
            string productName = product.Name;
            string productImagePath = product.ImagePath;
            int productPrice = product.Price;
            // Отправляем запрос на удаление продукта на сервер
            string apiUrl = "http://192.168.1.5:5000/delete_product";
            string jsonData = $"{{\"UserId\": \"{userId}\", \"ProductId\": \"{productId}\"}}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    Product.Remove(product);
                    y--;
                    if (y == 0) AcceptButton.Visibility = Visibility.Collapsed;
                    allPrice -= product.Price;
                    
                }
                else
                {
                    MessageBox.Show($"Ошибка при удалении продукта: {response.StatusCode}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        
    }
}


