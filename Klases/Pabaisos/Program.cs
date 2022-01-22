using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pabaisos
{
    internal class Program
    {
        class Pabaisa 
        {
            private string pav;                 //pabaisos pavadinimas
            private int ragai;                  // ragų kiekis vienetais
            private int uodegos;                // uodegų kiekis vienetais
            private int amžius;                 // pabaisos amžius
            public Pabaisa(string pav, int ragai, int uodegos, int amžius)
            {
                this.pav = pav;
                this.ragai = ragai;
                this.uodegos = uodegos;
                this.amžius = amžius;
            }
            /** Grąžina pavadinimą*/
            public string imtiPav() { return pav; }
            /** Grąžina ragų kiekį*/
            public int imtiRagus() { return ragai; }
            /** Grąžina uodegų kiekį*/
            public int imtiUodegas() { return uodegos; }
            /** Grąžina upabaisos amžių*/
            public int imtiAmžių() { return amžius; }
        }
        class Studentas
        {
            private string vardas;                 //Studento vardas
            private int ragųtrof;                   //Ragų trofėjai
            private int uodegųtrof;                 //Uodegų trofėjai
            public Studentas(string vardas, int ragųtrof, int uodegųtrof)
            {
                this.vardas = vardas;
                this.ragųtrof = ragųtrof;
                this.uodegųtrof = uodegųtrof;
            }
            /** Grąžina vardą*/
            public string imtiVardą() { return vardas; }
            /** Grąžina ragų trofėjų kiekį*/
            public int imtiRagus() { return ragųtrof; }
            /** Grąžina uodegų kiekį*/
            public int imtiUodegas() { return uodegųtrof; }
            // Įdeda ragų trofėjus
            public void dėtiRagus(int ragųtrof)
            {
                this.ragųtrof = ragųtrof;
            }
            // Įdeda uodegų trofėjus
            public void dėtiUodegas(int uodegųtrof)
            {
                this.uodegųtrof =  uodegųtrof;
            }

        }
        static void Main(string[] args)
        {
            Pabaisa p1, p2, p3;             // Pabaisų objektai
            Console.WriteLine("Įveskite pirmos pabaisos ragų ir uodegų kiekį vienetais bei jos amžių");
            p1 = new Pabaisa("Pabaisa 1", int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("Įveskite antros pabaisos ragų ir uodegų kiekį vienetais bei jos amžių");
            p2 = new Pabaisa("Pabaisa 2", int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("Įveskite trečios pabaisos ragų ir uodegų kiekį vienetais bei jos amžių");
            p3 = new Pabaisa("Pabaisa 3", int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("Išviso pabaisos turi {0,2:d} ragus ir {1,2:d} uodegas", kiekRagų(p1.imtiRagus(), p2.imtiRagus(), p3.imtiRagus()), kiekUodegų(p1.imtiUodegas(), p2.imtiUodegas(), p3.imtiUodegas()));
            Console.WriteLine();
            int minUodegų = p1.imtiUodegas();           // Mažiausiai uodeguotos pabaisos uodegų sk
            int minUodRagų = p1.imtiRagus();            // Kiek ragų turi mažiausiai uodeguota pabaisa
            string minUodPav = p1.imtiPav();
            if (minUodegų > p2.imtiUodegas())
            {
                minUodegų = p2.imtiUodegas();
                minUodRagų = p2.imtiRagus();
                minUodPav = p2.imtiPav();
            }
            if (minUodegų > p3.imtiUodegas())
            {
                minUodegų = p3.imtiUodegas();
                minUodRagų = p3.imtiRagus();
                minUodPav = p2.imtiPav();
            }
            Console.WriteLine("Mažiausiai uodeguota pabaisa yra {0} ir ji turi {1,2:d} ragus",minUodPav, minUodRagų);
            Console.WriteLine();
            Console.ReadLine();
            int vyrPab;             //Vyriausia pabaisa
            int jaunPab;            //Jauniausia pabaisa
            Studentas s1, s2;
            if (p1.imtiAmžių() > p2.imtiAmžių())
            {
                vyrPab = p1.imtiAmžių();
                jaunPab = p2.imtiAmžių();
                s1 = new Studentas("Petras", p1.imtiRagus(), p1.imtiUodegas());
                s2 = new Studentas("Jonas", p2.imtiRagus(), p2.imtiUodegas());
            }
            else 
            {
                vyrPab = p2.imtiAmžių();
                jaunPab = p1.imtiAmžių();
                s1 = new Studentas("Petras", p2.imtiRagus(), p2.imtiUodegas());
                s2 = new Studentas("Jonas", p1.imtiRagus(), p1.imtiUodegas());
            }
            if (vyrPab < p3.imtiAmžių())
            {
                vyrPab = p3.imtiAmžių();
                s1.dėtiRagus(p3.imtiRagus());
                s1.dėtiUodegas(p3.imtiUodegas());
            }
            if (jaunPab > p3.imtiAmžių())
            {
                jaunPab = p3.imtiAmžių();
                s2.dėtiRagus(p3.imtiRagus());
                s2.dėtiUodegas(p3.imtiUodegas());
            }
            Console.WriteLine();
            Console.WriteLine("{0} tūrėtų {1,2:d} torfėjus jeigu sunaikintų vyriausią pabaisą", s1.imtiVardą(), kiekTrofėjų(s1.imtiRagus(), s1.imtiUodegas()));
            Console.WriteLine();
            Console.WriteLine("{0} tūrėtų {1,2:d} torfėjus jeigu sunaikintų jauniausią pabaisą", s2.imtiVardą(), kiekTrofėjų(s2.imtiRagus(), s2.imtiUodegas()));
            Console.WriteLine();
            Console.WriteLine("{0} turi daugiau ragų", daugRagų(s1.imtiRagus(), s2.imtiRagus(), s1.imtiVardą(), s2.imtiVardą()));
            Console.WriteLine("{0} turi daugiau uodegų", daugUodegų(s1.imtiUodegas(), s2.imtiUodegas(), s1.imtiVardą(), s2.imtiVardą()));
            Console.WriteLine("Programa baigė darbą!");
        }


        /**Metodas grąžinantis bendrą ragų kiekį*/
        static int kiekRagų(int ragai1, int ragai2, int ragai3)
        {
            return ragai1 + ragai2 + ragai3;
        }
        /**Metodas grąžinantis bendrą uodegų kiekį*/
        static int kiekUodegų(int uodega1, int uodega2, int uodega3)
        {
            return uodega1 + uodega2 + uodega3;
        }
        /**Metodas grąžinantis trofėjų sumą*/
        static int kiekTrofėjų(int ragųtrof, int uodegųtrof)
        {
            return ragųtrof + uodegųtrof;
        }
        /**Metodas grąžinantis kuris turi daugiau  ragų*/
        static string daugRagų(int ragų1, int ragų2, string vardas1, string vardas2 )
        {
            if (ragų1 > ragų2)
                return vardas1;
            else
                return vardas2;
        }

        /**Metodas grąžinantis kuris turi daugiau  uodegų*/
        static string daugUodegų(int uodegų1, int uodegų2, string vardas1, string vardas2)
        {
            if (uodegų1 > uodegų2)
                return vardas1;
            else
                return vardas2;
        }
    }
}
