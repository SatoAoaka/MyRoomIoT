using System;
using System.Windows.Input;

namespace MyRoomIoT.Commands
{
    internal class Send : ICommand
    {
        private readonly Action _action;

        public event EventHandler CanExecuteChanged;

        public Send(Action action)
        {
            this._action = action;
        }

        //実行可能かどうかを判断する
        public bool CanExecute(object parameter)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //実行するときは以下を呼び出される
        public void Execute(object parameter)
        {
            this._action();
        }
    }
}
