using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.Drinks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Liquified Vegetation class
    /// </summary>
    public class LiquifiedVegetationUnitTests
    {
        /// <summary>
        /// Tests whether the Name property returns the correct name
        /// </summary>
        [Fact]
        public void NamePropertyShouldReturnCorrectValue()
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.Equal("Liquified Vegetation", drink.Name);
        }

        /// <summary>
        /// Tests whether the Description property returns the correct description
        /// </summary>
        [Fact]
        public void DescriptionPropertyShouldReturnCorrectValue()
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.Equal("A cold glass of blended vegetable juice.", drink.Description);
        }

        /// <summary>
        /// Tests whether the Size property returns the correct size
        /// </summary>
        [Fact]
        public void SizePropertyShouldReturnCorrectValue()
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.Equal(ServingSize.Small, drink.Size);
        }

        /// <summary>
        /// Tests whether the Ice property returns the correct value
        /// </summary>
        [Fact]
        public void IcePropertyShouldReturnCorrectValue()
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.True(drink.Ice);
        }

        /// <summary>
        /// Tests whether the Price property returns the correct value
        /// </summary>
        [Fact]
        public void PricePropertyShouldReturnCorrectValue()
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.Equal(1.00m, drink.Price);
            drink.Size = ServingSize.Medium;
            Assert.Equal(1.50m, drink.Price);
            drink.Size = ServingSize.Large;
            Assert.Equal(2.00m, drink.Price);
        }

        /// <summary>
        /// Tests whether the Calories property returns the correct value
        /// </summary>
        [Fact]
        public void CaloriesPropertyShouldReturnCorrectValue()
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.Equal(72u, drink.Calories);
            drink.Size = ServingSize.Medium;
            Assert.Equal(144u, drink.Calories);
            drink.Size = ServingSize.Large;
            Assert.Equal(216u, drink.Calories);
        }

        /// <summary>
        /// Tests whether the special instructions property returns the instructions
        /// </summary>
        [Fact]
        public void SpecialInstructionsPropertyShouldReturnCorrectValue()
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.Empty(drink.SpecialInstructions);
            drink.Ice = false;
            Assert.Contains("No Ice", drink.SpecialInstructions);
        }

    }
}
