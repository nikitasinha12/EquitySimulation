using Internal_System.Commands;
using Internal_System.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Internal_System.Shared_ViewModel
{
    class PM_ForgotPasswordViewModel
    {
        private DelegateCommand myCommand;
        public DelegateCommand MyCommand { get { return myCommand; } set { myCommand = value; } }
        public Login_Model.Login FPData { get; set; }
        public Login _login;

        EquityEntities db;

        public PM_ForgotPasswordViewModel(Login login)
        {
            MyCommand = new DelegateCommand( customPredicate, customAction);
            db = new EquityEntities();
            FPData = new Login_Model.Login();
            _login = login;
        }

        private void customAction(object obj)
        {
            var recievedObject = obj as Internal_System.Login_Model.Login;
            var UserFound = db.Users.First(u => u.UserName == recievedObject.UserName);
            if (UserFound != null)
	        {
                UserFound.PassWord = recievedObject.Password;
                db.Entry(UserFound).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
	        }
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = _login;
            Login loginScreen = new Login();
            loginScreen.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = loginScreen;
        }

        private bool customPredicate(object obj)
        {
            return true;
        }
    }
}
