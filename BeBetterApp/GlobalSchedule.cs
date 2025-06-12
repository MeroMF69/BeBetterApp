using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeBetterApp
{
    public static class GlobalSchedule
    {
        public static Schedule SharedSchedule { get; } = new Schedule(); // erstellt ein einziges Termin-Objekt, das überall in der App benutzt werden kann.
    }
}
