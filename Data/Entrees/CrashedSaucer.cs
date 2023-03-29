using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.BaseClasses;

namespace TheFlyingSaucer.Data.Entrees
{
    /// <summary>
    /// The class representing the blueprint for an CrashedSaucer object
    /// </summary>
    public class CrashedSaucer : Entree
    {
        /// <summary>
        /// The name of the CrashedSaucer instance
        /// </summary>
        public override string Name { get; } = "Crashed Saucer";

        /// <summary>
        /// The description of the CrashedSaucer instance
        /// </summary>
        public override string Description => "A stack of crispy french toast smothered in syrup and topped with a pat of butter";

        /// <summary>
        /// The private backing field for the StackSize property
        /// </summary>
        private uint _stackSize = 2;

        /// <summary>
        /// The number of French Toast slices in this instance of a CrashedSaucer
        /// </summary>
        /// <remarks>
        /// Note the set limits the stack size to a max of 6 slices
        /// </remarks>
        public uint StackSize
        {
            get
            {
                return _stackSize;
            }
            set
            {
                if (value <= 6)
                {
                    _stackSize = value;
                }
                else
                {
                    _stackSize = 6;
                }
                OnPropertyChanged(nameof(StackSize));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// A private backing field for the Syrup property
        /// </summary>
        private bool _syrup = true;

        /// <summary>
        /// If the CrashedSaucer instance is served with syrup
        /// </summary>
        public bool Syrup
        {
            get { return _syrup; }
            set
            {

                _syrup = value;
                OnPropertyChanged(nameof(Syrup));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));

            }
        }

        private bool _butter = true;

        /// <summary>
        /// If the CrashedSaucer instance is served with butter
        /// </summary>
        public bool Butter
        {
            get { return _butter; }
            set
            {

                _butter = value;
                OnPropertyChanged(nameof(Butter));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));

            }
        }

        /// <summary>
        /// The price of the CrashedSaucer instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (_stackSize > 2) return 6.45m + 1.50m * (_stackSize - 2);
                else return 6.45m;
            }
        }

        /// <summary>
        /// The amount of calories in the CrashedSaucer instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 149u * StackSize;
                if (Syrup) calories += 52;
                if (Butter) calories += 35;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this CrashedSaucer
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (StackSize != 2 && StackSize != 1) instructions.Add($"{StackSize} slices");
                if (StackSize == 1) instructions.Add($"{StackSize} slice");
                if (!Butter) instructions.Add("Hold Butter");
                if (!Syrup) instructions.Add("Hold Syrup");
                return instructions;
            }
        }

    }
}
