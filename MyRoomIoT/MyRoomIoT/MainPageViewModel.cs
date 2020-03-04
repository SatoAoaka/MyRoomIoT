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
            SendStopAir = new Send(actionMaker(MyData.STOP_AIR));
            SendStartHot = new Send(actionMaker(MyData.START_HOT));
            SendLightOn = new Send(actionMaker(MyData.LIGHT_ON));
            SendLightOff = new Send(actionMaker(MyData.LIGHT_OFF));
            SendLightNight = new Send(actionMaker(MyData.LIGHT_Night));
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
