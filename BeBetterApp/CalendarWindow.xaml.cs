using System;
using System.Windows;
using Syncfusion.UI.Xaml.Scheduler;

namespace BeBetterApp
{
    public partial class CalendarWindow : Window
    {
        public CalendarWindow()
        {
            InitializeComponent();

            // Globale Termine anzeigen
            scheduler.ItemsSource = GlobalSchedule.SharedSchedule.Termine;

            // Beispiel-Termin hinzufügen (Erinnerung)
            var erinnerung = new ScheduleAppointment
            {
                Subject = "Erinnerung: Trinken nicht vergessen!",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(30),
                Location = "Küche",
                AppointmentBackground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.DarkOrange)
            };

            GlobalSchedule.SharedSchedule.AddTermin(erinnerung);
        }
    }
}
