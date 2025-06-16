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
using System.Windows;




namespace BeBetterApp
{
    public class Schedule
    {
        // Liste mit allen Terminen
        public ObservableCollection<ScheduleAppointment> Termine { get; set; }

        // Konstruktor
        public Schedule()
        {
            Termine = new ObservableCollection<ScheduleAppointment>(); // Am anfang Termin Liste leer wenn ein neues schedule-Objekt erstellt wird 
            LoadFromFile_("termine.json"); // Wird von der Json Datei geladen 
        }

        // Termin hinzufügen
        public void AddTermin(ScheduleAppointment termin)
        {
            
            SaveToFile("termine.json"); // Speichere ins file
        }

        // Termin entfernen
        public void RemoveTermin(ScheduleAppointment termin)
        {
            
            Termine.Remove(termin); // Entfernt den Termin aus der Liste 
            SaveToFile("termine.json"); // Speichert die Aktulisierte Liste in die Datei 
        }

        // Alle Termine abrufen => Gibt ganze Liste zurück 
        public ObservableCollection<ScheduleAppointment> GetAlleTermine()
        {
            return Termine;
        }

        public void SaveToFile(string path)
        {
            // Wandelt jeden Termin in eine vereinfachte Form um (damit man ihn als Text speichern kann).
            var list = Termine.Select(t => new SerializableAppointment
            {
                Subject = t.Subject,
                StartTime = t.StartTime,
                EndTime = t.EndTime,
                Location = t.Location
            }).ToList();

            File.WriteAllText(path, JsonConvert.SerializeObject(list)); // Speichert die Termine Daten als JSON (Text)
        }

        public void LoadFromFile_(string path) // Lädt Daten aus aus der Datei
        {
            Termine.Clear(); //cleart liste das sie leer ist

            if (!File.Exists(path)) return; // Wenn Daten nicht gibt => abbruch 


            var json = File.ReadAllText(path); // Liest den Text aus der Datei
            var list = JsonConvert.DeserializeObject<List<SerializableAppointment>>(json); // wandelt den Text in Termin Daten um 


            // Fügt alle geladenen Termine wieder in die Liste ein => damit sie im Kalender angezeigt werden.
            foreach (var item in list) 
            {
                Termine.Add(new Syncfusion.UI.Xaml.Scheduler.ScheduleAppointment
                {
                    Subject = item.Subject,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Location = item.Location,
                });
            }
        }

    }
}
