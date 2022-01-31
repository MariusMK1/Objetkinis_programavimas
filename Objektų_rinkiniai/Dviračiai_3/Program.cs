using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dviračiai_3
{
    class Dviratis
    {
        private string pav;
        private int kiek;
        private int metai;              // pagaminimo metai
        private double kaina;           // piniginį vertė
        /**Dviračio duomenys*/
        public Dviratis(string pav, int kiek, int metai, double kaina)
        {
            this.pav = pav;
            this.kiek = kiek;
            this.metai = metai;
            this.kaina = kaina;
        }

        /**Grąžina dviračio pavadinimą*/
        public string imtiPavadinima() { return pav; }

        /**Grąžina kiekį*/
        public int imtiKiekį() { return kiek; }

        /**Grąžina metus*/
        public int imtiMetus() { return metai; }

        /**Grąžina kainą*/
        public double imtiKaina() { return kaina; }
        public void papildytiKiekį(int k) { kiek = kiek + k; }

    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Dviračiai_3\\bin\\Debug\\Duom.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Dviračiai_3\\bin\\Debug\\Duom2.txt";
        const string CFrez = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Dviračiai_3\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            //Pirmojo dviračių nuomos punkto
            Dviratis[] D = new Dviratis[Cn];                // Dviračių duomenys - objektai
            int n;                                          // Dviračių skaičius
            string pav;                                     //Nuomos punkto pavadinimas
            //Antrojo dviračių nuomos punkto
            Dviratis[] D2 = new Dviratis[Cn];                // Dviračių duomenys - objektai
            int n2;                                          // Dviračių skaičius
            string pav2;                                     //Nuomos punkto pavadinimas


            Skaityti(CFd, D, out n, out pav);
            Skaityti(CFd2, D2, out n2, out pav2);
            Console.WriteLine("Dviračių parduotuvė: {0}\n", pav);
            Console.WriteLine("Dviračių kiekis {0}\n", n);
            Console.WriteLine("Pavadinimas Kiekis Pgaminimo metai Kaina");
            for (int i = 0; i < n; i++)
                Console.WriteLine("{0,-12} {1,4:d}     {2,3:d}     {3, 7:f2}", D[i].imtiPavadinima(), D[i].imtiKiekį(), D[i].imtiMetus(), D[i].imtiKaina());
            Console.WriteLine();

            Console.WriteLine("Dviračių parduotuvė: {0}\n", pav2);
            Console.WriteLine("Dviračių kiekis {0}\n", n2);
            Console.WriteLine("Pavadinimas Kiekis Pgaminimo metai Kaina");
            for (int i = 0; i < n2; i++)
                Console.WriteLine("{0,-12} {1,4:d}     {2,3:d}     {3, 7:f2}", D2[i].imtiPavadinima(), D2[i].imtiKiekį(), D2[i].imtiMetus(), D2[i].imtiKaina());
            Console.WriteLine();

            if (File.Exists(CFrez))
                File.Delete(CFrez);

            SpausdintiDuomenis(CFrez, D, n, pav);
            SpausdintiDuomenis(CFrez, D2, n2, pav2);

            using (var fr = File.AppendText(CFrez))
            {
                if (D[Seniausias(D, n)].imtiMetus() < D2[Seniausias(D2, n2)].imtiMetus())
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte {0}", pav);
                else if (D[Seniausias(D, n)].imtiMetus() == D2[Seniausias(D2, n2)].imtiMetus())
                {
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte {0}", pav);
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte {0}", pav2);
                }
                else
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte {0}", pav2);
            }
            Dviratis[] Dr = new Dviratis[Cn];
            int nr;
            nr = 0;
            Formuoti(D, n, Dr, ref nr);
            Formuoti(D2, n2,Dr, ref nr);
            SpausdintiDuomenis(CFrez, Dr, nr, "Modelių sąrašas");
        }
        /**Skaityti duomenis iš failo metodas
        @param fv - failo vardas, kuris nurodomas konstanta CFd
        @param D - objektų rinkinys dviračių duomenims saugoti
        @param n - dviračių skaičius 
        @param pav - nuomos punkto pavadinimas */
        static void Skaityti(string fv, Dviratis[] D, out int n, out string pav)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                string eil; int kiekn; int metain; double kainan;
                string line;
                line = reader.ReadLine();
                string[] parts;
                pav = line;
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    eil = parts[0];
                    kiekn = int.Parse(parts[1]);
                    metain = int.Parse(parts[2]);
                    kainan = double.Parse(parts[3]);
                    D[i] = new Dviratis(eil, kiekn, metain, kainan);
                }
            }
        }
        /**Spausdina duomenis į failą
        @param fv - rezultatų failo vardas
        @param D - objektų rinkinys dviračių duomenims saugoti
        @param n - dviračių skaičius 
        @param pav - nuomos punkto pavadinimas */
        static void SpausdintiDuomenis(string fv, Dviratis[] D, int nkiek, string pav)
        {
            const string virsus =
                "|---------------|------------|-------------|----------|\r\n"
               + "|  Pavadinimas  |   kiekis   |  Pagaminimo |   Kaina  | \r\n"
               + "|               |            |     metai   |          | \r\n"
               + "|---------------|------------|-------------|----------| \r\n";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Nuomos firma: {0}", pav);
                fr.Write(virsus);
                Dviratis tarp;
                for(int i = 0; i < nkiek; i++)
                {
                    tarp = D[i];
                    fr.WriteLine("|{0,-15}| {1,8}   |    {2,5:d}    | {3,7:f2}  |", tarp.imtiPavadinima(), tarp.imtiKiekį(), tarp.imtiMetus(), tarp.imtiKaina());
                }
                fr.WriteLine("-------------------------------------------------------");
                fr.WriteLine();
            }
        }
        /** Grąžina dviračio, kurio metų skaičius yra mažiausias, indeksą
         @parm D - objektų rinkinys
         @parm n - objektų skaičius rinkinyje */
        static int Seniausias(Dviratis[] D, int n)
        {
            int k = 0;
            for (int i = 0; i < n; i++)
                if(D[i].imtiMetus() < D[k].imtiMetus())
                {
                    k = i;
                }
                return k;

        }
        /** Grąžina surasto dviračio masyve indeksą arba -1, jeigu dviračio masyve nera
         @parm D - objektų rinkinys
         @parm n - objektų skaičius rinkinyje
         @parm pav - ieškomo modelio pavadinimas */
        static int yraModelis(Dviratis[] D, int n, string pav, int metai)
        {
            for (int i = 0; i < n; i++)
            {
                if (D[i].imtiPavadinima() == pav && D[i].imtiMetus() == metai)
                {
                    return i;
                }
            }
            return -1;              
        }
        /** Grąžina surasto dviračio masyve indeksą arba -1, jeigu dviračio masyve nera
         // Jeigu objektų rinkinio D tokio pat modelio dviratis yra objektų rinkinyje Dr,
         // tuomet didinamas kiekis, kitaip - papildomas nauju objektu
         @parm D - objektų rinkinys iš kurio pildo
         @parm n - objektų skaičius rinkinyje D
         @parm nr - objektų skaičius rinkinyje Dr
         @parm Dr - objektų rinkinys, kurį pildo */
    static void Formuoti(Dviratis[] D, int n, Dviratis[] Dr, ref int nr)
        {
            int k;
            for (int i = 0; i < n; i++)
            {
                k = yraModelis(Dr, nr, D[i].imtiPavadinima(), D[i].imtiMetus());
                if (k >= 0)
                    Dr[k].papildytiKiekį(D[i].imtiKiekį());         //Didinamas kiekis
                else
                {
                    Dr[nr] = D[i];                                  // papildomas rinkinys
                    nr++;
                }
            }
        }
    }
}
