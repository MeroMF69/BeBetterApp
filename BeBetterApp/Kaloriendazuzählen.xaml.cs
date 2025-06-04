using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Kaloriendazuzählen.xaml
    /// </summary>
    public partial class Kaloriendazuzählen : Window
    {
        public int kalorien = 0;

        public Kaloriendazuzählen()
        {
            InitializeComponent();
        }

        private void Button_eingegeben_Click(object sender, RoutedEventArgs e)
        {
            kalorien = int.Parse(textblock_kalorieeneingabe.Text);

            using(StreamReader sr = new StreamReader("Kalorienspeicher.json"))
            {
                sr.ReadLine();
            }


            if (File.Exists("Essensplan.js"))
            {
                using (StreamWriter sw = new StreamWriter("Kalorienspeicher.json"))
                {
                    sw.WriteLine(kalorien);

                }

            }
            else
            {
                using (StreamWriter sw = new StreamWriter("Kalorienspeicher.json"))
                {
                    sw.WriteLine($"0#0#0#0#0#0#{kalorien}%");

                }
            }


        }
    }
}
