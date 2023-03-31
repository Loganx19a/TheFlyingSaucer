using TheFlyingSaucer.Data;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Enumerations;

namespace PointOfSaleUnitTests
{
    public class CashDrawerViewModelUnitTests
    {

        #region  test that the currency from customer, in drawer, and change update properly
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
        public void ChangingNickelsInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
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
        [InlineData(1, "NicklesInDrawer")]
        [InlineData(2, "AmountDueNegative")]
        [InlineData(3, "ChangeOwed")]
        [InlineData(4, "AmountDue")]
        public void ChangingDimesFromCustomerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.NicklesFromCustomer = num;
            });
        }

        [Theory]
        [InlineData(1, "NicklesInDrawer")]
        public void ChangingDimesInDrawerShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.NicklesInDrawer = num;
            });
        }

        [Theory]
        [InlineData(1, "NicklesChange")]
        public void ChangingDimesChangeShouldNotifyOfPropertyChanges(uint num, string propertyName)
        {
            Order temp = new Order();
            var cashDrawerVM = new CashDrawerViewModel(temp);
            Assert.PropertyChanged(cashDrawerVM, propertyName, () => {
                cashDrawerVM.NicklesChange = num;
            });
        }












        #endregion


    }
}