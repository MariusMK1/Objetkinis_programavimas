using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vandens_telkinys
{
    class Vanduo
    {
        private string pav;
        private double gylis;
        private double plotis;
        private double ilgis;
    public Vanduo(string pav, double gylis, double plotis, double ilgis)
        {
            this.pav = pav;
            this.gylis = gylis;
            this.plotis = plotis;
            this.ilgis = ilgis;
        }
        public string imtiPav() { return pav; }
        public double imtiGylį() { return gylis; }
        public double imtiPlotį() { return plotis; }
        public double imtiIlgis() { return ilgis; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vanduo v1, v2, v3;
            Console.WriteLine("įveskite pirmo telkinio gylį, plotį, ilgį:");
            v1 = new Vanduo("Pirmas telkinys", double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Console.WriteLine("įveskite antro telkinio gylį, plotį, ilgį:");
            v2 = new Vanduo("Antras telkinys", double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Console.WriteLine("įveskite trečio telkinio gylį, plotį, ilgį:");
            v3 = new Vanduo("Trečias telkinys", double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            double minGylis;
            double maxTūris;
            /**Min gylio skaičiavimas*/
            if (v1.imtiGylį() < v2.imtiGylį())
            {
                minGylis = v1.imtiGylį();
            }
            else
            {
                minGylis = v2.imtiGylį();
            }
            if (minGylis > v3.imtiGylį())
            {
                minGylis = v3.imtiGylį();
            }
            /**max tūrio skaičiavimas*/
            if(tūris(v1.imtiGylį(), v1.imtiPlotį(), v1.imtiIlgis()) > tūris(v2.imtiGylį(), v2.imtiPlotį(), v2.imtiIlgis()))
            {
                maxTūris = tūris(v1.imtiGylį(), v1.imtiPlotį(), v1.imtiIlgis());
            }
            else
            {
                maxTūris = tūris(v2.imtiGylį(), v2.imtiPlotį(), v2.imtiIlgis());
            }
            if (maxTūris < tūris(v3.imtiGylį(), v3.imtiPlotį(), v3.imtiIlgis()))
            {
                maxTūris = tūris(v3.imtiGylį(), v3.imtiPlotį(), v3.imtiIlgis());
            }
            Console.WriteLine();
            Console.WriteLine("Mažiausias gylis yra {0,5:f2}", minGylis);
            Console.WriteLine();
            Console.WriteLine("didžiausias tūris yra {0,5:f2}", maxTūris);
            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
        static double tūris(double gylis, double plotis, double ilgis)
        {
            return gylis * plotis * ilgis;
        }
    }
}
