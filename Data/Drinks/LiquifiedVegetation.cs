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
    /// A class representing the Liquified Vegetation drink
    /// </summary>
    public class LiquifiedVegetation : Drink
    {
        /// <summary>
        /// The name of the Liquified Vegetation instance
        /// </summary>
        public override string Name
        {
            get
            {
                if (Size == ServingSize.Medium) return "Medium Liquified Vegetation";
                if (Size == ServingSize.Large) return "Large Liquified Vegetation";
                return "Liquified Vegetation";
            }
        }

        /// <summary>
        /// The description of the Liquified Vegetation instance
        /// </summary>
        public override string Description { get; } = "A cold glass of blended vegetable juice.";

        /// <summary>
        /// A private backing field for the Size property
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// The serving size of the Liquified Vegetation instance
        /// </summary>
        public override ServingSize Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
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
        /// The price of the Liquified Vegetation instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Size == ServingSize.Small)
                    return 1.00m;
                else if (Size == ServingSize.Medium)
                    return 1.50m;
                else
                    return 2.00m;
            }
        }

        /// <summary>
        /// The amount of calories in the Liquified Vegetation instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == ServingSize.Small)
                    return 72u;
                else if (Size == ServingSize.Medium)
                    return 144u;
                else
                    return 216u;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Liquified Vegetation
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Ice == false) instructions.Add("No Ice");
                return instructions;
            }
        }
    }
}
