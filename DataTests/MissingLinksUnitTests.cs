using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the MissingLinks class
    /// </summary>
    public class MissingLinksUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that MissingLinks implements the IMenuItem interface
        /// </summary>
        [Fact]
        public void MissingLinksShouldImplementIMenuItemInterface()
        {
            MissingLinks links = new();
            Assert.IsAssignableFrom<IMenuItem>(links);
        }

        /// <summary>
        /// Checks that an unaltered MissingLinks has 2 sausage links
        /// </summary>
        [Fact]
        public void DefaultNumberOfLinksShouldBeTwo()
        {
            MissingLinks ml = new();
            Assert.Equal(2u, ml.Count);
        }


        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the MissingLink's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of links included</param>
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
        public void NameShouldAlwaysBeMissingLinks(uint count)
        {
            MissingLinks ml = new()
            {
               Count = count
            };
            Assert.Equal("Missing Links", ml.Name);
        }

        /// <summary>
        /// This test verifies that a Missing Link's count cannot exceed 8, and 
        /// if it is attempted, the count will be set to 8.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetTheNumberOfLinksAboveEight()
        {
            MissingLinks ml = new();
            ml.Count = 9;
            Assert.Equal(8u, ml.Count);
        }

        /// <summary>
        /// This test verifies that a Missing Link's count cannot be below 1, and 
        /// if it is attempted, the count will be set to 1.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetTheNumberOfLinksBelowOne()
        {
            MissingLinks ml = new();
            ml.Count = 0;
            Assert.Equal(1u, ml.Count);
        }

        /// <summary>
        /// This test verifies that the price of a Missing Links corresponds to the number of sausage links added to it
        /// </summary>
        /// <param name="count">The number of sausage links in this instance of a LivestockMutilation</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void PriceShouldCorrespondToNumberOfLinks(uint count)
        {
            MissingLinks ml = new()
            {
                Count = count,
            };
            Assert.Equal(1.00m * count, ml.Price);
        }

        /// <summary>
        /// This test checks that even as the Missing Link's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of links included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(1, 391 * 1)]
        [InlineData(2, 391 * 2)]
        [InlineData(3, 391 * 3)]
        [InlineData(4, 391 * 4)]
        [InlineData(5, 391 * 5)]
        [InlineData(6, 391 * 6)]
        [InlineData(7, 391 * 7)]
        [InlineData(8, 391 * 8)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal(calories, ml.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="count">The number of panacakes</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(3, new string[] { "3 links" })]
        [InlineData(4, new string[] { "4 links" })]
        [InlineData(5, new string[] { "5 links" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ml.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ml.SpecialInstructions.Count());
        }

        #endregion

    }
}
