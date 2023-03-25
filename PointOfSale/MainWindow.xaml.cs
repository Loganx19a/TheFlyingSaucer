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

        private void BackToMainMenu(object sender, RoutedEventArgs e)
        {
            MenuItemBorder.Child = null;
        }

        void CancelOrderClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order order) this.DataContext = new Order();
        }
    }
}
