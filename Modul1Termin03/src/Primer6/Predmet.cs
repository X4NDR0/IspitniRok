using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer6
{
    class Predmet
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        //studenti koje pohađaju predmet
        public List<Student> Studenti { get; set; }

        //konstruktori
        // konstruktor bez parametra
        public Predmet()
        {
            Studenti = new List<Student>();
        }

        //konstruktor sa vise parametara
        public Predmet(int id, String naziv)
        {
            this.Id = id;
            this.Naziv = naziv;
        }

        public Predmet(int id, String naziv, List<Student> studenti)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Studenti = studenti;
        }

        //konstruktor koji popunjava podatke na osnovu očitanog teksta iz fajla predmet.csv
        public Predmet(String tekst)
        {
            StreamReader sr = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\predmeti.csv");

            string predmeti = sr.ReadToEnd();

            string[] predmet2 = predmeti.Split('\n'); 

            String[] tokeni = predmet2[0].Split(',');
            //npr. 		1,Matematika
            //tokeni 	0		1	 

            if (tokeni.Length != 2)
            {
                Console.WriteLine("Greska pri ocitavanju predmeta " + tekst);
                //izlazak iz aplikacije
                Environment.Exit(0);
            }

            Id = Int32.Parse(tokeni[0]);
            Naziv = tokeni[1];
        }

        //metode
        public String PreuzmiTekstualnuReprezentacijuKlase()
        {
            String ispis = "Predmet sa id " + Id + " ima naziv "
                    + Naziv;
            return ispis;
        }

        public String PreuzmiPotpunuTekstualnuReprezentacijuKlase()
        {
            StringBuilder sb = new StringBuilder("Predmet sa id " + Id + " ima naziv "
                    + Naziv);

            if (Studenti != null)
            {
                sb.Append(" i pohađaju ga studenti\n");
                for (int i = 0; i < Studenti.Count; i++)
                {
                     sb.Append("\t" + Studenti[i].PreuzmiTekstualnuReprezentacijuKlase() + "\n");
                }
            }

            return sb.ToString();
        }

        //dva objekta su ista ako imaju isti id
        public bool Isti(Predmet pr)
        {
            bool isti = false;
            if (Id == pr.Id)
            {
                isti = true;
            }
            return isti;
        }
    }
}
