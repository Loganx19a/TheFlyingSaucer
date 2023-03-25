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
    /// Interaction logic for CountBox.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for CountBox.xaml
    /// </summary>
    public partial class CountBox : UserControl
    {
        public CountBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            nameof(Count),
            typeof(uint),
            typeof(CountBox), new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public uint Count
        {
            get { return (uint)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Count != uint.MaxValue) Count++;
            e.Handled = true;
        }

        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count != 0) Count--;
            e.Handled = true;
        }
    }
}
