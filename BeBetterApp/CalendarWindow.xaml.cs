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

            // Termine anzeigen
            scheduler.ItemsSource = GlobalSchedule.SharedSchedule.Termine;
        }

        private void Button_Zurueck_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
