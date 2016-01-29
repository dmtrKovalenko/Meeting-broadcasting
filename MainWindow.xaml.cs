using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace thurst_media_player
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer _player = new MediaPlayer();
        MediaTimeline _line = new MediaTimeline();
        public string _threadURL = Properties.Resources.ThreadURL;

        public MainWindow()
        {
            InitializeComponent();           
            CheckConnection();

            _line = new MediaTimeline(new Uri(_threadURL));
            _player.Clock = _line.CreateClock(true) as MediaClock;

            _player.MediaFailed += Player_Failed;
            _player.BufferingStarted += Player_Started;
            _player.Clock.CurrentTimeInvalidated += Clock_TimeChanged;
        }

        public void CheckConnection()
        {
            if (!InternetConnection.IsInternetConnection(_threadURL))
            {
                Dispatcher.BeginInvoke(new Action(() => error.Visibility = Visibility.Visible));

                if (!InternetConnection.IsInternetConnection("https://www.google.co.in/"))
                {
                    Dispatcher.BeginInvoke(new Action(() => attention.Text = "Пожалуйста проверьте подключение к интернету, для переподключения нажмите play"));
                }
                else
                    Dispatcher.BeginInvoke(new Action(() => attention.Text = "Извините, в данный момент трансляции нету, для повторного подключения нажмите play")); 
            }
        }

        private void Player_Failed (object sender, EventArgs e)
        {
            new Thread(() => CheckConnection()).Start();
            _player.Clock.Controller.Stop();
        }

        private void Player_Started(object sender, EventArgs e)
        {
            error.Visibility = Visibility.Hidden;
            attention.Text = "";
        }

        private void Clock_TimeChanged(object sender, EventArgs e)
        {
            Duration.Content = _player.Clock.CurrentTime.ToString();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            if (_player.Clock.IsPaused)
            {
                _player.Clock.Controller.Resume();
            }
            else if (_player.Clock.CurrentState == System.Windows.Media.Animation.ClockState.Stopped)
            {
                _player.Clock = _line.CreateClock(true) as MediaClock;
                _player.Clock.CurrentTimeInvalidated += Clock_TimeChanged;
            }
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            _player.Clock.Controller.Pause();
        }

        private void mute_Click(object sender, RoutedEventArgs e)
        {
            if (!_player.IsMuted)
            {
                _player.IsMuted = true;

                mute.Content = Application.Current.Resources["MuteIcon"];
            }
            else
            {
                _player.IsMuted = false;

                mute.Content = Application.Current.Resources["VolumeIcon"];
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _player.Volume = slider.Value;
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _player.Close();
        }
    }
}
