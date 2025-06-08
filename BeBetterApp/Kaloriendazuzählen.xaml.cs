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
        public int[] kalorientage = new int[7];
        DateOnly heute = DateOnly.FromDateTime(DateTime.Now);
        Kalorienanzhalprotag kl = new Kalorienanzhalprotag();

        public Kaloriendazuzählen()
        {
            InitializeComponent();
        }

        private void Button_eingegeben_Click(object sender, RoutedEventArgs e)
        {
            kalorien = int.Parse(textblock_kalorieeneingabe.Text);

            stats();
            kalorientage[6] = kalorientage[6]+kalorien;

            using (StreamWriter sw = new StreamWriter("Kalorienspeicher.json"))
            {
                sw.WriteLine($"{kalorientage[0]}#{kalorientage[1]}#{kalorientage[2]}#{kalorientage[3]}#{kalorientage[4]}#{kalorientage[5]}#{kalorientage[6]}#{heute}");

            }
            this.DialogResult = true;
            this.Close();
            

        }

        public void stats()
        {



            if (File.Exists("Kalorienspeicher.json"))
            {
                using (StreamReader sr = new StreamReader("Kalorienspeicher.json"))
                {




                    string data = sr.ReadLine();
                    kl.DeserializeFromCsv(data);
                }
                    if (kl.Tag == heute)
                    {
                        kalorientage[0] = kl.Tag7;
                        kalorientage[1] = kl.Tag6;
                        kalorientage[2] = kl.Tag5;
                        kalorientage[3] = kl.Tag4;
                        kalorientage[4] = kl.Tag3;
                        kalorientage[5] = kl.Tag2;
                        kalorientage[6] = kl.Tag1;
                    }
                    else
                    {
                        kalorientage[0] = kl.Tag6;
                        kalorientage[1] = kl.Tag5;
                        kalorientage[2] = kl.Tag4;
                        kalorientage[3] = kl.Tag3;
                        kalorientage[4] = kl.Tag2;
                        kalorientage[5] = kl.Tag1;
                        kalorientage[6] = 0;

                        using (StreamWriter sw = new StreamWriter("Kalorienspeicher.json"))
                        {
                            sw.WriteLine($"{kl.Tag6}#{kl.Tag5}#{kl.Tag4}#{kl.Tag3}#{kl.Tag2}#{kl.Tag1}#0#{heute}");

                        }
                    }
                    
                



            }
            else
            {
                using (StreamWriter sw = new StreamWriter("Kalorienspeicher.json"))
                {
                    sw.WriteLine($"0#0#0#0#0#0#{kalorien}#{heute}");

                }
            }
            
        }
    }
}
