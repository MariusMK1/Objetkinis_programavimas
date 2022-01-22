using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salė
{
    class Kėdė
    {
        private int plotis;    // kėdės plotis mm
        private int ilgis;     // kėdės ilgis mm
        private int aukštis;   // sėdimos plokštumos aukštis nuo grindų mm
        public Kėdė(int plotis, int ilgis, int aukštis)
        {
            this.plotis = plotis;
            this.ilgis = ilgis;
            this.aukštis = aukštis;
        }
        // Grąžina kėdės plotį
        public int imtiPlotį() { return plotis;  }

        // Grąžina kėdės ilgį
        public int imtiIlgį() { return ilgis; }
        // Grąžina kėdės aukštį
        public int imtiAukštį() { return aukštis; }
    }
    class Salė
    {
        private double ilgis;       //Salės ilgis m
        private double plotis;      //Salės plotis m
        public Salė(double ilgis, double plotis)
        { 
            this.ilgis = ilgis;
            this.plotis = plotis;
        }
        // Grąžina salės ilgį
        public double imtiIlgį() { return ilgis; }
        // Grąžina salės plotį
        public double imtiPlotį() { return plotis; }
        // Įdeda salės ilgį
        public void dėtiIlgį(double ilgis) 
        { 
            this.ilgis = ilgis;
        }
        // Įdeda salės plotį
        public void dėtiPlotį(double plotis)
        {
            this.plotis = plotis;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kėdė k1, k2, k3;
            Console.WriteLine("Įveskite pirmos kėdės plotį, ilgį, sėdimos plokštumos aukštį (milimetrais)");
            k1 = new Kėdė(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("Įveskite antros kėdės plotį, ilgį, aukštį (milimetrais)");
            k2 = new Kėdė(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("Įveskite trečios kėdės plotį, ilgį, aukštį (milimetrais)");
            k3 = new Kėdė(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.Clear();
            int maxPlotas = užimamasPlotas(k1.imtiPlotį(), k1.imtiIlgį());              // kintamasis didžiausiam kedės plotui
            string didKėdė = "Pirmoji kėdė";                                            // kintamasis kėdės pavadinimui su didžiausiu plotu
            if (maxPlotas < užimamasPlotas(k2.imtiPlotį(), k2.imtiIlgį()))
            {
                maxPlotas = užimamasPlotas(k2.imtiPlotį(), k2.imtiIlgį());
                didKėdė = "Antroji kėdė";
            }
            if (maxPlotas < užimamasPlotas(k3.imtiPlotį(), k3.imtiIlgį()))
            {
                maxPlotas = užimamasPlotas(k3.imtiPlotį(), k3.imtiIlgį());
                didKėdė = "Trečioji kėdė";
            }

            Console.WriteLine("daugiausiai ploto užimanti yra {0}", didKėdė);
            Console.WriteLine("kuri užima {0} mm2", maxPlotas);
            Console.WriteLine();

            Salė s1;
            s1 = new Salė(10.0, 7.0);
            if (k1.imtiAukštį() >= 400 && k1.imtiAukštį() <= 500)
                Console.WriteLine("Pirmo tipo kėdžių salėje telpa: {0,6:d}", kiekKėdžių(s1.imtiIlgį(), s1.imtiPlotį(), k1.imtiIlgį(), k1.imtiPlotį()));
            else
                Console.WriteLine("Pirmo tipo kėdės nėra tinkamo aukščio");
            if (k2.imtiAukštį() >= 400 && k2.imtiAukštį() <= 500)
                Console.WriteLine("Antro tipo kėdžių salėje telpa: {0,6:d}", kiekKėdžių(s1.imtiIlgį(), s1.imtiPlotį(), k2.imtiIlgį(), k2.imtiPlotį()));
            else
                Console.WriteLine("Antro tipo kėdės nėra tinkamo aukščio");
            if (k3.imtiAukštį() >= 400 && k3.imtiAukštį() <= 500)
                Console.WriteLine("Trečio tipo kėdžių salėje telpa: {0,6:d}", kiekKėdžių(s1.imtiIlgį(), s1.imtiPlotį(), k3.imtiIlgį(), k3.imtiPlotį()));
            else
                Console.WriteLine("Trečio tipo kėdės nėra tinkamo aukščio");
            Console.ReadLine();
            Console.Clear();

            // Salės matmenų keitimas
            Console.WriteLine("Salės pradiniai matmenys metrais: Ilgis = {0,3:f1}, Plitis = {1,3:f1}", s1.imtiIlgį(), s1.imtiPlotį());
            Console.WriteLine();
            Console.Write("Įveskite naują salės iglį:");
            s1.dėtiIlgį(double.Parse(Console.ReadLine()));
            Console.Write("Įveskite naują salės plotį:");
            s1.dėtiPlotį(double.Parse(Console.ReadLine()));
            Console.WriteLine();
            Console.WriteLine("Salės nauji matmenys metrais: Ilgis = {0,3:f1}, Plitis = {1,3:f1}", s1.imtiIlgį(), s1.imtiPlotį());
            int minKėdžių = kiekKėdžių(s1.imtiIlgį(), s1.imtiPlotį(), k1.imtiIlgį(), k1.imtiPlotį());           // Kintamasis kiek mažiausiai kėdžių reikės 
            string minpav = "Pirmo";                                                                            // Kintamasis nusakantis kurio tipo kėdžių mažiausiai reikia
            if (minKėdžių > kiekKėdžių(s1.imtiIlgį(), s1.imtiPlotį(), k2.imtiIlgį(), k2.imtiPlotį()))
            {
                minKėdžių = kiekKėdžių(s1.imtiIlgį(), s1.imtiPlotį(), k2.imtiIlgį(), k2.imtiPlotį());
                minpav = "Antro";
            }
            if (minKėdžių > kiekKėdžių(s1.imtiIlgį(), s1.imtiPlotį(), k3.imtiIlgį(), k3.imtiPlotį()))
            {
                minKėdžių = kiekKėdžių(s1.imtiIlgį(), s1.imtiPlotį(), k3.imtiIlgį(), k3.imtiPlotį());
                minpav = "Trečio";
            }
            Console.WriteLine("{0} tipo kėdžių reikės mažiausiai : {1,6:d}", minpav, minKėdžių);
            Console.WriteLine("Programa baigė darbą");
        }
            /** Metodas apskaičiuojantis plotą kurį užima kėdė*/
            static int užimamasPlotas(int plotis, int ilgis)
        {
            return plotis * ilgis;
        }
        /** kėdžių skaičiavimas kiek telpa salėje*/
        static int kiekKėdžių(double ilgis, double plotis, int kėdėsIlgis, int kėdėsPlotis)
        {
            int vntEilėje = (int) Math.Floor(((ilgis - 2)* 1000) / kėdėsPlotis);                               // kiek kėdžių telpa į eilę
            int eiliųSk = (int) Math.Floor(((plotis - 3)* 1000) / (kėdėsIlgis + 300));                       // kiek eilių telpa
            return vntEilėje * eiliųSk;
        }
    }
}
