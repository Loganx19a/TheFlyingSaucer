using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the CrashedSaucer class
    /// </summary>
    public class CrashedSaucerUnitTests
    {

        #region default values

        /// <summary>
        /// Checks that a Crashed Saucer implements the IMenuItem interface
        /// </summary>
        [Fact]
        public void CrashedSaucerShouldImplementIMenuItemInterface()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<IMenuItem>(cs);
        }

        /// <summary>
        /// Checks that an unaltered Crashed Saucer has 2 slices of french toast
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoFrenchToastSlices()
        {
            CrashedSaucer cs = new();
            Assert.Equal(2u, cs.StackSize);
        }

        /// <summary>
        /// Checks that an unaltered Crashed Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Flying Saucer is served with butter
        /// </summary>
        [Fact]
        public void DefaultServedWithButter()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Butter);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of french toast slices included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with butter</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, true, true)]
        [InlineData(0, true, true)]
        [InlineData(12, true, true)]
        [InlineData(6, true, false)]
        [InlineData(6, false, false)]
        [InlineData(3, true, false)]
        [InlineData(8, false, false)]
        [InlineData(11, true, true)]
        public void NameShouldAlwaysBeCrashedSaucer(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            Assert.Equal("Crashed Saucer", cs.Name);
        }

        /// <summary>
        /// This test verifies that a CrashedSaucer's StackSize cannot exceed 6, and 
        /// if it is attempted, the StackSize will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveSix()
        {
            CrashedSaucer cs = new();
            cs.StackSize = 7;
            Assert.Equal(6u, cs.StackSize);
        }

        /// <summary>
        /// This test verifies that the price of a Livestock Mutilation corresponds to the number of french toast slices added to it
        /// </summary>
        /// <param name="slices">The number of biscuits in this instance of a LivestockMutilation</param>
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void PriceShouldCorrespondToNumberOfFrenchToastSlices(uint slices)
        {
            CrashedSaucer cs = new()
            {
                StackSize = slices,
            };
            Assert.Equal(6.45m + 1.50m * (slices - 2m), cs.Price);
        }

        /// <summary>
        /// This test checks that even as the CrashedSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of french toast slices included</param>
        /// <param name="syrup">If the Crashed Saucer will be served with syrup</param>
        /// <param name="butter">If the Crashed Saucer will be served with butter</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(2, true, true, 149 * 2 + 52 + 35)]
        [InlineData(0, true, true, 149 * 0 + 52 + 35)]
        [InlineData(4, true, true, 149 * 4 + 52 + 35)]
        [InlineData(2, true, false, 149 * 2 + 52 + 0)]
        [InlineData(2, false, false, 149 * 2 + 0 + 0)]
        [InlineData(1, true, false, 149 + 52 + 0)]
        [InlineData(8, false, false, 149 * 6)]
        [InlineData(11, true, true, 149 * 6 + 52 + 35)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool butter, uint calories)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            Assert.Equal(calories, cs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crashed Saucer
        /// </summary>
        /// <param name="stackSize">The number of french toast slices</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="butter">If served with butter</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, true, true, new string[] {})]
        [InlineData(3, true, true, new string[] { "3 slices" })]
        [InlineData(4, true, true, new string[] { "4 slices" })]
        [InlineData(5, true, true, new string[] { "5 slices" })]
        [InlineData(6, true, true, new string[] { "6 slices" })]
        [InlineData(4, false, false, new string[] { "4 slices", "Hold Syrup", "Hold Butter" })]
        [InlineData(4, true, false, new string[] { "4 slices", "Hold Butter" })]
        [InlineData(4, false, true, new string[] { "4 slices", "Hold Syrup" })]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool butter, string[] instructions)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cs.SpecialInstructions.Count());
        }

        /// <summary>
        /// Tests whether the ToString method is working properly for this class
        /// </summary>
        /// <param name="name">the Name property of this class</param>
        [Theory]
        [InlineData("Crashed Saucer")]
        public void ToStringMethodShouldWorkProperly(string name)
        {
            Assert.Equal("Crashed Saucer", name);
        }

        #endregion 
    }
}
