
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
using System.Xml.Linq;
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
            Product = new ObservableCollection<Product>();

            using (var context = new ApplicationDbItem())
            {
                // Проверяем наличие продуктов с состоянием state = 1 в базе данных
                var productsFromDb = context.Item.Where(item => item.state == 0).ToList();

                // Добавляем только те продукты, которые соответствуют условию
                foreach (var productFromDb in productsFromDb)
                {
                    Product.Add(new Product
                    {
                        Id = productFromDb.id,
                        Name = productFromDb.name,
                        Price = productFromDb.price,
                        ImagePath = productFromDb.imagePath
                    });
                }
            }

            DataContext = this;
        }
        private void BuyButton_Click(object sender, RoutedEventArgs e)
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
                    existingItem.state = 1;
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

            Product.Remove(product);
        }


    }
}
