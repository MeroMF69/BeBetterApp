using System;
using System.Linq;
using System.Windows.Controls;
using System.Collections.Generic;
using Syncfusion.UI.Xaml.Scheduler;

namespace BeBetterApp
{
    public partial class TerminListe : UserControl
    {
        public TerminListe()
        {
            InitializeComponent();
            DataContext = GlobalSchedule.SharedSchedule; // verbindet die UI mit den Terminen aus GlobalSchedule.SharedSchedule.

        }

        private void LadeNächstenTermin()
        {
            // Sucht den frühesten Termin und gibt dann den frühesten zurück 
            var nächster = GlobalSchedule.SharedSchedule.Termine
                .Where(t => t.StartTime > DateTime.Now)
                .OrderBy(t => t.StartTime)
                .FirstOrDefault(); 

            if (nächster != null)
            {
                // Wenn der Zukünftige Termin gefunden wurde wird er dann im Main angezeigt 
                TerminListControl.ItemsSource = new List<ScheduleAppointment> { nächster };
                HinweisText.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                // Wenn es momentan kein Termin gibt 
                TerminListControl.ItemsSource = null;
                HinweisText.Text = "Im Moment keine Termine.";
                HinweisText.Visibility = System.Windows.Visibility.Visible;
            }
        }

        
        public void Aktualisieren()
        {
            LadeNächstenTermin();
        }



    }
}
