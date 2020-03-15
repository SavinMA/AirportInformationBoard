using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AirportInformationBoard.Models
{
    public class Statistic : INotifyPropertyChanged
    {   // Количество пассажиров


        // - в последнем рейсе
        // - за последние 24 часа
        // - сумма за всё время работы
        private int lastFlight, lastDayFlight, sumFlight;

        public int LastFlight
        {
            get { return lastFlight; }
            set { lastFlight = value; SumFlight += value; OnPropertyChanged(); }
        }
        public int LastDayFlight
        {
            get { return lastDayFlight; }
            set { lastDayFlight = value; OnPropertyChanged(); }
        }
        public int SumFlight
        {
            get { return sumFlight; }
            set { sumFlight = value; OnPropertyChanged(); }
        }

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Statistic()
        {
            LastFlight = 0;
            LastDayFlight = 0;
            SumFlight = 0;
        }
    }
}
