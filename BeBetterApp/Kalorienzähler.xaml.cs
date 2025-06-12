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
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;


namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for Kalorienzähler.xaml
    /// </summary>
    public partial class Kalorienzähler : Window
    {
        public ISeries[] Series { get; set; }

        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }

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
            YAxes = new Axis[]
            {
                new Axis
                {
                    MinLimit = 0, // Damit werden keine negativen Werte angezeigt
                    
                }
            };


            XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = new[] { "Vor 6 Tagen", "Vor 5 Tgaen", "Vor 4 Tagen", "Vor 3 Tagen", "Vor 2 Tagen", "Gestern", "Heute" },
                    
                }
            };

            InitializeComponent();
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
            WindowSelect windowSelect = new WindowSelect();
            windowSelect.Show();
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
