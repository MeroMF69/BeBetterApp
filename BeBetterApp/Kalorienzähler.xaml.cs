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




            //using (StreamWriter sw = new StreamWriter(Kalorienspeicher.js))
            {
            //    sw.WriteLine(save); 

            }


            //string inhalt = File.ReadAllText(Speicherort);


            InitializeComponent();

            Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] {1000000, 4, 6, 3, 2, 6 }
                }
            };




            DataContext = this;
        }

        private void Button_Tagadden_Click(object sender, RoutedEventArgs e)
        {
            Kaloriendazuzählen kaloriendazuzählen = new Kaloriendazuzählen();
            kaloriendazuzählen.Show();


        }

        private void Button_zurück_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
