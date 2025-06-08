using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeBetterApp
{
    public class Kalorienanzhalprotag
    {
        public int Tag1 { get; set; }
        public int Tag2 { get; set; }
        public int Tag3 { get; set; }
        public int Tag4 { get; set; }
        public int Tag5 { get; set; }
        public int Tag6 { get; set; }
        public int Tag7 { get; set; }
        public DateOnly Tag { get; set; }



        public void DeserializeFromCsv(string data)
        {
            string[] dataSplit = data.Split('#');

            Tag7 = int.Parse(dataSplit[0]);
            Tag6 = int.Parse(dataSplit[1]);
            Tag5 = int.Parse(dataSplit[2]);
            Tag4 = int.Parse(dataSplit[3]);
            Tag3 = int.Parse(dataSplit[4]);
            Tag2 = int.Parse(dataSplit[5]);
            Tag1 = int.Parse(dataSplit[6]);
            Tag = DateOnly.Parse(dataSplit[7]);

        }

    }
}
