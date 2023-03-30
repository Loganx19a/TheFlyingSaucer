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

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for CurrencyControl.xaml
    /// </summary>
    public partial class CashPaymentControl : UserControl
    {
        public CashPaymentControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty FromCustomerProperty = DependencyProperty.Register(
            nameof(Paid),
            typeof(uint),
            typeof(CountBox), new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public uint Paid
        {
            get { return (uint)GetValue(FromCustomerProperty); }
            set { SetValue(FromCustomerProperty, value); }
        }

        public static readonly DependencyProperty OwedProperty = DependencyProperty.Register(
            nameof(Owed),
            typeof(uint),
            typeof(CountBox), new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 
        /// </summary>
        public uint Owed
        {
            get { return (uint)GetValue(OwedProperty); }
            set { SetValue(OwedProperty, value); }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Paid != uint.MaxValue) Paid++;
            e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Owed != 0) Owed--;
            e.Handled = true;
        }
    }
}
