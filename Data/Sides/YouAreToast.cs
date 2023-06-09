﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.BaseClasses;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// The class representing the blueprint for the YouAreToast object
    /// </summary>
    public class YouAreToast : Side
    {
        /// <summary>
        /// The name for the YouAreToast instance
        /// </summary>
        public override string Name { get; } = "You're Toast";

        /// <summary>
        /// The description for the YouAreToast instance
        /// </summary>
        public override string Description { get; } = "Texas toast.";

        /// <summary>
        /// A private backing field for the Count property
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// The default number of toast slices in the YouAreToast instance
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value <= 12 && value >= 1)
                {
                    _count = value;
                    
                }
                else if (value > 12)
                {
                    _count = 12;
                }
                else
                {
                    _count = 1;
                }
                OnPropertyChanged(nameof(Count));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The price of the YouAreToast instance
        /// </summary>
        public override decimal Price
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
        public override uint Calories
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
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (Count > 2) instructions.Add(Count + " slices");
                if (Count == 1) instructions.Add(Count + " slice");
                return instructions;
            }
        }
    }
}
