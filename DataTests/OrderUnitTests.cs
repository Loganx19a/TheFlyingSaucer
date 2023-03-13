using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Order class
    /// </summary>
    public class OrderUnitTests
    {
        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockMenuItem : IMenuItem
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public uint Calories { get; set; }
            public IEnumerable<string> SpecialInstructions { get; set; }
        }

        /// <summary>
        /// Tests that the Number property updates and matches the corresponding ordinal number of the order
        /// </summary>
        [Fact]
        public void Test_Order_Number_Increment()
        {
            // Arrange
            int expectedNumber = 1;

            // Act
            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();

            // Assert
            Assert.Equal(expectedNumber++, order1.Number);
            Assert.Equal(expectedNumber++, order2.Number);
            Assert.Equal(expectedNumber++, order3.Number);
        }

        /// <summary>
        /// Tests that the time and date reflect when the order is created
        /// </summary>
        [Fact]
        public void PlacedAtDateAndTimeReflectWhenOrderIsCreated()
        {
            // Arrange
            DateTime expectedPlacedAt = DateTime.Now;

            // Act
            Order order = new Order();

            // Assert
            Assert.Equal(expectedPlacedAt.Date, order.PlacedAt.Date);
            Assert.Equal(expectedPlacedAt.Hour, order.PlacedAt.Hour);
            Assert.Equal(expectedPlacedAt.Minute, order.PlacedAt.Minute);
            Assert.Equal(expectedPlacedAt.Second, order.PlacedAt.Second);
        }

        /// <summary>
        /// Tests whether the time and date changes when requested multiple times
        /// </summary>
        [Fact]
        public void PlacedAtDateAndTimeDoNotChangeWhenRequestedMoreThanOnce()
        {
            // Arrange
            Order order = new Order();
            DateTime expectedPlacedAt = order.PlacedAt;

            // Act
            DateTime placedAt1 = order.PlacedAt;
            DateTime placedAt2 = order.PlacedAt;

            // Assert
            Assert.Equal(expectedPlacedAt.Date, placedAt1.Date);
            Assert.Equal(expectedPlacedAt.Hour, placedAt1.Hour);
            Assert.Equal(expectedPlacedAt.Minute, placedAt1.Minute);
            Assert.Equal(expectedPlacedAt.Second, placedAt1.Second);
            Assert.Equal(expectedPlacedAt.Date, placedAt2.Date);
            Assert.Equal(expectedPlacedAt.Hour, placedAt2.Hour);
            Assert.Equal(expectedPlacedAt.Minute, placedAt2.Minute);
            Assert.Equal(expectedPlacedAt.Second, placedAt2.Second);
        }


        /// <summary>
        /// Tests whether the order class implements INotifyPropertyChanged correctly
        /// </summary>
        /// <remarks>
        /// Important to check because property binding only works if the class can be cast to be an instance of INotifyPropertyChanged
        /// We want to make sure it's possible to cast an object (order) to a specific type (INotifyPropertyChanged).
        /// Where T is the type to cast into.
        /// </remarks>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /// <summary>
        /// Tests whether the TaxRate property triggers the PropertyChanged event when its value changes
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            // Changing TaxRate should change TaxRate, Tax, and Total

            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Tests whether the Tax property changes as a result of the TaxRate property having changed
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfTaxPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Tax", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Tests whether the Total property changes as a result of the TaxRate property having changed
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfTotalPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Total", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Tests whether the Count property changes as a result of Adding an item to the order
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyOfCountPropertyChange()
        {
            Order order = new Order();
            MockMenuItem mock = new MockMenuItem();
            Assert.PropertyChanged(order, "Count", () => {
                order.Add(mock);
            });
        }

        /// <summary>
        /// Tests whether the Count property changes as a result of Adding an item to the order
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyOfSubtotalPropertyChange()
        {
            Order order = new Order();
            MockMenuItem mock = new MockMenuItem();
            Assert.PropertyChanged(order, "Subtotal", () => {
                order.Add(mock);
            });
        }

        /// <summary>
        /// Tests whether the Total property changes as a result of Adding an item to the order
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyOfTotalPropertyChange()
        {
            Order order = new Order();
            MockMenuItem mock = new MockMenuItem();
            Assert.PropertyChanged(order, "Total", () => {
                order.Add(mock);
            });
        }

        /// <summary>
        /// Tests whether the Count property changes as a result of Removing an item to the order
        /// </summary>
        [Fact]
        public void RemovingItemShouldNotifyOfCountPropertyChange()
        {
            Order order = new Order();
            MockMenuItem mock = new MockMenuItem();
            order.Add(mock);
            Assert.PropertyChanged(order, "Count", () => {
                order.Remove(mock);
            });
        }

        /// <summary>
        /// Tests whether the Subtotal property changes as a result of Removing an item to the order
        /// </summary>
        [Fact]
        public void RemovingItemShouldNotifyOfSubtotalPropertyChange()
        {
            Order order = new Order();
            MockMenuItem mock = new MockMenuItem();
            order.Add(mock);
            Assert.PropertyChanged(order, "Subtotal", () => {
                order.Remove(mock);
            });
        }

        /// <summary>
        /// Tests whether the Tax property changes as a result of Removing an item to the order
        /// </summary>
        [Fact]
        public void RemovingItemShouldNotifyOfTaxPropertyChange()
        {
            Order order = new Order();
            MockMenuItem mock = new MockMenuItem();
            order.Add(mock);
            Assert.PropertyChanged(order, "Tax", () => {
                order.Remove(mock);
            });
        }

        /// <summary>
        /// Tests whether the Total property changes as a result of Removing an item to the order
        /// </summary>
        [Fact]
        public void RemovingItemShouldNotifyOfTotalPropertyChange()
        {
            Order order = new Order();
            MockMenuItem mock = new MockMenuItem();
            order.Add(mock);
            Assert.PropertyChanged(order, "Total", () => {
                order.Remove(mock);
            });
        }

        /// <summary>
        /// Tests whether the Count property changes as a result of Clearing the order
        /// </summary>
        [Fact]
        public void ClearingMenuShouldNotifyOfCountPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Count", () => {
                order.Clear();
            });
        }

        /// <summary>
        /// Tests whether the Subtotal property changes as a result of Clearing the order
        /// </summary>
        [Fact]
        public void ClearningMenuShouldNotifyOfSubtotalPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Subtotal", () => {
                order.Clear();
            });
        }

        /// <summary>
        /// Tests whether the Tax property changes as a result of Clearing the order
        /// </summary>
        [Fact]
        public void ClearingMenuShouldNotifyOfTaxPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Tax", () => {
                order.Clear();
            });
        }

        /// <summary>
        /// Tests whether the Total property changes as a result of Clearing the order
        /// </summary>
        [Fact]
        public void ClearingMenuShouldNotifyOfTotalPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Total", () => {
                order.Clear();
            });
        }


        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyOfCollectionChange()
        {
            Order order = new Order();

        }


        /// <summary>
        /// Checks the Substotal of the order is calculated correctly
        /// </summary>
        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            var order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });

            var result = order.Subtotal;

            Assert.Equal(6.50m, result);
        }


        /// <summary>
        /// Checks that the Add method works correctly
        /// </summary>
        [Fact]
        public void AddShouldAddItemToOrder()
        {
            
            var order = new Order();
            var item = new MockMenuItem() { Name = "Mock Item", Price = 1.00m };

            
            order.Add(item);

            
            Assert.Contains(item, order);
        }

        /// <summary>
        /// Checks that the Clear method works correctly
        /// </summary>
        [Fact]
        public void ClearShouldRemoveAllItemsFromOrder()
        {
            
            var order = new Order();
            var item1 = new MockMenuItem() { Name = "Mock Item 1", Price = 1.00m };
            var item2 = new MockMenuItem() { Name = "Mock Item 2", Price = 2.50m };
            order.Add(item1);
            order.Add(item2);

            
            order.Clear();

            Assert.Empty(order);
        }

        /// <summary>
        /// Checks that the Contains method works correctly if item is in the order
        /// </summary>
        [Fact]
        public void ContainsShouldReturnTrueIfItemIsInOrder()
        {
            
            var order = new Order();
            var item = new MockMenuItem() { Name = "Mock Item", Price = 1.00m };
            order.Add(item);

            
            var result = order.Contains(item);

            
            Assert.True(result);
        }

        /// <summary>
        /// Checks that the Contains method works correctly if item is not in the order
        /// </summary>
        [Fact]
        public void ContainsShouldReturnFalseIfItemIsNotInOrder()
        {
            
            var order = new Order();
            var item1 = new MockMenuItem() { Name = "Mock Item 1", Price = 1.00m };
            var item2 = new MockMenuItem() { Name = "Mock Item 2", Price = 2.50m };
            order.Add(item1);

            
            var result = order.Contains(item2);

            
            Assert.False(result);
        }
    }
}
