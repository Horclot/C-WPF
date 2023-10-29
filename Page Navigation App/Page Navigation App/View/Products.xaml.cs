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
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    
    public partial class Products : UserControl
    {
        private ObservableCollection<Product> products = new ObservableCollection<Product>();
        public Products()
        {
            InitializeComponent();
            productListView.ItemsSource = products;
            // Заполните список товаров
            products.Add(new Product { Name = "Товар 1", Price = 10.99 });
            products.Add(new Product { Name = "Товар 2", Price = 15.49 });
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            // Обработка нажатия кнопки "В корзину"
            var button = (Button)sender;
            var product = (Product)button.Tag;
            // Добавьте товар в корзину
            // Можете использовать свой собственный код для управления корзиной
        }
    }
}
