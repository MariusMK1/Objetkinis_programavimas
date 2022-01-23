using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Turistai
{
    internal class Program
    {
        class Turistas
        {
            private string vardas;
            private double pinigai;
            public Turistas(string vardas, double pinigai)
            {
                this.vardas = vardas;
                this.pinigai = pinigai;
            }
            /**Grąžina vardą*/
            public string imtiVardą() { return vardas; }

            /**Grąžina pinigus*/
            public double imtiPinigus() { return pinigai; }
        }
        const int Cn = 100;
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Turistai\\bin\\Debug\\Duom.txt";
        static void Main(string[] args)
        {
            Turistas[] T = new Turistas[Cn];
            int n;
            Skaityti(CFd, T, out n);
            Console.WriteLine("Turistų skaičius: {0,2:d}", n);
            Console.WriteLine("Turisto vardas    Pinigai");
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("    {0}   \t{1,7:f2}\n", T[i].imtiVardą(), T[i].imtiPinigus());
            }
            double visoPinigų;                  // kiek iš viso pinigų turi turistai
            double vidurkisPinigų;              // kiek pinigų vidutiniškai turi
            pinigai(T, n, out visoPinigų, out vidurkisPinigų);
            Console.WriteLine("Bendrai turistai turi: {0,7:f2} eurų", visoPinigų);
            Console.WriteLine("Vidutiniškai kiekvienam nariui tenka po {0,7:f2} eurų", vidurkisPinigų);
            Console.WriteLine("Bendroms grupės išlaidoms yra {0,7:f2} eurų", bendromsIšlaidoms(T, n));
        }
        /**Skaityti duomenis iš failo metodas
        @param fv - failo vardas, kuris nurodomas konstanta CFd
        @param T - objektų rinkinys turistų duomenims saugoti
        @param n - turistų skaičius */
        static void Skaityti(string fv, Turistas[] T, out int n)
        {
            string vardas;
            double pinigai;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    vardas = parts[0];
                    pinigai = double.Parse(parts[1]);
                    T[i] = new Turistas(vardas, pinigai);
                }
            }
        }
        /**Skaičiuoja tnkamo amžiaus dviračių kainų sumą ir kiekį
        @param T - turistų duomenys
        @param n - turistų skaičius
        @param suma - Pinigų suma
        @param vidurkis - Pinigų vidurkis*/
        static void pinigai(Turistas[] T, int n, out double suma, out double vidurkis)
        {
            suma = 0;
            vidurkis = 0;
            for(int i = 0; i < n; i++)
            {
                suma += T[i].imtiPinigus();
            }
            vidurkis = suma / n;
        }
        static double bendromsIšlaidoms(Turistas[] T, int n)
        {
            double bendrosIšl = 0;
            for(int i = 0; i < n;i++)
            {
                bendrosIšl += T[i].imtiPinigus() * 0.25;
            }
            return bendrosIšl;
        }
    }
}
