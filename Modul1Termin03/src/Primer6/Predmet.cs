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
        public List<Student> Studenti { get; set; }

        public Predmet()
        {
            Studenti = new List<Student>();
        }

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

        public Predmet(String tekst)
        {
            String[] tokeni = tekst.Split(',');

            if (tokeni.Length != 2)
            {
                Console.WriteLine("Greska pri ocitavanju predmeta " + tekst);
                Environment.Exit(0);
            }

            Id = Int32.Parse(tokeni[0]);
            Naziv = tokeni[1];
        }

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
