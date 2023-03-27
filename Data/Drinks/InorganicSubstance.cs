using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.BaseClasses;
using TheFlyingSaucer.Data.Enumerations;

namespace TheFlyingSaucer.Data.Drinks
{
    /// <summary>
    /// A class representing the Inorganic Substance drink
    /// </summary>
    public class InorganicSubstance : Drink
    {


        /// <summary>
        /// The name of the Inorganic Substance instance
        /// </summary>
        public override string Name
        {
            get
            {
                if (Size == ServingSize.Medium) return "Medium Inorganic Substance";
                if (Size == ServingSize.Large) return "Large Inorganic Substance";
                return "Inorganic Substance";
            }
        }

        /// <summary>
        /// The description of the Inorganic Substance instance
        /// </summary>
        public override string Description { get; } = "A cold glass of ice water.";

        /// <summary>
        /// A private backing field for the Size property
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// The serving size of the Inorganic Substance instance
        /// </summary>
        public override ServingSize Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// A private backing field for the Ice property
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// If the Inorganic Substance has ice
        /// </summary>
        public bool Ice
        {
            get { return _ice; }
            set 
            {
                _ice = value;
                OnPropertyChanged(nameof(Ice));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the Inorganic Substance instance
        /// </summary>
        public override decimal Price { get; } = 0m;

        /// <summary>
        /// The amount of calories in the Inorganic Substance instance
        /// </summary>
        public override uint Calories { get; } = 0u;

        /// <summary>
        /// Special instructions for the preparation of this Inorganic Substance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!Ice) instructions.Add("No Ice");
                return instructions;
            }
        }
    }
}
