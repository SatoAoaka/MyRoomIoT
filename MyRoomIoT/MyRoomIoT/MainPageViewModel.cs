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
            SendStopAir = new Send(Send_HTMLStopAir);
            SendStartHot = new Send(Send_HTMLStartHot);
            LabelText = "ここにHTMLレスポンスが表示されます";
        }

        private async void Send_HTMLStopAir()
        {           
            LabelText = await HTMLRequest.SendPostAsync("stop_air.dat");
        }
        private async void Send_HTMLStartHot()
        {
            LabelText = await HTMLRequest.SendPostAsync("start_hot.dat");
        }
    }
}
