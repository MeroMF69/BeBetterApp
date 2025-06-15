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
using Serilog;
using System.Globalization;


namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for Kalorienzähler.xaml
    /// </summary>
    public partial class Kalorienzähler : Window
    {
        public ISeries[] Series { get; set; } // enthält Daten

        public Axis[] XAxes { get; set; }  // beschriftung von der x achse
        public Axis[] YAxes { get; set; } // beschriftung con y achse

        DateTime heute = DateTime.Today;

        DayOfWeek wochentag = DateTime.Today.DayOfWeek;

        public Kalorienzähler()
        {
            Kaloriendazuzählen kdz = new Kaloriendazuzählen();
            kdz.stats();


            Log.Verbose("Diagram wird erstellt");

            DateTime gestern = heute.AddDays(-1);
            DateTime Vor2Tagen = heute.AddDays(-2);
            DateTime Vor3Tagen = heute.AddDays(-3);
            DateTime Vor4Tagen = heute.AddDays(-4);
            DateTime Vor5Tagen = heute.AddDays(-5);
            DateTime Vor6Tagen = heute.AddDays(-6);

            var de = new CultureInfo("de-DE");



            Series = new ISeries[]
            {
                new LineSeries<int>
                {
                    Values = kdz.kalorientage
                }
            }; // LineSeries<int> erzeugt eine Linien-Reihe mit ganzzahligen Werten.
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
                    Labels = new[] { $"{Vor6Tagen.ToString("dddd", de)}", $"{Vor5Tagen.ToString("dddd", de)}", $"{Vor4Tagen.ToString("dddd", de)}", $"{Vor3Tagen.ToString("dddd", de)}", $"{Vor2Tagen.ToString("dddd", de)}", $"{gestern.ToString("dddd", de)}", $"{heute.ToString("dddd", de)}" },
                    
                }
            };

            Log.Verbose("Diagram wurde erstellt");
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
            Ernaerungselect ernaerungselect = new Ernaerungselect();
            ernaerungselect.Show();
        }

        public void UpdateChart()
        {
            Log.Verbose("Diagram wurde geupdated");
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
