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
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : UserControl
    {
        public Transactions()
        {
            InitializeComponent();
            SupportText.Text = "QUESTION 1: WHAT IS YOUR APPLICATION?\r\nAnswer: Our Windows application provides the ability to order custom application creation services. You can choose from 1 to 6 different options to customize your future application. Options include database, optimization, server, security, scalability and usability.\r\n\r\nQUESTION 2: HOW DOES THE ORDERING PROCESS WORK?\r\nAnswer: The process of ordering services is very simple and convenient. On the purchase page, you select the required options from the list, add them to your cart, and then you can complete the purchase by providing the required payment information. Once the purchase is completed, we will begin working on your application.\r\n\r\nQUESTION 3: WHAT INFORMATION IS AVAILABLE IN YOUR PURCHASE HISTORY?\r\nAnswer: In your personal account you will find the “Purchase History” section, where you can view all previously placed orders. You will see a list of purchased services, order date and cost. This is useful for tracking your costs and monitoring orders.\r\n\r\nQUESTION 4: HOW DO I KNOW HOW MUCH MONEY I SPENT ON ORDERS?\r\nAnswer: In your personal account there is a “Financial History” section, where you can see the total amount you spent on orders. This will help you estimate the budget spent on creating applications.\r\n\r\nQUESTION 5: CAN I CANCEL OR CHANGE AN ORDER AFTER I HAVE PLACED IT?\r\nAnswer: Once an order is placed, changes may be limited depending on the stage of development of the project. However, if you have questions or require a change, please contact our support team to review your request.\r\n\r\nQUESTION 6: HOW IS MY DATA AND PAYMENT SECURED?\r\nAnswer: We take security seriously. We use encryption and security standards to protect your data and payment information. Your privacy is important to us.\r\n\r\nQUESTION 7: HOW CAN I CONTACT YOUR TECHNICAL SUPPORT IF I HAVE ADDITIONAL QUESTIONS?\r\nAnswer: You can contact our technical support by writing to us at [support email address] or through the feedback form on our website. We are ready to answer all your questions and help you.";
        }
    }
}
