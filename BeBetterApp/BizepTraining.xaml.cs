using Serilog;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace BeBetterApp
{
    public partial class BizepTraining : UserControl
    {
        private BitmapImage[] _gifs = new BitmapImage[9];

        public BizepTraining()
        {
            InitializeComponent();
            Log.Information("BizepTraining geladen");

            // GIF laden
            for (int i = 0; i < 9; i++)
            {
                try
                {
                    string filename = $"{i + 1}.{GetFilename(i)}";
                    _gifs[i] = new BitmapImage(new Uri($"pack://application:,,,/BeBetterApp;component/GIFs/Bizep-Training/{filename}"));
                    Log.Debug($"GIF {i + 1} geladen: {filename}");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Fehler beim Laden von Bizep-GIF {i + 1}");
                }
            }

            // GIFs in Images einfügen und pausieren
            ImageBehavior.SetAnimatedSource(GifImage1, _gifs[0]);
            ImageBehavior.SetAutoStart(GifImage1, false);

            ImageBehavior.SetAnimatedSource(GifImage2, _gifs[1]);
            ImageBehavior.SetAutoStart(GifImage2, false);

            ImageBehavior.SetAnimatedSource(GifImage3, _gifs[2]);
            ImageBehavior.SetAutoStart(GifImage3, false);

            ImageBehavior.SetAnimatedSource(GifImage4, _gifs[3]);
            ImageBehavior.SetAutoStart(GifImage4, false);

            ImageBehavior.SetAnimatedSource(GifImage5, _gifs[4]);
            ImageBehavior.SetAutoStart(GifImage5, false);

            ImageBehavior.SetAnimatedSource(GifImage6, _gifs[5]);
            ImageBehavior.SetAutoStart(GifImage6, false);

            ImageBehavior.SetAnimatedSource(GifImage7, _gifs[6]);
            ImageBehavior.SetAutoStart(GifImage7, false);

            ImageBehavior.SetAnimatedSource(GifImage8, _gifs[7]);
            ImageBehavior.SetAutoStart(GifImage8, false);

            ImageBehavior.SetAnimatedSource(GifImage9, _gifs[8]);
            ImageBehavior.SetAutoStart(GifImage9, false);
        }

        private string GetFilename(int index)
        {
            return index switch
            {
                0 => "BarbellBicepCurl.gif",
                1 => "HammerCurls.gif",
                2 => "Preacher Curls.gif",
                3 => "Chin-ups.gif",
                4 => "Chin-ups.gif", 
                5 => "InclineDumbbellCurls.gif",
                6 => "ZottmanCurls.gif",
                7 => "Reverse Grip Barbell Curls.gif",
                8 => "SpiderCurls.gif",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void GifImage1_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 1 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage1)?.Play();
        }

        private void GifImage1_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 1 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage1)?.Pause();
        }

        private void GifImage2_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 2 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage2)?.Play();
        }

        private void GifImage2_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 2 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage2)?.Pause();
        }

        private void GifImage3_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 3 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage3)?.Play();
        }

        private void GifImage3_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 3 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage3)?.Pause();
        }

        private void GifImage4_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 4 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage4)?.Play();
        }

        private void GifImage4_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 4 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage4)?.Pause();
        }

        private void GifImage5_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 5 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage5)?.Play();
        }

        private void GifImage5_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 5 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage5)?.Pause();
        }

        private void GifImage6_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 6 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage6)?.Play();
        }

        private void GifImage6_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 6 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage6)?.Pause();
        }

        private void GifImage7_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 7 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage7)?.Play();
        }

        private void GifImage7_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 7 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage7)?.Pause();
        }

        private void GifImage8_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 8 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage8)?.Play();
        }

        private void GifImage8_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 8 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage8)?.Pause();
        }

        private void GifImage9_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 9 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage9)?.Play();
        }

        private void GifImage9_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bizep GIF 9 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage9)?.Pause();
        }

    }
}
