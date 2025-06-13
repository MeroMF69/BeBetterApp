using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeBetterApp
{
    // Die Klasse SerializableAppointment speichert einfache Termindaten, damit man sie als Text (JSON) speichern und laden kann.
    class SerializableAppointment
    {
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }
}
