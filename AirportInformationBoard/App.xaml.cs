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
        protected override void OnStartup(StartupEventArgs e)
        {
            App.Current.DispatcherUnhandledException += DispatcherUnhandledException;

            base.OnStartup(e);
        }

        private void DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"{e.Exception} \r\n {e.Exception.InnerException}");
        }
    }
}
