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
    /// Interaction logic for WindowTrainingsplanerstellung.xaml
    /// </summary>
    public partial class WindowTrainingsplanerstellung : Window
    {
        public WindowTrainingsplanerstellung()
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
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            KIKlasse kI = new KIKlasse();
            kI.Ki(Ausgabe);

        }
    }
}
