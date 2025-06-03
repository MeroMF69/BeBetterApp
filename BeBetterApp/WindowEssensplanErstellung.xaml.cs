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
using System.IO;

namespace BeBetterApp
{
    /// <summary>
    /// Interaction logic for WindowEssensplanErstellung.xaml
    /// </summary>
    public partial class WindowEssensplanErstellung : Window
    {
        public WindowEssensplanErstellung()
        {
            InitializeComponent();
            if (File.Exists("Trainingsplan.js"))
            {
                string jetzigerplan = File.ReadAllText("Trainingsplan.js");

                if (!string.IsNullOrWhiteSpace(jetzigerplan))
                {
                    if (Ausgabe.Text == "" || Ausgabe.Text == null)
                    {
                        Ausgabe.Text = "Es wurde schon ein Plan für sie erstellt! Schauen sie unter 'Gespeichert' im Hauptmenü nach um " +
    "Ihren Trainingsplan zu sehen.";
                    }

                }
            }
            else
            {
                if (Ausgabe.Text == "" || Ausgabe.Text == null)
                {
                    Ausgabe.Text = ("Hier können Sie Ihr Trainingsplan erstellen! Füllen Sie Ihre Daten aus und los gehts!");
                }

            }

            if (Gewicht.Text == "")
            {
                Gewicht.Text = "Gewicht";
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            KIKlasse kI = new KIKlasse();

            Gewicht.Background = null;
            Größe.Background = null;

            bool erlaubniss1 = false;
            bool erlaubniss2 = false;
            bool erlaubniss3 = false;

            try
            {
                int gewicht = int.Parse(Gewicht.Text);
                erlaubniss1 = true;
            }
            catch
            {
                MessageBox.Show("Bitte geben Sie nur Zahlen ein bei der Gewichtseingabe!");
                Gewicht.Background = Brushes.LightCoral;
            }

            try
            {
                int gewicht = int.Parse(Größe.Text);
                erlaubniss2 = true;
            }
            catch
            {
                MessageBox.Show("Bitte geben Sie nur Zahlen win bei der Größeneingabe!");
                Größe.Background = Brushes.LightCoral;
            }

            if (preferänz.Text == null || preferänz.Text == "")
            {
                MessageBox.Show("Bitte wählen Sie Ihre präferenz aus!");
            }
            else
            {
                erlaubniss3 = true;
            }


            if (erlaubniss1 == true && erlaubniss2 == true && erlaubniss3 == true)
            {
                string aufforderung = $"Gib mir ein Essensplan wo ich {preferänz.Text} kann für eine woche. Ich bin {Gewicht.Text} schwer und {Größe.Text}cm groß. Gib nur den Plan nichts dazu schreiben oder so ** hinzufügen ein komplett normaler Text. Danke!";

                kI.Ki(Ausgabe, aufforderung, "Trainingsplan.js");
            }



        }




        private void Gewicht_GotFocus(object sender, RoutedEventArgs e)
        {
            Gewicht.Text = string.Empty;
        }
    }
   }

