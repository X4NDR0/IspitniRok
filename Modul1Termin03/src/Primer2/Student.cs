using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer2
{
    //klasa
    class Student
    {
        //atributi tj property-i
        public int Id;
        public string Ime;
        public string Prezime;
        public string Grad;
        public string Indeks;
        //predmete koje pohađa student
        public Predmet[] Predmeti;

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
                    if (Predmeti[i] != null)
                    {
                        sb.Append("\t" + Predmeti[i].PreuzmiTekstualnuReprezentacijuKlase() + "\n");
                    }
                    else
                    {
                        sb.Append("\t /\n");
                    }
                    
                }
            }
            return sb.ToString();
        }

        public void PostaviNovoImeIGrad(string Ime, string Grad)
        {
            this.Ime = Ime;
            this.Grad = Grad;
        }

    }
}
