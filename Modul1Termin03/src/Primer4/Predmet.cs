using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer4
{
    class Predmet
    {
        public int Id;
        public string Naziv;
        //studenti koje pohađaju predmet
        public Student[] Studenti;

        //konstruktori
        // konstruktor bez parametra
        public Predmet()
        {
            Studenti = new Student[30];
        }

        //konstruktor sa vise parametara
        public Predmet(int id, String naziv)
        {
            this.Id = id;
            this.Naziv = naziv;
        }

        public Predmet(int id, String naziv, Student[] studenti)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Studenti = studenti;
        }

        //konstruktor koji popunjava podatke na osnovu očitanog teksta iz fajla predmet.csv
        public Predmet(String tekst)
        {
            String[] tokeni = tekst.Split(',');
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
            Studenti = new Student[30];
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
                for (int i = 0; i < Studenti.Length; i++)
                {
                    if (Studenti[i] != null)
                    {
                        sb.Append("\t" + Studenti[i].PreuzmiTekstualnuReprezentacijuKlase() + "\n");
                    }
                    else
                    {
                        sb.Append("\t /\n");
                    }
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
