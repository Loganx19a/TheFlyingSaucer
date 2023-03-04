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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        public MenuItemSelectionControl()
        {
            InitializeComponent();

        }

        public void AddItemClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> data)
            {
                if (sender == FlyingSaucerButton)
                {
                    var item = new FlyingSaucer();
                    data.Add(item);
                }

                if (sender == CrashedSaucerButton)
                {
                    var item = new CrashedSaucer();
                    data.Add(item);
                }

                if (sender == LiveStockMutilationButton)
                {
                    var item = new LivestockMutilation();
                    data.Add(item);
                }

                if (sender == OuterOmletteButton)
                {
                    var item = new OuterOmlette();
                    data.Add(item);
                }

                if (sender == CropCircleButton)
                {
                    var item = new CropCircle();
                    data.Add(item);
                }

                if (sender == GlowingHaystackButton)
                {
                    var item = new GlowingHaystack();
                    data.Add(item);
                }

                if (sender == TakenBaconButton)
                {
                    var item = new TakenBacon();
                    data.Add(item);
                }

                if (sender == MissingLinksButton)
                {
                    var item = new MissingLinks();
                    data.Add(item);
                }

                if (sender == EvisceratedEggsButton)
                {
                    var item = new EvisceratedEggs();
                    data.Add(item);
                }

                if (sender == YoureToastButton)
                {
                    var item = new YouAreToast();
                    data.Add(item);
                }

                if (sender == LiquifiedVegetationButton)
                {
                    var item = new LiquifiedVegetation();
                    data.Add(item);
                }

                if (sender == SaucerFuelButton)
                {
                    var item = new SaucerFuel();
                    data.Add(item);
                }

                if (sender == InorganicSubstanceButton)
                {
                    var item = new InorganicSubstance();
                    data.Add(item);
                }

               
            }

          
        }

        private void FlyingSaucerButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
