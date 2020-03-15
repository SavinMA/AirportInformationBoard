using System;
using System.Collections.Generic;
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
    /// Interaction logic for DateTimeView.xaml
    /// </summary>
    public partial class DateTimeView : UserControl
    {
        public static readonly DependencyProperty DateTimeProperty = DependencyProperty.Register("DateTimeProp", typeof(DateTime), typeof(DateTimeView), new PropertyMetadata(DateTime.Now));
        public static readonly DependencyProperty IsAnimatedProperty = DependencyProperty.Register("IsAnimated", typeof(bool), typeof(DateTimeView), new PropertyMetadata(true));

        public DateTime DateTimeProp
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }

        public bool IsAnimated
        {
            get { return (bool)GetValue(IsAnimatedProperty); }
            set { SetValue(IsAnimatedProperty, value); }
        }

        public DateTimeView()
        {
            InitializeComponent();
        }
    }
}
