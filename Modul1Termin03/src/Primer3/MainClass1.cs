using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul1Termin03.Primer3.Podprimer1; //privi način identifikacije: using blok

namespace Modul1Termin03.Primer3
{
    class MainClass1
    {
        public static void Main(String[] args)
        {
            
            /////////////modifikatorima pristupa

            //pozivanje konstruktora bez parametra
            AccessModifiersClass ob1 = new AccessModifiersClass();

            //identifikacija na osnovu prostora imena (namespace)
            //Modul1Termin03.Primer3.Podprimer1.AccessModifiersClass ob1 = new Modul1Termin03.Primer3.Podprimer1.AccessModifiersClass();

            //atribut1 je public, dozvoljen pristup u istom assembly a i drugom
            ob1.Atribut1 = "javno";

            //atribut2 je protected, dozvoljen pristup u istoj klasi ili strukturi, a i u klasama naslednicama
            //ob1.Atribut2 = "zasticeno";

            //modifikator pristupa nije definisan za atribut3 pa se primenjuje podrazumevana vrednost za određeni tip - u ovom slučaju je private za tip string
            //ob1.Atribut3 = "nedefinisano";

            //atribut4 je private, dozvoljen pristup samo u istoj klasi ili strukturi
            //ob1.Atribut4 = "privatno";

            //ako je metoda public poziv je moguc uvek iz bilo koje klase
            ob1.PublicMetoda1();

            //ako je metoda protected poziv je moguc samo u okviru klasa koje nasledjuju ili u okviru klasa iz istog paketa
            //		ob1.protectedMogucPoziv();

            //ako je metoda private poziv je moguc samo u okviru same klase u kojoj je metoda napisana
            //		ob1.privateNemogucPoziv();
            ob1.PublicMetoda2();

            Console.WriteLine("Zavrsen rad sa modifikatorima pristupa");
            Console.WriteLine("-------------------------------------------");
            Console.ReadKey();
        }
    }
}
