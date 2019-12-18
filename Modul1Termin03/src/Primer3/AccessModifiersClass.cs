using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin03.Primer3.Podprimer1
{
    class AccessModifiersClass
    {
        //modifikatori pristupa, sta koji znaci?
        public string Atribut1 { get; set; }
        protected string Atribut2 { get; set; }
        string Atribut3 { get; set; }
        private string atribut4;
        internal int Atribut5 { get; set; }

        protected internal string Atribut4
        {
            get { return atribut4; }
            set { atribut4 = value; }
        }

        public void PublicMetoda1()
        {
            atribut4 = "!";
            Console.WriteLine("PublicMetoda() - moguc poziv"+atribut4);
        }

        protected void ProtectedMetoda()
        {
            Console.WriteLine("ProtectedMetoda() - moguc poziv");
        }

        private void PrivateMetoda()
        {
            Console.WriteLine("PrivateMetoda() - nemoguc poziv van klase");
        }

        public void PublicMetoda2()
        {
            Console.WriteLine("Moguć poziv privatne metode u okviru public metode");
            PrivateMetoda();
        }

    }
}
