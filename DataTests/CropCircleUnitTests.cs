using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the CropCircle class
    /// </summary>
    public class CropCircleUnitTests
    {

        #region default values

        /// <summary>
        /// Checks that an unaltered Crop Circle is served with berries 
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            CropCircle cc = new();
            Assert.True(cc.Berries);
        }


        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the CropCircle's state mutates, the name does not change
        /// </summary>
        /// <param name="berries">If the Crop Circle will be served with berries</param>
        /// <remarks>There are only 2 possible permutations of state, so we pick this set to test against</remarks>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeCrashedSaucer(bool berries)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            Assert.Equal("Crop Circle", cc.Name);
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="berries">If the Crashed Saucer will be served with butter</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(true, 158 + 89)]
        [InlineData(false, 158)]
        public void CaloriesShouldBeCorrect(bool berries, uint calories)
        {
            CropCircle cc = new()
            {
                Berries = berries
            };
            Assert.Equal(calories, cc.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crashed Saucer
        /// </summary>
        /// <param name="berries">If served with butter</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "Hold Berries" })]
        public void SpecialInstructionsRelfectsState(bool berries, string[] instructions)
        {
            CropCircle cc = new()
            {
                Berries = berries,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cc.SpecialInstructions);
            }
            // Check that no unexpected special instructions exist
            Assert.Equal(instructions.Length, cc.SpecialInstructions.Count());
        }

        #endregion 
    }

}

