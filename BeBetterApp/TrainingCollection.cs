using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeBetterApp
{
    public class TrainingCollection
    {
        public List<Trainigstag> TrainigstagList = new List<Trainigstag>();

        TrainingCollection() { }

        public void Add(Trainigstag Trainigstag)
        {
            TrainigstagList.Add(Trainigstag);
        }

        public void serialize()
        {

        }

    }


}
