using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.BaseClasses;
using TheFlyingSaucer.Data.Entrees;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the OutterOmlette Class
    /// </summary>
    public class OuterOmletteUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that OuterOmlette implements the IMenuItem interface
        /// </summary>
        [Fact]
        public void OuterOmletteShouldImplementIMenuItemInterface()
        {
            OuterOmlette omlette = new();
            Assert.IsAssignableFrom<IMenuItem>(omlette);
        }

        /// <summary>
        /// Checks that a unaltered Outter Omlette is served with Cheddar Cheese 
        /// </summary>
        [Fact]
        public void DefaultServedWithCheddarCheese()
        {
            OuterOmlette oo = new();
            Assert.True(oo.CheddarCheese);
        }

        /// <summary>
        /// Checks that a unaltered Outter Omlette is served with peppers
        /// </summary>
        [Fact]
        public void DefaultServedWithPeppers()
        {
            OuterOmlette oo = new();
            Assert.True(oo.Peppers);
        }

        /// <summary>
        /// Checks that a unaltered Outter Omlette is served with mushrooms 
        /// </summary>
        [Fact]
        public void DefaultServedWithMushrooms()
        {
            OuterOmlette oo = new();
            Assert.True(oo.Mushrooms);
        }

        /// <summary>
        /// Checks that a unaltered Outter Omlette is served with tomatoes 
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            OuterOmlette oo = new();
            Assert.True(oo.Tomatoes);
        }

        /// <summary>
        /// Checks that a unaltered Outter Omlette is served with onions 
        /// </summary>
        [Fact]
        public void DefaultServedWithOnions()
        {
            OuterOmlette oo = new();
            Assert.True(oo.Onions);
        }

        /// <summary>
        /// Checks that an Outter Omlette has a price of $7.45 
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            OuterOmlette oo = new();
            Assert.Equal(7.45m, oo.Price);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the OutterOmlette's state mutates, the name does not change
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omlette will be served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omlette will be served with peppers</param>
        /// <param name="mushrooms">If the Outer Omlette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omlette will be served with tomatoes</param>
        /// <param name="onions">If the Outer Omlette will be served with onions</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(false, true, true, true, true)]
        [InlineData(true, false, true, true, true)]
        [InlineData(true, true, false, true, true)]
        [InlineData(true, true, true, false, true)]
        [InlineData(true, true, true, true, false)]
        [InlineData(false, false, true, true, true)]
        [InlineData(false, false, false, true, true)]
        public void NameShouldAlwaysBeOuterOmlette(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions)
        {
            OuterOmlette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms, 
                Tomatoes = tomatoes,
                Onions = onions,
            };
            Assert.Equal("Outer Omlette", oo.Name);
        }


        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omlette will be served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omlette will be served with peppers</param>
        /// <param name="mushrooms">If the Outer Omlette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omlette will be served with tomatoes</param>
        /// <param name="onions">If the Outer Omlette will be served with onions</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(true, true, true, true, true, 94u + 113u + 24u + 4u + 22u + 22u)]
        [InlineData(false, true, true, true, true, 94u + 24u + 4u + 22u + 22u)]
        [InlineData(true, false, true, true, true, 94u + 113u + 4u + 22u + 22u)]
        [InlineData(true, true, false, true, true, 94u + 113u + 24u + 22u + 22u)]
        [InlineData(true, true, true, false, true, 94u + 113u + 24u + 4u + 22u)]
        [InlineData(true, true, true, true, false, 94u + 113u + 24u + 4u + 22u)]
        [InlineData(false, false, true, true, true, 94u + 4u + 22u + 22u)]
        [InlineData(false, false, false, true, true, 94u + 22u + 22u)]
        public void CaloriesShouldBeCorrect(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, uint calories)
        {
            OuterOmlette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions,
            };
            Assert.Equal(calories, oo.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Outer Omlette
        /// </summary>
        /// <param name="cheddarCheese">If the Outer Omlette will be served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omlette will be served with peppers</param>
        /// <param name="mushrooms">If the Outer Omlette will be served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omlette will be served with tomatoes</param>
        /// <param name="onions">If the Outer Omlette will be served with onions</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, true, true, new string[] { })]
        [InlineData(false, true, true, true, true, new string[] { "Hold Cheddar Cheese" })]
        [InlineData(true, false, true, true, true, new string[] { "Hold Peppers" })]
        [InlineData(true, true, false, true, true, new string[] { "Hold Mushrooms" })]
        [InlineData(true, true, true, false, true, new string[] { "Hold Tomatoes" })]
        [InlineData(true, true, true, true, false, new string[] { "Hold Onions" })]
        [InlineData(false, false, true, true, true, new string[] { "Hold Cheddar Cheese", "Hold Peppers" })]
        [InlineData(false, false, false, true, true, new string[] { "Hold Cheddar Cheese", "Hold Peppers", "Hold Mushrooms" })]
        public void SpecialInstructionsRelfectsState(bool cheddarCheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, string[] instructions)
        {
            OuterOmlette oo = new()
            {
                CheddarCheese = cheddarCheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, oo.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, oo.SpecialInstructions.Count());
        }

        /// <summary>
        /// Tests whether the ToString method is working properly for this class
        /// </summary>
        /// <param name="name">the Name property of this class</param>
        [Theory]
        [InlineData("Outer Omlette")]
        public void ToStringMethodShouldWorkProperly(string name)
        {
            Assert.Equal("Outer Omlette", name);
        }


        // new string[] { }
        #endregion

    }
}
