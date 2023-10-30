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
        public string ImagePath { get; set; }
    }

    public partial class Products : UserControl
    {
        public ObservableCollection<Product> Product { get; set; } = new ObservableCollection<Product>();
        public Products()
        {
            InitializeComponent();  
            Product = new ObservableCollection<Product>();
            // Добавьте товары в коллекцию Products
            Product.Add(new Product { Name = "ServerApp", Price = 350.00, ImagePath = "C:\\Users\\diana\\OneDrive\\Рабочий стол\\GitHub\\C-WPF\\Page Navigation App\\Page Navigation App\\Images\\invent1.png" });
            Product.Add(new Product { Name = "Social network", Price = 200.00, ImagePath = "C:\\Users\\diana\\OneDrive\\Рабочий стол\\GitHub\\C-WPF\\Page Navigation App\\Page Navigation App\\Images\\invent2.png" });
            Product.Add(new Product { Name = "Your idea", Price = 5000.00, ImagePath = "C:\\Users\\diana\\OneDrive\\Рабочий стол\\GitHub\\C-WPF\\Page Navigation App\\Page Navigation App\\Images\\invent3.png" });
            Product.Add(new Product { Name = "Optimized", Price = 400.00, ImagePath = "C:\\Users\\diana\\OneDrive\\Рабочий стол\\GitHub\\C-WPF\\Page Navigation App\\Page Navigation App\\Images\\invent4.png" });
            Product.Add(new Product { Name = "Simple app", Price = 200.00, ImagePath = "C:\\Users\\diana\\OneDrive\\Рабочий стол\\GitHub\\C-WPF\\Page Navigation App\\Page Navigation App\\Images\\invent5.png" });
            Product.Add(new Product { Name = "Premium app", Price = 800.00, ImagePath = "C:\\Users\\diana\\OneDrive\\Рабочий стол\\GitHub\\C-WPF\\Page Navigation App\\Page Navigation App\\Images\\invent6.png" });

            // Добавьте другие товары
            DataContext = this;
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var product = (Product)button.Tag;
            // Обработка нажатия кнопки "Купить"
            MessageBox.Show("ДА!");
        }
    }
}
