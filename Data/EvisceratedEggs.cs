using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// The class representing the blueprint for an EvisceratedEggs object
    /// </summary>
    public class EvisceratedEggs
    {
        /// <summary>
        /// The name of the EvisceratedEggs instance
        /// </summary>
        public string Name { get; } = "Eviscerated Eggs";

        /// <summary>
        /// The description of the EvisceratedEggs instance
        /// </summary>
        public string Description { get; } = "Eggs prepared the way you like.";

        /// <summary>
        /// The style of how the EvisceratedEggs instance is cooked
        /// </summary>
        public EggStyle Style { get; set; } = EggStyle.OverEasy;

        /// <summary>
        /// A private backing field for the Count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// The default number of eggs in the EvisceratedEggs instance
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value <= 6)
                {
                    _count = value;
                }
                else
                {
                    _count = 6;
                }
            }
        }

        /// <summary>
        /// The price of the EvisceratedEggs instance
        /// </summary>
        public decimal Price
        {
            get
            {
                return 1.00m * Count;
            }
        }

        /// <summary>
        /// The calories in an EvisceratedEggs instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class
        /// </remarks>
        public uint Calories
        {
            get
            {
                uint calories = 78u * Count;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this EvisceratedEggs
        /// </summary>
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
