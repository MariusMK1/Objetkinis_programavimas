using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dviračiai
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
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Dviračiai\\bin\\Debug\\Duom.txt";
        static void Main(string[] args)
        {
            //Dviratis d;
            //d = new Dviratis(2012, 25.26);
            //Console.WriteLine("{0} {1, 6:f2} \n", d.imtiMetus(), d.imtiKaina());
            //Console.WriteLine("Programa baigė darbą!");
            Dviratis[] D = new Dviratis[Cn];                // Dviračių duomenys - objektai
            int n;                                          // Dviračių skaičius
            int am;                                         //dviračio tinkamumo naudoti kritinis amžius
            Skaityti(CFd, D, out n, out am);
            Console.WriteLine("Dviračių kiekis {0}\n", n);
            Console.WriteLine("Pagrindiniai metai    Kaina");
            for (int i = 0; i < n; i++)
                Console.WriteLine("       {0}         {1,7:f2}", D[i].imtiMetus(), D[i].imtiKaina());
            Console.WriteLine();

            int kiekTinka;
            double sumaTinka;
            Pinigai(D, n, 0, am, 2015, out kiekTinka, out sumaTinka);
            Console.WriteLine("tinkami naudoti: {0,3:d}  {1,7:f2}", kiekTinka, sumaTinka);

            int kiekNetinka;
            double sumaNetinka;
            //netinkami naudoti dviračiai, kurių amžius didelis,
            //t.y. intervale nuo m iki beaglybės (pvz., 1000 metų)
            Pinigai(D, n, am + 1, 1000, 2015, out kiekNetinka, out sumaNetinka);
            Console.WriteLine("Netinkami naudoti: {0}  {1,7:f2}\n", kiekNetinka, sumaNetinka);
            Console.WriteLine();

            double vidurkisTinka = Vidurkis(D, n, 2015, 0, am);
            if (vidurkisTinka > 0)
                Console.WriteLine("Tinkamų naudoti dviračių vidutinis amžius:  {0,7:f2}", vidurkisTinka);
            else
                Console.WriteLine("Tinkamų naudoti dviračių nėra");
            double vidurkisNetinka = Vidurkis(D, n, 2015, am + 1, 1000);
            if (vidurkisNetinka > 0)
                Console.WriteLine("Netinkamų naudoti dviračių vidutinis amžius:{0,7:f2}\n", vidurkisNetinka);
            else
                Console.WriteLine("Netinkamų naudoti dviračių nėra\n");

            // programos papildymas
            int visųMetai;
            double visųVertė;
            Pinigai(D, n, 0, 1000, 2015, out visųMetai, out visųVertė);
            Console.WriteLine("Visų dviračių piniginė vertė: {0,7:f2}", visųVertė);
            double visųVidurkis = Vidurkis(D, n, 2015, 0, 1000);
            Console.WriteLine("Visų dviračių vidutinis amžius:  {0,7:f2}", visųVidurkis);
            int vnt2012;
            double suma2012;
            Pinigai(D, n, 0, 0, 2012, out vnt2012, out suma2012);
            Console.WriteLine("2012 metais pagamintų dviračių yra:{0,3:d} ir jų vidutinis amžius{1,7:f2} metai", vnt2012, Vidurkis(D, n, 2015, 3, 3));
            int vnt1000;
            double suma1000;
            Pinigai(D, n, 0, 0, 1000, out vnt1000, out suma1000);
            Console.WriteLine("1000 metais pagamintų dviračių yra:{0,3:d} ir jų vidutinis amžius{1,7:f2} metai", vnt1000, Vidurkis(D, n, 2015, 1115, 1115));
            Console.WriteLine("Programa baigė darbą!");
        }
        /**Skaityti duomenis iš failo metodas
        @param fv - failo vardas, kuris nurodomas konstanta CFd
        @param D - objektų rinkinys dviračių duomenims saugoti
        @param n - dviračių skaičius 
        @param m - kritinis dviračių naudojimo amžius  */
        static void Skaityti(string fv, Dviratis[ ] D, out int n, out int m)
        {
            int metai;
            double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
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
        static void Pinigai(Dviratis[ ] D, int n, int ammPr, int amPb, int metai, out int kiek, out double suma)
        {
            kiek = 0;
            suma = 0;
            int amžius;
            for (int i = 0; i < n; i++)
            {
                amžius = metai - D[i].imtiMetus();
                if ((ammPr <= amžius ) && (amžius <= amPb))
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
        static double Vidurkis(Dviratis[ ] D, int n, int metai, int amPr, int amPb)
        {
            int kiek = 0, suma = 0;
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
            if (kiek > 0) return (double)suma / kiek;
            return 0.0;
        }
    }
}
