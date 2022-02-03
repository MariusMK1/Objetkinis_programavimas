using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Statybinės_prekės
{
    class Prekė
    {
        private string pavadinimas;                //Statybinės prekės pavadinimas
        private double kaina;                      //Kvadrato kaina
        private int storis;                     //Prekės storis
        public Prekė(string pavadinimas, double kaina, int storis)
        {
            this.pavadinimas = pavadinimas;
            this.kaina = kaina;
            this.storis = storis;
        }
        public string imtiPavadinimą() { return pavadinimas; }
        public double imtiKainą() { return kaina; }
        public int imtiStorį() { return storis; }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Statybinės_prekės\\bin\\Debug\\Duom.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Statybinės_prekės\\bin\\Debug\\Duom2.txt";
        const string CFrez = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Statybinės_prekės\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Prekė[] P = new Prekė[100];
            int kiek;
            string parduotuvė;
            Skaityti(CFd, P, out kiek, out parduotuvė);

            Console.Write("Įveskite kainą kurios nenorite viršyti:");
            double maxKaina = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite storio ribas milimetrais nuo iki:");
            int minStoris = int.Parse(Console.ReadLine());
            int maxStoris = int.Parse(Console.ReadLine());

            int KiekTinkamųPrekių = kiekTinkamųPrekių(P, kiek, maxKaina, minStoris, maxStoris);
            Console.WriteLine("Tinkamų prekių yra {0} vnt", KiekTinkamųPrekių);
        }
        static void Skaityti(string Fd, Prekė[] P, out int kiek, out string parduotuvė)
        {
            using (StreamReader reader = new StreamReader(Fd))
            {
                string pavadinimas; double kaina; int storis;
                string line;
                line = reader.ReadLine();
                string[] parts;
                parduotuvė = line;
                line = reader.ReadLine();
                kiek = int.Parse(line);
                for (int i = 0; i < kiek; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pavadinimas = parts[0];
                    kaina = double.Parse(parts[1]);
                    storis = int.Parse(parts[2]);
                    P[i] = new Prekė(pavadinimas, kaina, storis);
                }
            }
        }
        static int kiekTinkamųPrekių(Prekė[] P, int kiek, double maxKaina, int minStoris, int maxStoris)
        {
            int suma = 0;
            for(int i = 0; i < kiek; i++)
            {
                if((P[i].imtiKainą() <= maxKaina) && (P[i].imtiStorį() >= minStoris) && (P[i].imtiStorį() <= maxStoris))
                {
                    suma++;
                }
            }
            return suma;
        }
    }
}
