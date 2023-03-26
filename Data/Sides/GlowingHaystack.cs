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
    /// The class representing the blueprint for a GlowingHaystack object
    /// </summary>
    public class GlowingHaystack : Side
    {
        /// <summary>
        /// The name of the GlowingHaystack instance
        /// </summary>
        public override string Name { get; } = "Glowing Haystack";

        /// <summary>
        /// The description of the GlowingHaystack instance
        /// </summary>
        public override string Description { get; } = "Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.";

        /// <summary>
        /// A private backing field for the SourCream property
        /// </summary>
        private bool _sourCream = true;

        /// <summary>
        /// If the GlowingHaystack instance has sour cream
        /// </summary>
        public bool SourCream
        {
            get { return _sourCream; }
            set 
            { 
                _sourCream = value;
                OnPropertyChanged(nameof(SourCream));
                OnPropertyChanged(nameof(Calories));
                if (_sourCream == false) OnPropertyChanged(nameof(SpecialInstructions));

            }
        }

        /// <summary>
        /// A private backing field for the GreenChileSauce property
        /// </summary>
        private bool _greenChileSauce = true;

        /// <summary>
        /// If the GlowingHaystack instance has green chile sauce
        /// </summary>
        public bool GreenChileSauce
        {
            get { return _greenChileSauce; }
            set 
            { 
                _greenChileSauce = value;
                OnPropertyChanged(nameof(GreenChileSauce));
                OnPropertyChanged(nameof(Calories));
                if (_greenChileSauce == false) OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// A private backing field for the Tomatoes property
        /// </summary>
        private bool _tomatoes = true;

        /// <summary>
        /// If the GlowingHaystack instance has tomatoes
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
        /// The price of the GlowingHaystack instance
        /// </summary>
        public override decimal Price { get; } = 2.00m;

        /// <summary>
        /// The calories of the GlowingHaystack instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 470u;
                if (GreenChileSauce) calories += 15u;
                if (SourCream) calories += 23u;
                if (Tomatoes) calories += 22u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this GlowingHaystack
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (!GreenChileSauce) instructions.Add("Hold Green Chile Sauce");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                return instructions;
            }
        }
    }
}
