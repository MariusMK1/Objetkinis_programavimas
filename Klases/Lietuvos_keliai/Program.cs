using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lietuvos_keliai
{
    //** klasė kelio duomenims saugoti @ class Kelias */
    class Kelias
    {
        private string pav;          // kelio pavadinimas
        private double ilgis;        // kelio ilgis km
        private int lgr;             // lleistinas greitis km/val
        public Kelias(string pav, double ilgis, int lgr)
        {
            this.pav = pav;
            this.ilgis = ilgis;
            this.lgr = lgr;
        }

        /** įrašo leistiną greitį km/val.*/
        public void dėtiLeistGreitį(int lg) { lgr = lg; }
        /** grąžina kelio pavadinimą*/
        public string imtiPav() { return pav; }
        /** grąžina kelio ilgį*/
        public double imtiIlgį() { return ilgis; }
        /** grąžina leistiną greitį km/val*/
        public int imtiLesitGreitį() { return lgr; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Duomenų priskirimas
            Kelias k1, k2, k3;          // Objektai
            k1 = new Kelias("Kaunas - Vilnius", 105.0, 110);
            k2 = new Kelias("Kaunas - Alytus", 65.6, 90);
            k3 = new Kelias("Vilnius - Panevėžys", 136.0, 120);

            // Važiavimo laiko radimas
            double laikas = k2.imtiIlgį() / k2.imtiLesitGreitį() + k1.imtiIlgį() / k1.imtiLesitGreitį() + k3.imtiIlgį() / k3.imtiLesitGreitį();

            // Ilgiausio kelio radimas
            string maxPav = k1.imtiPav();
            double maxIlg = k1.imtiIlgį();
            if (k2.imtiIlgį() > maxIlg)
            {
                maxPav = k2.imtiPav();
                maxIlg = k2.imtiIlgį();
            }
            if (k3.imtiIlgį() > maxIlg)
            {
                maxPav = k3.imtiPav();
                maxIlg = k3.imtiIlgį();
            }

            // Mažiausio leisitino greičio radimas
            string minPav = k1.imtiPav();
            double minLgr = k1.imtiLesitGreitį();
            if (k2.imtiLesitGreitį() < minLgr)
            {
                minPav = k2.imtiPav();
                minLgr = k2.imtiLesitGreitį();
            }
            if (k3.imtiLesitGreitį() < minLgr)
            {
                minPav = k3.imtiPav();
                minLgr = k3.imtiLesitGreitį();
            }

            // Duomenų spausdinimas
            Console.WriteLine("Keliai, (pavadinimas, \t   ilgis, \t   leistinas greitis:)");
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k1.imtiPav(), k1.imtiIlgį(), k1.imtiLesitGreitį());
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k2.imtiPav(), k2.imtiIlgį(), k2.imtiLesitGreitį());
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k3.imtiPav(), k3.imtiIlgį(), k3.imtiLesitGreitį());
            Console.WriteLine();
            Console.WriteLine("Iš Alytaus į Panevėžį nuvažiuosime per {0,5:f2} val.", laikas);
            Console.WriteLine();
            Console.WriteLine("Ilgiausias kelias: {0}", maxPav);
            Console.WriteLine();
            Console.WriteLine("Mažiausias leistinas greitis yra: {0} kelyje", minPav);
            Console.WriteLine();
            Console.WriteLine("programa baigė darbą!");
        }
    }
}
