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
    /// A class representing the Saucer Fuel drink
    /// </summary>
    public class SaucerFuel : Drink
    {
        /// <summary>
        /// The name of the Saucer Fuel instance
        /// </summary>
        public override string Name
        {
            get
            {
                if (Decaf == true && Size == ServingSize.Small) return "Decaf Saucer Fuel";

                if (Size == ServingSize.Medium && Decaf == true) return "Medium Decaf Saucer Fuel";
                if (Size == ServingSize.Medium && Decaf == false) return "Medium Saucer Fuel";
                if (Size == ServingSize.Large && Decaf == true) return "Large Decaf Saucer Fuel";
                if (Size == ServingSize.Large && Decaf == false) return "Large Saucer Fuel";
                return "Saucer Fuel";
            }
        }

        /// <summary>
        /// The description of the Saucer Fuel instance
        /// </summary>
        public override string Description { get; } = "A steaming cup of coffee.";

        /// <summary>
        /// A private backing field for the Size property
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// The serving size of the Saucer Fuel instance
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
        /// A private backing field for the Decaf property
        /// </summary>
        private bool _decaf = false;

        /// <summary>
        /// If the Saucer Fuel is decaf
        /// </summary>
        public bool Decaf
        {
            get { return _decaf; }
            set 
            {
                _decaf = value;
                OnPropertyChanged(nameof(Decaf));
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// A private backing field for the Cream property
        /// </summary>
        private bool _cream = false;

        /// <summary>
        /// If the Saucer Fuel has cream
        /// </summary>
        public bool Cream
        {
            get { return _cream; }
            set 
            {
                _cream = value;
                OnPropertyChanged(nameof(Cream));
                OnPropertyChanged(nameof(Calories));
            }
        }

        /// <summary>
        /// The price of the Saucer Fuel instance
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
        /// The amount of calories in this Saucer Fuel instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == ServingSize.Small)
                {
                    if (Cream)
                        return 1u + 29u;
                    else
                        return 1u;
                }

                else if (Size == ServingSize.Medium)
                {
                    if (Cream)
                        return 2u + 29u;
                    else
                        return 2u;
                }
                else
                {
                    if (Cream)
                        return 3u + 29u;
                    else
                        return 3u;
                }
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this Saucer Fuel
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Cream) instructions.Add("With Cream");
                return instructions;
            }
        }
    }


}
