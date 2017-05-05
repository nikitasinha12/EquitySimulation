using Mock_Project.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Project.Shared_ViewModel
{
    public class BaseViewModel : ANotifyPropertyChanged, IDataErrorInfo
    {
        public string Error { get; private set; }

        public virtual string this[string columnName]
        {
            get { return null; }
        }
    }
}
