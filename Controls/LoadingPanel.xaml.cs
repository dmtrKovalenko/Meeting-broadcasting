using System.Windows;
using System.Windows.Input;

namespace thurst_media_player.Controls
{
    /// <summary>
    /// Interaction logic for LoadingPanel.xaml
    /// </summary>
    public partial class LoadingPanel
    {
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(LoadingPanel), new UIPropertyMetadata(false));

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(LoadingPanel), new UIPropertyMetadata("Loading..."));

        public static readonly DependencyProperty SubMessageProperty =
            DependencyProperty.Register("SubMessage", typeof(string), typeof(LoadingPanel), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty ClosePanelCommandProperty =
            DependencyProperty.Register("ClosePanelCommand", typeof(ICommand), typeof(LoadingPanel));

        public LoadingPanel()
        {
            InitializeComponent();
        }

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

    }
}