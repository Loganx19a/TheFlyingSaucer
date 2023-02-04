﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// The class representing the blueprint for a TakenBacon object
    /// </summary>
    public class TakenBacon
    {
        /// <summary>
        /// The name of the TakenBacon instance
        /// </summary>
        public string Name { get; } = "Taken Bacon";

        /// <summary>
        /// The description of the TakenBacon instance
        /// </summary>
        public string Description { get; } = "Crispy strips of bacon";

        /// <summary>
        /// The default number of bacon strips in the TakenBacon instance
        /// </summary>
        public uint Count { get; set; } = 2;

        /// <summary>
        /// The price of the TakenBacon instance
        /// </summary>
        public decimal Price
        {
            get
            {
                return 1.00m * Count;
            }
        }

        /// <summary>
        /// The calories of the TakenBacon instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class
        /// </remarks>
        public uint Calories 
        {
            get
            {
                uint calories = 43u * Count;
                return calories;
            }
        }

        /// <summary>
        /// Special instructinos for the preparation of this TakenBacon
        /// </summary>
        public IEnumerable<string> SpecialInstruction 
        { 
            get
            {
                List<string> instructions = new();

                if (Count != 2) instructions.Add(Count + " strips");
                return instructions;
            }
        }
        
    }
}
