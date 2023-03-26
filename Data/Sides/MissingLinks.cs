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
    /// The class representing the blueprint for a MissingLinks object
    /// </summary>
    public class MissingLinks : Side
    {
        /// <summary>
        /// The name of the MissingLinks instance
        /// </summary>
        public override string Name { get; } = "Missing Links";

        /// <summary>
        /// The description of the MissingLinks instance
        /// </summary>
        public override string Description { get; } = "Sizzling pork sausage links.";

        /// <summary>
        /// A private backing field for the Count property
        /// </summary>
        private uint _count = 2;


        /// <summary>
        /// The default number of links in the MissingLinks instance
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value <= 8 && value >= 1)
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
                else if (value > 8)
                {
                    _count = 8;
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
        /// The price of the MissingLinks instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                return 1.00m * Count;
            }
        }

        /// <summary>
        /// The calories in the MissingLinks instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 391u * Count;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparations of this MissingLinks 
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
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
