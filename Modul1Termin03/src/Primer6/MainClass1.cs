using Modul1Termin03.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;

namespace Modul1Termin03.Primer6
{
    class MainClass1
    {
        public static List<Student> sviStudenti = new List<Student>();
        public static List<IspitniRok> listaIspitnihRokova = new List<IspitniRok>();
        public static List<IspitnaPrijava> listaIspitnihPrijava = new List<IspitnaPrijava>();
        public static List<Predmet> listaPredmeta = new List<Predmet>();
        public static string FilePath;
        public static void Main(String[] args)
        {
            CheckPerson();

            LoadStudents();
            LoadPredmete();
            LoadIspitneRokove();
            LoadIspitnePrijave();

            sviStudenti.Insert(0, new Student(4, "Miloš ", "Sekulić", "Beograd", "E1 01/2016"));
            IspisiStudente(sviStudenti);

            Console.WriteLine("Ispis ispitnih rokova:");
            IspisiIspite(listaIspitnihRokova);

            Console.WriteLine("Ispis predmeta:");
            IspisiPredmete(listaPredmeta);

            Console.WriteLine("Izracunavanje ocene");

            foreach (IspitnaPrijava ispitnaPrijava in listaIspitnihPrijava)
            {
                ispitnaPrijava.IzracunajOcenu();
            }

            double result = Math.Round(listaIspitnihPrijava.Average(x => x.BrojBodovaTeorija + x.BrojBodovaZadaci));

            Console.WriteLine("Izracuvanja proseka");

            Console.WriteLine(result);

            Console.WriteLine("Ispis ispitnih prijava");
            IspisiIspitnePrijave();

            Console.WriteLine("******************************");
            sviStudenti.RemoveAt(2);
            Console.WriteLine("Broj studenata je:" + sviStudenti.Count);

            sviStudenti.Clear();
            Console.WriteLine("Broj studenata je:" + sviStudenti.Count);

            Console.WriteLine("Zavrsen rad sa listom");

            Console.ReadKey();
        }

        private static void IspisiStudente(List<Student> lista)
        {
            foreach (Student student in lista)
            {
                Console.WriteLine(student.PreuzmiTekstualnuReprezentacijuKlase());
            }
        }

        private static void IspisiIspite(List<IspitniRok> lista)
        {
            foreach (IspitniRok ispitniRok in lista)
            {
                Console.WriteLine("ID:" + ispitniRok.ID + " Naziv:" + ispitniRok.Naziv + " Pocetak:" + ispitniRok.Pocetak + " Kraj:" + ispitniRok.Kraj);
            }
        }

        private static void IspisiPredmete(List<Predmet> lista)
        {
            foreach (Predmet predmet in lista)
            {
                Console.WriteLine("ID:" + predmet.Id + " Naziv:" + predmet.Naziv);
            }
        }

        public static void IspisiIspitnePrijave()
        {
            foreach (IspitnaPrijava isp in listaIspitnihPrijava)
            {
                Console.WriteLine("Student ID:" + isp.StudentID + " Ime studenta:" + isp.Student.Ime + " Prezime studenta:" + isp.Student.Prezime + "\n" + "Predmet ID:" + isp.PredmetID + " Naziv predmeta:" + isp.Predmet.Naziv + "\n" + "Ispitni Rok ID:" + isp.IspitniRokID + " Naziv ispitnog roka:" + isp.IspitniRok.Naziv + " Pocetak ispitnog roka:" + isp.IspitniRok.Pocetak + " Kraj ispitnog roka:" + isp.IspitniRok.Kraj);
            }
        }

        private static void LoadStudents()
        {
            StreamReader srStudent = new StreamReader(FilePath + "studenti.csv");
            string studenti = srStudent.ReadToEnd();
            string[] studentSplit = studenti.Split('\n');

            Student student = null;

            for (int i = 0; i < studentSplit.Length; i++)
            {
                student = new Student(studentSplit[i]);
                sviStudenti.Add(student);
            }
        }
        private static void LoadPredmete()
        {
            StreamReader sr = new StreamReader(FilePath + "predmeti.csv");
            string predmeti = sr.ReadToEnd();
            string[] predmetSplit = predmeti.Split('\n');

            Predmet predmet = null;

            for (int i = 0; i < predmetSplit.Length; i++)
            {
                predmet = new Predmet(predmetSplit[i]);
                listaPredmeta.Add(predmet);
            }
        }

        private static void LoadIspitnePrijave()
        {
            StreamReader srip = new StreamReader(FilePath + "ispitne_prijave.csv");
            string ispitnePrijave = srip.ReadToEnd();
            string[] ispitnePrij = ispitnePrijave.Split('\n');

            IspitnaPrijava ispitnePrijaveObject = null;

            for (int i = 0; i < ispitnePrij.Length; i++)
            {
                ispitnePrijaveObject = new IspitnaPrijava(ispitnePrij[i]);
                listaIspitnihPrijava.Add(ispitnePrijaveObject);
            }
        }

        private static void LoadIspitneRokove()
        {
            StreamReader srIr = new StreamReader(FilePath + "ispitni_rokovi.csv");
            string ispitniRokovi = srIr.ReadToEnd();

            string[] ispitniRok = ispitniRokovi.Split('\n');
            IspitniRok ispitniRokObject = null;

            for (int i = 0; i < ispitniRok.Length; i++)
            {
                ispitniRokObject = new IspitniRok(ispitniRok[i]);
                listaIspitnihRokova.Add(ispitniRokObject);
            }
        }

        private static void CheckPerson()
        {
            if (WindowsIdentity.GetCurrent().Name.StartsWith("MILOSH"))
            {
                FilePath = AppConfig.Milos;
                return;
            }
            FilePath = AppConfig.Aleksandar;
        }
    }
}
