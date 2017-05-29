using Internal_System.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Internal_System.Traders
{
    class IndividualOrder : INotifyPropertyChanged, IDataErrorInfo
    {
        
        long _orderID;
        long _orderTypeID;
        long? _blockID;
        long _portfolioID;
        long _PMID;
        long _orderStatusID;
        decimal? _marketPrice;
        decimal? _limitPrice;
        long _alloctedQty;
        long _totalQty;
        DateTime? _expiryDate;
        string _side;
        long _symbolID;
        decimal? _stopPrice;
        DateTime _creationDate;
        DateTime _updationDate;
        Block _block;
        Order_Status _orderStatus;
        Order_Type _orderType;
        Portfolio _portfolio;
        Symbol_Properties _symbolProperties;
        User _user;

        public long OrderID
        {
            get { return _orderID; }

            set
            {
                _orderID = value;
                OnPropertyChanged();
            }
        }
        public long OrderTypeID
        {
            get { return _orderTypeID; }

            set
            {
                _orderTypeID = value;
                OnPropertyChanged();
            }
        }
        public long? BlockID
        {
            get { return _blockID; }

            set
            {
                _blockID = value;
                OnPropertyChanged();
            }
        }
        public long PortfolioID
        {
            get { return _portfolioID; }

            set
            {
                _portfolioID = value;
                OnPropertyChanged();
            }
        }
        public long PMID
        {
            get { return _PMID; }

            set
            {
                _PMID = value;
                OnPropertyChanged();
            }
        }
        public long OrderStatusID
        {
            get { return _orderStatusID; }

            set
            {
                _orderStatusID = value;
                OnPropertyChanged();
            }
        }
        public decimal? MarketPrice
        {
            get { return _marketPrice; }

            set
            {
                _marketPrice = value;
                OnPropertyChanged();
            }
        }
        public decimal? LimitPrice
        {
            get { return _limitPrice; }

            set
            {
                _limitPrice = value;
                OnPropertyChanged();
            }
        }
        public long AllocatedQty
        {
            get { return _alloctedQty; }

            set
            {
                _alloctedQty = value;
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
        public DateTime? ExpiryDate
        {
            get { return _expiryDate; }

            set
            {
                _expiryDate = value;
                OnPropertyChanged();
            }
        }

        public string Side
        {
            get { return _side; }

            set
            {
                _side = value;
                OnPropertyChanged();
            }
        }
        public long SymbolID
        {
            get { return _symbolID; }

            set
            {
                _symbolID = value;
                OnPropertyChanged();
            }
        }
        public decimal? StopPrice
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
        public Block Block
        {
            get { return _block; }

            set
            {
                _block = value;
                OnPropertyChanged();
            }
        }
        public Order_Status OrderStatus
        {
            get { return _orderStatus; }

            set
            {
                _orderStatus = value;
                OnPropertyChanged();
            }
        }
        public Order_Type OrderType
        {
            get { return _orderType; }

            set
            {
                _orderType = value;
                OnPropertyChanged();
            }
        }
        public Portfolio Portfolio
        {
            get { return _portfolio; }

            set
            {
                _portfolio = value;
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
