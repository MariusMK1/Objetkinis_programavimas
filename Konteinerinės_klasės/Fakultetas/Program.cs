using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace Fakultetas
{ 
/** Klasė studento duomenims saugoti
    @class Studentas */
class Studentas
{
    private string pavardė,         //Studento pavardė
                   vardas,          //Studento vardas
                   grupė;           //mokymosi grupė 
    private ArrayList paž;          //pažymių masyvas

    /** Pradiniai studento duomenys, išskyrus pažymius */
    public Studentas()
    {
        pavardė = "";
        vardas = "";
        grupė = "";
        paž = new ArrayList();
    }
        /** Studento duomenų įrašymas
        @param pav - nauja pavardės reikšmė
        @param vard - nauja vardo reikšmė
        @param grup - nauja grupės reikšmė
        @param pž - naujos pažymių reikšmės */
        public void Dėti(string pav, string vard, string grup, ArrayList pž)
        {
            pavardė = pav;
            vardas = vard;
            grupė = grup;
            foreach (int sk in pž)
                paž.Add(sk);
        }
        // Spausdinimo metodas
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -12} {1, -9} {2, -7}", pavardė, vardas, grupė);
            foreach (int sk in paž)
                eilute = eilute + string.Format("{0, 3:d}", sk);
            return eilute;
        }
        /** Operatorius ! grąžina true, jeigu bent vienas pažymys yra mažesnis už 9; false - kitais atvejais */
        public static bool operator !(Studentas c1)
        {
            foreach (int sk in c1.paž)
            {
                if (sk < 9)
                    return true;
            }
            return false;
        }
        /** Operatorius grąžina true, jeigu pavardė yra mažesnė už kitą pavardę, arba pavardės yra lygios,
        o vardas yra mažesnis už kitą vardą; false - kitais atvejais. */
        public static bool operator <= (Studentas st1, Studentas st2)
        {
            int g = String.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            int p = String.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            return (g < 0 || (g == 0 && p < 0) || (g == 0 && p == 0 && v < 0));
        }
        /** Operatorius grąžina true, jeigu pavardė yra ddesnė už kitą pavardę, arba pavardės yra lygios,
        o vardas yra dydesnis už kitą vardą; false - kitais atvejais. */
        public static bool operator >= (Studentas st1, Studentas st2)
        {
            int g = String.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            int p = String.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            return (g > 0 || (g == 0 && p > 0) || (g == 0 && p == 0 && v > 0));
        }
    }
    /** Klasė studentų grupės duomenims saugoti
    @class Fakultetas */
    class Fakultetas
    {
        const int CMax = 100;           //Maksimalus studentų skaičius
        private Studentas[] St;         //Studentų duomenys
        private int n;                  //Studentų skaičius
        public Fakultetas()
        {
            n = 0;
            St = new Studentas[CMax];
        }
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
        public void SalintiNePirmunus() 
        {
            int i = 0;
            while (i < n)
            {
                if (!St[i])
                {
                    for (int j = i; j < n - 1; j++)
                        St[j] = St[j + 1];
                    n = n - 1;
                }
                else i++;
            }
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Fakultetas\\bin\\Debug\\Duom.txt";
        const string CFr = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Fakultetas\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Fakultetas grupes = new Fakultetas();
            Fakultetas grupes2 = new Fakultetas();
            if (File.Exists(CFr))
                File.Delete(CFr);
            Skaityti(ref grupes, CFd);
            Spausdinti(grupes, CFr, "Pradinis Studentų sąrašas");

            Formuoti(grupes, ref grupes2);
            if (grupes2.Imti() > 0)
                Spausdinti(grupes2, CFr, "Naujas studentų sąrašas");
            else
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine(" Tokių studentų nėra");
                }
            grupes2.Rikiuoti();
            Spausdinti(grupes2, CFr, "Sąrašas po rykiavimo");

            grupes.SalintiNePirmunus();
            Spausdinti(grupes, CFr, "Pradinis studentų sąrašas pašalinus ne pirmūnus");


            Console.WriteLine("Programa baigė darbą!");


        }
        /** Failo duomenis surašo į konteinerį
        @param grupe - studentų konteineris
        @param fv - duomenų failo vardas */
        static void Skaityti(ref Fakultetas grupe, string fv)
        {
            string pv, vrd, grp;
            ArrayList pz = new ArrayList();
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                pv = parts[0].Trim();
                vrd = parts[1].Trim();
                grp = parts[2].Trim();
                // Toliau pažymiai
                string[] eil = parts[3].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                pz.Clear();
                foreach (string eilute in eil)
                {
                    int aa = int.Parse(eilute);
                    pz.Add(aa);
                }
                Studentas stud = new Studentas();
                stud.Dėti(pv, vrd, grp, pz);
                grupe.Dėti(stud);
            }
        }
        /** Spausdina konteinerio duomenis faile lentele
        @param grupe - studentų konteineris
        @param fv - rezultatų failo vardas
        @param antraste - užrašas virš lentelės */
        static void Spausdinti(Fakultetas grupe, string fv, string antraštė)
        {
            string  virsus =  "------------------------------------------\r\n"
                            + " Pavardė    Vardas      Grupė    Pažymiai \r\n"
                            + "------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < grupe.Imti(); i++)
                    fr.WriteLine("{0}", grupe.Imti(i).ToString());
                fr.WriteLine("------------------------------------------\r\n");
            }
        }
        /** Iš pirmojo konteinerio atrenka į antrąjį konteinerį studentus, kurių įvertinimai yra 9 arba 10
        @param D - pirmasis studentų konteineris
        @param R - antrasis studentų konteineris */
        static void Formuoti(Fakultetas D, ref Fakultetas R)
        {
            for (int i = 0; i < D.Imti(); i++)
                if (!D.Imti(i))
                    ;
                else
                    R.Dėti(D.Imti(i));
        }
    }
}
