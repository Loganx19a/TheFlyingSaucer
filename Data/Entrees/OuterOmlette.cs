using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.BaseClasses;

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
        /// A private backing field for the CheddarCheese property
        /// </summary>
        private bool _cheddarCheese = true;

        /// <summary>
        /// If the OuterOmlette instance is served with cheddar cheese 
        /// </summary>
        public bool CheddarCheese
        {
            get { return _cheddarCheese; }
            set 
            { 
                _cheddarCheese = value;
                OnPropertyChanged(nameof(CheddarCheese));
                OnPropertyChanged(nameof(Calories));
                if (_cheddarCheese == false) OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// A private backing field for the Peppers property
        /// </summary>
        private bool _peppers = true;

        /// <summary>
        /// If the OuterOmlette instance is served with peppers
        /// </summary>
        public bool Peppers
        {
            get { return _peppers; }
            set 
            { 
                _peppers = value;
                OnPropertyChanged(nameof(Peppers));
                OnPropertyChanged(nameof(Calories));
                if (_peppers == false) OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// A private backing field for the Mushrooms property
        /// </summary>
        private bool _mushrooms = true;

        /// <summary>
        /// If the OuterOmlette instance is served with mushrooms
        /// </summary>
        public bool Mushrooms
        {
            get { return _mushrooms; }
            set 
            { 
                _mushrooms = value;
                OnPropertyChanged(nameof(Mushrooms));
                OnPropertyChanged(nameof(Calories));
                if (_mushrooms == false) OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// A private backing field for the Tomatoes property
        /// </summary>
        private bool _tomatoes = true;

        /// <summary>
        /// If the OuterOmlette instance is served with tomatoes
        /// </summary>
        public bool Tomatoes
        {
            get { return _tomatoes; }
            set 
            { 
                _tomatoes = value;
                OnPropertyChanged(nameof(Tomatoes));
                OnPropertyChanged(nameof(Calories));
                if (_tomatoes == false) OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// A private backing field for the Onion property
        /// </summary>
        private bool _onions = true;

        /// <summary>
        /// If the OuterOmlette instance is served with onions
        /// </summary>
        public bool Onions
        {
            get { return _onions; }
            set 
            {
                _onions = value;
                OnPropertyChanged(nameof(Onions));
                OnPropertyChanged(nameof(Calories));
                if (_onions == false) OnPropertyChanged(nameof(SpecialInstructions));
            }
        }


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
