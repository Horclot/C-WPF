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
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        public ObservableCollection<Historys> PurchaseHistory { get; set; }
        public Orders()
        {
            InitializeComponent();
            PurchaseHistory = new ObservableCollection<Historys>();

            using (var context = new ApplicationDbHistory())
            {
                // Здесь вы извлекаете записи из таблицы History, где UsersId соответствует SharedData.Id
                var userPurchaseHistory = context.History.Where(history => history.usersId == SharedData.Id).ToList();

                // Преобразуете записи из таблицы в объекты HistoryItem и добавляете их в PurchaseHistory
                foreach (var historyItem in userPurchaseHistory)
                {
                    PurchaseHistory.Add(new Historys
                    {
                        data = historyItem.data,
                        itemName = historyItem.itemName,
                        price = historyItem.price,
                        status = historyItem.status,
                        usersId = SharedData.Id
                    }); ;
                }
            }
            DataContext = this;
        }
    }
}