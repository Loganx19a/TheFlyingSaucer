using System;
using System.Collections.Generic;
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

        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => {
                order.TaxRate = 0.15m;
            });
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
