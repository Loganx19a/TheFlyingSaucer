using System.Collections.Specialized;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Entrees
{
    /// <summary>
    /// The class representing the blueprint for a FlyingSaucer object
    /// </summary>
    /// <remarks>
    /// this object must implement the INotifyPropertyChanged interface for changes in the data object to be automatically
    /// applied to the WPF control it's bound to
    /// </remarks>
    public class FlyingSaucer : Entree, INotifyPropertyChanged
    {
        // this object must implement the INotifyPropertyChanged interface for changes in the data object to be automatically
        // applied to the WPF control it's bound to
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The name of the FlyingSaucer instance
        /// </summary>
        /// <remarks>
        /// This is an example of a get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Flying Saucer";

        /// <summary>
        /// The description of the FlyingSaucer instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "A stack of six pancakes, smothered in rich maple syrup, and topped with mixed berries and whipped cream.";

        /// <summary>
        /// The private backing field for the StackSize property
        /// </summary>
        private uint _stackSize = 6;

        /// <summary>
        /// The number of panacakes in this instance of a Flying Saucer
        /// </summary>
        /// <remarks>
        /// Note the set limits the stack size to a maximum of 12 pancakes
        /// </remarks>
        public uint StackSize
        {
            get
            {
                return _stackSize;
            }
            set
            {
                if (value <= 12)
                {
                    _stackSize = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StackSize"));
                }
                else
                {
                    _stackSize = 12;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StackSize"));
                }
            }
        }

        /// <summary>
        /// private backing field for the Syrup property
        /// </summary>
        private bool _syrup;

        /// <summary>
        /// If the FyingSaucer instance is served with maple syrup
        /// </summary>
        /// <remarks>
        /// Initially we had an autoproperty with both getter and setter, 
        /// and a default value, but now we need to change that to implement data binding
        /// </remarks>
        public bool Syrup
        {
            get 
            {
                return _syrup;
            }
            set
            {
                if (value == true)
                {
                    _syrup = true;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Syrup"));
                }

                else
                {
                    _syrup = false;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Syrup"));
                }
            }
        }

        /// <summary>
        /// private backing field for the WhippedCream property
        /// </summary>
        private bool _whippedCream;

        /// <summary>
        /// If the FlyingSaucer instance is served with whipped cream
        /// </summary>
        public bool WhippedCream
        {
            get
            {
                return _whippedCream;
            }
            set
            {
                if (value == true)
                {
                    _whippedCream = true;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WhippedCream"));
                }

                else
                {
                    _whippedCream = false;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WhippedCream"));
                }
            }
        }

        private bool _berries;

        /// <summary>
        /// If the FlyingSaucer instance is served with berries
        /// </summary>
        public bool Berries 
        {
            get
            {
                return _berries;
            }
            set
            {
                if (value == true)
                {
                    _berries = true;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Berries"));
                }

                else
                {
                    _berries = false;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Berries"));
                }
            }
        }

        /// <summary>
        /// The price of the FlyingSaucer instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (StackSize > 6)
                {
                    return 8.50m + .75m * (StackSize - 6);
                }
                else
                {
                    return 8.50m;
                }
            }
        }

        /// <summary>
        /// The calories of the FlyingSaucer instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 64u * StackSize;
                if (Syrup) calories += 32u;
                if (WhippedCream) calories += 414u;
                if (Berries) calories += 89u;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
                return calories;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of this FlyingSaucer
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (StackSize != 6) instructions.Add($"{StackSize} Pancakes");
                if (!Syrup) instructions.Add("Hold Syrup");
                if (!WhippedCream) instructions.Add("Hold Whipped Cream");
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }



    }
}