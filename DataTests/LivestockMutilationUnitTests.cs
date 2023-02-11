using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the LiveStockMutilation tests
    /// </summary>
    public class LivestockMutilationUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered LivestockMutilation has 3 biscuits
        /// </summary>
        [Fact]
        public void DefaultNumberOfBiscuitsShouldBeThree()
        {
            LivestockMutilation lm = new();
            Assert.Equal(3u, lm.Biscuits);
        }

        /// <summary>
        /// Checks that a unaltered LivestockMutilation is served with gravy 
        /// </summary>
        [Fact]
        public void DefaultServedWithGravy()
        {
            LivestockMutilation lm = new();
            Assert.True(lm.Gravy);
        }


        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeLivestockMutilation(bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Gravy = gravy,
            };
            Assert.Equal("Livestock Mutilation", lm.Name);
        }

        /// <summary>
        /// This test verifies that a Livestock Mutilation's number of biscuits cannot exceed 8, and 
        /// if it is attempted, the number of biscuits will be set to 8.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetNumberOfBiscuitsAboveEight()
        {
            LivestockMutilation lm = new();
            lm.Biscuits = 9;
            Assert.Equal(8u, lm.Biscuits);
        }

        /// <summary>
        /// This test verifies that the price of a Livestock Mutilation corresponds to the number of biscuits added to it
        /// </summary>
        /// <param name="biscuits">The number of biscuits in this instance of a LivestockMutilation</param>
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void PriceShouldCorrespondToNumberOfBiscuits(uint biscuits)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
            };
            Assert.Equal(7.25m + 1.00m * (biscuits - 3), lm.Price);
        }

        /// <summary>
        /// This test checks that even as the Livestock Mutilation's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with gravy</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(3, true, 49 * 3 + 140)]
        [InlineData(4, true, 49 * 4 + 140)]
        [InlineData(5, true, 49 * 5 + 140)]
        [InlineData(6, false, 49 * 6)]
        [InlineData(7, false, 49 * 7)]
        [InlineData(8, false, 49 * 8)]
        [InlineData(3, false, 49 * 3)]
        [InlineData(8, true, 49 * 8 + 140)]
        public void CaloriesShouldBeCorrect(uint biscuits, bool gravy, uint calories)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy,
            };
            Assert.Equal(calories, lm.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="biscuits">If served with whipped cream</param>
        /// <param name="gravy">If served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, true, new string[] { "6 Biscuits", })]
        [InlineData(3, false, new string[] { "Hold Gravy" })]
        [InlineData(4, false, new string[] { "4 Biscuits", "Hold Gravy" })]
        [InlineData(5, false, new string[] { "5 Biscuits", "Hold Gravy" })]
        [InlineData(7, false, new string[] { "7 Biscuits", "Hold Gravy" })]
        [InlineData(8, false, new string[] { "8 Biscuits", "Hold Gravy" })]
        public void SpecialInstructionsRelfectsState(uint biscuits, bool gravy, string[] instructions)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lm.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lm.SpecialInstructions.Count());
        }

        #endregion
    }
}
