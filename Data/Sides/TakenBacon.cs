using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.BaseClasses;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// The class representing the blueprint for a TakenBacon object
    /// </summary>
    public class TakenBacon : Side
    {
        /// <summary>
        /// The name of the TakenBacon instance
        /// </summary>
        public override string Name { get; } = "Taken Bacon";

        /// <summary>
        /// The description of the TakenBacon instance
        /// </summary>
        public override string Description { get; } = "Crispy strips of bacon";

        /// <summary>
        /// The private backing field for the count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// The default number of bacon strips in the TakenBacon instance
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value <= 6 && value >= 1)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Count));
                    OnPropertyChanged(nameof(Price));
                    if (_count != 2)
                    {
                        OnPropertyChanged(nameof(Calories));
                        OnPropertyChanged(nameof(SpecialInstructions));
                    }
                }
                else if (value > 6)
                {
                    _count = 6;
                    OnPropertyChanged(nameof(Count));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
                else
                {
                    _count = 1;
                    OnPropertyChanged(nameof(Count));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(Calories));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }
            }
        }


        /// <summary>
        /// The price of the TakenBacon instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                return 1.00m * Count;
            }
        }

        /// <summary>
        /// The calories of the TakenBacon instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 43u * Count;
                return calories;
            }
        }

        /// <summary>
        /// Special instructinos for the preparation of this TakenBacon
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (Count > 2) instructions.Add(Count + " strips");
                else if (Count == 1) instructions.Add(Count + " strip");
                return instructions;
            }
        }

    }
}
