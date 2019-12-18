using System;

namespace Modul1Termin03.Primer6
{
    class IspitniRok
    {
        public int ID;
        public string Naziv;
        public DateTime Pocetak;
        public DateTime Kraj;

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
            }
            else
            {
                ID = Int32.Parse(splitter[0]);
                Naziv = splitter[1];
                Pocetak = DateTime.Parse(splitter[2]);
                Kraj = DateTime.Parse(splitter[3]);
            }
        }
    }
}
