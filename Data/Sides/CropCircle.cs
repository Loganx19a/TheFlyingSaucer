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
    /// The class representing the blueprint for a CropCircle object 
    /// </summary>
    public class CropCircle : Side
    {
        /// <summary>
        /// The name of the CropCircle instance
        /// </summary>
        public override string Name { get; } = "Crop Circle";

        /// <summary>
        /// The description of the CrashedSaucer instance
        /// </summary>
        public override string Description { get; } = "Oatmeal topped with mixed berries.";

        /// <summary>
        /// A private backing field 
        /// </summary>
        private bool _berries = true;

        /// <summary>
        /// If the CropCircle instance is served with Berries
        /// </summary>
        public bool Berries
        {
            get { return _berries; }
            set
            {
                _berries = value;
                OnPropertyChanged(nameof(Berries));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the CropCircle instance
        /// </summary>
        public override decimal Price { get; } = 2.00m;

        /// <summary>
        /// The calories of the CropCircle instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 158;
                if (Berries) calories += 89;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this CropCircle
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
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
