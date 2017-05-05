using Mock_Project.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Project.Login_Model
{
    class Login :ANotifyPropertyChanged
    {
        String _UserName,_Password;
        public String UserName
        {
            get
            {
                return _UserName;
            }
            set
                {
                _UserName = value;
                OnPropertyChanged();
            }
        }
        public String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }
    }
}
