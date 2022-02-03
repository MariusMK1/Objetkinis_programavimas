using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Monetos
{
    class Moneta
    {
        private string kilmė;                //Monetos kilmės šalis
        private double nominalas;            //Monetos nominalas
        private double svoris;               //Monetos svoris gramais
        public Moneta(string kilmė, double nominalas, double svoris)
        {
            this.kilmė = kilmė ;
            this.nominalas = nominalas;
            this.svoris = svoris;
        }
        public string imtiKilmę() { return kilmė; }
        public double imtiNominalą() { return nominalas; }
        public double imtiSvorį() { return svoris; }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Monetos\\bin\\Debug\\Duom.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Monetos\\bin\\Debug\\Duom2.txt";
        const string CFrez = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Monetos\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            // Pirmas kolekcininkas
            Moneta[] M = new Moneta[100];
            int kiek;
            string kolekcininkas;
            Skaityti(CFd, M, out kiek, out kolekcininkas);
            Console.WriteLine("Kolekcininkas: {0}", kolekcininkas);
            Console.WriteLine("Turi tokias monetas:");
            Console.WriteLine();
            Console.WriteLine("Kilmės šalis     Nominalas     Svoris");
            Console.WriteLine();
            for (int i = 0; i < kiek; i++)
            {
                Console.WriteLine("{0,-18}{1,5:f2}{2,13:f2}", M[i].imtiKilmę(), M[i].imtiNominalą(), M[i].imtiSvorį());
            }
            Console.WriteLine();
            int j;          // Sunkiausios monetos eilės numeris faile
            sunkiausiaMoneta(M, kiek, out j);
            Console.WriteLine("Sunkiausia moneta yra: {0} ir ji sveria: {1,5:f2} gramus", M[j].imtiNominalą(),M[j].imtiSvorį());
            Console.WriteLine("Visų monetų bendra vertė: {0,5:f2} Eurų", monetųSuma(M, kiek));
            Console.WriteLine();

            // Antras Kolekcininkas
            Moneta[] M2 = new Moneta[100];
            int kiek2;
            string kolekcininkas2;
            Skaityti(CFd2, M2, out kiek2, out kolekcininkas2);
            Console.WriteLine("Kolekcininkas: {0}", kolekcininkas2);
            Console.WriteLine("Turi tokias monetas:");
            Console.WriteLine();
            Console.WriteLine("Kilmės šalis     Nominalas     Svoris");
            Console.WriteLine();
            for (int i = 0; i < kiek2; i++)
            {
                Console.WriteLine("{0,-18}{1,5:f2}{2,13:f2}", M2[i].imtiKilmę(), M2[i].imtiNominalą(), M2[i].imtiSvorį());
            }
            Console.WriteLine();
            int j2;          // Sunkiausios monetos eilės numeris faile
            sunkiausiaMoneta(M2, kiek2, out j2);
            Console.WriteLine("Sunkiausia moneta yra: {0} ir ji sveria: {1,5:f2} gramus", M2[j].imtiNominalą(), M2[j].imtiSvorį());
            Console.WriteLine("Visų monetų bendra vertė: {0,5:f2} Eurų", monetųSuma(M2, kiek2));
            Console.WriteLine();


            kurisTurtingesnis(monetųSuma(M, kiek), monetųSuma(M2, kiek2), kolekcininkas, kolekcininkas2);       // Iškarto spausdina kuris turtingesnis į konsolę

            if (File.Exists(CFrez))
                File.Delete(CFrez);

            spausindtiViršų(CFrez);
            spausdintiNominalas1(CFrez, M, kiek);
            spausdintiNominalas1(CFrez, M2, kiek2);
            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine("---------------------------------------");
                fr.WriteLine();
            }
            Console.WriteLine("Programa baigė darbą!");
        }
        static void Skaityti(string Fd, Moneta[] M, out int kiek, out string kolekcininkas)
        {
            using (StreamReader reader = new StreamReader(Fd))
            {
                string kilmė; double nominalas, svoris;
                string line;
                line = reader.ReadLine();
                string[] parts;
                kolekcininkas = line;
                line = reader.ReadLine();
                kiek = int.Parse(line);
                for (int i = 0; i < kiek; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    kilmė = parts[0];
                    nominalas = double.Parse(parts[1]);
                    svoris = double.Parse(parts[2]);
                    M[i] = new Moneta(kilmė, nominalas, svoris);
                }
            }
        }
        /// <summary>
        /// Brangiausios kėdės radimo metodas
        /// </summary>
        /// <param name="K"></param>
        /// <param name="kiek"></param>
        /// <param name="j" eilės numerio duomenų faile radimas></param>
        static void sunkiausiaMoneta(Moneta[] M, int kiek, out int j)
        {
            j = 0;
            double svoris = 0;
            for (int i = 0; i < kiek; i++)
            {
                if (M[i].imtiSvorį() > svoris)
                {
                    svoris = M[i].imtiSvorį();
                    j = i;
                }
            }
        }
        static void kurisTurtingesnis(double suma, double suma2, string kolekcininkas, string kolekcininkas2)
        {
            if (suma > suma2)
                Console.WriteLine("Turtingesnis kolekcininkas yra: {0,5:f2}", kolekcininkas);
            else
                Console.WriteLine("Turtingesnis kolekcininkas yra: {0,5:f2}", kolekcininkas2);
        }
        static double monetųSuma(Moneta[] M, int kiek)
        {
            double suma = 0;
            for (int i = 0; i < kiek; i++)
                suma += M[i].imtiNominalą();
            return suma;
        }
        static void spausindtiViršų(string fv)
        {
            const string virsus =
                "|---------------|------------|--------|\r\n"
                + "|               |            |        | \r\n"
                + "|  Kilmės šalis |  Nominalas | Svoris | \r\n"
                + "|               |            |        | \r\n"
                + "|---------------|------------|--------| \r\n";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Monetų kurių nominalas yra 1 sąrašas:");
                fr.Write(virsus);
            }
        }
        static void spausdintiNominalas1(string fv, Moneta[] M, int nkiek)
        {
            using (var fr = File.AppendText(fv))
            {
                Moneta tarp;
                for (int i = 0; i < nkiek; i++)
                {
                    tarp = M[i];
                    if (M[i].imtiNominalą() == 1)
                        fr.WriteLine("|{0,-15}| {1,8}   |  {2,4:f2}  |", tarp.imtiKilmę(), tarp.imtiNominalą(), tarp.imtiSvorį());
                }
            }
        }
    }
}
