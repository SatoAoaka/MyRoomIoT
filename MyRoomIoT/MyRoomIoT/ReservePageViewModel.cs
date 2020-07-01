using MyRoomIoT.Commands;
using MyRoomIoT.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MyRoomIoT
{
    class ReservePageViewModel : ViewModelBase
    {
        private string _labelText;
        private string _dataTime;
        public ICommand SendLightOn { get; }
        public ICommand SendLightOff { get; }
        public ICommand SendLightNight { get; }
        public ICommand SendStartHot { get; }
        public ICommand SendStopAir { get; }

        public ICommand ChangeText { get; }
        public string LabelText
        {
            get { return _labelText; }
            set
            {
                this._labelText = value;
                this.OnPropertyChanged(nameof(LabelText));
            }
        }
        private DateTime _date;
        public DateTime Date {
            get { return _date; }
            set
            {
                this._date = value;
                this.OnPropertyChanged(nameof(Date));
            }
        }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                this._time = value;
                this.OnPropertyChanged(nameof(Time));
            }
        }


        public ReservePageViewModel()
        {
            SendStopAir = new Send(ActionMaker(MyData.STOP_AIR));
            SendStartHot = new Send(ActionMaker(MyData.START_HOT));
            SendLightOn = new Send(ActionMaker(MyData.LIGHT_ON));
            SendLightOff = new Send(ActionMaker(MyData.LIGHT_OFF));
            SendLightNight = new Send(ActionMaker(MyData.LIGHT_Night));
            this.Date = DateTime.Now;
        }

        private Action ActionMaker(string fileName)
        {
            Action action = async () =>
            {
                _dataTime = ReadDateTimePicker();
                LabelText = await ReserveRequest.SendPostAsync(fileName, _dataTime);
            };
            return action;
        }
       
        private string ReadDateTimePicker()
        {
            string dateTime="";
            dateTime = Date.Date.ToString("yyyyMMdd");
            dateTime += Time.ToString("hhmm");
            return dateTime;
        }
    }
}
