using System;

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
            }
            else
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

        public static void IzracunajOcenu(int zadaci, int teorija)
        {
            int rezultat = (zadaci + teorija);
            if (rezultat <= 50)
            {
                Console.WriteLine("5");
                IspitnePrijave.ocenaHelp = 5;
            }
            else if (rezultat < 65 && rezultat > 50)
            {
                Console.WriteLine("6");
                IspitnePrijave.ocenaHelp = 6;
            }
            else if (rezultat < 75 && rezultat > 65)
            {
                Console.WriteLine("7");
                IspitnePrijave.ocenaHelp = 7;
            }
            else if (rezultat < 85 && rezultat > 75)
            {
                Console.WriteLine("8");
                IspitnePrijave.ocenaHelp = 8;
            }
            else if (rezultat < 95 && rezultat > 85)
            {
                Console.WriteLine("9");
                IspitnePrijave.ocenaHelp = 9;
            }
            else if (rezultat < 100 && rezultat > 95)
            {
                Console.WriteLine("10");
                IspitnePrijave.ocenaHelp = 10;
            }
        }

        public static void IzracunajProsek(int teorija, int zadaci)
        {
            double rezultat = teorija + zadaci;
            double help = rezultat / 2;
            Console.WriteLine("Prosecan broj bodova je:" + help);
        }
    }
}
