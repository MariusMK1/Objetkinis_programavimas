using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Fakultetas_2
{/** Klasė studento duomenims saugoti
    @class Studentas */
    class Studentas
    {
        private string pavardė,         //Studento pavardė
                       vardas,          //Studento vardas
                       grupė;           //Mokymosi grupė 
        private int kiekPažimių;            //Kiek pažimių turi studentas
        private ArrayList paž;          //pažymių masyvas

        /** Pradiniai studento duomenys, išskyrus pažymius */
        public Studentas()
        {
            pavardė = "";
            vardas = "";
            grupė = "";
            kiekPažimių = 0;
            paž = new ArrayList();
        }
        /** Studento duomenų įrašymas
        @param pav - nauja pavardės reikšmė
        @param vard - nauja vardo reikšmė
        @param grup - nauja grupės reikšmė
        @param pž - naujos pažymių reikšmės */
        public void Dėti(string pav, string vard, string grup, int kiekPaž, ArrayList pž)
        {
            pavardė = pav;
            vardas = vard;
            grupė = grup;
            kiekPažimių = kiekPaž;
            foreach (int sk in pž)
                paž.Add(sk);
        }
        // Spausdinimo metodas
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -12} {1, -9} {2, -14} {3,-8}", pavardė, vardas, grupė, kiekPažimių);
            foreach (int sk in paž)
                eilute = eilute + string.Format("{0, 3:d}", sk);
            return eilute;
        }
        /** Operatorius ! grąžina true, jeigu bent vienas pažymys yra mažesnis už 9; false - kitais atvejais */
        public static bool operator !(Studentas c1)
        {
            string gr = "IF-1/8";
                if (c1.grupė == gr)
                    return true;
                else
                    return false;
        }
        /** Operatorius grąžina true, jeigu pavardė yra mažesnė už kitą pavardę, arba pavardės yra lygios,
        o vardas yra mažesnis už kitą vardą; false - kitais atvejais. */
        public static bool operator <=(Studentas st1, Studentas st2)
        {
            int g = String.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            int p = String.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            return (st1.Vidurkis() > st2.Vidurkis()|| (st1.Vidurkis() == st2.Vidurkis() && g < 0) || (st1.Vidurkis() == st2.Vidurkis() && g == 0 && p < 0) || (st1.Vidurkis() == st2.Vidurkis() &&  g == 0 && p == 0 && v < 0));
        }
        /** Operatorius grąžina true, jeigu pavardė yra ddesnė už kitą pavardę, arba pavardės yra lygios,
        o vardas yra dydesnis už kitą vardą; false - kitais atvejais. */
        public static bool operator >=(Studentas st1, Studentas st2)
        {
            int g = String.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            int p = String.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            return (st1.Vidurkis() < st2.Vidurkis() || (st1.Vidurkis() == st2.Vidurkis() && g > 0) || (st1.Vidurkis() == st2.Vidurkis() && g == 0 && p > 0) || (st1.Vidurkis() == st2.Vidurkis() && g == 0 && p == 0 && v > 0));
        }
        public double Vidurkis()
        {
            double suma = 0;
            foreach (int i in paž)
                suma += i;
            return suma / kiekPažimių;
        }
    }
    class Fakultetas
    {
        const int CMax = 100;           //Maksimalus studentų skaičius
        private string pav;             //Fakulteto pavadinimas
        private Studentas[] St;         //Studentų duomenys
        private int n;                  //Studentų skaičius
        public Fakultetas()
        {
            n = 0;
            St = new Studentas[CMax];
        }
        /** Grąžina fakulteto pavadinimą */
        public string ImtiPav() {return pav; }
        /** Grąžina studentų skaičių */
        public int Imti() { return n; }
        /** Grąžina nurodyto indekso studento objektą
        param i - studento indeksas */
        public Studentas Imti(int i) { return St[i]; }

        /** Padeda į studentų objektų masyvą naują studentą ir masyvo dydį padidina vienetu
        @param ob - studento objektas */
        public void Dėti(Studentas ob) { St[n++] = ob; }
        /** Surikiuoja studentų masyvą išrinkimo metodu pagal pavardes ir vardus */
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Studentas min = St[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (St[j] <= min)
                    {
                        //naudojamas užklotas operatorius <=
                        min = St[j];
                        im = j;
                    }
                St[im] = St[i];
                St[i] = min;
            }
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Fakultetas_2\\bin\\Debug\\Duom.txt";
        const string CFr = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Fakultetas_2\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Fakultetas grupes = new Fakultetas();
            Fakultetas grupes2 = new Fakultetas();
            Fakultetas grupes3 = new Fakultetas();
            if (File.Exists(CFr))
                File.Delete(CFr);
            string pav;
            Skaityti(ref grupes, CFd, out pav);
            Spausdinti(grupes, CFr, pav);
            Formuoti(grupes, ref grupes2, ref grupes3);
            grupes2.Rikiuoti();
            Spausdinti(grupes2, CFr, pav);
            SpausdintiGrupėsVidurkį(grupes2, CFr);
            grupes3.Rikiuoti();
            Spausdinti(grupes3, CFr, pav);
            SpausdintiGrupėsVidurkį(grupes3, CFr);

            Console.WriteLine("Programa baigė darbą!");
        }
        /** Failo duomenis surašo į konteinerį
        @param grupe - studentų konteineris
        @param fv - duomenų failo vardas */
        static void Skaityti(ref Fakultetas grupe, string fv, out string pav)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                string pv, vrd, grp;
                int kiekPaž;
                ArrayList pz = new ArrayList();
                string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
                string line;
                line = reader.ReadLine();
                pav = line;
                while (null != (line = reader.ReadLine()))
                {
                    string[] parts = line.Split(';');
                    pv = parts[0].Trim();
                    vrd = parts[1].Trim();
                    grp = parts[2].Trim();
                    kiekPaž = int.Parse(parts[3].Trim());
                    // Toliau pažymiai
                    string[] eil = parts[4].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    pz.Clear();
                    foreach (string eilute in eil)
                    {
                        int aa = int.Parse(eilute);
                        pz.Add(aa);
                    }
                    Studentas stud = new Studentas();
                    stud.Dėti(pv, vrd, grp, kiekPaž ,pz);
                    grupe.Dėti(stud);
                }
            }
        }
        /** Spausdina konteinerio duomenis faile lentele
        @param grupe - studentų konteineris
        @param fv - rezultatų failo vardas
        @param antraste - užrašas virš lentelės */
        static void Spausdinti(Fakultetas grupe, string fv, string antraštė)
        {
            string virsus = "--------------------------------------------------------------------------------\r\n"
                            + " Pavardė    Vardas      Grupė     Pažymių       Pažymiai              Vidurkis \r\n"
                            + "                                  Skaičius                                     \r\n"
                            + "--------------------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < grupe.Imti(); i++)
                    fr.WriteLine("{0,-65}        {1,4:f2}", grupe.Imti(i).ToString(), grupe.Imti(i).Vidurkis());
                fr.Write("-------------------------------------------------------------------------------\r\n");
            }
        }
        /** Iš pirmojo konteinerio atrenka į atskirus konteinerus studentus, pagal skirtingas grupes
        @param D - pirmasis studentų konteineris
        @param R - antrasis studentų konteineris
        @param E - trečias studentų konteineris*/
        static void Formuoti(Fakultetas D, ref Fakultetas R, ref Fakultetas E)
        {
            for (int i = 0; i < D.Imti(); i++)
                if (!D.Imti(i))
                    E.Dėti(D.Imti(i));
                else
                    R.Dėti(D.Imti(i));
        }
        static double GrupėsVidurkis(Fakultetas grupė)
        {
            double suma = 0;
            int kiek = 0;
            for (int i = 0; i < grupė.Imti(); i++)
            {
                suma += grupė.Imti(i).Vidurkis();
                kiek++;
            }
            return suma / kiek;                 
        }
        static void SpausdintiGrupėsVidurkį(Fakultetas grupe, string fv)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Grupės vidurkis: {0,5:f2}", GrupėsVidurkis(grupe));
                fr.WriteLine();
            }
        }
    }
}
