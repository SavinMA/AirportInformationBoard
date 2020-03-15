using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirportInformationBoard.Views
{
    /// <summary>
    /// Interaction logic for AnimatedTextBlock.xaml
    /// </summary>
    public partial class AnimatedTextBlock : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(AnimatedTextBlock), new PropertyMetadata("0", new PropertyChangedCallback(OnTextChanged)));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as AnimatedTextBlock).BeginStoryboard((d as AnimatedTextBlock).Resources["TextChangeAnimation"] as Storyboard);
        }

        public AnimatedTextBlock()
        {
            InitializeComponent();
        }
    }
}
