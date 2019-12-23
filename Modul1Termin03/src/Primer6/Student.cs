using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer6
{
    class Student
    {
        public Student(int id, String ime, String prezime, String grad, String indeks)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Grad = grad;
            this.Indeks = indeks;

        }
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Grad { get; set; }
        public string Indeks { get; set; }

        public List<Predmet> Predmeti { get; set; }
        public Student(String tekst)
        {
            String[] tokeni = tekst.Split(',');

            if (tokeni.Length != 5)
            {
                Console.WriteLine("Greska pri ocitavanju studenta " + tekst);
                Environment.Exit(0);
            }

            Id = Int32.Parse(tokeni[0]);
            Indeks = tokeni[1];
            Prezime = tokeni[2];
            Ime = tokeni[3];
            Grad = tokeni[4];
        }

        public string PreuzmiTekstualnuReprezentacijuKlase()
        {
            String ispis = "Student sa id " + Id + " čije je ime i prezime "
                    + Ime + " " + Prezime + " ima indeks " + Indeks + " i zivi u gradu " + Grad;
            return ispis;
        }

        public string PreuzmiPotpunuTekstualnuReprezentacijuKlase()
        {
            StringBuilder sb = new StringBuilder("Student sa id " + Id + " čije je ime i prezime "
                    + Ime + " " + Prezime + " ima indeks " + Indeks + " i zivi u gradu " + Grad);

            if (Predmeti != null)
            {
                sb.Append(" i pohađa predmete\n");
                for (int i = 0; i < Predmeti.Count; i++)
                {
                    sb.Append("\t" + Predmeti[i].PreuzmiTekstualnuReprezentacijuKlase() + "\n");
                }
            }
            return sb.ToString();
        }

        public bool Isti(Student pr)
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
