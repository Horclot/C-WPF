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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Page_Navigation_App.View
{
    
    public partial class Customers : UserControl
    {
        public Customers()
        {
            InitializeComponent();
            string name = SharedData.Name;
            string email = SharedData.Email;
            TextName.Content = "Name: " + name;
            TextEmail.Content = "Email: " + email;
            textId.Content = "id: " + SharedData.Id;

            
            using (var context = new ApplicationDbHistory())
            {
                // Подсчет количества покупок
                int purchaseCount = context.History
                    .Where(history => history.usersId == SharedData.Id)
                    .Count();

                // Подсчет общей потраченной суммы
                decimal totalSpent = context.History
                    .Where(history => history.usersId == SharedData.Id)
                    .Sum(history => history.price);

                // Обновление соответствующих элементов на форме
                SumItem.Content = "Total Spent: $" + totalSpent.ToString("0.00");
                Quantity.Content = "Purchase Count: " + purchaseCount;
            }
        }
    }
}
