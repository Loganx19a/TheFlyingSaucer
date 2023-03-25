using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.Drinks
{
    /// <summary>
    /// A class representing the Inorganic Substance drink
    /// </summary>
    public class InorganicSubstance : Drink, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the Inorganic Substance instance
        /// </summary>
        public override string Name { get; } = "Inorganic Substance";

        /// <summary>
        /// The description of the Inorganic Substance instance
        /// </summary>
        public override string Description { get; } = "A cold glass of ice water.";

        /// <summary>
        /// The serving size of the Inorganic Substance instance
        /// </summary>
        public override ServingSize Size { get; set; } = ServingSize.Small;

        /// <summary>
        /// If the Inorganic Substance has ice
        /// </summary>
        public bool Ice { get; set; } = true;

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
                if (!Ice)
                    instructions.Add("No Ice");
                return instructions;
            }
        }
    }
}
