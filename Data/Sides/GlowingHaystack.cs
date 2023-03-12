using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// The class representing the blueprint for a GlowingHaystack object
    /// </summary>
    public class GlowingHaystack : Side
    {
        /// <summary>
        /// The name of the GlowingHaystack instance
        /// </summary>
        public override string Name { get; } = "Glowing Haystack";

        /// <summary>
        /// The description of the GlowingHaystack instance
        /// </summary>
        public override string Description { get; } = "Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.";

        /// <summary>
        /// If the GlowingHaystack instance has sour cream
        /// </summary>
        public bool SourCream { get; set; } = true;

        /// <summary>
        /// If the GlowingHaystack instance has green chile sauce
        /// </summary>
        public bool GreenChileSauce { get; set; } = true;

        /// <summary>
        /// If the GlowingHaystack instance has tomatoes
        /// </summary>
        public bool Tomatoes { get; set; } = true;

        /// <summary>
        /// The price of the GlowingHaystack instance
        /// </summary>
        public override decimal Price { get; } = 2.00m;

        /// <summary>
        /// The calories of the GlowingHaystack instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 470u;
                if (GreenChileSauce) calories += 15u;
                if (SourCream) calories += 23u;
                if (Tomatoes) calories += 22u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this GlowingHaystack
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (!GreenChileSauce) instructions.Add("Hold Green Chile Sauce");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                return instructions;
            }
        }
    }
}
