using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Scheduler;
using System.IO;
using System.Linq;
using Newtonsoft.Json;




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

        public void SaveToFile(string path)
        {
            var list = Termine.Select(t => new SerializableAppointment
            {
                Subject = t.Subject,
                StartTime = t.StartTime,
                EndTime = t.EndTime,
                Location = t.Location
            }).ToList();

            File.WriteAllText(path, JsonConvert.SerializeObject(list));
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return;

            var json = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<SerializableAppointment>>(json);

            Termine.Clear();
            foreach (var item in list)
            {
                Termine.Add(new Syncfusion.UI.Xaml.Scheduler.ScheduleAppointment
                {
                    Subject = item.Subject,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Location = item.Location
                });
            }
        }

    }
}
