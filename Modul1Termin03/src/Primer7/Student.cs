using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer7
{
    //klasa
    class Student
    {
        //atributi tj property-i
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        //konstruktori
        
        // konstruktor bez parametra
        public Student()
        {

        }

        //konstruktor sa vise parametara
        public Student(int id, String ime, String prezime)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
        }

        public override string ToString()
        {
            return "Student: " + Ime + " " + Prezime;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Student))
                return false;
            Student s = (Student)obj;
            return this.Id == s.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Ime.GetHashCode() ^ Prezime.GetHashCode();
        }

    }
}
