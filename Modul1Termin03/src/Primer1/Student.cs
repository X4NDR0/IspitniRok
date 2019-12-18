using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer1
{
    //klasa
    class Student
    {
        //atributi
        public int Id;
        public string Ime;
        public string Prezime;
        public string Grad;
        public string Indeks;
        //predmete koje pohađa student
        public string[] Predmeti;

        //metode
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
                for (int i = 0; i < Predmeti.Length; i++)
                {
                    sb.Append("\t" + Predmeti[i] + "\n");
                }
            }
            return sb.ToString();
        }

        public void PostaviNovoIme(string novoIme)
        {
            Ime = novoIme;
        }

        //upozorenje - dvosmislenost identifikatora
        //nije jasno da li se u atribut Ime smešta vrednost
        //prosleđene promenljive ili obratno
        //nešto više o tome u nastavku
        public void PostaviNovoImeIGrad(string Ime, string Grad)
        {
            //Ime = Ime;
            //Grad = Grad;
        }
    }
}
