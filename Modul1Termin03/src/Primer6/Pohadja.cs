using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer6
{
    class Pohadja
    {
        public Pohadja(string podaci)
        {
            string[] text = podaci.Split(',');

            if (text.Length != 2)
            {
                Console.WriteLine("Error while reading!");
            }else
            {
                StudentID = Int32.Parse(text[0]);
                PredmetID = Int32.Parse(text[1]);
            }
        }

        public int StudentID;
        public int PredmetID;
    }
}
