using Internal_System.Framework;
using Internal_System.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internal_System.PM_Views;
using Internal_System.Traders.TraderDashboard;
using Internal_System.DataModel;
using Internal_System.Admin_Views;

namespace Internal_System.Login_ViewModel
{
    class SelectPageViewModel : ANotifyPropertyChanged
    {
        EquityEntities entity;
        DelegateCommand _PMRedirect, _TraderRedirect, _AdminRedirect;
        public DelegateCommand PMRedirect
        {
            get
            {
                return _PMRedirect;
            }
            set
            {
                _PMRedirect = value;
                OnPropertyChanged();
            }
        }
        public DelegateCommand TraderRedirect
        {
            get
            {
                return _TraderRedirect;
            }
            set
            {
                _TraderRedirect = value;
                OnPropertyChanged();
            }
        }
        public DelegateCommand AdminRedirect
        {
            get
            {
                return _AdminRedirect;
            }
            set
            {
                _AdminRedirect = value;
                OnPropertyChanged();
            }
        }
        public SelectPageViewModel()
        {
            _PMRedirect = new DelegateCommand(PMPredicate, PMAction);
            _TraderRedirect = new DelegateCommand(TraderPredicate, TraderAction);
            _AdminRedirect = new DelegateCommand(AdminPredicate, AdminAction);
            entity = new EquityEntities();
        }

        private bool AdminPredicate(object obj)
        {
            return true;
        }

        private void AdminAction(object obj)
        {
            var oldCurrentWindow = App.Current.MainWindow;
            Dashboard_Admin d = new Dashboard_Admin();
            App.Current.MainWindow = d;
            App.Current.MainWindow.Show();
            Session.CurrentRole = entity.Roles.Find(3);
            oldCurrentWindow.Close();
        }

        private void TraderAction(object obj)
        {
            var oldCurrentWindow = App.Current.MainWindow;
            //App.Current.MainWindow.Hide();
            TraderDashboard d = new TraderDashboard();
            App.Current.MainWindow = d;
            App.Current.MainWindow.Show();
            Session.CurrentRole = entity.Roles.Find(1);
            oldCurrentWindow.Close();
        }

        private bool TraderPredicate(object obj)
        {
            return true;
        }

        private void PMAction(object obj)
        {
            var oldCurrentWindow = App.Current.MainWindow;
            //App.Current.MainWindow.Hide();
            Dashboard d = new Dashboard();
            App.Current.MainWindow = d;
            App.Current.MainWindow.Show();
            Session.CurrentRole = entity.Roles.Find(2);
            oldCurrentWindow.Close();
        }

        private bool PMPredicate(object obj)
        {
            return true;
        }
    }
}
