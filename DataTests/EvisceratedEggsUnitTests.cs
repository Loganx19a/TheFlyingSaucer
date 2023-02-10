using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the EvisceratedEggs class
    /// </summary>
    public class EvisceratedEggsUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Eviscerated Eggs has 2 eggs
        /// </summary>
        [Fact]
        public void DefaultNumberOfEggsInAnInstanceShouldBeTwoEggs()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(2, (decimal)ee.Count);
        }

        /// <summary>
        /// Checks that the default egg style is Over Easy
        /// </summary>
        [Fact]
        public void DefaultEggStyleShouldBeOverEasy()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(5, (decimal)ee.Style);
        }



        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the EvisceratedEgg's state mutates, the name does not change
        /// </summary>
        /// <param name="count">If the Flying Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, SoftBoiled)]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(2)]
        public void NameShouldAlwaysBeEvisceratedEggs(uint count, EggStyle style)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = style
            };
            Assert.Equal("Eviscerated Eggs", ee.Name);
        }

        /// <summary>
        /// This test verifies that an EvisceratedEgg's Count cannot exceed 6, and 
        /// if it is attempted, the Egg Count will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetEggNumberAboveSix()
        {
            EvisceratedEggs ee = new();
            ee.Count = 7;
            Assert.Equal(6, (decimal)ee.Count);
        }

        /// <summary>
        /// This test checks that even as the EvisceratedEgg's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(0, 78 * 0)]
        [InlineData(1, 78 * 1)]
        [InlineData(2, 78 * 2)]
        [InlineData(3, 78 * 3)]
        [InlineData(4, 78 * 4)]
        [InlineData(5, 78 * 5)]
        [InlineData(6, 78 * 6)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            Assert.Equal(calories, ee.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Eviscerated Eggs
        /// </summary>
        /// <param name="count">The number of eggs</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(4, new string[] { "4 eggs" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ee.SpecialInstructions);
            }
            // Check that no unexpected special instructions exist
            Assert.Equal(instructions.Length, ee.SpecialInstructions.Count());
        }

        #endregion

    }
}
