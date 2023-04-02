using System.Transactions;
using TheFlyingSaucer.Data;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Enumerations;


namespace PointOfSaleUnitTests
{
    public class CashDrawerViewModelUnitTests
    {

        #region  tests that the currency from customer, in drawer, and change update properly
        /*
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ChangingTwentiesFromCustomerShouldNotifyOfPropertyChanges()
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);

            Assert.PropertyChanged(cashDrawerVM, "TwentiesFromCustomer", () => {
                cashDrawerVM.TwentiesFromCustomer = 1;
            });
        }
        */

        [Theory]
        [InlineData(1, "PenniesInDrawer")]
        [InlineData(2, "AmountDueNegative")]
        [InlineData(3, "ChangeOwed")]
        [InlineData(4, "AmountDue")]
        public void ChangingPenniesFromCustomerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.PenniesFromCustomer = num;
            });
        }

        [Theory]
        [InlineData(1, "PenniesInDrawer")]
        public void ChangingPenniesInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.PenniesInDrawer = num;
            });
        }

        [Theory]
        [InlineData(1, "PenniesChange")]
        public void ChangingPenniesChangeShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.PenniesChange = num;
            });
        }

        [Theory]
        [InlineData(1, "NicklesInDrawer")]
        [InlineData(2, "AmountDueNegative")]
        [InlineData(3, "ChangeOwed")]
        [InlineData(4, "AmountDue")]
        public void ChangingNickelsFromCustomerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.NicklesFromCustomer = num;
            });
        }

        [Theory]
        [InlineData(1, "NicklesInDrawer")]
        public void ChangingNicklesInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.NicklesInDrawer = num;
            });
        }

        [Theory]
        [InlineData(1, "NicklesChange")]
        public void ChangingNicklesChangeShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.NicklesChange = num;
            });
        }

        [Theory]
        [InlineData(1, "DimesInDrawer")]
        [InlineData(2, "AmountDueNegative")]
        [InlineData(3, "ChangeOwed")]
        [InlineData(4, "AmountDue")]
        public void ChangingDimesFromCustomerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.DimesFromCustomer = num;
            });
        }

        [Theory]
        [InlineData(1, "DimesInDrawer")]
        public void ChangingDimesInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.DimesInDrawer = num;
            });
        }

        [Theory]
        [InlineData(1, "DimesChange")]
        public void ChangingDimesChangeShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.DimesChange = num;
            });
        }

        [Theory]
        [InlineData(1, "QuartersInDrawer")]
        [InlineData(2, "AmountDueNegative")]
        [InlineData(3, "ChangeOwed")]
        [InlineData(4, "AmountDue")]
        public void ChangingQuartersFromCustomerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.QuartersFromCustomer = num;
            });
        }

        [Theory]
        [InlineData(1, "QuartersInDrawer")]
        public void ChangingQuartersInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.QuartersInDrawer = num;
            });
        }

        [Theory]
        [InlineData(1, "QuartersChange")]
        public void ChangingQuartersChangeShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.QuartersChange = num;
            });
        }

        [Theory]
        [InlineData(1, "OnesInDrawer")]
        [InlineData(2, "AmountDueNegative")]
        [InlineData(3, "ChangeOwed")]
        [InlineData(4, "AmountDue")]
        public void ChangingOnesFromCustomerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.OnesFromCustomer = num;
            });
        }

        [Theory]
        [InlineData(1, "OnesInDrawer")]
        public void ChangingOnesInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.OnesInDrawer = num;
            });
        }

        [Theory]
        [InlineData(1, "OnesChange")]
        public void ChangingOnesChangeShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.OnesChange = num;
            });
        }

        [Theory]
        [InlineData(1, "FivesInDrawer")]
        [InlineData(2, "AmountDueNegative")]
        [InlineData(3, "ChangeOwed")]
        [InlineData(4, "AmountDue")]
        public void ChangingFivesFromCustomerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.FivesFromCustomer = num;
            });
        }

        [Theory]
        [InlineData(1, "FivesInDrawer")]
        public void ChangingFivesInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.FivesInDrawer = num;
            });
        }

        [Theory]
        [InlineData(1, "FivesChange")]
        public void ChangingFivesChangeShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.FivesChange = num;
            });
        }

        [Theory]
        [InlineData(1, "TensInDrawer")]
        [InlineData(2, "AmountDueNegative")]
        [InlineData(3, "ChangeOwed")]
        [InlineData(4, "AmountDue")]
        public void ChangingTensFromCustomerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.TensFromCustomer = num;
            });
        }

        [Theory]
        [InlineData(1, "TensInDrawer")]
        public void ChangingTensInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.TensInDrawer = num;
            });
        }

        [Theory]
        [InlineData(1, "TensChange")]
        public void ChangingTensChangeShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.TensChange = num;
            });
        }

        [Theory]
        [InlineData(1, "TwentiesInDrawer")]
        [InlineData(2, "AmountDueNegative")]
        [InlineData(3, "ChangeOwed")]
        [InlineData(4, "AmountDue")]
        public void ChangingTwentiesFromCustomerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.TwentiesFromCustomer = num;
            });
        }

        [Theory]
        [InlineData(1, "TwentiesInDrawer")]
        public void ChangingTwentiesInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.TwentiesInDrawer = num;
            });
        }

        [Theory]
        [InlineData(1, "TwentiesChange")]
        public void ChangingTwentiesChangeShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.TwentiesChange = num;
            });
        }

        #endregion

        #region tests that the finalize transaction method works properly


        #endregion
    }
}