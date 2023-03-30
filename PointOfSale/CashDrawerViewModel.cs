using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundRegister;
using System.ComponentModel;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// 
    /// </summary>
    public class CashDrawerViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private uint _penniesFromCustomer;

        /// <summary>
        /// 
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
                OnPropertyChanged(nameof(PenniesInDrawer));
                //OnPropertyChanged(nameof(PenniesInDrawer));

            }

        }

        /// <summary>
        /// 
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

        private uint _penniesChange = 0;

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

        private uint _nicklesFromCustomer;

        /// <summary>
        /// 
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
                //OnPropertyChanged(nameof(PenniesInDrawer));

            }

        }

        /// <summary>
        /// 
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

        private uint _nicklesChange = 0;

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


        private uint _dimesFromCustomer;

        /// <summary>
        /// 
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
                //OnPropertyChanged(nameof(PenniesInDrawer));

            }

        }

        /// <summary>
        /// 
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

        private uint _dimesChange = 0;

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

        private uint _quartersFromCustomer;

        /// <summary>
        /// 
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
                //OnPropertyChanged(nameof(PenniesInDrawer));

            }

        }

        /// <summary>
        /// 
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

        private uint _quartersChange = 0;

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

        private uint _onesFromCustomer;

        /// <summary>
        /// 
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
                //OnPropertyChanged(nameof(PenniesInDrawer));

            }

        }

        /// <summary>
        /// 
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

        private uint _onesChange = 0;

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

        private uint _fivesFromCustomer;

        /// <summary>
        /// 
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
                //OnPropertyChanged(nameof(PenniesInDrawer));

            }

        }

        /// <summary>
        /// 
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

        private uint _fivesChange = 0;

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

        private uint _tensFromCustomer;

        /// <summary>
        /// 
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
                //OnPropertyChanged(nameof(PenniesInDrawer));

            }

        }

        /// <summary>
        /// 
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

        private uint _tensChange = 0;

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

        private uint _twentiesFromCustomer;

        /// <summary>
        /// 
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
                //OnPropertyChanged(nameof(PenniesInDrawer));

            }

        }

        /// <summary>
        /// 
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

        private uint _twentiesChange = 0;

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

        public decimal Total { get; set; }

        public decimal AmountDue
        {
            get
            {
                if (AmountDueNegative < 0) return 0;
                return AmountDueNegative;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal AmountDueNegative
        {
            get
            {
                return Total - (PenniesFromCustomer * .01m 
                    - NicklesFromCustomer * .05m
                    - DimesFromCustomer * .10m 
                    - QuartersFromCustomer * 25m
                    - OnesFromCustomer * 1
                    - FivesFromCustomer * 5
                    - TensFromCustomer * 10
                    - TwentiesFromCustomer * 20);
            }
        }

        /// <summary>
        /// 
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

        /// <summary>
        /// 
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

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // amount change to give


        // how much in drawer
    }
}
