using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sodas
{
    /**Obelis klasė
     @class Obelis*/
    class Obelis
    {
        private int kiek,                   //Pirmaisiais metais užderėjusių obuolių kiekis: atitinka užduotyje z0
                    priaug;                 //Obuolių prieaugis kiekvienais metais: atitinka užduotyje zh
        private int koef1, koef2;           //Dėsnio koeficientai: atitinka užduotyje a ir b
        
        /**Pradiniai obels duomenys*/
        public Obelis()
        {
            kiek = 0;
            priaug = 16;
            koef1 = 1;
            koef2 = 2;
        }
        /** Obels duomenys
        @param keik - Pirmaisiais metais užderėjusių obuolių kiekis
        @param priaug - Obuolių prieaugis kiekvienais metais
        @param koef1 - Dėsnio koeficientas a
        @param koef2 - Dėsnio koeficientas b */
        public Obelis(int kiek, int priaug, int koef1, int koef2)
        {
            this.kiek = kiek;
            this.priaug = priaug;
            this.koef1 = koef1;
            this.koef2 = koef2;

        }
        /**Spausdinimo metodas*/
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, 5:d} {1, 6:d} {2, 5:d} {3, 7:d}", koef1, koef2, kiek, priaug);
            return eilute;
        }
        /** Pagal nurodytą dėsnį - formulę apskaičiuoja ir grąžina užderėjusių obuolių kiekį
        @param a - 1-asis dėsnio koeficientas
        @param b - 2-asis dėsnio koeficientas
        @param z - dėsnio parametras */
        public int Dėsnis(int a, int b, double z)
        {
            if (Math.Sin(a * z) > 0.1)
            {
                double t = Math.Pow(Math.Sin(a * z) - 0.1, 0.5);
                int y = (int)Math.Floor(a - b * t + z * t * t);
                return y;
            }
            else
                return 0;
        }
        /** Apskaičiuoja ir ekrane lentele spausdina kiekvienais metais iki nurodytų metų obels užderėjusių obuolių kiekį
        @param metai - metų kiekis */
        public void Obuoliai(int metai)
        {
            int z = kiek;
            int y;
            Console.WriteLine(" ---------------------");
            Console.WriteLine(" Metai  Obuolių kiekis");
            Console.WriteLine(" ---------------------");
            for (int i = 0; i < metai; i++)
            {
                y = Dėsnis(koef1, koef2, z);
                if (y > 0)
                    Console.WriteLine("{0,5:d}  {1,8:d}", i + 1, y);
                else
                    Console.WriteLine("{0,5:d}    nėra obuolių", i + 1);
                z = z + priaug;
            }
            Console.WriteLine(" --------------------------\r\n");
        }
        public int VisoObuolių(int metai)
        {
            int z = kiek;
            int y;
            int suma = 0;
            for (int i = 0; i < metai; i++)
            {
                y = Dėsnis(koef1, koef2, z);
                suma += y;
                z = z + priaug;
            }
            return suma;
        }
    }

    //----------------------------------------------------------------------
    /**Sodo klasė
     @class Sodas*/
    class Sodas
    {
        const int CMaxi = 100;
        private Obelis[] Obelys;
        private int n;

        public Sodas()
        {
            n = 0;
            Obelys = new Obelis[CMaxi];
        }
        /**Grąžina nurodyto indekso obels objektą.
        @param i - obels indeksas*/
        public Obelis Imti(int i) { return Obelys[i]; }

        /** Grąžina obelų kiekį */
        public int Imti() { return n; }     //metodų užklojimas

        /** Padeda į obelų objektų masyvą naują obelį ir masyvo dydį padidina vienetu.
        @param ob - obels objektas */
        public void Dėti(Obelis ob) { Obelys[n++] = ob; }
        }

    //-------------------------------------------------------------
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Sodas\\bin\\Debug\\U1.txt";
        static void Main(string[] args)
        {
            Sodas sodas = new Sodas();
            Sodas sodasN = new Sodas();
            Skaityti(ref sodas, CFd);
            Spausdinti(sodas);

            int metai;
            Console.Write("Įveskite metų reikšmę: ");
            metai = int.Parse(Console.ReadLine());
            Skaičiuoti(sodas, metai);

            int kiek;
            Console.Write("Sunokintas obuolių kiekis: ");
            kiek = int.Parse(Console.ReadLine());
            Formuoti(sodas, metai,ref sodasN, kiek);
            Spausdinti(sodasN);

            Console.WriteLine("Programa baigė darbą!");
        }

        //--------------------------------------------------------------------
        /** Failo duomenis surašo į konteinerį
        @param sodas - obelų konteineris
        @param fv - duomenų failo vardas */
        static void Skaityti(ref Sodas sodas, string fv)
        {
            int koef1, koef2, kiek, priaug, n;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for(int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    koef1 = int.Parse(parts[0]);
                    koef2 = int.Parse(parts[1]);
                    kiek = int.Parse(parts[2]);
                    priaug = int.Parse(parts[3]);
                    Obelis ob = new Obelis(kiek, priaug, koef1, koef2);
                    sodas.Dėti(ob);
                }
            }
        }
        static void Spausdinti (Sodas sodas)
        {
            string virsus = "  Informacija apie obelis    \r\n"
                + "---------------------------------- \r\n"
                + " Nr.  koef1  koef2  kiek  prieaug  \r\n"
                + "---------------------------------- ";
            Console.WriteLine(virsus);
            for (int i = 0; i < sodas.Imti(); i++)
                Console.WriteLine("{0, 4:d} {1}", i + 1, sodas.Imti(i).ToString());
            Console.WriteLine("---------------------------------- \n\n");
        }
        /** Spausdina kiekvienos konteinerio obels kiekvienų metų derlių ekrane lentele
        @param sodas - obelų konteineris
        @param metai - metų kiekis */
        static void Skaičiuoti(Sodas sodas, int metai)
        {
            Console.WriteLine(" Informacija apie derlių");
            for (int i = 0; i < sodas.Imti(); i++)
            {
                Console.WriteLine("{0,3:d} obelis", i + 1);
                sodas.Imti(i).Obuoliai(metai);
            }
        }
        /** Iš pirmojo konteinerio atrenka į antrąjį konteinerį obelis, kurios per nurodytą metų kiekį sunokino daugiau, negu nurodytas kiekis obuolių
        @param sodas - pirmasis obelų konteineris
        @param metai - metų kiekis
        @param sodasN - antrasis obelų konteineris
        @param kiekis - obuolių kiekis */
        static void Formuoti(Sodas sodas, int metai, ref Sodas sodasN, int kiek)
        {
            for (int i = 0; i < sodas.Imti(); i++)
            {
                if (sodas.Imti(i).VisoObuolių(metai) > kiek)
                   sodasN.Dėti(sodas.Imti(i));
            }
        }
    }
}
