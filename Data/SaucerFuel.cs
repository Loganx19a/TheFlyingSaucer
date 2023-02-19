using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
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
                if (Decaf == true)
                    return "Decaf Saucer Fuel";
                else
                    return "Saucer Fuel";
            }
        }

        /// <summary>
        /// The description of the Saucer Fuel instance
        /// </summary>
        public override string Description { get; } = "A steaming cup of coffee.";

        /// <summary>
        /// The serving size of the Saucer Fuel instance
        /// </summary>
        public override ServingSize Size { get; set; } = ServingSize.Small;

        /// <summary>
        /// If the Saucer Fuel is decaf
        /// </summary>
        public bool Decaf { get; set; } = false;

        /// <summary>
        /// If the Saucer Fuel has cream
        /// </summary>
        public bool Cream { get; set; } = false;

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
                if (Cream)
                    instructions.Add("With Cream");
                return instructions;
            }
        }
    }


}
