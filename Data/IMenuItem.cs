using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// An interface for representing an item appearing on the menu
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// 
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<string> SpecialInstructions { get; }


    }
}
