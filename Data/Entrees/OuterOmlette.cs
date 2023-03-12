using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.Entrees
{
    /// <summary>
    /// The class representing the blueprint for an OuterOmlette object
    /// </summary>
    public class OuterOmlette : Entree
    {
        /// <summary>
        /// The name of the CropCircle instance
        /// </summary>
        public override string Name { get; } = "Outer Omlette";

        /// <summary>
        /// The description of the CrashedSaucer instance
        /// </summary>
        public override string Description { get; } = "A fully loaded Omlette.";

        /// <summary>
        /// If the OuterOmlette instance is served with cheddar cheese 
        /// </summary>
        public bool CheddarCheese { get; set; } = true;

        /// <summary>
        /// If the OuterOmlette instance is served with peppers
        /// </summary>
        public bool Peppers { get; set; } = true;

        /// <summary>
        /// If the OuterOmlette instance is served with mushrooms
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// If the OuterOmlette instance is served with tomatoes
        /// </summary>
        public bool Tomatoes { get; set; } = true;

        /// <summary>
        /// If the OuterOmlette instance is served with onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// The price of the OuterOmlette instance
        /// </summary>
        public override decimal Price { get; } = 7.45m;

        /// <summary>
        /// The calories of the OuterOmlette instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 94u;
                if (CheddarCheese) calories += 113u;
                if (Peppers) calories += 24u;
                if (Mushrooms) calories += 4u;
                if (Tomatoes) calories += 22u;
                if (Onions) calories += 22u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this OuterOmlette
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                if (!Onions) instructions.Add("Hold Onions");
                return instructions;
            }
        }





    }
}
