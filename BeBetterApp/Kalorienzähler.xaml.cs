using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
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
using OpenAI.Chat;
using System.IO;

namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for Kalorienzähler.xaml
    /// </summary>
    public partial class Kalorienzähler : Window
    {
        public ISeries[] Series { get; set; }

        public Kalorienzähler()
        {

            Kaloriendazuzählen kdz = new Kaloriendazuzählen();
            kdz.stats();

            Series = new ISeries[]
            {
        new LineSeries<int>
        {
            Values = kdz.kalorientage
        }
            };

            

            InitializeComponent();
            DataContext = this;




            DataContext = this;
        }

        private void Button_Tagadden_Click(object sender, RoutedEventArgs e)
        {
            Kaloriendazuzählen kaloriendazuzählen = new Kaloriendazuzählen();
            if (kaloriendazuzählen.ShowDialog() == true)
            {

                UpdateChart();
            }
        }

        private void Button_zurück_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void UpdateChart()
        {
            Kaloriendazuzählen kdz = new Kaloriendazuzählen();
            kdz.stats();

            Series = new ISeries[]
            {
            new LineSeries<int>
            {
            Values = kdz.kalorientage
            }
            };

            DataContext = null; 
            DataContext = this;
        }
    }
}
