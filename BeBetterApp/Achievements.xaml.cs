using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for Achievements.xaml
    /// </summary>
    public partial class Achievements : Window
    {
        public Achievements()
        {
            InitializeComponent();
            int punkte = 0;
            if (File.Exists("Daten.json"))
            {
                string daten = File.ReadAllText("Daten.json");
                Log.Verbose("Daten.json werden in achivements aufgerufen");
                if (!string.IsNullOrWhiteSpace(daten))
                {
                    string[] dataSplit = daten.Split('#');


                    punkte = int.Parse(dataSplit[1]);

                }
            }
            if (punkte > 7000)
            {
                Label_Leistung1.Content = "Du hast Bronze gemeistert!";
            }
            if (punkte > 31000)
            {
                Label_Leistung2.Content = "Du hast Silber gemeistert!";
            }
            if (punkte > 610000)
            {
                Label_Leistung3.Content = "Du bist Meister!";
            }



        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
