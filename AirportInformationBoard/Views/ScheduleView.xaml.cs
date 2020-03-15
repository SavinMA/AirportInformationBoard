using AirportInformationBoard.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirportInformationBoard.Views
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        public static readonly DependencyProperty ScheduleProperty = DependencyProperty.Register("Schedule", typeof(Schedule), typeof(ScheduleView)); 

        public Schedule Schedule
        {
            get { return (Schedule)GetValue(ScheduleProperty); }
            set { SetValue(ScheduleProperty, value); }
        }

        public ScheduleView()
        {
            InitializeComponent();
        }
    }

    [ValueConversion(typeof(Status), typeof(string))]
    public class ScheduleStatusToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return ((Status)value) switch
                {
                    Status.Waiting => "Ожидает",
                    Status.FlewIn => "Прилетел",
                    Status.FlewOut => "Вылетел",
                };
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
