using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Lazeriniai_spausdintuvai
{
    class Spausdintuvas
    {
        string gamintojas,      //Lazerinio spausdintuvo gamintojas
               modelis;        //Lazerinio spausdintuvo modelis
        int Vsparta,            //vienpusio spausdinimo sparta psl/min
            Dsparta;            //vienpusio spausdinimo sparta psl/min
        double ppsl;            //pirmojo puslapio išspausdinimo laikas s
        public Spausdintuvas()
        {
            /**Pradiniai bukleto duomenys*/
            gamintojas = "";
            modelis = "";
            Vsparta = 0;
            Dsparta = 0;
            ppsl = 0;
        }
        public Spausdintuvas(string gamintojas, string modelis, int Vsparta, int Dsparta, double ppsl)
        {
            this.gamintojas = gamintojas;
            this.modelis = modelis;
            this.Vsparta = Vsparta;
            this.Dsparta = Dsparta; 
            this.ppsl = ppsl;
        }
        /** Spausdinimo metodas*/
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("|    {0,-6}| {1,-6}|       {2,-8}|   {3,-5}| {4,-5} |", gamintojas, modelis, Vsparta, Dsparta, ppsl);
            return eilute;
        }
    }
    class Parduotuvė
    {
        const int CMax = 100;           //Maksimalus bukletų skaičius
        private Spausdintuvas[] Sp;         //bukletų duomenys
        private int n;                  //bukletų skaičius
        public Parduotuvė()
        {
            n = 0;
            Sp = new Spausdintuvas[CMax];
        }
        /**Grąžina nurodyto indekso spausdintuvo objektą.
        @param i - buto indeksas*/
        public Spausdintuvas Imti(int i) { return Sp[i]; }

        /** Grąžina spausdintuvų kiekį */
        public int Imti() { return n; }

        /** Padeda į spausdintuvų objektų masyvą naują bukletą ir masyvo dydį padidina vienetu.
        @param šul - šulinių objektas */
        public void Dėti(Spausdintuvas Spa) { Sp[n++] = Spa; }
        //public void Rikiuoti()
        //{
        //    for (int i = 0; i < n - 1; i++)
        //    {
        //        Spausdintuvas min = Sp[i];
        //        int im = i;
        //        for (int j = i + 1; j < n; j++)
        //            if (Sp[j] <= min)
        //            {
        //                min = Sp[j];
        //                im = j;
        //            }
        //        Sp[im] = Sp[i];
        //        Sp[i] = min;
        //    }
        //}
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Lazeriniai_spausdintuvai\\bin\\Debug\\Duom.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Lazeriniai_spausdintuvai\\bin\\Debug\\Duom2.txt";
        const string CFrez = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Lazeriniai_spausdintuvai\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Parduotuvė parduotuvė = new Parduotuvė();
            Parduotuvė parduotuvė2 = new Parduotuvė();
            Parduotuvė parduotuvė3 = new Parduotuvė();
            Parduotuvė parduotuvė4 = new Parduotuvė();
            if (File.Exists(CFrez))
                File.Delete(CFrez);
            Skaityti(ref parduotuvė, CFd);
            Skaityti(ref parduotuvė2, CFd2);
            Spausdinti(parduotuvė, CFrez, "Pirmas duomenų failas");
            Spausdinti(parduotuvė2, CFrez, "Antras duomenų failas");
            Formuoti(parduotuvė, parduotuvė3);
            Formuoti(parduotuvė2, parduotuvė3);
        }
        static void Skaityti(ref Parduotuvė parduotuvė, string fv)
        {
            int Vsparta, Dsparta;
            string gamintojas, modelis;
            double ppsl;
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                gamintojas = parts[0].Trim();
                modelis = parts[1].Trim();
                Vsparta = int.Parse(parts[2].Trim());
                Dsparta = int.Parse(parts[3].Trim());
                ppsl = double.Parse(parts[4].Trim());
                Spausdintuvas Sp = new Spausdintuvas(gamintojas, modelis, Vsparta, Dsparta, ppsl);
                parduotuvė.Dėti(Sp);
            }
        }
        static void Spausdinti(Parduotuvė parduotuvė, string fv, string antraštė)
        {
            string virsus = "------------------------------------------------------------- \r\n"
                + "| Gamintojas | modelis | Vienpusio | Dvipusio |   Pirmo puslapio  |\r\n"
                + "|            |         |   sparta  |  sparta  | spausdinimo laikas|\r\n"
                + "------------------------------------------------------------------- ";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < parduotuvė.Imti(); i++)
                    fr.WriteLine("{0}", parduotuvė.Imti(i).ToString());
                fr.WriteLine("------------------------------------------------------- \n\n");
            }
        }
        static void Formuoti(Parduotuvė D, Parduotuvė R)
        {
            for (int i = 0; i < D.Imti(); i++)
                R.Dėti(D.Imti(i));
        }
    }
}
