using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace AirportInformationBoard
{
    public class TimerManager : INotifyPropertyChanged
    {
        public event Action TimerElapsed;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private DateTime current;
        public DateTime Current 
        { 
            get { return current; } 
            private set { current = value; OnPropertyChanged(); }
        }

        public double Interval = 100d;
        public double Factor { get; set; } = 1d; //1:10:100:1000:10000
        public TimerManager()
        {
            Current = DateTime.Now;
        }

        public void StartTimer()
        {
            var timer = new Timer(Interval);
            timer.AutoReset = true;
            timer.Elapsed += (s, e) =>
            {
                Current = Current.AddMilliseconds(Interval * Factor);
                TimerElapsed?.Invoke();
            };
            timer.Start();
        }
    }
}
