﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Modul1Termin03.Primer6
{
    class Pohadja
    { 

        public Pohadja(string podaci,List<Predmet> listaPredmeta,List<Student> listaStudenata)
        {
            string[] text = podaci.Split(',');

            if (text.Length != 2)
            {
                Console.WriteLine("Error while reading!");
            }
            else
            {
                StudentID = Int32.Parse(text[0]);
                PredmetID = Int32.Parse(text[1]);

                Student FindStundent = listaStudenata.Where(x => x.Id == StudentID).FirstOrDefault();
                Predmet FindPredmet = listaPredmeta.Where(x => x.Id == PredmetID).FirstOrDefault();

                Student = FindStundent;
                Predmet = FindPredmet;
            }
        }

        public Student Student;
        public Predmet Predmet;

        public int StudentID;
        public int PredmetID;
    }
}
