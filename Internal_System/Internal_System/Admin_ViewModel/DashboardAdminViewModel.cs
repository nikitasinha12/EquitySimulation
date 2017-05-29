using Internal_System.Commands;
using Internal_System.Framework;
using Internal_System.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Internal_System.Admin_Views;
using System.Windows;
using System.Data.Entity;

namespace Internal_System.Admin_ViewModel
{
    class DashboardAdminViewModel:ANotifyPropertyChanged
    {
        public DelegateCommand AddUser { get; set; }
        public DelegateCommand EditUser { get; set; }
        public DelegateCommand DeleteUser { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }
        EquityEntities db;
        public DashboardAdminViewModel()
        {
            AddUser = new DelegateCommand(AddUserPredicate, AddUserAction);
            EditUser = new DelegateCommand(EditUserPredicate, EditUserAction);
            DeleteUser = new DelegateCommand(DeleteUserPredicate, DeleteUserAction);
            db = new EquityEntities();
            Users = new ObservableCollection<User>(db.Users.Where(t=> t.ISActive==true).ToList());
        }

        private void DeleteUserAction(object obj)
        {
            if (obj == null)
                return;
            else
            {
                var x=obj as User;
                MessageBoxButton msgBtn = MessageBoxButton.OKCancel;
                string msgText = "Do you really want to delete this user?\nName:\t\t" + x.FName + " " + x.LName + "\nUserName:\t" + x.UserName + "\nCreatedOn:\t" + x.CreationDate + "\nUpdatedOn:\t" + x.UpdationDate;
                string txt = "Confirm Delete Dialog";
                MessageBoxResult result=MessageBox.Show(msgText,txt,msgBtn);
                switch(result)
                {
                    case MessageBoxResult.OK:
                        db.Users.Find(x.UserID).ISActive = false;
                        db.SaveChanges();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
        }

        private bool DeleteUserPredicate(object obj)
        {
            return true;
        }

        private void EditUserAction(object obj)
        {
            if (obj == null)
                return;
            var selectedUser = obj as User;
            EditUserViewModel editUserViewModel = new EditUserViewModel();
            editUserViewModel.newUser = selectedUser;
            EditUser newEdit = new EditUser();
            newEdit.DataContext = editUserViewModel;
            //App.Current.MainWindow = newEdit;
            //App.Current.MainWindow.Show();
            newEdit.ShowDialog();
        }

        private bool EditUserPredicate(object obj)
        {
            return true;
        }

        private void AddUserAction(object obj)
        {
            
            CreateUser newCreate = new CreateUser();
            App.Current.MainWindow = newCreate;
            App.Current.MainWindow.Show();
        }

        private bool AddUserPredicate(object obj)
        {
            return true;
        }
    }
}
