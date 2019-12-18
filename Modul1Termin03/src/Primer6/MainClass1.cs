using System;
using System.Collections.Generic;
using System.IO;

namespace Modul1Termin03.Primer6
{
    class MainClass1
    {
        public static List<Student> sviStudenti = new List<Student>();
        public static List<IspitniRok> listaIspitnihRokova = new List<IspitniRok>();
        public static List<IspitnePrijave> listaIspitnihPrijava = new List<IspitnePrijave>();
        public static List<Predmet> listaPredmeta = new List<Predmet>();

        public static void Main(String[] args)
        {
            StreamReader srIr = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\ispitni_rokovi.csv");
            string ispitniRokovi = srIr.ReadToEnd();

            string[] ispitniRok = ispitniRokovi.Split('\n');
            IspitniRok ispitniRokObject = null;

            for (int i = 0; i < ispitniRok.Length; i++)
            {
                ispitniRokObject = new IspitniRok(ispitniRok[i]);
                listaIspitnihRokova.Add(ispitniRokObject);
            }

            StreamReader srStudent = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\studenti.csv");
            string studenti = srStudent.ReadToEnd();
            string[] studentSplit = studenti.Split('\n');

            Student student = null;

            for (int i = 0; i < studentSplit.Length; i++)
            {
                student = new Student(studentSplit[i]);
                sviStudenti.Add(student);
            }

            StreamReader sr = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\predmeti.csv");
            string predmeti = sr.ReadToEnd();
            string[] predmetSplit = predmeti.Split('\n');

            Predmet predmet = null;

            for (int i = 0; i < predmetSplit.Length; i++)
            {
                predmet = new Predmet(predmetSplit[i]);
                listaPredmeta.Add(predmet);
            }

            StreamReader srip = new StreamReader("C:\\Users\\XANDRO\\Desktop\\Modul1\\Termin03\\data\\ispitne_prijave.csv");
            string ispitnePrijave = srip.ReadToEnd();
            string[] ispitnePrij = ispitnePrijave.Split('\n');

            IspitnePrijave ispitnePrijaveObject = null;

            for (int i = 0; i < ispitnePrij.Length; i++)
            {
                ispitnePrijaveObject = new IspitnePrijave(ispitnePrij[i]);
                listaIspitnihPrijava.Add(ispitnePrijaveObject);
            }

            sviStudenti.Insert(0, new Student(4, "Miloš ", "Sekulić", "Beograd", "E1 01/2016"));
            IspisiStudente(sviStudenti);

            Console.WriteLine("Ispis ispitnih rokova:");
            IspisiIspite(listaIspitnihRokova);

            Console.WriteLine("Izracunavanje ocene");

            foreach (IspitnePrijave ispitnePrijave1 in listaIspitnihPrijava)
            {
                IspitniRok.IzracunajOcenu(ispitnePrijave1.brojBodovaTeorija, ispitnePrijave1.brojBodovaZadaci);
            }

            Console.WriteLine("Izracuvanja proseka");
            foreach (IspitnePrijave ispitnePrijave2 in listaIspitnihPrijava)
            {
                IspitniRok.IzracunajProsek(ispitnePrijave2.brojBodovaZadaci,ispitnePrijave2.brojBodovaTeorija);
            }

            Console.WriteLine("******************************");
            sviStudenti.RemoveAt(2);
            Console.WriteLine("Broj studenata je:" + sviStudenti.Count);

            sviStudenti.Clear();
            Console.WriteLine("Broj studenata je:" + sviStudenti.Count);

            Console.WriteLine("Zavrsen rad sa listom");

            Console.ReadKey();
        }
        public static void IspisiStudente(List<Student> lista)
        {
            foreach (Student student in lista)
            {
                Console.WriteLine(student.PreuzmiTekstualnuReprezentacijuKlase());
            }
        }

        public static void IspisiIspite(List<IspitniRok> lista)
        {
            foreach (IspitniRok ispitniRok in lista)
            {
                Console.WriteLine("ID:" + ispitniRok.id + " Naziv:" + ispitniRok.naziv + " Pocetak:" + ispitniRok.pocetak + " Kraj:" + ispitniRok.kraj);
            }
        }
    }
}
