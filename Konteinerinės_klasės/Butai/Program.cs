using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Butai
{
    class Butas
    {
        int numeris;         //Buto numeris
        int plotas;          //Buto plotas
        int kambariai;       //Kambarių sk
        int kaina;           //Pardavimo kaina
        int telNr;          //Telefono numeris
        public Butas()
        {
            /**Pradiniai buto duomenys*/
            numeris = 0;
            plotas = 0;
            kambariai = 0;
            kaina = 0;
            telNr = 0;
        }
        public Butas(int numeris, int plotasm, int kambariai, int kaina, int telNr)
        {
            this.numeris = numeris;
            this.plotas = plotasm;
            this.kambariai = kambariai;
            this.kaina = kaina;
            this.telNr = telNr;
        }
        /**Spausdinimo metodas*/
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,3:d} {1,7:d} {2,10:d} {3,13:d} {4, 18:d}", numeris, plotas, kambariai, kaina, telNr);
            return eilute;
        }
        public int tinkamųKambarių(int nurKambariai)
        {
            int z = kambariai;
            int y = kaina;
            if (z == nurKambariai)
            {
                return y;
            }
            else
                return 0;
        }

    }
    class Namas
    {
        const int Cmaxi = 100;
        private Butas[] Butai;
        private int n;
        public Namas()
        {
            n = 0;
            Butai = new Butas[Cmaxi];
        }

        /**Grąžina nurodyto indekso buto objektą.
        @param i - buto indeksas*/
        public Butas Imti(int i) { return Butai[i]; }

        /** Grąžina butų kiekį */
        public int Imti() { return n; }

        /** Padeda į butų objektų masyvą naują butą ir masyvo dydį padidina vienetu.
        @param bu - butų objektas */
        public void Dėti(Butas bu) { Butai[n++] = bu; }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Butai\\bin\\Debug\\Duom.txt";
        static void Main(string[] args)
        {
            Namas namas = new Namas();
            Namas namasN = new Namas();
            Skaityti(ref namas, CFd);
            Spausdinti(namas);

            int nurKambariai;
            Console.Write("Įveskite kambarių skaičių: ");
            nurKambariai = int.Parse(Console.ReadLine());

            int nurKaina;
            Console.Write("Įveskite maksimalią kainą: ");
            nurKaina = int.Parse(Console.ReadLine());
            Formuoti(namas, nurKambariai,ref namasN, nurKaina);
            Spausdinti(namasN);
        }
        //--------------------------------------------------------------------
        /** Failo duomenis surašo į konteinerį
        @param butas - butų konteineris
        @param fv - duomenų failo vardas */
        static void Skaityti(ref Namas namas, string fv)
        {
            int numeris, kambariai, n, telNr;
            int plotas, kaina;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    numeris = int.Parse(parts[0]);
                    plotas = int.Parse(parts[1]);
                    kambariai = int.Parse(parts[2]);
                    kaina = int.Parse(parts[3]);
                    telNr = int.Parse(parts[4]);
                    Butas bu = new Butas(numeris, plotas, kambariai, kaina, telNr);
                    namas.Dėti(bu);
                }
            }
        }
        static void Spausdinti(Namas namas)
        {
            string virsus = "  Informacija apie butus   \r\n"
                + "------------------------------------------------------------- \r\n"
                + " Nr.   plotas   kambarių sk.  kaina       telefono numeris \r\n"
                + "------------------------------------------------------------- ";
            if (namas.Imti() != 0)
            {
                Console.WriteLine(virsus);
                for (int i = 0; i < namas.Imti(); i++)
                    Console.WriteLine("{0}", namas.Imti(i).ToString());
                Console.WriteLine("------------------------------------------------------------- \n\n");
            }
            else
                Console.WriteLine("Tokio buto nėra");
        }
        /** Iš pirmojo konteinerio atrenka į antrąjį konteinerį butus, kuri turi nurodyta kambarių skaičių ir neviršija nurodytos kainos
        @param namas - pirmasis namo konteineris
        @param nurKambariai - nurodytas kambarių sk
        @param namasN - antrasis mano konteineris
        @param nurKaina - nurodyta kaina */
        static void Formuoti(Namas namas, int nurKambariai, ref Namas namasN, int nurKaina)
        {
            for (int i = 0; i < namas.Imti(); i++)
            {
                if ((namas.Imti(i).tinkamųKambarių(nurKambariai) < nurKaina) && (namas.Imti(i).tinkamųKambarių(nurKambariai) != 0))
                    namasN.Dėti(namas.Imti(i));
            }
        }
    }
}
