using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    public class YouAreToast
    {
        public string Name { get; }

        public string Description { get; }

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
                uint calories = 100u * Count;
                return calories;
            }
        }

        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add(Count + " slices");
                return instructions;
            }
        }
    }
}
