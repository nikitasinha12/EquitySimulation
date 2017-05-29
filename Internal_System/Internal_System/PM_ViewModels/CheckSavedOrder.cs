using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal_System.PM_ViewModels
{
    class CheckSavedOrder : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName)
        {
            // Retrieve handler
            PropertyChangedEventHandler handler = this.PropertyChanged;
            // Check to make sure handler is not null
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool _OrderChecked;
        public bool OrderChecked {
            get { return _OrderChecked; }
            set { _OrderChecked = value;
            OnPropertyChanged("OrderChecked");
            }
        }
    }
}
