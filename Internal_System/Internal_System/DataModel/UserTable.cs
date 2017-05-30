using Internal_System.Shared_ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal_System.DataModel
{
    public partial class UserTable : BaseViewModel
    {
        private string _userName;
        private string _password;
        public UserTable()
        {
            this.Blocks = new HashSet<Block>();
            this.Orders = new HashSet<Order>();
            this.Portfolios = new HashSet<Portfolio>();
            this.User_Role = new HashSet<User_Role>();
        }

        public long UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        public string PassWord
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public bool ISActive { get; set; }
        public System.DateTime CreationDate { get; set; }
        public System.DateTime UpdationDate { get; set; }

        public virtual ICollection<Block> Blocks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<User_Role> User_Role { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (string.IsNullOrEmpty(UserName))
                {
                    return "This field is required";
                }
                if(string.IsNullOrEmpty(PassWord))
                {
                    return "This field is required";
                }
                return base[columnName];
            }
        }
    }
}
