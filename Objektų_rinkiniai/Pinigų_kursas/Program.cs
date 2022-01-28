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
            Pinigai[] P = new Pinigai[Cn];
            int n;
            string vardas;
            Skaityti(CFd, P, out n, out vardas);
            Console.WriteLine("{0}", vardas);
            Console.WriteLine("Pingiai    centai    kursas");
            for (int i = 0; i < n; i++)
                Console.WriteLine("{0,-10}  {1,3}    {2,7:f2}", P[i].imtiPinigus(), P[i].imtiCentus(), P[i].imtiKursą());

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
                line=reader.ReadLine();
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
    }
}
