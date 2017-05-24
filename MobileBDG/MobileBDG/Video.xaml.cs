using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileBDG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Video : ContentPage
    {
        private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;

        public Video()
        {
            InitializeComponent();
            ProgressBar.Progress = 0;

            CrossMediaManager.Current.PlayingChanged += async (sender, e) =>
            {
                //ProgressBar
                double valor = (e.Progress * 100) / e.Duration.TotalSeconds;
                String entrada = valor.ToString();
                double db = Double.Parse(entrada.Replace(',', '.'));
                await ProgressBar.ProgressTo(valor * 6, 1000, Easing.Linear);
                //Label mostrando tempo
                int duration = e.Duration.TotalSeconds > 0 ? Convert.ToInt32(e.Duration.TotalSeconds) : 0;
                int position = e.Position.TotalSeconds > 0 ? Convert.ToInt32(e.Position.TotalSeconds) : 0;
                Duration.Text = GetFormattedTime(position) + " / " + GetFormattedTime(duration);
            };
        }

        public string GetFormattedTime(int value)
        {
            var span = TimeSpan.FromMilliseconds(value);
            if (span.Hours > 0)
            {
                return string.Format("{0}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);
            }
            else
            {
                return string.Format("{0}:{1:00}", (int)span.Minutes, span.Seconds);
            }
        }

        void PrevClicked(object sender, System.EventArgs e)
        {
            PlaybackController.PlayPrevious();
        }

        void PlayClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Play();
            btnPause.IsVisible = true;
            btnPlay.IsVisible = false;
        }

        void PauseClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Pause();
            btnPause.IsVisible = false;
            btnPlay.IsVisible = true;
        }

        void NextClicked(object sender, System.EventArgs e)
        {
            PlaybackController.PlayNext();
        }
    }
}
