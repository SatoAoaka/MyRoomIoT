using System;
using System.Windows.Input;
using MyRoomIoT.Commands;
using MyRoomIoT.Model;


namespace MyRoomIoT
{
    internal class MainPageViewModel : ViewModelBase
    {
        private string _labelText;
        public string sendURL = MyData.URL;

        public ICommand SendLightOn { get; }
        public ICommand SendLightOff { get; }
        public ICommand SendLightNight { get; }
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
            SendStopAir = new Send(ActionMaker(MyData.STOP_AIR));
            SendStartHot = new Send(ActionMaker(MyData.START_HOT));
            SendLightOn = new Send(ActionMaker(MyData.LIGHT_ON));
            SendLightOff = new Send(ActionMaker(MyData.LIGHT_OFF));
            SendLightNight = new Send(ActionMaker(MyData.LIGHT_Night));
            LabelText = "";
        }

        private Action ActionMaker(string fileName)
        {
            Action action = async () =>
            {
                LabelText = await HTMLRequest.SendPostAsync(fileName);
            };
            return action;
        }
    }
}
