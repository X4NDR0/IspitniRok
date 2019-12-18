using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer5
{
    //struktura
    public struct Grad
    {
        public string Naziv;
        public int PostanskiBroj;

        public Grad(string naziv, int postanskiBroj)
        {
            this.Naziv = naziv;
            this.PostanskiBroj = postanskiBroj;
        }

        //metode
        public string PreuzmiTekstualnuReprezentacijuStrukture()
        {
            return Naziv + " sa poštanskim brojem " + PostanskiBroj;
        }
    };
    //klasa
    class Student
    {
        //atributi tj property-i
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Grad Mesto { get; set; }
        public string Indeks { get; set; }

        //konstruktori
        
        // konstruktor bez parametra
        public Student()
        {

        }

        //konstruktor sa vise parametara
        public Student(int id, String ime, String prezime, Grad mesto, String indeks)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Mesto = mesto;
            this.Indeks = indeks;
        }

        //metode
        public string PreuzmiTekstualnuReprezentacijuKlase()
        {
            String ispis = "Student sa id " + Id + " čije je ime i prezime "
                    + Ime + " " + Prezime + " ima indeks " + Indeks + " i zivi u gradu " + Mesto.PreuzmiTekstualnuReprezentacijuStrukture();
            return ispis;
        }

    }
}
