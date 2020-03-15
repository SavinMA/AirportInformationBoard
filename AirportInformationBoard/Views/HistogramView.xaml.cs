using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace AirportInformationBoard.Views
{
    /// <summary>
    /// Interaction logic for HistogramView.xaml
    /// </summary>
    public partial class HistogramView : UserControl
    {
        public ChartValues<int> Departures { get; set; } = new ChartValues<int>();
        public ChartValues<int> Arrivals { get; set; } = new ChartValues<int>();
        public List<string> Times { get; set; } = new List<string>();
        public HistogramView()
        {
            InitializeComponent();
            DataContext = this;
            var startTime = DateTime.Now.AddDays(-1d);

            for(int i=0;i<24;i++)
            {
                Add(startTime, 0, 0);
                startTime = startTime.AddHours(1d);
            }
        }

        public void Add(DateTime current, int departures, int arrivals)
        {
            if (Departures.Count > 23)
                Departures.RemoveAt(0);
            if (Arrivals.Count > 23)
                Arrivals.RemoveAt(0);
            if (Times.Count > 23)
                Times.RemoveAt(0);

            Departures.Add(departures);
            Arrivals.Add(arrivals);
            Times.Add($"{current.AddHours(-1d).ToString("HH")} - {current.ToString("HH\r\ndd.MM.yyyy")}");
        }
    }
}
