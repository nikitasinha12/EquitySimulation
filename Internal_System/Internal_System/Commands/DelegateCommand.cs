using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Internal_System.Commands
{
    public class DelegateCommand : ICommand
    {
        private Predicate<object> _predicate;
        private Action<object> _action;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Predicate<object> predicate, Action<object> action)
        {
            _predicate = predicate;
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return _predicate(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
