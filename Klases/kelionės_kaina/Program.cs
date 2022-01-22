using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kelionės_kaina
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
    /** klasė automobilio duomenims saugoti @ class Auto */
    class Auto
    {
        private string pav;             // automobilio pavadinimas
        private string degalai;         // degalų tipas
        private double sąnaudos;        // sąnaudos per 100 km. litrais
        public Auto(string pav, string degalai, double sanaudos)
        {
            this.pav = pav;
            this.degalai = degalai;
            this.sąnaudos = sanaudos;
        }
        /** grąžina automoblio pavadinimą*/
        public string imtiPav() { return pav; }
        /** grąžina degalų tipą*/
        public string imtiDegalus() { return degalai;}
        /** grąžina sąnaudoas l/100km*/
        public double imtiSąnaudas() { return sąnaudos;}
    }
    class Degalai
    {
        private string tipas;           // 1 litro tipas
        private double kaina;           // 1 litro kaina
        public Degalai(string tipas, double kaina)
        {
            this.tipas = tipas;
            this.kaina = kaina;
        }
        //** grąžina kuro tipą*/
        public string imtitipą() { return tipas; }
        //** grąžina 1l kainą*/
        public double imtiKainą() { return kaina; } 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Duomenų priskirimas
            Kelias k1, k2, k3;          // keliai
            k1 = new Kelias("Kaunas - Vilnius", 105.0, 110);
            k2 = new Kelias("Kaunas - Alytus", 65.6, 90);
            k3 = new Kelias("Vilnius - Panevėžys", 136.0, 120);
            Auto a1, a2;                // automobiliai
            a1 = new Auto("Opel Meriva", "benzinas", 7.5);
            a2 = new Auto("Volkswagen Golf", "dyzelinass", 6.3);

            // Duomenų spausdinimas
            Console.WriteLine("Keliai, (pavadinimas, \t   ilgis, \t   leistinas greitis:)");
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k1.imtiPav(), k1.imtiIlgį(), k1.imtiLesitGreitį());
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k2.imtiPav(), k2.imtiIlgį(), k2.imtiLesitGreitį());
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k3.imtiPav(), k3.imtiIlgį(), k3.imtiLesitGreitį());
            Console.WriteLine();
            Console.WriteLine("Automobiliai:");
            Console.WriteLine("{0},\t\t {1},\t {2,8:f2}", a1.imtiPav(), a1.imtiDegalus(), a1.imtiSąnaudas());
            Console.WriteLine("{0},\t {1},\t {2,8:f2}", a2.imtiPav(), a2.imtiDegalus(), a2.imtiSąnaudas());
            Console.WriteLine();

            // Duomenų įvedias ranka
            //double bkaina, dkaina;
            //Console.Write("Kiek kainuoja 1 litras benzino? ");
            //bkaina = double.Parse(Console.ReadLine());
            //Console.Write("Kiek kainuoja 1 litras dyzelino? ");
            //dkaina = double.Parse(Console.ReadLine());

            Degalai d1, d2;
            Console.Write("Kiek kainuoja 1 litras benzino? ");
            d1 = new Degalai("benzinas", double.Parse(Console.ReadLine()));
            Console.Write("Kiek kainuoja 1 litras dyzelino? ");
            d2 = new Degalai("dyzelinas",double.Parse(Console.ReadLine()));

            // Kelionės išlaidų skaičiavimas
            double kaina1, kaina2;
            double atstumas = k1.imtiIlgį() + k2.imtiIlgį() + k3.imtiIlgį();
            if (a1.imtiDegalus() == d1.imtitipą())
                kaina1 = kelionėsKaina(atstumas, a1.imtiSąnaudas(), d1.imtiKainą());
            else
                kaina1 = kelionėsKaina(atstumas, a1.imtiSąnaudas(), d1.imtiKainą());
            if (a2.imtiDegalus() == d2.imtitipą())
                kaina2 = kelionėsKaina(atstumas, a2.imtiSąnaudas(), d2.imtiKainą());
            else
                kaina2 = kelionėsKaina(atstumas, a2.imtiSąnaudas(), d2.imtiKainą());

            // Kainų spausdinimas
            Console.WriteLine();
            Console.WriteLine("Automobiliu {0} iš Alytaus į Panevėžį nuvažiuosime už {1,7:f2} EUR.\n", a1.imtiPav(), kaina1);
            Console.WriteLine("Automobiliu {0} iš Alytaus į Panevėžį nuvažiuosime už {1,7:f2} EUR.\n", a2.imtiPav(), kaina2);
            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą");

        }

        //** Suskaičiuoja ir grąžina kelionės kainą*/
        static double kelionėsKaina(double atstumas, double sąnaudos, double litroKaina)
        {
            return (atstumas / 100) * sąnaudos * litroKaina;
        }
    }
}
