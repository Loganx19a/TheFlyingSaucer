using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.BaseClasses
{
    /// <summary>
    /// The abstract base class representing a blueprint for an Entree menu item
    /// </summary>
    public abstract class Entree : IMenuItem
    {
        /// <summary>
        /// The name of the Entree instance
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the Entree instance
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The price of the Entree instance
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The amount of calories in the Entree instance
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for the preparation of this Entree
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// Override for the ToString() method 
        /// </summary>
        /// <returns>the string version of the Name property</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
