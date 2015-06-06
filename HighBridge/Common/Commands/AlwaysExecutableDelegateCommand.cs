using System;

namespace HighBridge.Common.Commands
{
    public class AlwaysExecutableDelegateCommand : DelegateCommandBase
    {
        public AlwaysExecutableDelegateCommand(Action<object> act)
            : base(act)
        {

        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
