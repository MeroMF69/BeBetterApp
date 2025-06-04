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
    /// Interaction logic for BizepTraining.xaml
    /// </summary>
    public partial class BizepTraining : UserControl
    {
        public BizepTraining()
        {
            InitializeComponent();


            var gif1 = new Uri("pack://application:,,,/BeBetterApp;component/Icons/BizepsKabelzug.gif");
            var gif2 = new Uri("pack://application:,,,/BeBetterApp;component/Icons/BizepTraining.gif");

            ImageBehavior.SetAnimatedSource(GifImage1, new BitmapImage(gif1));
            ImageBehavior.SetAnimatedSource(GifImage2, new BitmapImage(gif2));
        }
    }
}
