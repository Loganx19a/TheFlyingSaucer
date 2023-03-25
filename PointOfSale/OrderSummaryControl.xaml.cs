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
using TheFlyingSaucer.Data.BaseClasses;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Entrees;
using TheFlyingSaucer.Data.Sides;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EditItemClick(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow as PointOfSale.MainWindow;
            if (e.OriginalSource is Button button)
            {
                if (button.DataContext is IMenuItem item)
                {
                    if (item is FlyingSaucer)
                    {
                        var fs = new FlyingSaucerCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is CrashedSaucer)
                    {
                        var fs = new CrashedSaucerCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is LivestockMutilation)
                    {
                        var fs = new LivestockMutilationCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is OuterOmlette)
                    {
                        var fs = new OuterOmletteCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is CropCircle)
                    {
                        var fs = new CropCircleCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is GlowingHaystack)
                    {
                        var fs = new GlowingHaystackCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is TakenBacon)
                    {
                        var fs = new TakenBaconCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is MissingLinks)
                    {
                        var fs = new MissingLinksCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is EvisceratedEggs)
                    {
                        var fs = new EvisceratedEggsCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is YouAreToast)
                    {
                        var fs = new YouAreToastCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is LiquifiedVegetation)
                    {
                        var fs = new FlyingSaucerCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is SaucerFuel)
                    {
                        var fs = new FlyingSaucerCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs);
                    }

                    else if (item is InorganicSubstance)
                    {
                        var fs = new FlyingSaucerCustomizationControl();
                        fs.DataContext = item;
                        window.ShowScreen(fs); 
                    }


                }
            }


        }

        void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                if (button.DataContext is IMenuItem item)
                {
                    var window = (MainWindow)Application.Current.MainWindow;
                    Order order = (Order)window.DataContext;
                    order.Remove(item);
                }
            }
        }
    }
}
