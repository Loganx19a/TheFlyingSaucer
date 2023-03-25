using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Enumerations;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Saucer Fuel class
    /// </summary>
    public class SaucerFuelUnitTests
    {
        /// <summary>
        /// Tests that the name is set correctly
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldSetName()
        {
            // Arrange & Act
            SaucerFuel sf = new SaucerFuel();

            // Assert
            Assert.Equal("Saucer Fuel", sf.Name);
        }

        /// <summary>
        /// Tests that Decaf property works correctly
        /// </summary>
        [Fact]
        public void Decaf_ShouldSetName()
        {
            // Arrange & Act
            SaucerFuel sf = new SaucerFuel() { Decaf = true };

            // Assert
            Assert.Equal("Decaf Saucer Fuel", sf.Name);
        }

        /// <summary>
        /// Tests that the price is calculated correctly
        /// </summary>
        [Fact]
        public void Price_ShouldCalculateCorrectly()
        {
            // Arrange
            SaucerFuel sf1 = new SaucerFuel() { Size = ServingSize.Small };
            SaucerFuel sf2 = new SaucerFuel() { Size = ServingSize.Medium };
            SaucerFuel sf3 = new SaucerFuel() { Size = ServingSize.Large };

            // Act & Assert
            Assert.Equal(1.00m, sf1.Price);
            Assert.Equal(1.50m, sf2.Price);
            Assert.Equal(2.00m, sf3.Price);
        }

        /// <summary>
        /// Tests that the calories is calculated correctly
        /// </summary>
        [Fact]
        public void Calories_ShouldCalculateCorrectly()
        {
            // Arrange
            SaucerFuel sf1 = new SaucerFuel() { Size = ServingSize.Small };
            SaucerFuel sf2 = new SaucerFuel() { Size = ServingSize.Medium };
            SaucerFuel sf3 = new SaucerFuel() { Size = ServingSize.Large };

            // Act & Assert
            Assert.Equal(1u, sf1.Calories);
            Assert.Equal(2u, sf2.Calories);
            Assert.Equal(3u, sf3.Calories);

            sf1.Cream = true;
            sf2.Cream = true;
            sf3.Cream = true;

            Assert.Equal(30u, sf1.Calories);
            Assert.Equal(31u, sf2.Calories);
            Assert.Equal(32u, sf3.Calories);
        }

        /// <summary>
        /// Tests that the special instructions work correctly
        /// </summary>
        [Fact]
        public void SpecialInstructions_ShouldReturnCorrectly()
        {
            // Arrange
            SaucerFuel sf1 = new SaucerFuel() { Cream = true };
            SaucerFuel sf2 = new SaucerFuel() { Cream = false };

            // Act & Assert
            Assert.Equal(new List<string>() { "With Cream" }, sf1.SpecialInstructions.ToList());
            Assert.Equal(new List<string>(), sf2.SpecialInstructions.ToList());
        }
    }
}
