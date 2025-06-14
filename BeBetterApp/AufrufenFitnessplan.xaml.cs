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
    /// Interaction logic for AufrufenFitnessplan.xaml
    /// </summary>
    public partial class AufrufenFitnessplan : Window
    {
        public AufrufenFitnessplan()
        {
            InitializeComponent();

            if (File.Exists("Trainingsplan.json"))
            {
                string daten = File.ReadAllText("Trainingsplan.json");
                Log.Verbose("Trainingsplan wird aufgerufen");
                if (!string.IsNullOrWhiteSpace(daten))
                {
                    Ausgabe.Text = daten;
                }
                else
                {
                    Ausgabe.Text = "Bitte gehen Sie auf Fitness<Trainingsplan erstellen< und erstellen sie Ihren eigenen Trainingsplan!";
                }
            }
            else
            {

                    Ausgabe.Text = "Bitte gehen Sie auf Fitness<Trainingsplan erstellen< und erstellen sie Ihren eigenen Trainingsplan!";
                
            }
        }


        private void Button_zuruck(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
