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
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Degalų_sąnaudos\\bin\\Debug\\Duom.txt";
        const string CFrez = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Degalų_sąnaudos\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Auto[] A = new Auto[100];
            int na;                     //Automobilių kiekis

            Console.WriteLine("Programa baigė darbą");

            if (File.Exists(CFrez))
                File.Delete(CFrez);
            Skaityti(CFd, A, out na);
            Spausdinti(CFrez, A, na);

            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine("Vidutinės degalų sąnaudos: {0,7:f2} litro/100 km", vidSąnaudos(A, na));
            }
            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine("Dyzelinių automobilių yra {0} vienetai", dyzeliniaiAuto(A, na));
            }
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
        static void Spausdinti(string fv, Auto[] A, int nkiek)
        {
            const string virsus =
                "|-----|---------------|-------------|----------------------|\r\n"
                + "|     |               |             |                      | \r\n"
                + "| El. |  Pavadinimas  |   Degalai   |  Sąnaudos (l/100 km) | \r\n"
                + "| Nr  |               |             |                      | \r\n"
                + "|-----|---------------|-------------|----------------------| \r\n";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Automobilių kiekis: {0}", nkiek);
                fr.WriteLine("Automobilių sąrašas:");
                fr.Write(virsus);
                Auto tarp;
                for (int i = 0; i < nkiek; i++)
                {
                    tarp = A[i];
                    fr.WriteLine("| {0,-3} |{1,-15}| {2,-9}   |    {3,16:f2}  |", i + 1, tarp.imtiPav(), tarp.imtiDegalus(), tarp.imtiSąnaudas());
                }
                fr.WriteLine("--------------------------------------------------------------");
                fr.WriteLine();
            }
        }
        static double vidSąnaudos(Auto[] A, int kiek)
        {
            double sum = 0;
            for (int i = 0; i < kiek; i++)
            {
                sum += A[i].imtiSąnaudas();
            }   
            return sum / kiek;
        }
        static int dyzeliniaiAuto(Auto[] A, int kiek)
        {
            int sum = 0;
            for (int i = 0; i < kiek; i++)
            {
                if(A[i].imtiDegalus() == "Dyzelinas")
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}
