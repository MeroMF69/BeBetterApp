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
using System.Windows.Shapes;

namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for WindowEinzelneKoerperteileTrainieren.xaml
    /// </summary>
    public partial class WindowEinzelneKoerperteileTrainieren : Window
    {
        public WindowEinzelneKoerperteileTrainieren()
        {
            InitializeComponent();


          
        }

        

        private void Button_Click_Brust(object sender, RoutedEventArgs e)
        {
            RightContentArea.Content = new BrustTraining();
        }

        private void Button_Click_Bizep(object sender, RoutedEventArgs e)
        {
            RightContentArea.Content = new BizepTraining();
        }

        private void Button_Click_Trizep(object sender, RoutedEventArgs e)
        {
            RightContentArea.Content = new TrizepTraining();
        }

        private void Button_Click_Schulter(object sender, RoutedEventArgs e)
        {
            RightContentArea.Content = new SchulterTraining();
        }

        private void BauchMuskel_Click(object sender, RoutedEventArgs e)
        {
            RightContentArea.Content = new BauchmuskelTraining();
        }
    }
}
