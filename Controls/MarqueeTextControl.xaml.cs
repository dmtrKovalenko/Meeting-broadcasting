using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Media.Animation;

namespace thurst_media_player.Controls
{
    /// <summary>
    /// Логика взаимодействия для MarqueeTextControl.xaml
    /// </summary>
    public partial class MarqueeText : UserControl
    {
        public static readonly DependencyProperty MarqueeContentProperty =
         DependencyProperty.Register("MarqueeContent", typeof(string), typeof(MarqueeText), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty IsMarquingProperty =
         DependencyProperty.Register("IsMarquing", typeof(bool), typeof(MarqueeText), new UIPropertyMetadata(false));

        public string MarqueeContent
        {
            get { return (string)GetValue(MarqueeContentProperty); }
            set
            {
                SetValue(MarqueeContentProperty, value);
                tbmarquee.Text = value;
            }
        }

        public bool IsMarquing
        {
            get { return (bool)GetValue(IsMarquingProperty); }
            set { SetValue(IsMarquingProperty, value); }
        }

        private double _marqueeTimeInSeconds;

        public double MarqueeTimeInSeconds
        {
            get { return _marqueeTimeInSeconds; }
            set
            {
                _marqueeTimeInSeconds = value;
            }
        }

        public MarqueeText()
        {
            InitializeComponent();
            canMain.Width = this.Width;
            this.Loaded += new RoutedEventHandler(MarqueeText_Loaded);
            canMain.Height = this.Height;
        }

        void MarqueeText_Loaded(object sender, RoutedEventArgs e)
        {
            RightToLeftMarquee();
        }

        private void RightToLeftMarquee()
        {
            if (!IsMarquing)
            {
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                this.Visibility = Visibility.Visible;
                DoubleAnimation doubleAnimation = new DoubleAnimation();
                doubleAnimation.From = -canMain.ActualWidth;
                doubleAnimation.To = canMain.ActualWidth;
                doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
                doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(_marqueeTimeInSeconds));
                tbmarquee.BeginAnimation(Canvas.RightProperty, doubleAnimation);
            }
        }
    }
}

