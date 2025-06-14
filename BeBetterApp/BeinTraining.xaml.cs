using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfAnimatedGif;

namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for BeinTraining.xaml
    /// </summary>
    public partial class BeinTraining : UserControl
    {
        private readonly BitmapImage[] _gifs = new BitmapImage[5];

        public BeinTraining()
        {
            InitializeComponent();
            Log.Information("BeinTraining geladen");

            for (int i = 0; i < 4; i++)
            {
                try
                {
                    string filename = GetFilename(i);
                    _gifs[i] = new BitmapImage(new Uri($"pack://application:,,,/BeBetterApp;component/GIFs/Bein-Training/{filename}"));
                    Log.Debug($"GIF {i + 1} geladen: {filename}");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Fehler beim Laden von Bein-GIF {i + 1}");
                }
            }

            ImageBehavior.SetAnimatedSource(GifImage1, _gifs[0]);
            ImageBehavior.SetAutoStart(GifImage1, false);

            ImageBehavior.SetAnimatedSource(GifImage2, _gifs[1]);
            ImageBehavior.SetAutoStart(GifImage2, false);

            ImageBehavior.SetAnimatedSource(GifImage3, _gifs[2]);
            ImageBehavior.SetAutoStart(GifImage3, false);

            ImageBehavior.SetAnimatedSource(GifImage4, _gifs[3]);
            ImageBehavior.SetAutoStart(GifImage4, false);

            
        }

        private string GetFilename(int index)
        {
            return index switch
            {
                0 => "HorizontalLegPress.gif",
                1 => "LegExtension.gif",
                2 => "LegPress(45-Degree).gif",
                3 => "LyingLegCurl.gif",
                _ => throw new ArgumentOutOfRangeException(nameof(index), "Invalid GIF index")
            };
        }


        private void GifImage1_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bein GIF 1 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage1)?.Play();
        }
        private void GifImage1_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bein GIF 1 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage1)?.Pause();
        }

        private void GifImage2_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bein GIF 2 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage2)?.Play();
        }
        private void GifImage2_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bein GIF 2 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage2)?.Pause();
        }

        private void GifImage3_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bein GIF 3 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage3)?.Play();
        }
        private void GifImage3_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bein GIF 3 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage3)?.Pause();
        }

        private void GifImage4_MouseEnter(object sender, MouseEventArgs e)
        {
            Log.Debug("Bein GIF 4 gestartet (MouseEnter)");
            ImageBehavior.GetAnimationController(GifImage4)?.Play();
        }
        private void GifImage4_MouseLeave(object sender, MouseEventArgs e)
        {
            Log.Debug("Bein GIF 4 pausiert (MouseLeave)");
            ImageBehavior.GetAnimationController(GifImage4)?.Pause();
        }

    }
}
