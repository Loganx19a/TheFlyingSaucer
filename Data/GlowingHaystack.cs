using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    public class GlowingHaystack
    {
        public string Name { get; } = "Glowing Haystack";

        public string Description { get; } = "Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.";

        public bool SourCream { get; set; } = true;

        public bool GreenChileSauce { get; set; } = true;

        public bool Tomatoes { get; set; } = true;

        public decimal Price { get; } = 2.00m;

        public uint Calories
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

        public IEnumerable<string> SpecialInstructions
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
