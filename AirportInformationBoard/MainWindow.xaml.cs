using AirportInformationBoard.Models;
using AirportInformationBoard.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace AirportInformationBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private object SyncObj = new object();

        private DateTime LastUpdate;

        private Schedule lastSchedule;
        List<Schedule> Schedules { get; set; }
        public TimerManager Timer { get; set; }

        public Schedule LastSchedule
        {
            get { return lastSchedule; }
            set { lastSchedule = value; OnPropertyChanged(); }
        }
        public MainWindow()
        {
            InitializeComponent();

            for (double d = 1; d < 100000; d *= 10)
                comboBox.Items.Add(d);

            Load();

            Timer = new TimerManager();
            Timer.TimerElapsed += Timer_TimerElapsed;
            Timer.StartTimer();

            DataContext = this;
            LastUpdate = Timer.Current;

            histogramView.Add(Timer.Current,
                        Schedules.Where(x => x.Departure.DateTime > Timer.Current.AddHours(-1d) && x.Departure.DateTime <= Timer.Current).Sum(x => x.PassengerCount),
                        Schedules.Where(x => x.Arrival.DateTime > Timer.Current.AddHours(-1d) && x.Arrival.DateTime <= Timer.Current).Sum(x => x.PassengerCount));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private void Load()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Schedules");
            var text = File.ReadAllTextAsync(path).Result;
            Schedules = Serializator<List<Schedule>>.DeSerializeFromString(text);
        }

        private void Timer_TimerElapsed()
        {
            lock (SyncObj)
            {
                var departuredSchedules = Schedules.Where(x => x.CurrentStatus == Status.Waiting && x.Departure.DateTime <= Timer.Current);
                departuredSchedules.AsParallel().ForAll(x =>
                    {
                        departureStatistic.Statistic.LastFlight = x.Start(new Random().Next(x.AircraftType.Capacity));
                        LastSchedule = x;
                    });

                var arrivalSchedules = Schedules.Where(x => x.CurrentStatus == Status.FlewOut && x.Arrival.DateTime <= Timer.Current);
                arrivalSchedules.AsParallel().ForAll(x =>
                {
                    arrivalStatistic.Statistic.LastFlight = x.Stop();
                    LastSchedule = x;
                });


                departureStatistic.Statistic.LastDayFlight = Schedules.Where(x => x.Departure.DateTime > Timer.Current.AddDays(-1d) && x.Departure.DateTime <= Timer.Current)
                                                                      .Sum(x => x.PassengerCount);
                arrivalStatistic.Statistic.LastDayFlight = Schedules.Where(x => x.Arrival.DateTime > Timer.Current.AddDays(-1d) && x.Arrival.DateTime <= Timer.Current)
                                                                    .Sum(x => x.PassengerCount);

                if (LastUpdate <= Timer.Current.AddHours(-1d))
                {
                    LastUpdate = Timer.Current;

                    histogramView.Add(Timer.Current,
                        Schedules.Where(x => x.Departure.DateTime > Timer.Current.AddHours(-1d) && x.Departure.DateTime <= Timer.Current).Sum(x => x.PassengerCount),
                        Schedules.Where(x => x.Arrival.DateTime > Timer.Current.AddHours(-1d) && x.Arrival.DateTime <= Timer.Current).Sum(x => x.PassengerCount));
                }
            }
        }

    }
}
