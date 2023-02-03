using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    public class OuterOmlette
    {
        public string Name { get; } = "Outer Omlette";

        public string Description { get; } = "A fully loaded Omlette.";

        public bool CheddarCheese { get; set; } = true;

        public bool Peppers { get; set; } = true;

        public bool Mushrooms { get; set; } = true;

        public bool Tomatoes { get; set; } = true;

        public bool Onions { get; set; } = true;

        public decimal Price { get; } = 7.45m;

        public uint Calories 
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

        public IEnumerable<string> SpecialInstructions 
        {
            get
            {
                List<string> instructions = new();
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold mushrooms");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                if (!Onions) instructions.Add("Hold Onions");
                return instructions;
            }
        }





    }
}
