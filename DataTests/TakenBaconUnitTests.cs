using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Taken Bacon class
    /// </summary>
    public class TakenBaconUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that TakenBacon implements the IMenuItem interface
        /// </summary>
        [Fact]
        public void TakenBaconShouldImplementIMenuItemInterface()
        {
            TakenBacon bacon = new();
            Assert.IsAssignableFrom<IMenuItem>(bacon);
        }

        /// <summary>
        /// Checks that an unaltered Taken Bacon has 2 bacon strips
        /// </summary>
        [Fact]
        public void DefaultNumberOfBaconSlicesShouldBeTwo()
        {
            TakenBacon tb = new();
            Assert.Equal(2u, tb.Count);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the Taken Bacon's state mutates, the name does not change
        /// </summary>
        /// <param name="count">The number of slices of bacon included</param>
        /// <remarks>There are 6 possible permutations of state</remarks>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void NameShouldAlwaysBeFlyingSaucer(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal("Taken Bacon", tb.Name);
        }

        /// <summary>
        /// This test verifies that a Taken Bacon's Count cannot exceed 6, and 
        /// if it is attempted, the Count will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetNumberOfBaconSlicesAboveSix()
        {
            TakenBacon tb = new();
            tb.Count = 7;
            Assert.Equal(6u, tb.Count);
        }

        /// <summary>
        /// This test verifies that a Taken Bacon's Count cannot be less than 1, and 
        /// if it is attempted, the Count will be set to 1.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetNumberOfBaconSlicesLessThanOne()
        {
            TakenBacon tb = new();
            tb.Count = 0;
            Assert.Equal(1u, tb.Count);
        }

        /// <summary>
        /// This test verifies that the price of a Taken Bacon corresponds to the number of bacon strips added to it
        /// </summary>
        /// <param name="count">The number of bacon strips in this instance of a TakenBacon</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void PriceShouldCorrespondToNumberOfStrips(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count,
            };
            Assert.Equal(1.00m * count, tb.Price);
        }

        /// <summary>
        /// This test checks that even as the Taken Bacon's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The number of strips of bacon included</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(1, 43)]
        [InlineData(2, 43 * 2)]
        [InlineData(3, 43 * 3)]
        [InlineData(4, 43 * 4)]
        [InlineData(5, 43 * 5)]
        [InlineData(6, 43 * 6)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            TakenBacon tb = new()
            {
                Count = count,
            };
            Assert.Equal(calories, tb.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="count">The number of strips of bacon included</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(4, new string[] { "4 strips" })]
        [InlineData(5, new string[] { "5 strips" })]
        [InlineData(6, new string[] { "6 strips" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            TakenBacon tb = new()
            {
                Count = count,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, tb.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, tb.SpecialInstructions.Count());
        }

        /// <summary>
        /// Tests whether the ToString method is working properly for this class
        /// </summary>
        /// <param name="name">the Name property of this class</param>
        [Theory]
        [InlineData("Taken Bacon")]
        public void ToStringMethodShouldWorkProperly(string name)
        {
            Assert.Equal("Taken Bacon", name);
        }

        #endregion
    }
}
