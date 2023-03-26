﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.Enumerations;

namespace TheFlyingSaucer.Data.BaseClasses
{
    /// <summary>
    /// The abstract base class representing a blueprint for an Drink menu item
    /// </summary>
    public abstract class Drink : IMenuItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the Drink instance
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the Drink instance
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The price of the Drink instance
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The size of the Drink instance
        /// </summary>
        public abstract ServingSize Size { get; set; }

        /// <summary>
        /// The amount of calories in the Drink instance
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for the preparation of this Drink
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
