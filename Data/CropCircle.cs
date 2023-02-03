using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    public class CropCircle
    {
        public string Name { get; } = "Crop Circle";

        public string Description { get; } = "Oatmeal topped with mixed berries.";

        public bool Berries { get; set; } = true;

        public decimal Price { get; } = 2.00m;

        public uint Calories 
        {
            get
            {
                uint calories = 158;
                if (Berries) calories += 89;
                return calories;
            }

            
        }

        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }
    }
}
