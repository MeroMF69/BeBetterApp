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
    /// Interaction logic for SchulterTraining.xaml
    /// </summary>
    public partial class SchulterTraining : UserControl
    {

        private BitmapImage[] _gifs = new BitmapImage[9];

        public SchulterTraining()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                string filename = GetFilename(i);
                _gifs[i] = new BitmapImage(new Uri($"pack://application:,,,/BeBetterApp;component/GIFs/SchulterMuskel-Trainieren/{filename}"));

            }

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
        }

        private string GetFilename(int index)
        {
            return index switch
            {
                0 => "1.SeatedBent-OverLateralRaise.gif",
                1 => "2.BarbellRow.gif",
                2 => "3.One-ArmDumbbellFrontRaise.gif",
                3 => "4.DumbbellShoulderPress.gif",
                4 => "5.SeatedDumbbellShoulderPress.gif",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void GifImage1_MouseEnter(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage1)?.Play();
        private void GifImage1_MouseLeave(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage1)?.Pause();

        private void GifImage2_MouseEnter(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage2)?.Play();
        private void GifImage2_MouseLeave(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage2)?.Pause();

        private void GifImage3_MouseEnter(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage3)?.Play();
        private void GifImage3_MouseLeave(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage3)?.Pause();

        private void GifImage4_MouseEnter(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage4)?.Play();
        private void GifImage4_MouseLeave(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage4)?.Pause();

        private void GifImage5_MouseEnter(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage5)?.Play();
        private void GifImage5_MouseLeave(object sender, MouseEventArgs e) => ImageBehavior.GetAnimationController(GifImage5)?.Pause();
    }
    
}
