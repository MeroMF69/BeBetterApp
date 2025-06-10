using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Scheduler;


namespace BeBetterApp
{
    public class Schedule
    {
        // Öffentliche Liste der Termine
        public ObservableCollection<ScheduleAppointment> Termine { get; set; }

        // Konstruktor
        public Schedule()
        {
            Termine = new ObservableCollection<ScheduleAppointment>();
        }

        // Termin hinzufügen
        public void AddTermin(ScheduleAppointment termin)
        {
            Termine.Add(termin);
        }

        // Termin entfernen
        public void RemoveTermin(ScheduleAppointment termin)
        {
            Termine.Remove(termin);
        }

        // Alle Termine abrufen
        public ObservableCollection<ScheduleAppointment> GetAlleTermine()
        {
            return Termine;
        }
    }
}
