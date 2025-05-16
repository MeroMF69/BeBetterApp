using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BeBetterApp
{
    public class Trainingseinheit
    {
        public string Übung;
        public int Sätze;
        public int Wiederholungen;

        Trainingseinheit(string übung, int sätze, int wiederholungen)
        {
            this.Übung = übung ;
            this.Sätze= sätze ;
            this.Wiederholungen = wiederholungen ;
        }
    }


}
