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
        public static List<Nastavnik> listaNastavnika = new List<Nastavnik>();
        public static List<Pohadja> listaPohadjanja = new List<Pohadja>();
        public static List<Predaje> listaPredaje = new List<Predaje>();
        public static string FilePath;
        public static void Main(String[] args)
        {
            CheckPerson();

            LoadStudents();
            LoadPredmete();
            LoadIspitneRokove();
            LoadIspitnePrijave();
            LoadNastavnike();
            LoadPohadja();
            LoadPredaja();

            sviStudenti.Insert(0, new Student(4, "Miloš ", "Sekulić", "Beograd", "E1 01/2016"));
            IspisiStudente(sviStudenti);

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Ispis ispitnih rokova:");
            IspisiIspite(listaIspitnihRokova);
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Ispis predmeta:");
            IspisiPredmete(listaPredmeta);
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Bodovi pretvoreni u ocenu:");

            foreach (IspitnaPrijava ispitnaPrijava in listaIspitnihPrijava)
            {
                ispitnaPrijava.IzracunajOcenu();
            }
            Console.WriteLine("-----------------------------------------");

            double result = Math.Round(listaIspitnihPrijava.Average(x => x.BrojBodovaTeorija + x.BrojBodovaZadaci));

            Console.WriteLine("Izracuvanja proseka:" + result);

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Ispis ispitnih prijava");
            IspisiIspitnePrijave();

            Console.WriteLine("Ispis pohadjanja");
            IspisiPohadjanja();

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Ispis svih nastavnika");
            IspisiNastavnike();

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Ispis predaja");
            IspisiPredaje();

            Console.WriteLine("-----------------------------------------");

            SaveIspitnePrijave();
            SaveIspitneRokove();
            SaveStudents();

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
                Console.WriteLine("ID:" + ispitniRok.ID + " Naziv:" + ispitniRok.Naziv + " Pocetak:" + ispitniRok.Pocetak.ToString("dd/MM/yyyy") + " Kraj:" + ispitniRok.Kraj.ToString("dd/MM/yyyy"));
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
            foreach (IspitnaPrijava ispitnaPrijava in listaIspitnihPrijava)
            {
                Console.WriteLine("Student ID:" + ispitnaPrijava.Student.Id + " Ime studenta:" + ispitnaPrijava.Student.Ime + " Prezime studenta:" + ispitnaPrijava.Student.Prezime + "\n" + "Predmet ID:" + ispitnaPrijava.Predmet.Id + " Naziv predmeta:" + ispitnaPrijava.Predmet.Naziv + "\n" + "Ispitni Rok ID:" + ispitnaPrijava.IspitniRok.ID + "Pocetak:" + ispitnaPrijava.IspitniRok.Pocetak.ToString("dd/MM/yyyy") + " Kraj:" + ispitnaPrijava.IspitniRok.Kraj.ToString("dd/MM/yyyy") + " Naziv ispitnog roka:" + ispitnaPrijava.IspitniRok.Naziv + "\nBroj bodova na zadacima:" + ispitnaPrijava.BrojBodovaZadaci + "\nBroj bodova na teoriji:" + ispitnaPrijava.BrojBodovaTeorija);
                Console.WriteLine("-----------------------------------------");
            }
        }

        public static void IspisiPohadjanja()
        {
            foreach (Pohadja pohadja in listaPohadjanja)
            {
                Console.WriteLine("Student sa imenom:" + pohadja.Student.Ime + " " + pohadja.Student.Prezime + " pohadja predmet:" + pohadja.Predmet.Naziv);
            }
        }

        public static void IspisiNastavnike()
        {
            foreach (Nastavnik nastavnik in listaNastavnika)
            {
                Console.WriteLine("ID:" + nastavnik.NastavnikID + " Ime:" + nastavnik.Ime + " Prezime:" + nastavnik.Prezime + " Znanje:" + nastavnik.Znanje);
            }
        }

        public static void IspisiPredaje()
        {
            foreach (Predaje predaje in listaPredaje)
            {
                Console.WriteLine("Nastavnik sa imenom " + predaje.Nastavnik.Ime + " " + predaje.Nastavnik.Prezime + " predaje predmet:" + predaje.Predmet.Naziv);
            }
        }

        private static void LoadStudents()
        {
            StreamReader citacFajlova = new StreamReader(FilePath + "studenti.csv");
            string podaci = citacFajlova.ReadToEnd();
            string[] studentSplit = podaci.Split('\n');

            Student student = null;

            for (int i = 0; i < studentSplit.Length; i++)
            {
                student = new Student(studentSplit[i]);
                sviStudenti.Add(student);
            }
        }
        private static void LoadPredmete()
        {
            StreamReader citacFajlova = new StreamReader(FilePath + "predmeti.csv");
            string podaci = citacFajlova.ReadToEnd();
            string[] predmetSplit = podaci.Split('\n');

            Predmet predmet = null;

            for (int i = 0; i < predmetSplit.Length; i++)
            {
                predmet = new Predmet(predmetSplit[i]);
                listaPredmeta.Add(predmet);
            }
        }

        private static void LoadIspitnePrijave()
        {
            StreamReader citacFajlova = new StreamReader(FilePath + "ispitne_prijave.csv");
            string podaci = citacFajlova.ReadToEnd();
            string[] ispitnePrijave = podaci.Split('\n');

            IspitnaPrijava ispitnaPrijavaObject = null;

            for (int i = 0; i < ispitnePrijave.Length; i++)
            {
                ispitnaPrijavaObject = new IspitnaPrijava(ispitnePrijave[i], sviStudenti, listaPredmeta, listaIspitnihRokova);
                listaIspitnihPrijava.Add(ispitnaPrijavaObject);
            }
        }

        private static void LoadIspitneRokove()
        {
            StreamReader citacFajlova = new StreamReader(FilePath + "ispitni_rokovi.csv");
            string podaci = citacFajlova.ReadToEnd();

            string[] ispitniRok = podaci.Split('\n');
            IspitniRok ispitniRokObject = null;

            for (int i = 0; i < ispitniRok.Length; i++)
            {
                ispitniRokObject = new IspitniRok(ispitniRok[i]);
                listaIspitnihRokova.Add(ispitniRokObject);
            }
        }

        public static void LoadNastavnike()
        {
            StreamReader citacFajlova = new StreamReader(FilePath + "nastavnici.csv");
            string podaci = citacFajlova.ReadToEnd();

            string[] nastavnici = podaci.Split('\n');
            Nastavnik nastavnikObject = null;

            for (int i = 0; i < nastavnici.Length; i++)
            {
                nastavnikObject = new Nastavnik(nastavnici[i]);
                listaNastavnika.Add(nastavnikObject);
            }
        }

        public static void LoadPohadja()
        {
            StreamReader citacFajlova = new StreamReader(FilePath + "pohadja.csv");
            string podaci = citacFajlova.ReadToEnd();
            string[] pohadja = podaci.Split('\n');

            Pohadja pohadjaObject = null;

            for (int i = 0; i < pohadja.Length; i++)
            {
                pohadjaObject = new Pohadja(pohadja[i], listaPredmeta, sviStudenti);
                listaPohadjanja.Add(pohadjaObject);
            }
        }

        public static void LoadPredaja()
        {
            StreamReader citacFajlova = new StreamReader(FilePath + "predaje.csv");
            string podaci = citacFajlova.ReadToEnd();

            string[] predaje = podaci.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            Predaje predajeObject = null;

            for (int i = 0; i < predaje.Length; i++)
            {
                predajeObject = new Predaje(predaje[i], listaNastavnika, listaPredmeta);
                listaPredaje.Add(predajeObject);
            }
        }

        public static void SaveIspitnePrijave()
        {
            foreach (IspitnaPrijava ispitnaPrijavaa in listaIspitnihPrijava)
            {
                ispitnaPrijavaa.ToFileString(listaIspitnihPrijava);
            }
        }

        public static void SaveIspitneRokove()
        {
            foreach (IspitniRok ispitniRok in listaIspitnihRokova)
            {
                ispitniRok.ToFileString(listaIspitnihRokova);
            }
        }

        public static void SaveStudents()
        {
            foreach (Student student in sviStudenti)
            {
                student.ToFileString(sviStudenti);
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
