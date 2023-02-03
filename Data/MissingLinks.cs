using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    public class MissingLinks
    {
        public string Name { get; } = "Missing Links";

        public string Description { get; } = "Sizzling pork sausage links.";

        public uint Count { get; set; } = 2;

        public decimal Price
        {
            get
            {
                return 1.00m * Count;
            }
        }

        public uint Calories
        {
            get
            {
                uint calories = 391u * Count;
                return calories;
            }
        }

        public IEnumerable<string> SpecialInstructions 
        {
            get
            {
                List<string> instructions = new();

                if (Count != 2) instructions.Add(Count + " links");
                return instructions;
            }
        }
    }
}
