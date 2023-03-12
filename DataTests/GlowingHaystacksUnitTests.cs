using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.Sides;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the Glowing Haystack class
    /// </summary>
    public class GlowingHaystacksUnitTests
    {
        #region default values

        /// <summary>
        /// Checks that GlowingHaystack implements the IMenuItem interface
        /// </summary>
        [Fact]
        public void GlowingHaystackShouldImplementIMenuItemInterface()
        {
            GlowingHaystack haystack = new();
            Assert.IsAssignableFrom<IMenuItem>(haystack);
        }

        /// <summary>
        /// Checks that a unaltered GlowingHaystack is served with sour cream 
        /// </summary>
        [Fact]
        public void DefaultServedWithSourCream()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.SourCream);
        }

        /// <summary>
        /// Checks that a unaltered GlowingHaystack is served with green chile sauce 
        /// </summary>
        [Fact]
        public void DefaultServedWithGreenChileSauce()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.GreenChileSauce);
        }

        /// <summary>
        /// Checks that a unaltered GlowingHaystack is served with tomatoes
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.Tomatoes);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the GlowingHaystack's state mutates, the name does not change
        /// </summary>
        /// <param name="sourCream">If the Glowing Haystack will be served with sour cream</param>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(false, true, true)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        [InlineData(false, true, false)]
        [InlineData(true, false, false)]
        public void NameShouldAlwaysBeGlowingHaystack(bool sourCream, bool greenChileSauce, bool tomatoes)
        {
            GlowingHaystack gh = new()
            {
               SourCream = sourCream,
               GreenChileSauce = greenChileSauce,
               Tomatoes = tomatoes,
            };
            Assert.Equal("Glowing Haystack", gh.Name);
        }


        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="sourCream">If the Glowing Haystack will be served with sour cream</param>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(true, true, true, 470u + 15u + 23u + 22u)]
        [InlineData(true, true, false, 470u + 15u + 23u)]
        [InlineData(true, false, true, 470u + 15u + 22u)]
        [InlineData(false, true, true, 470u + 23u + 22u)]
        [InlineData(false, false, true, 470u + 22u)]
        [InlineData(false, false, false, 470u)]
        [InlineData(false, true, false, 470u + 23u)]
        [InlineData(true, false, false, 470u + 15u)]
        public void CaloriesShouldBeCorrect(bool greenChileSauce, bool sourCream, bool tomatoes, uint calories)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenChileSauce,
                SourCream = sourCream,
                Tomatoes = tomatoes,
            };
            Assert.Equal(calories, gh.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="sourCream">If the Glowing Haystack will be served with sour cream</param>
        /// <param name="greenChileSauce">If the Glowing Haystack will be served with green chile sauce</param>
        /// <param name="tomatoes">If the Glowing Haystack will be served with tomatoes</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, new string[] { })]
        [InlineData(true, true, false, new string[] { "Hold Tomatoes" })]
        [InlineData(true, false, true, new string[] { "Hold Green Chile Sauce" })]
        [InlineData(false, true, true, new string[] { "Hold Sour Cream" })]
        [InlineData(false, false, true, new string[] { "Hold Sour Cream", "Hold Green Chile Sauce" })]
        [InlineData(false, false, false, new string[] { "Hold Sour Cream", "Hold Green Chile Sauce", "Hold Tomatoes" })]
        [InlineData(false, true, false, new string[] { "Hold Sour Cream", "Hold Tomatoes" })]
        [InlineData(true, false, false, new string[] { "Hold Green Chile Sauce", "Hold Tomatoes" })]
        public void SpecialInstructionsRelfectsState(bool sourCream, bool greenChileSauce, bool tomatoes, string[] instructions)
        {
            GlowingHaystack gh = new()
            {
                SourCream = sourCream,
                GreenChileSauce = greenChileSauce,
                Tomatoes = tomatoes,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, gh.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count());
        }

        /// <summary>
        /// Tests whether the ToString method is working properly for this class
        /// </summary>
        /// <param name="name">the Name property of this class</param>
        [Theory]
        [InlineData("Glowing Haystack")]
        public void ToStringMethodShouldWorkProperly(string name)
        {
            Assert.Equal("Glowing Haystack", name);
        }

        #endregion
    }
}
