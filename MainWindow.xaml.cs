using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.ComponentModel;

namespace thurst_media_player
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private MediaPlayer _player = new MediaPlayer();
        private MediaTimeline _line;
        private string _attentionText;
        private bool _isLoaded;
        private string _threadURL = "http://air.radiorecord.ru:8102/yo_320";
        private double _lastVolumeValue;

        public MainWindow()
        {
            InitializeComponent();

            _line = new MediaTimeline(new Uri(_threadURL));
            _player.Clock = _line.CreateClock(true) as MediaClock;
            _isLoaded = new bool();
            _lastVolumeValue = new double();

            _player.MediaFailed += Player_Failed;
            _player.Clock.CurrentTimeInvalidated += Clock_TimeInvalidated;
            _player.BufferingStarted += Player_BufferingStarted;
            _player.BufferingEnded += Player_BufferingEnded;
            _player.Clock.CurrentStateInvalidated += Clock_StateInvalidated;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public bool IsLoading
        {
            get
            {
                return _isLoaded;
            }
            set
            {
                _isLoaded = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public string AttentionText
        {
            get
            {
                return _attentionText;
            }
            set
            {
                _attentionText = value;
                OnPropertyChanged(nameof(AttentionText));
            }
        }

        public void LoadTimerAnimation()
        {
            play.IsEnabled = false;
            IsLoading = true;
            DispatcherTimer loadingTimer = new DispatcherTimer();
            loadingTimer.Interval = new TimeSpan(0, 0, 0, 1);
            loadingTimer.Tick += (s, e) =>
            {
                IsLoading = false;
                loadingTimer.IsEnabled = false;
                play.IsEnabled = true;
            };
            loadingTimer.Start();
        }

        public async Task CheckConnectionAsync()
        {
            await Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke(async () =>
                {
                    if (await ConnectivityChecker.CheckInternetConnectionAsync(_threadURL) == false)
                    {
                        marqueeAttention.IsMarquing = true;
                        StopAnimation();
                        play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/play-icon.png")));

                        if (await ConnectivityChecker.CheckInternetConnectionAsync() == false)
                        {
                            marqueeAttention.MarqueeContent = "Please, check your connection to Internet, for reconnection press play";
                        }
                        else
                        {
                            marqueeAttention.MarqueeContent = "Sorry, now broadcasting is not available, for reconnection press play";
                        }
                    }
                    else
                    {
                        marqueeAttention.IsMarquing = false;
                        StartAnimation();
                    }
                        
                });
            });
        }

        private void Clock_StateInvalidated(object sender, EventArgs e)
        {
           
        }

        private void Player_BufferingEnded(object sender, EventArgs e)
        {
            IsLoading = false;
        }

        private async void Player_BufferingStarted(object sender, EventArgs e)
        {
            IsLoading = true;
            await CheckConnectionAsync();
        }

        private async void Player_Failed(object sender, EventArgs e1)
        {
            await CheckConnectionAsync();
            _player.Clock.Controller.Stop();
            StopAnimation();
        }

        private void Player_Started(object sender, EventArgs e)
        {
            play.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/pause-icon.png", UriKind.RelativeOrAbsolute)));
            StartAnimation();
        }

        private void StartAnimation()
        {
            DoubleAnimation marqueeOpacity = new DoubleAnimation(1, 0, new TimeSpan(0, 0, 0, 1), FillBehavior.Stop);
            ThicknessAnimation titleAnimation = new ThicknessAnimation(new Thickness(45, 2, 0, 0.5), new TimeSpan(0, 0, 1), FillBehavior.Stop);
            marqueeOpacity.Completed += (s, e) =>
            {
                marqueeAttention.IsMarquing = false;
                title.BeginAnimation(MarginProperty, titleAnimation);
            };
            marqueeAttention.BeginAnimation(OpacityProperty, marqueeOpacity);
        }

        private void StopAnimation()
        {
            ThicknessAnimation titleAnimation = new ThicknessAnimation(new Thickness(45, -40, 0, 0.5), new TimeSpan(0, 0, 1), FillBehavior.HoldEnd);
            title.BeginAnimation(MarginProperty, titleAnimation);
        }

        private void Clock_TimeInvalidated(object sender, EventArgs e)
        {
            if (_player.Clock.CurrentTime != null)
            {
                Duration.Content = _player.Clock.CurrentTime.Value.ToString(_player.Clock.CurrentTime.Value.Hours < 1 ? "mm\\:ss" : "hh\\:mm\\:ss");
            }
        }

        private async void play_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush content = play.Background as ImageBrush;
            if (_player.Clock.IsPaused)
            {
                _player.Clock.Controller.Resume();
                content.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/pause-icon.png", UriKind.RelativeOrAbsolute));
            }
            else if (_player.Clock.CurrentState == ClockState.Stopped) //if player failed or not created ClockState will be set to "stopped"
            {
                await CheckConnectionAsync();
                _player.Clock = _line.CreateClock(true) as MediaClock;
                _player.Clock.CurrentTimeInvalidated += Clock_TimeInvalidated;
            }
            else
            {
                _player.Clock.Controller.Pause();
                content.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/play-icon.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void mute_Click(object sender, RoutedEventArgs e)
        {
            if (!_player.IsMuted)
            {
                _lastVolumeValue = volumeSlider.Value;
                _player.IsMuted = true;
                volumeSlider.Value = 0;

                mute.Content = Application.Current.Resources["MuteIcon"];
            }
            else
            {
                _player.IsMuted = false;
                volumeSlider.Value = _lastVolumeValue;

                mute.Content = Application.Current.Resources["VolumeIcon"];
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _player.Volume = volumeSlider.Value;
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _player.Close();
        }

    }
}
