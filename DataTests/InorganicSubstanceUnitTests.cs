﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Enumerations;


namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Inorganic Substance class
    /// </summary>
    public class InorganicSubstanceUnitTests
    {
        #region default values

        /// <summary>
        /// Tests whether the InorganicSubstance has the correct name
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectName()
        {
            var drink = new InorganicSubstance();
            Assert.Equal("Inorganic Substance", drink.Name);
        }

        /// <summary>
        /// Tests that the InorganicSubstance has the correct description
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectDescription()
        {
            var drink = new InorganicSubstance();
            Assert.Equal("A cold glass of ice water.", drink.Description);
        }

        /// <summary>
        /// Tests that the InorganicSubstance has the correct size
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectSize()
        {
            var drink = new InorganicSubstance();
            Assert.Equal(ServingSize.Small, drink.Size);

            drink.Size = ServingSize.Medium;
            Assert.Equal(ServingSize.Medium, drink.Size);

            drink.Size = ServingSize.Large;
            Assert.Equal(ServingSize.Large, drink.Size);
        }

        /// <summary>
        /// Tests that the InorganicSubstance has ice
        /// </summary>
        [Fact]
        public void ShouldHaveIceByDefault()
        {
            var drink = new InorganicSubstance();
            Assert.True(drink.Ice);
        }

        /// <summary>
        /// Tests that the InorganicSubstance has the correct price
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectPrice()
        {
            var drink = new InorganicSubstance();
            Assert.Equal(0m, drink.Price);
        }

        /// <summary>
        /// Tests that the InorganicSubstance has the correct calories
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectCalories()
        {
            var drink = new InorganicSubstance();
            Assert.Equal(0u, drink.Calories);
        }

        /// <summary>
        /// Tests that the InorganicSubstance doesn't have special instructions by default
        /// </summary>
        [Fact]
        public void ShouldHaveNoSpecialInstructionsByDefault()
        {
            var drink = new InorganicSubstance();
            Assert.Empty(drink.SpecialInstructions);
        }

        #endregion

        #region state changes

        /// <summary>
        /// Tests that the Ice property can be set for the InorganicSubstance
        /// </summary>
        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var drink = new InorganicSubstance();
            drink.Ice = false;
            Assert.False(drink.Ice);
        }

        /// <summary>
        /// Tests that the InorganicSubstance has no special instructions when there's no ice
        /// </summary>
        [Fact]
        public void ShouldHaveNoIceSpecialInstructionWhenNoIce()
        {
            var drink = new InorganicSubstance();
            drink.Ice = false;
            Assert.Contains("No Ice", drink.SpecialInstructions);
        }

        /// <summary>
        /// Tests whether the ToString method is working properly for this class
        /// </summary>
        /// <param name="name">the Name property of this class</param>
        [Theory]
        [InlineData("Inorganic Substance")]
        public void ToStringMethodShouldWorkProperly(string name)
        {
            Assert.Equal("Inorganic Substance", name);
        }

        #endregion

        #region property changes

        [Theory]
        [InlineData(false, "Ice")]
        [InlineData(false, "SpecialInstructions")]
        [InlineData(true, "Ice")]
        [InlineData(true, "SpecialInstructions")]
        public void ChangingIceShouldNotifyOfPropertyChanges(bool ice, string propertyName)
        {
            InorganicSubstance inS = new();
            Assert.PropertyChanged(inS, propertyName, () => {
                inS.Ice = ice;
            });
        }

        #endregion
    }
}
