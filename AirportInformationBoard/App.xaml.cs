using AirportInformationBoard.Models;
using AirportInformationBoard.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AirportInformationBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        protected override void OnStartup(StartupEventArgs e)
        {
            LoadSchedule();

            App.Current.DispatcherUnhandledException += DispatcherUnhandledException;

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            cancellationTokenSource.Cancel();

            base.OnExit(e);
        }

        private void DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"{e.Exception} \r\n {e.Exception.InnerException}");
        }

        private async void LoadSchedule()
        {
            try
            {
                var text = await File.ReadAllTextAsync(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Schedules"), cancellationTokenSource.Token);
                var shedules = Serializator<List<Schedule>>.DeSerializeFromString(text);
            }
            catch(Exception e)
            {
                MessageBox.Show($"{e} \r\n {e.InnerException}");
            }
        }
    }
}
