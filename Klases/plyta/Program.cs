using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plyta
{   /** Klasė plytos duomenims saugoti
    @class Plyta */
    class Plyta
    {
        private int ilgis,          // plytos ilgis, milimetrais
                    plotis,         // plytos plotis, milimetrais
                    aukštis;        // plyos aukštis milimetrais
        public Plyta(int ilgis, int pločioReikšmė, int aukščioReikšmė)
        {
            this.ilgis = ilgis;
            plotis = pločioReikšmė;
            aukštis = aukščioReikšmė;
        }
        //* gražina plytos ilgį */
        public int imtiIlgį() { return ilgis; }

        //* gražina plytos plotį */
        public int imtiPlotį() { return plotis; }

        //* gražina plytos aukštį */
        public int imtiAukštį() { return aukštis; }

    }
    class program
    {
        static void Main(string[] args)
        {
            Plyta p1;                           // Pirmas plytų tipas
            p1 = new Plyta(250, 120, 88);
            Plyta p2;                           // Antras plytų tipas
            p2 = new Plyta(240, 115, 71);
            Plyta p3;                           // Trečias plytų tipas
            p3 = new Plyta(240, 115, 61);
            double sienosIlgis = 12.0,
                   sienosPlotis = 0.23,
                   sienosAukštis = 3.0;
            int k1;                             // Pirmo tipo plytų kiekis
            k1 = (int)(sienosIlgis * 1000 / p1.imtiIlgį() * sienosPlotis * 1000 / p1.imtiPlotį() * sienosAukštis * 1000 / p1.imtiAukštį());
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1, 4:d} \nplytos ilgis: {2, 5:d}\n", p1.imtiAukštį(), p1.imtiPlotį(), p1.imtiIlgį());
            Console.WriteLine("1-o tipo plytų reikia: {0,6:d} \n", (4 * k1));                           // Antras plytų tipas
            int k2;                             // Antro tipo plytų kiekis
            k2 = (int)(sienosIlgis * 1000 / p2.imtiIlgį() * sienosPlotis * 1000 / p2.imtiPlotį() * sienosAukštis * 1000 / p2.imtiAukštį());
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1, 4:d} \nplytos ilgis: {2, 5:d}\n", p2.imtiAukštį(), p2.imtiPlotį(), p2.imtiIlgį());
            Console.WriteLine("2-o tipo plytų reikia: {0,6:d} \n", (4 * k2));                          // Trečias plytų tipas
            int k3;                             // Antro tipo plytų kiekis
            k3 = (int)(sienosIlgis * 1000 / p3.imtiIlgį() * sienosPlotis * 1000 / p3.imtiPlotį() * sienosAukštis * 1000 / p3.imtiAukštį());
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1, 4:d} \nplytos ilgis: {2, 5:d}\n", p3.imtiAukštį(), p3.imtiPlotį(), p3.imtiIlgį());
            Console.WriteLine("3-o tipo plytų reikia: {0,6:d} \n", (4 * k3));

            // Čia apskaičiuojama su vienaSiena metodu
            Console.WriteLine("Atsakymai skaičiuojami per metodus!///////////////////////////////////////////");
            spausdintiPlytą(p1);
            Console.WriteLine("1-o tipo plytų reikia: {0,6:d} \n", (4 * vienaSiena(p1, sienosPlotis, sienosIlgis, sienosAukštis)));
            spausdintiPlytą(p2);
            Console.WriteLine("2-o tipo plytų reikia: {0,6:d} \n", (4 * vienaSiena(p2, sienosPlotis, sienosIlgis, sienosAukštis)));
            spausdintiPlytą(p3);
            Console.WriteLine("3-o tipo plytų reikia: {0,6:d} \n", (4 * vienaSiena(p3, sienosPlotis, sienosIlgis, sienosAukštis)));

            // bokšto apskaičiavimas
            double cilindroSkersmuo = 3.0,
                   cilindroAukštis = 4.0,
                   cilindroSienosStoris = 0.24;

            Console.WriteLine("Bošto sprendimas/////////////////////////////////////");
            Console.WriteLine("1-o tipo plytų bokštui reikia: {0,6:d} \n", bokštoPlytųSkaičiavimas(p1, cilindroSkersmuo, cilindroAukštis, cilindroSienosStoris));
            Console.WriteLine("2-o tipo plytų bokštui reikia: {0,6:d} \n", bokštoPlytųSkaičiavimas(p2, cilindroSkersmuo, cilindroAukštis, cilindroSienosStoris));
            Console.WriteLine("3-o tipo plytų bokštui reikia: {0,6:d} \n", bokštoPlytųSkaičiavimas(p3, cilindroSkersmuo, cilindroAukštis, cilindroSienosStoris));
            Console.WriteLine("programa baigė darbą!");
        }          

        // pakeisti parametrai sienos
        //static void Main(string[] args)
        //{
        //    Plyta p1;                           // Pirmas plytų tipas
        //    p1 = new Plyta(250, 120, 88);
        //    Plyta p2;                           // Antras plytų tipas
        //    p2 = new Plyta(240, 115, 71);
        //    Plyta p3;                           // Trečias plytų tipas
        //    p3 = new Plyta(240, 115, 61);
        //    double sienosIlgis = 15.0,
        //           sienosPlotis = 0.36,
        //           sienosAukštis = 4.0;
        //    spausdintiPlytą(p1);
        //    Console.WriteLine("1-o tipo plytų reikia: {0,6:d} \n", (4 * vienaSiena(p1, sienosPlotis, sienosIlgis, sienosAukštis)));
        //    spausdintiPlytą(p2);
        //    Console.WriteLine("2-o tipo plytų reikia: {0,6:d} \n", (4 * vienaSiena(p2, sienosPlotis, sienosIlgis, sienosAukštis)));
        //    spausdintiPlytą(p3);
        //    Console.WriteLine("3-o tipo plytų reikia: {0,6:d} \n", (4 * vienaSiena(p3, sienosPlotis, sienosIlgis, sienosAukštis)));
        //    Console.WriteLine("programa baigė darbą!");
        //}

        // Siena mažesnė už plyą
        //static void Main(string[] args)
        //{
        //    Plyta p1;                           // Pirmas plytų tipas
        //    p1 = new Plyta(250, 120, 88);
        //    Plyta p2;                           // Antras plytų tipas
        //    p2 = new Plyta(240, 115, 71);
        //    Plyta p3;                           // Trečias plytų tipas
        //    p3 = new Plyta(240, 115, 61);
        //    double sienosIlgis = 0.02,
        //           sienosPlotis = 0.1,
        //           sienosAukštis = 0.05;
        //    spausdintiPlytą(p1);
        //    Console.WriteLine("1-o tipo plytų reikia: {0,6:d} \n", (4 * vienaSiena(p1, sienosPlotis, sienosIlgis, sienosAukštis)));
        //    spausdintiPlytą(p2);
        //    Console.WriteLine("2-o tipo plytų reikia: {0,6:d} \n", (4 * vienaSiena(p2, sienosPlotis, sienosIlgis, sienosAukštis)));
        //    spausdintiPlytą(p3);
        //    Console.WriteLine("3-o tipo plytų reikia: {0,6:d} \n", (4 * vienaSiena(p3, sienosPlotis, sienosIlgis, sienosAukštis)));
        //    Console.WriteLine("programa baigė darbą!");
        //}
        static int vienaSiena(Plyta p, double sienosPlotis, double sienosIlgis, double sienosAukštis)
        {
            return (int)(sienosIlgis * 1000 / p.imtiIlgį() * sienosPlotis * 1000 / p.imtiPlotį() * sienosAukštis * 1000 / p.imtiAukštį());
        }
        static void spausdintiPlytą(Plyta p)
        {
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1, 4:d} \nplytos ilgis: {2, 5:d}\n", p.imtiAukštį(), p.imtiPlotį(), p.imtiIlgį());
        }
        static int bokštoPlytųSkaičiavimas(Plyta p, double cilindroSkersmuo, double cilindroAukštis, double cilindroSienosStoris)
        {
            return (int)((cilindroSkersmuo * Math.PI * 1000) / p.imtiIlgį() * cilindroAukštis * 1000 / p.imtiPlotį() * cilindroSienosStoris * 1000 / p.imtiAukštį());
        }
    }
}