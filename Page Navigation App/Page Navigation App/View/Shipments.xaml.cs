using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Page_Navigation_App.View
{
    public partial class Shipments : UserControl
    {
        int sum = 0;
        public ObservableCollection<Product> Product { get; set; } = new ObservableCollection<Product>();

        public Shipments()
        {

            InitializeComponent();

            

            Product = new ObservableCollection<Product>();

            using (var context = new ApplicationDbItem())
            {
                // Проверяем наличие продуктов с состоянием state = 1 в базе данных
                var productsFromDb = context.Item.Where(item => item.state == 1).ToList();

                // Добавляем только те продукты, которые соответствуют условию
                foreach (var productFromDb in productsFromDb)
                {
                    sum = sum + productFromDb.price;
                    Product.Add(new Product
                    {
                        Id = productFromDb.id,
                        Name = productFromDb.name,
                        Price = productFromDb.price,
                        ImagePath = productFromDb.imagePath
                    });
                }
            }
            sumPriceText.Content = "Total: " + sum + "$";
            DataContext = this;
        }
        private void BuyButton_Click1(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var product = (Product)button.Tag;

            using (var content = new ApplicationDbItem())
            {
                string name = product.Name;

                // Поиск продукта с тем же именем в базе данных
                var existingItem = content.Item.FirstOrDefault(item => item.name == name);

                if (existingItem != null)
                {
                    // Если продукт с таким именем существует, обновите его состояние
                    existingItem.state = 0;
                }
                else
                {
                    int id = product.Id;
                    int price = product.Price;
                    string img = product.ImagePath;

                    var newItems = new Items
                    {
                        name = name,
                        id = id,
                        price = price,
                        imagePath = img,
                        state = 1
                    };

                    content.Item.Add(newItems);
                }

                content.SaveChanges();
            }
            
            sum = sum - product.Price;
            sumPriceText.Content = "Total: " + sum + "$";
            Product.Remove(product);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var contextItem = new ApplicationDbItem())
            {
                using (var contextHistory = new ApplicationDbHistory())
                {
                    // Проверяем наличие продуктов с состоянием state = 1 в базе данных
                    var cartItems = contextItem.Item.Where(item => item.state == 1).ToList();

                    if (cartItems.Any())
                    {
                        // Создаем запись в таблице History
                        var historyItem = new Historys
                        {
                            data = DateTime.Now.ToString(), // Текущая дата и время
                            itemName = string.Join(", ", cartItems.Select(item => item.name)), // Список имен продуктов
                            price = sum, // Общая сумма
                            status = "accept", // Устанавливаем статус "accept"
                            usersId = SharedData.Id 
                        };

                        contextHistory.History.Add(historyItem);

                        // Устанавливаем state = 0 для всех продуктов в корзине
                        foreach (var item in cartItems)
                        {
                            item.state = 0;
                        }

                        contextItem.SaveChanges();
                        contextHistory.SaveChanges();

                        // Очищаем коллекцию продуктов и обновляем отображение
                        Product.Clear();
                        sum = 0;
                        sumPriceText.Content = "Total: " + sum + "$";
                    }
                    else
                    {
                        MessageBox.Show("Cart is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }


    }


}
     
