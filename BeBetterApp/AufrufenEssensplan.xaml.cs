using Serilog;
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
    /// Interaction logic for AufrufenEssensplan.xaml
    /// </summary>
    public partial class AufrufenEssensplan : Window
    {
        public AufrufenEssensplan()
        {
            InitializeComponent();

            if (File.Exists("Essensplan.json"))
            {
                string daten = File.ReadAllText("Essensplan.json");
                Log.Verbose("Essensplan wird aufgerufen");
                if (!string.IsNullOrWhiteSpace(daten))
                {
                    Ausgabe.Text = daten;
                }
                else
                {
                    Ausgabe.Text = "Bitte gehen Sie auf Ernährung<Essensplan erstellen< und erstellen sie Ihren eigenen Essensplan!";
                }
            }
            else
            {
                Ausgabe.Text = "Bitte gehen Sie auf Ernährung<Essensplan erstellen< und erstellen sie Ihren eigenen Essensplan!";

            }
        }

        private void Button_zuruck(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

    }
}
