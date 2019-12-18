using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer2
{
    class Predmet
    {
        public int Id;
        public string Naziv;
        //studenti koje pohađaju predmet
        public Student[] Studenti;

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
    }
}
