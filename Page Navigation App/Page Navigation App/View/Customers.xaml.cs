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
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : UserControl
    {
        public Customers()
        {
            InitializeComponent();
            int idFromWindow1 = SharedData.Id;
            string id = idFromWindow1.ToString();
            string name = SharedData.Name;
            string email = SharedData.Email;
            TextName.Content = "Name: " + name;
            TextEmail.Content = "Email: " + email;
            textId.Content = "id: " + SharedData.Id;
        }
    }
}
