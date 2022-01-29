using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pinigų_kursas
{
    class Pinigai
    {
        private int pinigai;
        private int centai;
        private double kursas;                  // Valiutos keitimo į Eurus kursas 
        public Pinigai(int pinigai, int centai, double kursas)
        {
            this.pinigai = pinigai;
            this.centai = centai;
            this.kursas = kursas;
        }
        public int imtiPinigus() { return pinigai; }
        public double imtiCentus() { return centai; }
        public double imtiKursą() { return kursas; }
    }

    internal class Program
    {
        const int Cn = 100;
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Pinigų_kursas\\bin\\Debug\\A.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Pinigų_kursas\\bin\\Debug\\B.txt";
        static void Main(string[] args)
        {
            // pirmojo žmogaus pinigų skaičiavimas
            Pinigai[] P = new Pinigai[Cn];
            int n;
            string vardas;
            double eurai, euroCentai;
            Skaityti(CFd, P, out n, out vardas);
            Console.WriteLine("{0}", vardas);
            Console.WriteLine("Pingiai    centai    kursas");
            for (int i = 0; i < n; i++)
                Console.WriteLine("{0,-10}  {1,3}    {2,7:f2}", P[i].imtiPinigus(), P[i].imtiCentus(), P[i].imtiKursą());
            konvertuotiEurus(P, n, out eurai, out euroCentai);
            Console.WriteLine("{0} turi {1} eurą ir {2,2:f0} centų", vardas, eurai, euroCentai);
            Console.WriteLine();

            // Antrojo žmogaus pinigų skaičiavimas
            Pinigai[] P2 = new Pinigai[Cn];
            int n2;
            string vardas2;
            double eurai2, euroCentai2;
            Skaityti(CFd2, P2, out n2, out vardas2);
            Console.WriteLine("{0}", vardas2);
            Console.WriteLine("Pingiai    centai    kursas");
            for (int i = 0; i < n2; i++)
                Console.WriteLine("{0,-10}  {1,3}  {2,9:f2}", P2[i].imtiPinigus(), P2[i].imtiCentus(), P2[i].imtiKursą());
            konvertuotiEurus(P2, n2, out eurai2, out euroCentai2);
            Console.WriteLine("{0} turi {1} eurų ir {2,2:f0} centus", vardas2, eurai2, euroCentai2);
            Console.WriteLine();

            // Bendrai turi eurų
            double bendraiEurai, bendraiEuroCentai;
            bendraiTuriEuru(eurai, eurai2, euroCentai, euroCentai2, out bendraiEurai, out bendraiEuroCentai);
            Console.WriteLine("{0} ir {1} bendrai turi {2} eurus ir {3,2:f0} centus", vardas, vardas2, bendraiEurai, bendraiEuroCentai);
        }
        /**
         @param fv - failo vardas, kuris nurodomas konstanta CFd
         @param P - objektų rinkinys pinigų duomenims saugoti
         @param n - eilučių faile skaičius*/
        static void Skaityti(string fv, Pinigai[] P, out int n, out string vardas)
        {
            int pinigai, centai;
            double kursas;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                vardas = line;
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pinigai = int.Parse(parts[0]);
                    centai = int.Parse(parts[1]);
                    kursas = double.Parse(parts[2]);
                    P[i] = new Pinigai(pinigai, centai, kursas);
                }
            }
        }
        static void konvertuotiEurus(Pinigai[] P, int n, out double eurai, out double euroCentai)
        {
            double bendraSuma = 0;
            for(int i = 0; i < n;i++)
            {
                bendraSuma += ((P[i].imtiPinigus() + P[i].imtiCentus() / 100) * P[i].imtiKursą());
            }
            eurai = Math.Floor(bendraSuma);
            euroCentai = (bendraSuma - eurai) * 100;

        }
        static void bendraiTuriEuru(double eurai, double eurai2, double euroCentai, double euroCentai2, out double bendraiEurai, out double bendraiEuroCentai )
        {
            double bendrai = eurai + eurai2 + (euroCentai + euroCentai2) / 100;
            bendraiEurai = Math.Floor(bendrai);
            bendraiEuroCentai = (bendrai - bendraiEurai) * 100;
        }
    }
}
