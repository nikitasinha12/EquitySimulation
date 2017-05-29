using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mock_Project.Shared_ViewModel
{
    class RedirectionViewModel
    {
        internal static void WindowRedirectMethod(Window newWindow)
        {
            Window currentWindow = Application.Current.MainWindow;
            newWindow.Show();
            Application.Current.MainWindow = newWindow;
            currentWindow.Close();
        }
    }
}
