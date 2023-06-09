﻿using System;
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
using TheFlyingSaucer.Data.Entrees;
using TheFlyingSaucer.Data.Sides;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.BaseClasses;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddItemClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICollection<IMenuItem> data)
            {
                if (sender == FlyingSaucerButton)
                {
                    var item = new FlyingSaucer();
                    var screen = new FlyingSaucerCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == CrashedSaucerButton)
                {
                    var item = new CrashedSaucer();
                    var screen = new CrashedSaucerCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == LiveStockMutilationButton)
                {
                    var item = new LivestockMutilation();
                    var screen = new LivestockMutilationCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == OuterOmletteButton)
                {
                    var item = new OuterOmlette();
                    var screen = new OuterOmletteCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == CropCircleButton)
                {
                    var item = new CropCircle();
                    var screen = new CropCircleCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == GlowingHaystackButton)
                {
                    var item = new GlowingHaystack();
                    var screen = new GlowingHaystackCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == TakenBaconButton)
                {
                    var item = new TakenBacon();
                    var screen = new TakenBaconCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == MissingLinksButton)
                {
                    var item = new MissingLinks();
                    var screen = new MissingLinksCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == EvisceratedEggsButton)
                {
                    var item = new EvisceratedEggs();
                    var screen = new EvisceratedEggsCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == YoureToastButton)
                {
                    var item = new YouAreToast();
                    var screen = new YouAreToastCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == LiquifiedVegetationButton)
                {
                    var item = new LiquifiedVegetation();
                    var screen = new LiquifiedVegetationCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == SaucerFuelButton)
                {
                    var item = new SaucerFuel();
                    var screen = new SaucerFuelCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

                if (sender == InorganicSubstanceButton)
                {
                    var item = new InorganicSubstance();
                    var screen = new InorganicSubstanceCustomizationControl();
                    screen.DataContext = item;
                    var window = Application.Current.MainWindow as TheFlyingSaucer.PointOfSale.MainWindow;
                    window.ShowScreen(screen);
                    Order order = (Order)window.DataContext;
                    data.Add(item);
                }

               
            }

          
        }



    }
}
