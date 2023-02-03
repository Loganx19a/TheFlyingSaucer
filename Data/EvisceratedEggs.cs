using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    public class EvisceratedEggs
    {
        public string Name { get; } = "Eviscerated Eggs";

        public string Description { get; } = "Eggs prepared the way you like.";

        public EggStyle Style { get; set; } = EggStyle.OverEasy;

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
                uint calories = 78u * Count;
                return calories;
            }
        }

        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Style == EggStyle.OverEasy) instructions.Add("Over Easy");
                if (Count != 2) instructions.Add(Count + " eggs");
                return instructions;
            }
        }
    }
}
