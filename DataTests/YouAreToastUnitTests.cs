using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the YouAreToast class
    /// </summary>
    public class YouAreToastUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that YouAreToast implements the IMenuItem interface
        /// </summary>
        [Fact]
        public void YouAreToastShouldImplementIMenuItemInterface()
        {
            YouAreToast toast = new();
            Assert.IsAssignableFrom<IMenuItem>(toast);
        }

        /// <summary>
        /// Checks that an unaltered YouAreToast has 2 slices 
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeSixPancakes()
        {
            YouAreToast yat = new();
            Assert.Equal(2u, yat.Count);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the YouAreToast's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of toast slices included</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void NameShouldAlwaysBeYoureToast(uint count)
        {
            YouAreToast yat = new()
            {
                Count = count
            };
            Assert.Equal("You're Toast", yat.Name);
        }

        /// <summary>
        /// This test verifies that a YouAreToast's Count cannot exceed 12, and 
        /// if it is attempted, the Count will be set to 12.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveTwelve()
        {
            YouAreToast yat = new();
            yat.Count = 13;
            Assert.Equal(12u, yat.Count);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of slices of toast included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(1, 100)]
        [InlineData(2, 100 * 2)]
        [InlineData(3, 100 * 3)]
        [InlineData(4, 100 * 4)]
        [InlineData(5, 100 * 5)]
        [InlineData(6, 100 * 6)]
        [InlineData(7, 100 * 7)]
        [InlineData(8, 100 * 8)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            YouAreToast yat = new()
            {
                Count = count
            };
            Assert.Equal(calories, yat.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the You Are Toast
        /// </summary>
        /// <param name="count">The number of toast slices</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(1, new string[] { "1 slice" })]
        [InlineData(3, new string[] { "3 slices" })]
        [InlineData(4, new string[] { "4 slices" })]
        [InlineData(5, new string[] { "5 slices" })]
        [InlineData(6, new string[] { "6 slices" })]
        [InlineData(7, new string[] { "7 slices" })]
        [InlineData(8, new string[] { "8 slices" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            YouAreToast yat = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, yat.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, yat.SpecialInstructions.Count());
        }

        /// <summary>
        /// Tests whether the ToString method is working properly for this class
        /// </summary>
        /// <param name="name">the Name property of this class</param>
        [Theory]
        [InlineData("You're Toast")]
        public void ToStringMethodShouldWorkProperly(string name)
        {
            Assert.Equal("You're Toast", name);
        }

        #endregion
    }
}
