using Syncfusion.UI.Xaml.Schedule;
using System.Collections.ObjectModel;
using System.Windows;

using ScheduleNamespace = Syncfusion.UI.Xaml.Schedule;

namespace BeBetterApp
{
    public partial class CalendarWindow : Window
    {
        private ObservableCollection<AppointmentItem> sharedAppointments;

        public CalendarWindow(ObservableCollection<AppointmentItem> appointments)
        {
            InitializeComponent();
            sharedAppointments = appointments;

            LoadAppointmentsFromList();
        }

        private void LoadAppointmentsFromList()
        {
            var appointments = new ScheduleNamespace.ScheduleAppointmentCollection();

            foreach (var appt in sharedAppointments)
            {
                appointments.Add(new ScheduleNamespace.ScheduleAppointment()
                {
                    StartTime = appt.Date,
                    EndTime = appt.Date.AddHours(1),
                    Subject = appt.Text
                });
            }

            scheduler.ItemsSource = appointments; // ItemsSource statt ScheduleAppointments
        }

        public void SyncAppointmentsToMainList()
        {
            sharedAppointments.Clear();

            if (scheduler.ItemsSource is ScheduleNamespace.ScheduleAppointmentCollection appointmentCollection)
            {
                foreach (var appointment in appointmentCollection)
                {
                    sharedAppointments.Add(new AppointmentItem
                    {
                        Date = appointment.StartTime,
                        Text = appointment.Subject ?? "(Keine Beschreibung)"
                    });
                }
            }
        }
    }
}
