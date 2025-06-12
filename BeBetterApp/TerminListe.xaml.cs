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
            TerminListControl.ItemsSource = GlobalSchedule.SharedSchedule.Termine;
            
        }

        private void LadeNächstenTermin()
        {
            var nächster = GlobalSchedule.SharedSchedule.Termine
                .Where(t => t.StartTime > DateTime.Now)
                .OrderBy(t => t.StartTime)
                .FirstOrDefault(); // nur der früheste zukünftige Termin

            if (nächster != null)
            {
                TerminListControl.ItemsSource = new List<ScheduleAppointment> { nächster };
            }
            else
            {
                // Option: leere Liste oder Hinweis anzeigen
                TerminListControl.ItemsSource = null;
            }
        }

        // Falls du später manuell aktualisieren willst
        public void Aktualisieren()
        {
            LadeNächstenTermin();
        }
    }
}
