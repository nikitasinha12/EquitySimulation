using Mock_Project.Framework;
using Mock_Project.DataModel;
using Mock_Project.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mock_Project.Admin_Views;

namespace Mock_Project.Admin_ViewModel
{
    class CreateUserViewModel : ANotifyPropertyChanged
    {
        EquityEntities db;
        public User newUser { get; set; }
        public DelegateCommand AddUser { get; set; }
        public CreateUserViewModel()
        {
            newUser = new User();
            AddUser = new DelegateCommand(AddUserPredicate, AddUserAction);
            db = new EquityEntities();
        }

        private void AddUserAction(object obj)
        {
            
            if (obj == null)
            {
                return;
            }
            else
            {
                var parameters = (object[])obj;
                var newUser = parameters[0] as User;
                dynamic paswordTemp = parameters[1];
                newUser.PassWord = paswordTemp.Password;
                newUser.CreationDate = DateTime.Now;
                newUser.UpdationDate = DateTime.Now;
                newUser.ISActive = true;
                db.Users.Add(newUser);
                
            }
            if(CreateUser.PM)
            {
                db.User_Role.Add(new User_Role() { UserID = newUser.UserID, RoleID = 2, ISActive = true, CreationDate = DateTime.Now, UpdationDate = DateTime.Now });
            }
            if (CreateUser.Trader)
            {
                db.User_Role.Add(new User_Role() { UserID = newUser.UserID, RoleID = 1, ISActive = true, CreationDate = DateTime.Now, UpdationDate = DateTime.Now });
            }
            if (CreateUser.Admin)
            {
                db.User_Role.Add(new User_Role() { UserID = newUser.UserID, RoleID = 3, ISActive = true, CreationDate = DateTime.Now, UpdationDate = DateTime.Now });
            }
            db.SaveChanges();
            App.Current.MainWindow.Hide();
        }

        private bool AddUserPredicate(object obj)
        {
            return true;
        }

    }
}
