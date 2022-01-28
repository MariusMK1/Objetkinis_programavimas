using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Du_dviračių_punktai
{
    class Dviratis
    {
        private int metai;              // pagaminimo metai
        private double kaina;           // piniginį vertė
        /**Dviračio duomenys*/
        public Dviratis(int metai, double kaina)
        {
            this.metai = metai;
            this.kaina = kaina;
        }
        /**Grąžina metus*/
        public int imtiMetus() { return metai; }

        /**Grąžina kainą*/
        public double imtiKaina() { return kaina; }

    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Du_dviračių_punktai\\bin\\Debug\\Duom.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Du_dviračių_punktai\\bin\\Debug\\Duom2.txt";
        static void Main(string[] args)
        {
            //Pirmojo dviračių nuomos punkto
            Dviratis[] D = new Dviratis[Cn];                // Dviračių duomenys - objektai
            int n;                                          // Dviračių skaičius
            int am;                                         //dviračio tinkamumo naudoti kritinis amžius
            string pav;                                     //Nuomos punkto pavadinimas
            int kiekTinka, kiekNetinka, metuSumaTinka, metuSumaNetinka;
            double sumaTinka, sumaNetinka;
            //Antrojo dviračių nuomos punkto
            Dviratis[] D2 = new Dviratis[Cn];                // Dviračių duomenys - objektai
            int n2;                                          // Dviračių skaičius
            int am2;                                         //dviračio tinkamumo naudoti kritinis amžius
            string pav2;                                     //Nuomos punkto pavadinimas
            int kiekTinka2, kiekNetinka2, metuSumaTinka2, metuSumaNetinka2;
            double sumaTinka2, sumaNetinka2;


            Skaityti(CFd, D, out n, out am, out pav);
            Skaityti(CFd2, D2, out n2, out am2, out pav2);
            Console.WriteLine("Dviračių parduotuvė: {0}\n", pav);
            Console.WriteLine("Dviračių kiekis {0}\n", n);
            Console.WriteLine("Pagrindiniai metai    Kaina");
            for (int i = 0; i < n; i++)
                Console.WriteLine("       {0}         {1,7:f2}", D[i].imtiMetus(), D[i].imtiKaina());
            Console.WriteLine();

            Console.WriteLine("Dviračių parduotuvė: {0}\n", pav2);
            Console.WriteLine("Dviračių kiekis {0}\n", n2);
            Console.WriteLine("Pagrindiniai metai    Kaina");
            for (int i = 0; i < n2; i++)
                Console.WriteLine("       {0}         {1,7:f2}", D2[i].imtiMetus(), D2[i].imtiKaina());
            Console.WriteLine();

            Pinigai(D, n, 0, am, 2015, out kiekTinka, out sumaTinka);
            Pinigai(D, n, am + 1, 1000, 2015, out kiekNetinka, out sumaNetinka);
            MetuSuma(D, n, 2015, 0, am, out metuSumaTinka);
            MetuSuma(D, n, 2015, am + 1, 1000, out metuSumaNetinka);
            Pinigai(D2, n2, 0, am2, 2015, out kiekTinka2, out sumaTinka2);
            Pinigai(D2, n2, am2 + 1, 1000, 2015, out kiekNetinka2, out sumaNetinka2);
            MetuSuma(D2, n2, 2015, 0, am2, out metuSumaTinka2);
            MetuSuma(D2, n2, 2015, am2 + 1, 1000, out metuSumaNetinka2);

            double bendrasTinka = kiekTinka + kiekTinka2;
            double bendrasNetinka = kiekNetinka + kiekNetinka2;
            double bendraSumaTinka = sumaTinka + sumaTinka2;
            double bendraSumaNetinka = sumaNetinka + sumaNetinka2;
            double bendrasVidurkisTinka = (metuSumaTinka + metuSumaTinka2) / bendrasTinka;
            double bendrasVidurkisNetinka = (metuSumaNetinka + metuSumaNetinka2) / bendrasNetinka;
            Console.WriteLine("Abiejuose nuomos punktuose tinkamų naudoti dviračių yra: {0,7:f2}", bendrasTinka);
            Console.WriteLine("Abiejuose nuomos punktuose tinkamų naudoti dviračių vertė yra: {0,7:f2}", bendraSumaTinka);
            if (bendrasVidurkisTinka > 0)
                Console.WriteLine("Tinkamų naudoti dviračių vidutinis amžius:  {0,7:f2}", bendrasVidurkisTinka);
            else
                Console.WriteLine("Tinkamų naudoti dviračių nėra");

            Console.WriteLine("Abiejuose nuomos punktuose netinkamų naudoti dviračių yra: {0,7:f2}", bendrasNetinka);
            Console.WriteLine("Abiejuose nuomos punktuose netinkamų naudoti dviračių vertė yra: {0,7:f2}", bendraSumaNetinka);
            if (bendrasVidurkisNetinka > 0)
                Console.WriteLine("Netinkamų naudoti dviračių vidutinis amžius:{0,7:f2}\n", bendrasVidurkisNetinka);
            else
                Console.WriteLine("Netinkamų naudoti dviračių nėra\n");



            Console.WriteLine("Daugiau tinkamų naudoti dviračių yra parduotuvėje: {0}", kuriameTinkamuDaugiau(kiekTinka, kiekTinka2, pav, pav2));
            double visaVerte = sumaTinka + sumaNetinka;
            double visaVerte2 = sumaTinka2 + sumaNetinka2;
            if (visaVerte > visaVerte2)
                Console.WriteLine("Didesnė dviračių piniginė vertė ({0, 7:f2} Eurai) yra parduotuvėje {1}", visaVerte, pav);
            else
                Console.WriteLine("Didesnė dviračių piniginė vertė ({0, 7:f2} Eurai) yra parduotuvėje {1}", visaVerte2, pav2);

        }
        /**Skaityti duomenis iš failo metodas
        @param fv - failo vardas, kuris nurodomas konstanta CFd
        @param D - objektų rinkinys dviračių duomenims saugoti
        @param n - dviračių skaičius 
        @param m - kritinis dviračių naudojimo amžius
        @param pav - nuomos punkto pavadinimas */
        static void Skaityti(string fv, Dviratis[] D, out int n, out int m, out string pav)
        {
            int metai;
            double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                pav = line;
                line = reader.ReadLine();
                m = int.Parse(line);
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    metai = int.Parse(parts[0]);
                    kaina = double.Parse(parts[1]);
                    D[i] = new Dviratis(metai, kaina);
                }
            }
        }
        /**Skaičiuoja tnkamo amžiaus dviračių kainų sumą ir kiekį
        @param D - dviračių duomenys
        @param n - dviračių skaičius
        @param amPr - dviračių paieškos amžiaus intervalo pradžia
        @param amPb - dviračių paieškos amžiaus intervalo pabaiga  
        @param metai - metai, kurių atžvilgiu skaičiuojamas amžius
        @param kiek - dviračių skaičius duotame amžiaus intervale
        @param suma - duoto amžiaus intervalo dviračių piniginė verttė */
        static void Pinigai(Dviratis[] D, int n, int ammPr, int amPb, int metai, out int kiek, out double suma)
        {
            kiek = 0;
            suma = 0;
            int amžius;
            for (int i = 0; i < n; i++)
            {
                amžius = metai - D[i].imtiMetus();
                if ((ammPr <= amžius) && (amžius <= amPb))
                {
                    suma = suma + D[i].imtiKaina();
                    kiek++;
                }
            }
        }
        /**Skaičiuoja nurodyto dviračių amžiaus intervalo vidurkį
        @param D - dviračių duomenys
        @param n - dviračių skaičius
        @param amPr - dviračių paieškos amžiaus intervalo pradžia
        @param amPb - dviračių paieškos amžiaus intervalo pabaiga
        @param metai - metai, kurių atžvilgiu skaičiuojamas amžius */
        static void MetuSuma(Dviratis[] D, int n, int metai, int amPr, int amPb, out int suma)
        {
            int kiek = 0;
            suma = 0;
            int amžius;
            for (int i = 0; i < n; i++)
            {
                amžius = metai - D[i].imtiMetus();
                if ((amPr <= amžius) && (amžius <= amPb))
                {
                    suma = suma + amžius;
                    kiek++;
                }
            }
        }
        static string kuriameTinkamuDaugiau(int kiekTinka, int kiekTinka2, string pav, string pav2)
        {
            if (kiekTinka > kiekTinka2)
                return pav;
            else
                return pav2;
        }
    }
}
