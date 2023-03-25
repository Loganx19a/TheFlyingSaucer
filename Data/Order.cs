using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data.BaseClasses;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// A class representing a collection of menu items being ordered together
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// A private list of IMenuItem objects called _items
        /// </summary>
        private List<IMenuItem> _items = new List<IMenuItem>();

        /// <summary>
        /// Private backing field for the Number property
        /// </summary>
        private static int _number = 1;

        /// <summary>
        /// Property tracking the order number
        /// </summary>
        public int Number { get; } 

        /// <summary>
        /// Property tracking the date at which the order was placed
        /// </summary>
        public DateTime PlacedAt { get; init; } = DateTime.Now;

        public Order()
        {
            Number = _number++;
        }

        /// <summary>
        /// Private backing field for the tax rate of the order
        /// </summary>
        private decimal _taxRate = 0.15m;

        /// <summary>
        /// The rate at which the subtotal is taxed
        /// </summary>
        public decimal TaxRate
        {
            get
            {
                return _taxRate;
            }
            set
            {
                _taxRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
        }

        /// <summary>
        /// The number of items comprising the order
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// The subtotal of the order
        /// </summary>
        public decimal Subtotal
        {
            get { return _items.Sum(item => item.Price); }
        }

        /// <summary>
        /// The sales tax for the order
        /// </summary>
        public decimal Tax
        {
            get { return Subtotal * TaxRate; }
        }

        /// <summary>
        /// The total cost of the order, including sales tax
        /// </summary>
        public decimal Total
        {
            get { return Subtotal + Tax; }
        }

        /// <summary>
        /// Indicates whether something is ReadOnly
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// A method for adding items to the order
        /// </summary>
        /// <param name="item">The item to be added to the order</param>
        public void Add(IMenuItem item)
        {
            _items.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// A method for removing an item from _items
        /// </summary>
        /// <param name="item">The given item to be removed</param>
        /// <returns>True if the item is successfully removed, and false otherwise</returns>
        public bool Remove(IMenuItem item)
        {
            int index = _items.IndexOf(item);
            if (index == -1) return false;
            _items.Remove(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

            return true;
        }

        /// <summary>
        /// A method for removing all items from the order
        /// </summary>
        public void Clear()
        {
            _items.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            
        }

        /// <summary>
        /// A method to determine if the given item is contained within the list of items
        /// </summary>
        /// <param name="item">The given item to look for</param>
        /// <returns>True or false, depending upon whether the given item is contained within the </returns>
        public bool Contains(IMenuItem item)
        {
            return _items.Contains(item);
        }

        /// <summary>
        /// A method for copying the list of items from _items to another array
        /// </summary>
        /// <param name="array">the given array to copy to</param>
        /// <param name="arrayIndex">the index at which to place the first item in _items</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// A method used to retrieve an enumerator that iterates through the List<T>
        /// </summary>
        /// <returns>An enumerator that iterates through the List<T></returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// A method for returning an IEnumerator object that can be used to iterate through the collection
        /// </summary>
        /// <returns>Returns an enumerator that iterates through a collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
