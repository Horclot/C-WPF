using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Page_Navigation_App.View
{
    /// <summary>
    /// Логика взаимодействия для CartAccept.xaml
    /// </summary>
    public partial class CartAccept : Window
    {
        public CartAccept()
        {
            InitializeComponent();

            using (var context = new ApplicationDbItem())
            {
                // Получите все продукты с состоянием state = 1 из базы данных
                var productsWithState1 = context.Item.Where(item => item.state == 1).ToList();

                StringBuilder sb = new StringBuilder();
                decimal totalPrice = 0;

                foreach (var product in productsWithState1)
                {
                    // Добавьте имя и цену каждого продукта в строку
                    sb.AppendLine($"{product.name} - ${product.price:F2}");
                    totalPrice += product.price;
                }

                // Добавьте сумму всех цен в строку
                sb.AppendLine($"\n\n\n\nTotal Price: ${totalPrice:F2}");

                // Установите строку в TotalPriceLabel
                TotalPriceLabel.Text = sb.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
