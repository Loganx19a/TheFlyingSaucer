using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// The class representing the blueprint for a LivestockMutilation object
    /// </summary>
    public class LivestockMutilation : Entree
    {
        /// <summary>
        /// The name of the LivestockMutilation instance
        /// </summary>
        public override string Name { get; } = "Livestock Mutilation";

        /// <summary>
        /// The description of the LivestockMutilation instance
        /// </summary>
        public override string Description => "A hearty serving of biscuits, smothered in sausage-laden gravy";

        /// <summary>
        /// The private backing field for the Biscuits property
        /// </summary>
        private uint _numBiscuits = 3;

        /// <summary>
        /// The number of biscuits in this instance of a LivestockMutilation
        /// </summary>
        public uint Biscuits
        {
            get
            {
                return _numBiscuits;
            }
            set
            {
                if ( value <= 8 )
                {
                    _numBiscuits = value;
                }
                else
                {
                    _numBiscuits = 8;
                }
            }
        }

        /// <summary>
        /// If the LivestockMutilation is served with gravy
        /// </summary>
        public bool Gravy { get; set; } = true;

        /// <summary>
        /// The price of the LivestockMutilation instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (_numBiscuits > 3) return 7.25m + 1.00m * (_numBiscuits - 3);
                else return 7.25m;
            }
        }

        /// <summary>
        /// The amount of calories in the LivestockMutilation instance
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 49u * _numBiscuits;
                if (Gravy) calories += 140u;
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this LivestockMutilation 
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (_numBiscuits != 3) instructions.Add($"{_numBiscuits} Biscuits");
                if (!Gravy) instructions.Add("Hold Gravy");
                return instructions;
            }
        }
    }
}
