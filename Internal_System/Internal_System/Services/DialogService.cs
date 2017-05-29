using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Internal_System.Services
{
    class DialogService : IDialogService
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }


        public string ShowDialog()
        {
            return " ";
        }
    }

    public interface IDialogService
    {
        void Show(string message);
        string ShowDialog();
    }
}
