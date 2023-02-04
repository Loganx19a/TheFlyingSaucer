﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// The class representing the blueprint for the YouAreToast object
    /// </summary>
    public class YouAreToast
    {
        /// <summary>
        /// The name for the YouAreToast instance
        /// </summary>
        public string Name { get; } = "You're Toast";

        /// <summary>
        /// The description for the YouAreToast instance
        /// </summary>
        public string Description { get; } = "Texas toast.";

        /// <summary>
        /// The default number of toast slices in the YouAreToast instance
        /// </summary>
        public uint Count { get; set; } = 2;

        /// <summary>
        /// The price of the YouAreToast instance
        /// </summary>
        public decimal Price
        {
            get
            {
                return 1.00m * Count;
            }
        }

        /// <summary>
        /// The calories in the YouAreToast instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class
        /// </remarks>
        public uint Calories
        {
            get
            {
                uint calories = 100u * Count;
                return calories;
            }
        }

        /// <summary>
        /// Special instractions for the preparation of this YouAreToast
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count != 2) instructions.Add(Count + " slices");
                return instructions;
            }
        }
    }
}