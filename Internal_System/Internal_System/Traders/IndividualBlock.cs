using Internal_System.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Internal_System.Traders.TraderDashboard
{
    class IndividualBlock : INotifyPropertyChanged, IDataErrorInfo
    {
        long _blockId;
        long _userId;
        long _blockStatusId;
        long _symbolId;
        long _executedQty;
        decimal _limitPrice;
        long _totalQty;
        decimal _stopPrice;
        DateTime _creationDate;
        DateTime _updationDate;
        Block_status _blockStatus;
        Symbol_Properties _symbolProperties;
        User _user;
        ICollection<Order> _orders;

        public long BlockID
        {
            get { return _blockId; }

            set
            {
                _blockId = value;
                OnPropertyChanged();
            }
        }
        public long UserID
        {
            get { return _userId; }

            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }
        public long BlockStatusID
        {
            get { return _blockStatusId; }

            set
            {
                _blockStatusId = value;
                OnPropertyChanged();
            }
        }
        public long SymbolID
        {
            get { return _symbolId; }

            set
            {
                _symbolId = value;
                OnPropertyChanged();
            }
        }
        public long ExecutedQty
        {
            get { return _executedQty; }

            set
            {
                _executedQty = value;
                OnPropertyChanged();
            }
        }
        public decimal LimitPrice
        {
            get { return _limitPrice; }

            set
            {
                _limitPrice = value;
                OnPropertyChanged();
            }
        }
        public long TotalQty
        {
            get { return _totalQty; }

            set
            {
                _totalQty = value;
                OnPropertyChanged();
            }
        }
        public decimal StopPrice
        {
            get { return _stopPrice; }

            set
            {
                _stopPrice = value;
                OnPropertyChanged();
            }
        }
        public DateTime CreationDate
        {
            get { return _creationDate; }

            set
            {
                _creationDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime UpdationDate
        {
            get { return _updationDate; }

            set
            {
                _updationDate = value;
                OnPropertyChanged();
            }
        }
        public Block_status BlockStatus
        {
            get { return _blockStatus; }

            set
            {
                _blockStatus = value;
                OnPropertyChanged();
            }
        }
        public Symbol_Properties SymbolProperties
        {
            get { return _symbolProperties; }

            set
            {
                _symbolProperties = value;
                OnPropertyChanged();
            }
        }
        public User User
        {
            get { return _user; }

            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public ICollection<Order> BlockOrdersList
        {
            get { return _orders; }

            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {

                //if (string.IsNullOrEmpty(LastName) && columnName == "LastName")
                //{
                //    return "Last Name Is Required";
                //}
                //if (string.IsNullOrEmpty(Id.ToString()) && columnName == "Id")
                //{
                //    return "Id is Required";
                //}

                //if (string.IsNullOrEmpty(FirstName) && columnName == "FirstName")
                //{
                //    return "First Name Is Required";
                //}
                //if (string.IsNullOrEmpty(Age.ToString()) && columnName == "Age")
                //{
                //    return "Age Is Required";
                //}

                //if (Age < 18 && columnName == "Age")
                //{
                //    return "Age should be 18 or above";
                //}
                return null;
            }
        }


    }
}
