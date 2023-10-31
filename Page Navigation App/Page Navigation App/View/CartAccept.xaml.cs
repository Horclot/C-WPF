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
            TextAccept.Text = "Check";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
