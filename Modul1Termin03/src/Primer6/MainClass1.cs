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

            Console.WriteLine("Izracunavanje ocene");

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
                Console.WriteLine("Student ID:" + isp.StudentID + " Ime studenta:" + isp.Student.Ime + " Prezime studenta:" + isp.Student.Prezime + "\n" + "Predmet ID:" + isp.PredmetID + " Naziv predmeta:" + isp.Predmet.Naziv + "\n" + "Ispitni Rok ID:" + isp.IspitniRokID + "Pocetak:" + isp.IspitniRok.Pocetak.ToString("dd/MM/yyyy") + " Kraj:" + isp.IspitniRok.Kraj.ToString("dd/MM/yyyy") + " Naziv ispitnog roka:" + isp.IspitniRok.Naziv + "\nBroj bodova na zadacima:" + isp.BrojBodovaZadaci + "\nBroj bodova na teoriji:" + isp.BrojBodovaTeorija);
                Console.WriteLine("-----------------------------------------");
            }
        }

        public static void IspisiPohadjanja()
        {
            foreach (Pohadja pohadja in listaPohadjanja)
            {
                Console.WriteLine("Student sa id-om:" + pohadja.StudentID + " pohadja predmet pod ID-om:" + pohadja.PredmetID);
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
                Console.WriteLine("Nastavnik sa ID-om:" + predaje.NastavnikID + " predaje predmet pod ID-om:" + predaje.PredmetID);
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

        public static void LoadNastavnike()
        {
            StreamReader sr = new StreamReader(FilePath + "nastavnici.csv");
            string nastavnici = sr.ReadToEnd();

            string[] nastavnik = nastavnici.Split('\n');
            Nastavnik nastavnikObject = null;

            for (int i = 0; i < nastavnik.Length; i++)
            {
                nastavnikObject = new Nastavnik(nastavnik[i]);
                listaNastavnika.Add(nastavnikObject);
            }
        }

        public static void LoadPohadja()
        {
            StreamReader sr = new StreamReader(FilePath + "pohadja.csv");
            string info = sr.ReadToEnd();
            string[] pohadja = info.Split('\n');

            Pohadja pohadjaObject = null;

            for (int i = 0; i < pohadja.Length; i++)
            {
                pohadjaObject = new Pohadja(pohadja[i]);
                listaPohadjanja.Add(pohadjaObject);
            }
        }

        public static void LoadPredaja()
        {
            StreamReader sr = new StreamReader(FilePath + "predaje.csv");
            string text = sr.ReadToEnd();

            string[] predaje = text.Split('\n');

            //string[] predaje = text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            Predaje predajeObject = null;

            for (int i = 0; i < predaje.Length; i++)
            {
                predajeObject = new Predaje(predaje[i]);
                listaPredaje.Add(predajeObject);
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
