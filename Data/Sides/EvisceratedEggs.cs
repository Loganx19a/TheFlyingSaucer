using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// The class representing the blueprint for an EvisceratedEggs object
    /// </summary>
    public class EvisceratedEggs : Side, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the EvisceratedEggs instance
        /// </summary>
        public override string Name { get; } = "Eviscerated Eggs";

        /// <summary>
        /// The description of the EvisceratedEggs instance
        /// </summary>
        public override string Description { get; } = "Eggs prepared the way you like.";

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
                if (value <= 6 && value >= 1)
                {
                    _count = value;
                }
                else if (value > 6)
                {
                    _count = 6;
                }
                else
                {
                    _count = 1;
                }
            }
        }

        /// <summary>
        /// The price of the EvisceratedEggs instance
        /// </summary>
        public override decimal Price
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
        public override uint Calories
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
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                //instructions.Add($"{Style}");

                switch (Style)
                {
                    case EggStyle.SoftBoiled:
                        instructions.Add("Soft Boiled");
                        break;
                    case EggStyle.HardBoiled:
                        instructions.Add("Hard Boiled");
                        break;
                    case EggStyle.Scrambled:
                        instructions.Add("Scrambled");
                        break;
                    case EggStyle.Poached:
                        instructions.Add("Poached");
                        break;
                    case EggStyle.SunnySideUp:
                        instructions.Add("Sunny Side Up");
                        break;
                    case EggStyle.OverEasy:
                        instructions.Add("Over Easy");
                        break;
                }

                if (Count > 2) instructions.Add(Count + " eggs");
                else if (Count == 1) instructions.Add(Count + " egg");
                return instructions;
            }
        }
    }
}
