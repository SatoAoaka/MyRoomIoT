using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MyRoomIoT.Commands;
using MyRoomIoT.Model;


namespace MyRoomIoT
{
    internal class MainPageViewModel : ViewModelBase
    {
        private string _labelText;

        public ICommand SendStartHot { get; }
        public ICommand SendStopAir { get; }
        public string LabelText
        {
            get { return _labelText; }
            set
            {
                this._labelText = value;
                this.OnPropertyChanged(nameof(LabelText));
            }
        }
        public MainPageViewModel()
        {
            SendStopAir = new Send(actionMaker("stop_air.dat"));
            SendStartHot = new Send(actionMaker("start_hot.dat"));
            LabelText = "ここにHTMLレスポンスが表示されます";
        }

        private Action actionMaker(string fileName)
        {
            Action action = async () =>
            {
                LabelText = await HTMLRequest.SendPostAsync(fileName);
            };
            return action;
        }
    }
}
