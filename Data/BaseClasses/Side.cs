using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.BaseClasses
{
    /// <summary>
    /// The abstract base class representing a blueprint for an Entree menu item
    /// </summary>
    public abstract class Side : IMenuItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the Side instance
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the Side instance
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The price of the Side instance
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The amount of calories in the Side instance
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for the preparation of this Side
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
