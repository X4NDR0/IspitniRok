using System;
using System.Collections.Generic;
using System.IO;

namespace Modul1Termin03.Primer6
{
    class IspitniRok
    {

        public IspitniRok(string data)
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

        public int ID;
        public string Naziv;
        public DateTime Pocetak;
        public DateTime Kraj;

        public string PreuzmiTekstualnuReprezentacijuKlase()
        {
            string text = ID + "," + Naziv + "," + Pocetak.ToString("yyyy/MM/dd") + "," + Kraj.ToString("yyyy/MM/dd");
            return text;
        }

        public void ToFileString(List<IspitniRok> lista)
        {
            StreamWriter recorder = new StreamWriter("C:\\Users\\XANDRO\\Desktop\\ispitniRok.txt");
            foreach (IspitniRok ispitniRok in lista)
            {
                recorder.WriteLine(ispitniRok.PreuzmiTekstualnuReprezentacijuKlase());
            }
            recorder.Close();
        }
    }
}
