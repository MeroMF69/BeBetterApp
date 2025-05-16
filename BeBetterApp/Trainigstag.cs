using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BeBetterApp
{
    public class Trainigstag
    {
        public string Tag;
        Trainingseinheit Trainingseinheit;

        Trainigstag(string tag, Trainingseinheit trainingseinheit)
        {
            this.Tag = tag;
            this.Trainingseinheit = trainingseinheit;
        }
    }
}
