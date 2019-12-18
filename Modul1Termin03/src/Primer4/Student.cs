using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer4
{
    //klasa
    class Student
    {
        //atributi tj property-i
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Grad { get; set; }
        //public string Indeks { get; set; }

        //umesto interfejsnog property-ia
        //moze se definisati putpuni eproperty - sa get/st blokom
        private string indeks;

        public string Indeks
        {
            get { return indeks; }
            set { indeks = value; }
        }


        //predmete koje pohađa student
        public Predmet[] Predmeti { get; set; }
        
        //konstruktori

        // konstruktor bez parametra
        public Student()
        {
            Predmeti = new Predmet[3];
        }

        //konstruktor sa vise parametara
        public Student(int id, String ime, String prezime, String grad, String indeks)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Grad = grad;
            this.Indeks = indeks;
            Predmeti = new Predmet[3];
        }

        public Student(int id, String ime, String prezime, String grad, String indeks, Predmet[] predmeti)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Grad = grad;
            this.Indeks = indeks;
            this.Predmeti = predmeti;
        }

        //konstruktor koji popunjava podatke na osnovu očitanog teksta iz fajla studenti.csv
        public Student(String tekst)
        {
            String[] tokeni = tekst.Split(',');
            //npr. 		1,E2 01/2016,Jevrić,Srđan,Loznica
            //tokeni 	0		1		2		3			4

            if (tokeni.Length != 5)
            {
                Console.WriteLine("Greska pri ocitavanju studenta " + tekst);
                //izlazak iz aplikacije
                Environment.Exit(0);
            }

            Id = Int32.Parse(tokeni[0]);
            Indeks = tokeni[1];
            Prezime = tokeni[2];
            Ime = tokeni[3];
            Grad = tokeni[4];
            Predmeti = new Predmet[3];
        }

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

        //dva objekta su ista ako imaju isti id
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
