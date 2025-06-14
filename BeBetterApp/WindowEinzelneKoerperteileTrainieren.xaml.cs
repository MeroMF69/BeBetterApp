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
            Log.Information("Fenster 'Einzelne Körperteile' geöffnet");


        }


        private void Button_Click_Brust(object sender, RoutedEventArgs e)
        {
            Log.Information("Brust-Training geöffnet");
            RightContentArea.Content = new BrustTraining();
        }

        private void Button_Click_Bizep(object sender, RoutedEventArgs e)
        {
            Log.Information("Bizep-Training geöffnet");
            RightContentArea.Content = new BizepTraining();
        }

        private void Button_Click_Trizep(object sender, RoutedEventArgs e)
        {
            Log.Information("Trizep-Training geöffnet");
            RightContentArea.Content = new TrizepTraining();
        }

        private void Button_Click_Schulter(object sender, RoutedEventArgs e)
        {
            Log.Information("Schulter-Training geöffnet");
            RightContentArea.Content = new SchulterTraining();
        }

        private void BauchMuskel_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("Bauch-Training geöffnet");
            RightContentArea.Content = new BauchmuskelTraining();
        }

        private void Button_zuruck(object sender, RoutedEventArgs e)
        {
            Log.Information("Fenster Einzelkörper-Trainieren wurde geschlossen");
            this.Close();
            WindowSelect windowSelect = new WindowSelect();
            windowSelect.Show();
        }

        private void Button_Click_Bein(object sender, RoutedEventArgs e)
        {
            Log.Information("Bein-Training geöffnet");
            RightContentArea.Content = new BeinTraining();
        }
    }
}
