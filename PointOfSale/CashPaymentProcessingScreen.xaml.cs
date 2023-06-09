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
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for CashPaymentProcessingScreen.xaml
    /// </summary>
    public partial class CashPaymentProcessingScreen : UserControl
    {
        public CashPaymentProcessingScreen()
        {
            InitializeComponent();
        }

        public void FinalizeSale(object sender, RoutedEventArgs e)
        {
            ((CashDrawerViewModel)this.DataContext).FinalizeTransaction();
        }
    }
}
