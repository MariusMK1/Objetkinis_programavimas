using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plyta_du
{
    /** Klasė plytos duomenims saugoti
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
    /** Klasė sienos duomenims saugoti
    @class Plyta */
    class Siena
    {
        private double ilgis,          // sienos ilgis, metrais
                    plotis,         // sienos plotis, metrais
                    aukštis;        // sienos aukštis, metrais
        public Siena(double ilgis, double plotis, double aukštis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.aukštis = aukštis;
        }
        //* gražina plytos ilgį */
        public double imtiIlgį() { return ilgis; }

        //* gražina plytos plotį */
        public double imtiPlotį() { return plotis; }

        //* gražina plytos aukštį */
        public double imtiAukštį() { return aukštis; }
    }
    /** Klasė bokšto duomenims saugoti
    @class Plyta */
    class Bokštas
    {
        private double skersmuo,          // bokšto skersmuo, metrais
                       storis,         // bokšto sienos storis, metrais
                       aukštis;        // bokšto aukštis, metrais
        public Bokštas(double skersmuo, double storis, double aukštis)
        {
            this.skersmuo = skersmuo;
            this.storis = storis;
            this.aukštis = aukštis;
        }
        //* gražina bokšto skersmenį */
        public double imtiSkersmenį() { return skersmuo; }

        //* gražina bokšto sienos storį */
        public double imtiStorį() { return storis; }

        //* gražina bokšto aukštį */
        public double imtiAukštį() { return aukštis; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Plyta p1;                           // Pirmas plytų tipas
            p1 = new Plyta(250, 120, 88);
            Plyta p2;                           // Antras plytų tipas
            p2 = new Plyta(240, 115, 71);
            Plyta p3;                           // Trečias plytų tipas
            p3 = new Plyta(240, 115, 61);

            Siena s1;                           // Pirmas sienos tipas
            s1 = new Siena(12.0, 0.23, 3.0);
            Siena s2;                           // Antras sienos tipas
            s2 = new Siena(15.0, 0.23, 3.0);

            Bokštas b1;                           // Pirmas bokšto tipas
            b1 = new Bokštas(4.0, 0.24, 3.0);

            // Duomenų spausdinimas
            spausdintiPlytą(p1);
            spausdintiPlytą(p2);
            spausdintiPlytą(p3);
            Console.WriteLine("Sienos aukštis:\t {0, 6:f2} \nSienos plotis:\t {1, 6:f2} \nSienos ilgis:\t {2, 6:f2}\n", s1.imtiAukštį(), s1.imtiPlotį(), s1.imtiIlgį());
            Console.WriteLine();
            Console.WriteLine("1-o tipo plytų reikia: {0,6:d} \n", (4 * reikiaPlytų(p1, s1)));
            Console.WriteLine();
            Console.WriteLine("2-o tipo plytų reikia: {0,6:d} \n", (4 * reikiaPlytų(p2, s1)));
            Console.WriteLine();
            Console.WriteLine("3-o tipo plytų reikia: {0,6:d} \n", (4 * reikiaPlytų(p3, s1)));
            // Duomenų spausdinimas su nevienodais sienų ilgiais
            Console.WriteLine("-----------Namui su nevienodais sienų ilgiais:-----------");
            Console.WriteLine();
            Console.WriteLine("1-o tipo plytų reikia: {0,6:d} \n", (2 * reikiaPlytų(p1, s1) + 2 * reikiaPlytų(p1, s2)));
            Console.WriteLine();
            Console.WriteLine("2-o tipo plytų reikia: {0,6:d} \n", (2 * reikiaPlytų(p2, s1) + 2 * reikiaPlytų(p2, s2)));
            Console.WriteLine();
            Console.WriteLine("3-o tipo plytų reikia: {0,6:d} \n", (2 * reikiaPlytų(p3, s1) + 2 * reikiaPlytų(p3, s2)));

            // Duomenų spausdinimas su nevienodais sienų ilgiais
            Console.WriteLine("----------Piliai pastatyti reikia plytų:-------------");
            Console.WriteLine();
            Console.WriteLine("1-o tipo plytų reikia: {0,6:d} \n", (2 * reikiaPlytų(p1, s1) + 2 * reikiaPlytų(p1, s2) + 4 * bokštoPlytųSkaičiavimas(p1, b1)));
            Console.WriteLine();
            Console.WriteLine("2-o tipo plytų reikia: {0,6:d} \n", (2 * reikiaPlytų(p2, s1) + 2 * reikiaPlytų(p2, s2) + 4 * bokštoPlytųSkaičiavimas(p2, b1)));
            Console.WriteLine();
            Console.WriteLine("3-o tipo plytų reikia: {0,6:d} \n", (2 * reikiaPlytų(p3, s1) + 2 * reikiaPlytų(p3, s2) + 4 * bokštoPlytųSkaičiavimas(p3, b1)));
            Console.WriteLine();
            Console.WriteLine("programa baigė darbą!");
        }
        // Metodai
        static void spausdintiPlytą(Plyta p)
        {
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1, 4:d} \nPlytos ilgis: {2, 5:d}\n", p.imtiAukštį(), p.imtiPlotį(), p.imtiIlgį());
        }

        static int reikiaPlytų(Plyta p, Siena s)
        {
            return (int)(s.imtiIlgį() * 1000 / p.imtiIlgį() * s.imtiPlotį() * 1000 / p.imtiPlotį() * s.imtiAukštį() * 1000 / p.imtiAukštį());
        }
        static int bokštoPlytųSkaičiavimas(Plyta p, Bokštas b)
        {
            return (int)((b.imtiSkersmenį() * Math.PI * 1000) / p.imtiIlgį() * b.imtiAukštį() * 1000 / p.imtiPlotį() * b.imtiStorį() * 1000 / p.imtiAukštį());
        }
    }
}
