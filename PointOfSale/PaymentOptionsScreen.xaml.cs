using RoundRegister;
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
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentOptionsScreen.xaml
    /// </summary>
    public partial class PaymentOptionsScreen : UserControl
    {
        public PaymentOptionsScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// An event handler that's called when the user clicks the "Cash" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CashClick(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
            Order temp = (Order)window.DataContext;
            var screen = new CashPaymentProcessingScreen() {DataContext= new CashDrawerViewModel(temp) {Total = temp.Total}};
            
            window.ShowScreen(screen);
            //window.MenuItemBorder.Child = screen;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CreditDebitClick(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
            Order temp = (Order)window.DataContext;
            string result = CardReader.RunCard((double)temp.Total).ToString();

            CashDrawerViewModel viewModel = new CashDrawerViewModel(temp);
            if (result.Equals("Approved")) viewModel.PrintReceipt();
            MessageBox.Show(result);
        }
    }
}
