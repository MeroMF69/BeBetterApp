using System;
using System.Windows;
using Serilog;
using Syncfusion.UI.Xaml.Scheduler;

namespace BeBetterApp
{
    public partial class CalendarWindow : Window
    {
        public CalendarWindow()
        {
            InitializeComponent();
            // Log.Information("CalendarWindow geöffnet");

            // Termine anzeigen
            scheduler.ItemsSource = GlobalSchedule.SharedSchedule.Termine;
        }

        private void Button_Zurueck_Click(object sender, RoutedEventArgs e)
        {
            // Log.Information("Kalender wurde geschlossen");
            this.Close();
        }


    }
}
