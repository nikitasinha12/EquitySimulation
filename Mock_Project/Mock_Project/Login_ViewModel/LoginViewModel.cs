using Mock_Project.Framework;
using Mock_Project.Commands;
using Mock_Project.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mock_Project.PM_Views;
using Mock_Project.Traders.TraderDashboard;
using Mock_Project.Admin_Views;

namespace Mock_Project.Login_ViewModel
{
    class LoginViewModel : ANotifyPropertyChanged
    {
        public Uri loginImage { get; set; }
        private EquityEntities entity;
        DelegateCommand _LoginCommand;
        public EquityEntities Entity { get { return entity; } set { entity = value; OnPropertyChanged(); } }        
        Login_Model.Login _Credentials;
        private string error;
        public string ErrorMessage { get { return error; } set { error = value; OnPropertyChanged(); } }
        public static bool PM, Trader, Admin;
        
        public Login_Model.Login Credentials
        {
            get
            {
                return _Credentials;
            }

            set
            {
                _Credentials = value;
                OnPropertyChanged();
            }
        }
        public DelegateCommand LoginCommand 
        {
            get
            {
                return _LoginCommand;
            }

            set
            {
                _LoginCommand = value;
                OnPropertyChanged();
            }
        }
        public LoginViewModel()
        {
            _LoginCommand = new DelegateCommand(LoginPredicate, LoginAction);
            Entity = new EquityEntities();
            _Credentials = new Login_Model.Login();
            ErrorMessage = "";
            loginImage = new Uri(@"Resources\Images\login-page-image.jpg",UriKind.Relative);
        }

        private void LoginAction(object obj)
        {
            if (obj ==null)
            {
                ErrorMessage = "null object error";
                return;
            }
            PM = Trader = Admin = false;
            List<Role> role = Entity.Roles.ToList();
            var parameters = (object[])obj;
            dynamic password = parameters[1];
            Login_Model.Login cred=parameters[0] as Login_Model.Login;
            if (String.IsNullOrEmpty(cred.UserName) || String.IsNullOrEmpty(password.Password.ToString()))
            {
                ErrorMessage = String.IsNullOrEmpty(cred.UserName) ? "Username can not be empty !!" : "Password can not be empty !!";
                return;
            }

            cred.Password = password.Password;
            List<User_Role> urole = Entity.User_Role.ToList();
            List<User> users = Entity.Users.ToList();
            if(users.Exists(u=> (u.UserName==cred.UserName)))
            {
                User u=users.First(u2=> (u2.UserName==cred.UserName));
                if(u.PassWord==cred.Password)
                {
                    if (u.ISActive)
                    {
                        Session.CurrentUser = u;
                        List<User_Role> roles = urole.FindAll(user => (user.UserID == u.UserID));

                        foreach (var item in roles)
                        {
                            switch (item.RoleID)
                            {
                                case 1:
                                    PM = true;
                                    break;
                                case 2:
                                    Trader = true;
                                    break;
                                case 3:
                                    Admin = true;
                                    break;
                            }
                        }
                        if (roles.Count > 1)
                        {
                            var oldCurrentWindow = App.Current.MainWindow;
                            //App.Current.MainWindow.Hide();
                            SelectPage sp = new SelectPage();
                            App.Current.MainWindow = sp;
                            App.Current.MainWindow.Show();
                            //sp.Show();
                            oldCurrentWindow.Close();
                        }
                        else
                        {
                            if (PM)
                            {
                                var oldCurrentWindow = App.Current.MainWindow;
                                //App.Current.MainWindow.Hide();
                                Dashboard d = new Dashboard();
                                App.Current.MainWindow = d;
                                App.Current.MainWindow.Show();
                                Session.CurrentRole = Entity.Roles.Find(2);
                                oldCurrentWindow.Close();
                            }
                            else if (Trader)
                            {
                                var oldCurrentWindow = App.Current.MainWindow;
                                //App.Current.MainWindow.Hide();
                                TraderDashboard d = new TraderDashboard();
                                App.Current.MainWindow = d;
                                App.Current.MainWindow.Show();
                                Session.CurrentRole = Entity.Roles.Find(1);
                                oldCurrentWindow.Close();
                            }
                            else if (Admin)
                            {
                                var oldCurrentWindow = App.Current.MainWindow;
                                //App.Current.MainWindow.Hide();
                                Dashboard_Admin d = new Dashboard_Admin();
                                App.Current.MainWindow = d;
                                App.Current.MainWindow.Show();
                                Session.CurrentRole = Entity.Roles.Find(3);
                                oldCurrentWindow.Close();
                            }
                        }
                    }
                }
                else
                {

                    ErrorMessage = "Invalid UserName/Password";
                    return;
                }
            }
            else
            {
                ErrorMessage = "Invalid UserName/Password";
                return;
            }
        }

        private bool LoginPredicate(object obj)
        {
            return true;
        }
    }
}
