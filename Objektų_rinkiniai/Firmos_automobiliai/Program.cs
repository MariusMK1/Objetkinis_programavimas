using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Firmos_automobiliai
{
    class Auto
    {
        private string pav,
                       degalai;
        private double sąnaudos;
        public Auto(string pav, string degalai, double sąnaudos)
        {
            this.pav = pav;
            this.degalai = degalai;
            this.sąnaudos = sąnaudos;
        }
        public string imtiPav() { return pav; }

        public string imtiDegalus() { return degalai; }
        public double imtiSąnaudas() { return sąnaudos; }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Firmos_automobiliai\\bin\\Debug\\Duom.txt";
        static void Main(string[] args)
        {
            Auto[] A = new Auto[100];
            int na;                     //Automobilių kiekis

            Console.WriteLine("Programa baigė darbą");
        }
        static void Skaityti(string Fd, Auto[] A, out int kiek)
        {
            using (StreamReader reader = new StreamReader(Fd))
            {
                string pav, degalai; double sąnaudos;
                string line;
                line = reader.ReadLine();
                string[] parts;
                kiek = int.Parse(line);
                for (int i = 0; i < kiek; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    degalai = parts[1];
                    sąnaudos = double.Parse(parts[2]);
                    A[i] = new Auto(pav, degalai, sąnaudos);
                }
            }
        }
    }
}
