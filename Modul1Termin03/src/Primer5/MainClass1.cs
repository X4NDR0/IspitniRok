using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer5
{
    class MainClass1
    {
        static void Main(string[] args)
        {
            //prvi način kreiranja strukture
            Grad mesto;
            mesto.Naziv = "Loznica";
            mesto.PostanskiBroj = 15300;

            //drugi način
            //Grad mesto = new Grad("Loznica", 15300);
            //mesto.Naziv = "Novi Sad";
            
            //niz struktura
            Grad[] gradovi = new Grad[10];
            gradovi[0] = mesto;
            //...

            // u promenljivu mesto2 se smesta kopija strukture a ne referenca
            Grad mesto2 = gradovi[0];
            // mesto2 i gradovi[0] su odvojeni objekti, ne uticu jedan na drugog

            Student student1 = new Student();
            //1,E2 01/2016,Jevrić,Srđan,Loznica
            student1.Id = 1;
            student1.Indeks = "E2 01/2016";
            student1.Prezime = "Jevrić";
            student1.Ime = "Srđan";
            student1.Mesto = gradovi[0]; //kopiranje vrednosnog tipa

            //Nije moguće menjati vrednosni tip jer se menja kopija a to nema smisla
            //student1.Mesto.Naziv = "Novi Sad";
            Console.WriteLine(student1.PreuzmiTekstualnuReprezentacijuKlase());

            Console.ReadKey();
        }
    }
}
