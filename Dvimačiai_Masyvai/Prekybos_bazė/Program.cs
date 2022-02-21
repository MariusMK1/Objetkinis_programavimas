using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Prekybos_bazė
{
    /** Klasė kasų duomenims saugoti
     @class Matrica*/
    class Matrica
    {
        const int CMaxEil = 10;             //Didižiausias galimas eilučių (kasų) skaičius
        const int CMaxSt = 100;             //Didžiausias galimas stulpelių (dienų) skaičius
        private int[,] A;                   //Duomenų matrica
        public int n { get; set; }         //Eilučių skaičius (kasų skaičius)
        public int m { get; set; }         //Stulpelių skaičius (dienų skaičius)

        /**Pradinių matricos duomenų nustatymas*/
        public Matrica()
        {
            n = 0;
            m = 0;
            A = new int[CMaxEil, CMaxSt];
        }

        /**Priskiria klasės matricos kintamajam reikšmę.
        @param i - eilutės (kasos) indeksas
        @param j - stulpelio (dienos) indeksas
        @param pirk - pirkėjų skaičius*/
        public void Dėti(int i, int j, int pirk)
        {
            A[i, j] = pirk;
        }
        /**Gražina pirkėjų kiekį.
        @param i - eilutės (kasos) indeksas
        @param j - stulpelio (dienos) indeksas
        */
        public int ImtiReiksme(int i, int j)
        {
            return A[i, j];
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Prekybos_bazė\\bin\\Debug\\Duom.txt";
        const string CFr = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Prekybos_bazė\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Matrica prekybosBaze = new Matrica();
            Skaityti(CFd, ref prekybosBaze);
            if (File.Exists(CFr))
                File.Delete(CFr);
            Spausdinti(CFr, prekybosBaze, "Pradiniai duomenys:");
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine("Rezultatai");
                fr.WriteLine();
                fr.WriteLine("Viso aptarnauta: {0} klientų.", VisoAptarnautų(prekybosBaze));
                fr.WriteLine("Daugiausia pirkėjų aptarnavo (kasa): {0}", KasosNrMaxPirkėjų(prekybosBaze));
            }
            KiekvienaKasaAptarnavo(CFr, prekybosBaze);
            KiekvienąDienąAptarnauta(CFr, prekybosBaze);

            Console.WriteLine("Programa baigė darbą");
        }
        /**Failo duomenis surašo į konteinerį.
        @param fd - duomenų failo vardas
        @param prekybosBazė - dvimatis konteineris */
        static void Skaityti(string fd, ref Matrica prekybosBaze)
        {
            int nn, mm, skaic;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                prekybosBaze.n = nn;
                prekybosBaze.m = mm;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < mm; j++)
                    {
                        skaic = int.Parse(parts[j]);
                        prekybosBaze.Dėti(i, j, skaic);
                    }
                }
            }
        }
        /**Failo duomenis surašo į konteinerį.
        @param fd - duomenų failo vardas
        @param prekybosBazė - dvimatis konteineris */
        static void Spausdinti(string fv, Matrica prekybosBaze, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine("Kasų kiekis {0}", prekybosBaze.n);
                fr.WriteLine("Darbo dienų kiekis {0}", prekybosBaze.m);
                fr.WriteLine("Aptarnautų klientų kiekiai");
                for (int i = 0; i < prekybosBaze.n; i++)
                {
                    for (int j = 0; j < prekybosBaze.m; j++)
                        fr.Write("{0,4:d}", prekybosBaze.ImtiReiksme(i, j));
                    fr.WriteLine();
                }
            }
        }
        /**Skačiuoja ir gražina prekybos bazėje aptarnautų pirkėjų skaičių.
        @param A - konteinerio vardas*/
        static int VisoAptarnautų(Matrica A)
        {
            int suma = 0;
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                    suma = suma + A.ImtiReiksme(i, j);
            }
            return suma;
        }
        /**Skačiuoja ir išspausdina, kiek pikrėjų aptarnavo kiekvieną kasą.
        @param CFr - rezultatų failo vardas
        @param A - konteinerio vardas */
        static void KiekvienaKasaAptarnavo(string CFr, Matrica A)
        {
            using (var fr = File.AppendText(CFr))
            {
                for (int i = 0; i < A.n; i++)
                {
                    int suma = 0;
                    for (int j = 0; j < A.m; j++)
                        suma = suma + A.ImtiReiksme(i, j);
                    fr.WriteLine("kasa nr {0} aptarnavo {1} klientų.", i + 1, suma);
                }
            }
        }
        /**Skačiuoja ir išspausdina, kiek pikrėjų buvo aptarnauta kiekvieną dien1.
        @param CFr - rezultatų failo vardas
        @param A - konteinerio vardas */
        static void KiekvienąDienąAptarnauta(string CFr, Matrica A)
        {
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                for (int j = 0; j < A.m; j++)
                {
                    int suma = 0;
                    for (int i = 0; i < A.n; i++)
                        suma = suma + A.ImtiReiksme(i, j);
                    fr.WriteLine("Diena nr. {0}: aptarnavo klientų - {1}", j + 1, suma);
                }
            }
        }
        /**Suranda ir grąžina, kur kasa patarnavo daugiausiai pirkėjų
        @param A - konteinerio vardas */
        static int KasosNrMaxPirkėjų(Matrica A)
        {
            int max = 0;
            int nr = 0;
            for (int i = 0; i < A.n; i++)
            {
                int suma = 0;
                for (int j = 0; j < A.m; j++)
                    suma = suma + A.ImtiReiksme(i, j);
                if (suma > max)
                {
                    max = suma;
                    nr = i + 1;
                }
            }
            return nr;
        }
    }
}
