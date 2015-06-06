using System;

namespace HighBridge.Common.Commands
{

    public abstract class DelegateCommandBase : CommandBase
    {
        private Action<object> onExecute;
        public DelegateCommandBase(Action<object> act)
        {
            this.onExecute = act;
        }

        public override void Execute(object o)
        {
            onExecute(o);
        }
    }
}
