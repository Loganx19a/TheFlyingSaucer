using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    public class TakenBacon
    {
        public string Name { get; } = "Taken Bacon";

        public string Description { get; } = "Crispy strips of bacon";

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
                uint calories = 43u * Count;
                return calories;
            }
        }

        public IEnumerable<string> SpecialInstruction 
        { 
            get
            {
                List<string> instructions = new();

                if (Count != 2) instructions.Add(Count + " strips");
                return instructions;
            }
        }
        
    }
}
