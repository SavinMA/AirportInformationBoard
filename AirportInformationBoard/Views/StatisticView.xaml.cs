using AirportInformationBoard.Models;
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
    /// Interaction logic for Statistic.xaml
    /// </summary>
    public partial class StatisticView : UserControl
    {
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(UIElement), new PropertyMetadata("Количество пассажиров"));

        public string HeaderText
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public Statistic Statistic { get; set; } = new Statistic();
        public StatisticView()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
