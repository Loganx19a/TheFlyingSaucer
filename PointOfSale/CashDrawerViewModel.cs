using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundRegister;
using System.ComponentModel;
using TheFlyingSaucer.Data;
using TheFlyingSaucer.Data.BaseClasses;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// The CashDrawerViewModel class that represents the ViewModel of the MVVM architecture
    /// </summary>
    public class CashDrawerViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// Event handler for implementing the INotifyPropertyChanged interface
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #region properties that represent the quantity of each kind of currency: the customer is using to pay, in the drawer, and that should be given to the customer as change

        public Order orderObject { get; set; }

        /// <summary>
        /// A private backing field for the pennies from the customer
        /// </summary>
        private uint _penniesFromCustomer;

        /// <summary>
        /// A property for the pennies from the customer
        /// </summary>
        public uint PenniesFromCustomer
        {
            get
            {
                return _penniesFromCustomer;
            }
            set
            {
                if (_penniesFromCustomer != value) _penniesFromCustomer = value;
                OnPropertyChanged(nameof(PenniesFromCustomer));
                OnPropertyChanged(nameof(PenniesInDrawer));
                OnPropertyChanged(nameof(AmountDueNegative));
                OnPropertyChanged(nameof(ChangeOwed));
                OnPropertyChanged(nameof(AmountDue));
            }

        }

        /// <summary>
        /// A property for the pennies in the cash drawer
        /// </summary>
        public uint PenniesInDrawer
        {
            get
            {
                return CashDrawer.Pennies;
            }
            set
            {
                if(CashDrawer.Pennies != value)
                {
                    CashDrawer.Pennies = value;
                    OnPropertyChanged(nameof(PenniesInDrawer));
                }
            }
        }

        /// <summary>
        /// A private backing field for the pennies to give to the customer as change
        /// </summary>
        private uint _penniesChange = 0;

        /// <summary>
        /// A property for the pennies to give to the customer as change
        /// </summary>
        public uint PenniesChange
        {
            get
            {
                return _penniesChange;
            }
            set
            {
                if (_penniesChange != value) _penniesChange = value;
                OnPropertyChanged(nameof(PenniesChange));
            }
        }

        /// <summary>
        /// A private backing field for the nickels received from the customer
        /// </summary>
        private uint _nicklesFromCustomer;

        /// <summary>
        /// A property for the nickels received from the customer
        /// </summary>
        public uint NicklesFromCustomer
        {
            get
            {
                return _nicklesFromCustomer;
            }
            set
            {
                if (_nicklesFromCustomer != value) _nicklesFromCustomer = value;
                OnPropertyChanged(nameof(NicklesFromCustomer));
                OnPropertyChanged(nameof(NicklesInDrawer));
                OnPropertyChanged(nameof(AmountDueNegative));
                OnPropertyChanged(nameof(ChangeOwed));
                OnPropertyChanged(nameof(AmountDue));
            }

        }

        /// <summary>
        /// A property for the nickels in the cash drawer
        /// </summary>
        public uint NicklesInDrawer
        {
            get
            {
                return CashDrawer.Pennies;
            }
            set
            {
                if (CashDrawer.Nickles != value)
                {
                    CashDrawer.Nickles = value;
                    OnPropertyChanged(nameof(NicklesInDrawer));
                }
            }
        }

        /// <summary>
        /// A private backing field for the nickels to give to the customer as change
        /// </summary>
        private uint _nicklesChange = 0;

        /// <summary>
        /// A property for the nickels to give to the customer as change
        /// </summary>
        public uint NicklesChange
        {
            get
            {
                return _nicklesChange;
            }
            set
            {
                if (_nicklesChange != value) _nicklesChange = value;
                OnPropertyChanged(nameof(NicklesChange));
            }
        }

        /// <summary>
        /// A private backing field for the dimes received from the customer
        /// </summary>
        private uint _dimesFromCustomer;

        /// <summary>
        /// A property for the dimes received from the customer
        /// </summary>
        public uint DimesFromCustomer
        {
            get
            {
                return _dimesFromCustomer;
            }
            set
            {
                if (_dimesFromCustomer != value) _dimesFromCustomer = value;
                OnPropertyChanged(nameof(DimesFromCustomer));
                OnPropertyChanged(nameof(DimesInDrawer));
                OnPropertyChanged(nameof(AmountDueNegative));
                OnPropertyChanged(nameof(ChangeOwed));
                OnPropertyChanged(nameof(AmountDue));
            }

        }

        /// <summary>
        /// A property for the dimes in the cash drawer
        /// </summary>
        public uint DimesInDrawer
        {
            get
            {
                return CashDrawer.Dimes;
            }
            set
            {
                if (CashDrawer.Dimes != value)
                {
                    CashDrawer.Dimes = value;
                    OnPropertyChanged(nameof(DimesInDrawer));
                }
            }
        }

        /// <summary>
        /// A private backing field for the dimes to give to the customer as change
        /// </summary>
        private uint _dimesChange = 0;

        /// <summary>
        /// A property for the dimes to give to the customer as change
        /// </summary>
        public uint DimesChange
        {
            get
            {
                return _dimesChange;
            }
            set
            {
                if (_dimesChange != value) _dimesChange = value;
                OnPropertyChanged(nameof(DimesChange));
            }
        }

        /// <summary>
        /// A private backing field for the quarters received from the customer
        /// </summary>
        private uint _quartersFromCustomer;

        /// <summary>
        /// A property for the quarters received from the customer
        /// </summary>
        public uint QuartersFromCustomer
        {
            get
            {
                return _quartersFromCustomer;
            }
            set
            {
                if (_quartersFromCustomer != value) _quartersFromCustomer = value;
                OnPropertyChanged(nameof(QuartersFromCustomer));
                OnPropertyChanged(nameof(QuartersInDrawer));
                OnPropertyChanged(nameof(AmountDueNegative));
                OnPropertyChanged(nameof(ChangeOwed));
                OnPropertyChanged(nameof(AmountDue));
            }

        }

        /// <summary>
        /// A property for the quarters in the cash drawer
        /// </summary>
        public uint QuartersInDrawer
        {
            get
            {
                return CashDrawer.Quarters;
            }
            set
            {
                if (CashDrawer.Quarters != value)
                {
                    CashDrawer.Quarters = value;
                    OnPropertyChanged(nameof(QuartersInDrawer));
                }
            }
        }

        /// <summary>
        /// A private backing field for the quarters to give to the customer as change
        /// </summary>
        private uint _quartersChange = 0;

        /// <summary>
        /// A property for the quarters to give to the customer as change
        /// </summary>
        public uint QuartersChange
        {
            get
            {
                return _quartersChange;
            }
            set
            {
                if (_quartersChange != value) _quartersChange = value;
                OnPropertyChanged(nameof(QuartersChange));
            }
        }

        /// <summary>
        /// A private backing field for the ones received from the customer
        /// </summary>
        private uint _onesFromCustomer;

        /// <summary>
        /// A property for the ones received from the customer
        /// </summary>
        public uint OnesFromCustomer
        {
            get
            {
                return _onesFromCustomer;
            }
            set
            {
                if (_onesFromCustomer != value) _onesFromCustomer = value;
                OnPropertyChanged(nameof(OnesFromCustomer));
                OnPropertyChanged(nameof(OnesInDrawer));
                OnPropertyChanged(nameof(AmountDueNegative));
                OnPropertyChanged(nameof(ChangeOwed));
                OnPropertyChanged(nameof(AmountDue));
            }

        }

        /// <summary>
        /// A property for the ones in the cash drawer
        /// </summary>
        public uint OnesInDrawer
        {
            get
            {
                return CashDrawer.Ones;
            }
            set
            {
                if (CashDrawer.Ones != value)
                {
                    CashDrawer.Ones = value;
                    OnPropertyChanged(nameof(OnesInDrawer));
                }
            }
        }

        /// <summary>
        /// A private backing field for the ones to give to the customer as change
        /// </summary>
        private uint _onesChange = 0;

        /// <summary>
        /// A property for the ones to give to the customer as change
        /// </summary>
        public uint OnesChange
        {
            get
            {
                return _onesChange;
            }
            set
            {
                if (_onesChange != value) _onesChange = value;
                OnPropertyChanged(nameof(OnesChange));
            }
        }

        /// <summary>
        /// A private backing field fo the fives received from the customer
        /// </summary>
        private uint _fivesFromCustomer;

        /// <summary>
        /// A property for the fives received from the customer
        /// </summary>
        public uint FivesFromCustomer
        {
            get
            {
                return _fivesFromCustomer;
            }
            set
            {
                if (_fivesFromCustomer != value) _fivesFromCustomer = value;
                OnPropertyChanged(nameof(FivesFromCustomer));
                OnPropertyChanged(nameof(FivesInDrawer));
                OnPropertyChanged(nameof(AmountDueNegative));
                OnPropertyChanged(nameof(ChangeOwed));
                OnPropertyChanged(nameof(AmountDue));
            }

        }

        /// <summary>
        /// A property for the fives in the cash drawer
        /// </summary>
        public uint FivesInDrawer
        {
            get
            {
                return CashDrawer.Fives;
            }
            set
            {
                if (CashDrawer.Fives != value)
                {
                    CashDrawer.Fives = value;
                    OnPropertyChanged(nameof(FivesInDrawer));
                }
            }
        }

        /// <summary>
        /// A private backing field for the fives given to the customer as change
        /// </summary>
        private uint _fivesChange = 0;

        /// <summary>
        /// A property for the fives given to the customer as change
        /// </summary>
        public uint FivesChange
        {
            get
            {
                return _fivesChange;
            }
            set
            {
                if (_fivesChange != value) _fivesChange = value;
                OnPropertyChanged(nameof(FivesChange));
            }
        }

        /// <summary>
        /// A private backing field for the tens recevied from the customer
        /// </summary>
        private uint _tensFromCustomer;

        /// <summary>
        /// A property for the tens received from the customer
        /// </summary>
        public uint TensFromCustomer
        {
            get
            {
                return _tensFromCustomer;
            }
            set
            {
                if (_tensFromCustomer != value) _tensFromCustomer = value;
                OnPropertyChanged(nameof(TensFromCustomer));
                OnPropertyChanged(nameof(TensInDrawer));
                OnPropertyChanged(nameof(AmountDueNegative));
                OnPropertyChanged(nameof(ChangeOwed));
                OnPropertyChanged(nameof(AmountDue));
            }

        }

        /// <summary>
        /// A property for the tens in the cash drawer
        /// </summary>
        public uint TensInDrawer
        {
            get
            {
                return CashDrawer.Tens;
            }
            set
            {
                if (CashDrawer.Tens != value)
                {
                    CashDrawer.Tens = value;
                    OnPropertyChanged(nameof(TensInDrawer));
                }
            }
        }

        /// <summary>
        /// A private backing field for the tens given to the customer as change
        /// </summary>
        private uint _tensChange = 0;

        /// <summary>
        /// A property for the tens given to the customer as change
        /// </summary>
        public uint TensChange
        {
            get
            {
                return _tensChange;
            }
            set
            {
                if (_tensChange != value) _tensChange = value;
                OnPropertyChanged(nameof(TensChange));
            }
        }

        /// <summary>
        /// A private backing field for the twenties received from the customer
        /// </summary>
        private uint _twentiesFromCustomer;

        /// <summary>
        /// A property for the twenties received from the customer
        /// </summary>
        public uint TwentiesFromCustomer
        {
            get
            {
                return _twentiesFromCustomer;
            }
            set
            {
                if (_twentiesFromCustomer != value) _twentiesFromCustomer = value;
                OnPropertyChanged(nameof(TwentiesFromCustomer));
                OnPropertyChanged(nameof(TwentiesInDrawer));
                OnPropertyChanged(nameof(AmountDueNegative));
                OnPropertyChanged(nameof(ChangeOwed));
                OnPropertyChanged(nameof(AmountDue));
            }

        }

        /// <summary>
        /// A property for the twenties in the cash drawer
        /// </summary>
        public uint TwentiesInDrawer
        {
            get
            {
                return CashDrawer.Twenties;
            }
            set
            {
                if (CashDrawer.Twenties != value)
                {
                    CashDrawer.Twenties = value;
                    OnPropertyChanged(nameof(TwentiesInDrawer));
                }
            }
        }

        /// <summary>
        /// A private backing field for the twenties given as change
        /// </summary>
        private uint _twentiesChange = 0;

        /// <summary>
        /// A property for the twenties given to the customer as change
        /// </summary>
        public uint TwentiesChange
        {
            get
            {
                return _twentiesChange;
            }
            set
            {
                if (_twentiesChange != value) _twentiesChange = value;
                OnPropertyChanged(nameof(TwentiesChange));
            }
        }

        /// <summary>
        /// A property representing the total cost of the order
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// A property representing the remaining amount due by the customer
        /// </summary>
        public decimal AmountDue
        {
            get
            {
                if (AmountDueNegative < 0) return 0;
                return AmountDueNegative;
            }
        }

        /// <summary>
        /// A property that calculates the difference between what the total and the amount the customer paid
        /// </summary>
        public decimal AmountDueNegative
        {
            get
            {
                return Total - (PenniesFromCustomer * .01m) 
                    - (NicklesFromCustomer * .05m)
                    - (DimesFromCustomer * .10m) 
                    - (QuartersFromCustomer * .25m)
                    - (OnesFromCustomer * 1)
                    - (FivesFromCustomer * 5)
                    - (TensFromCustomer * 10)
                    - (TwentiesFromCustomer * 20);
            }
        }

        /// <summary>
        /// A property representing the change owed to the customer
        /// </summary>
        public decimal ChangeOwed
        {
            get
            {
                decimal temp = AmountDueNegative * -1;
                if (AmountDueNegative < 0) return temp;
                return 0;
            }
        }

        #endregion


        #region methods

        /// <summary>
        /// Constructs a new CashDrawerViewModel object
        /// </summary>
        /// <param name="orderObject"></param>
        public CashDrawerViewModel(Order orderObject)
        {
            this.orderObject = orderObject;
        }

        /// <summary>
        /// A method for making the appropriate change
        /// </summary>
        public void MakeChange()
        {
            decimal temp = ChangeOwed;
            
            while (temp - 20 >= 0 && TwentiesInDrawer > 0)
            {
                temp -= 20;
                TwentiesInDrawer--;
                TwentiesChange++;
            }

            while (temp - 10 >= 0 && TensInDrawer > 0)
            {
                temp -= 10;
                TensInDrawer--;
                TensChange++;
            }

            while (temp - 5 >= 0 && FivesInDrawer > 0)
            {
                temp -= 5;
                FivesInDrawer--;
                FivesChange++;
            }

            while (temp - 1 >= 0 && OnesInDrawer > 0)
            {
                temp -= 1;
                OnesInDrawer--;
                OnesChange++;
            }

            while (temp - .25m >= 0 && QuartersInDrawer > 0)
            {
                temp -= .25m;
                QuartersInDrawer--;
                QuartersChange++;
            }

            while (temp - .10m >= 0 && DimesInDrawer > 0)
            {
                temp -= .10m;
                DimesInDrawer--;
                DimesChange++;
            }

            while (temp - .05m >= 0 && NicklesInDrawer > 0)
            {
                temp -= .05m;
                NicklesInDrawer--;
                NicklesChange++;
            }

            while (temp - .01m >= 0 && PenniesInDrawer > 0)
            {
                temp -= .01m;
                PenniesInDrawer--;
                PenniesChange++;
            }

        }

        /// <summary>
        /// A method for finalizing the transaction
        /// </summary>
        public void FinalizeTransaction()
        {
            CashDrawer.Open();      // Invoke the CashDrawer.Open() method

            #region Add the quantity of currency the customer paid to the CashDrawer's fields
            #endregion

            PenniesInDrawer += PenniesFromCustomer;
            _penniesFromCustomer = 0;
            NicklesInDrawer += NicklesFromCustomer;
            _nicklesFromCustomer = 0;
            DimesInDrawer += DimesFromCustomer;
            _dimesFromCustomer = 0;
            QuartersInDrawer += QuartersFromCustomer;
            _quartersFromCustomer = 0;

            OnesInDrawer += OnesFromCustomer;
            _onesFromCustomer = 0;
            FivesInDrawer += FivesFromCustomer;
            _fivesFromCustomer = 0;
            TensInDrawer += TensFromCustomer;
            _tensFromCustomer = 0;
            TwentiesInDrawer += TwentiesFromCustomer;
            _twentiesFromCustomer = 0;

            #region Deduct the quantity given as change
            #endregion

            MakeChange();
            PrintReceipt();
        }

        /// <summary>
        /// A method for printing a receipt for the transaction
        /// </summary>
        public void PrintReceipt()
        {
            #region The receipt should print the following
            /*
                The order number
                The date and time the order was finalized
                A complete list of all items in the order, including their price and any customization instructions
                The subtotal for the order
                The tax for the order
                The total for the order
                The payment method (i.e. cash or card)
                The change owed
             */
            #endregion


            RoundRegister.ReceiptPrinter.PrintLine("Order Number: " + orderObject.Number.ToString());
            RoundRegister.ReceiptPrinter.PrintLine("Date: " + orderObject.PlacedAt.ToString());

            foreach (IMenuItem item in orderObject)
            {
                RoundRegister.ReceiptPrinter.PrintLine("Name: " + item.Name);
                RoundRegister.ReceiptPrinter.PrintLine("Price: " + item.Price.ToString());

                foreach (string instruction in item.SpecialInstructions)
                {
                    RoundRegister.ReceiptPrinter.PrintLine("    " + instruction);
                }
            }
            RoundRegister.ReceiptPrinter.PrintLine("Subtotal: " + orderObject.Subtotal.ToString());
            RoundRegister.ReceiptPrinter.PrintLine("Tax: " + orderObject.Tax.ToString());
            RoundRegister.ReceiptPrinter.PrintLine("Total: " + orderObject.Total.ToString());

            RoundRegister.ReceiptPrinter.CutTape();
        }

        /// <summary>
        /// A method for signaling when a property has changed
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
    }
}
