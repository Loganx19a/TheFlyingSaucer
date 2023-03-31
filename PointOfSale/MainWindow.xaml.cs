using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Order();
        }
        
        /// <summary>
        /// Shows the desired screen in the Main Window
        /// </summary>
        /// <param name="screen"></param>
        public void ShowScreen(UserControl screen)
        {
            MenuItemBorder.Child = screen;
        }

        /// <summary>
        /// An event handler method that's called when the user clicks on the "Back To Menu" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToMainMenu(object sender, RoutedEventArgs e)
        {
            MenuItemBorder.Child = null;
        }

        /// <summary>
        /// An event handler method that's called when the user clicks on the "Cancel Order" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CancelOrderClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) this.DataContext = new Order();
        }

        /// <summary>
        /// An event handler that's called when the user clicks the "Complete Order" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CompleteOrderClick(object sender, RoutedEventArgs e)
        {
            var screen = new PaymentOptionsScreen();
            var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
            window.ShowScreen(screen);
        }
    }
}
