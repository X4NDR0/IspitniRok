using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer6
{
    class IspitniRok
    {

        public IspitniRok()
        {

        }

        public IspitniRok(String data)
        {
            string[] splitter = data.Split(',');
            if (splitter.Length != 4)
            {
                Console.WriteLine("I'm can't read the file,sorry.");
                Environment.Exit(0);
            }else
            {
                id = Int32.Parse(splitter[0]);
                naziv = splitter[1];
                pocetak = DateTime.Parse(splitter[2]);
                kraj = DateTime.Parse(splitter[3]);
            }
        }

        public int id;
        public string naziv;
        public DateTime pocetak;
        public DateTime kraj;
    }
}
