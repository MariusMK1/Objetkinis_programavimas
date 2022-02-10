using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Bukletai
{
    class Bukletas
    {
        string formatas;        //bukleto formatas
        double kaina;           //500 lapų tokio formato popieriaus pakuotės kaina
        int lapųSk,             //bukleto lapų skaičius
            kiekis;             //egzempliorių kiekis
        public Bukletas()
        {
            /**Pradiniai bukleto duomenys*/
            formatas = "";
            kaina = 0;
            lapųSk = 0;
            kiekis = 0;
        }
        public Bukletas(string formatas, double kaina, int lapųSk, int kiekis)
        {
            this.formatas = formatas;
            this.kaina = kaina;
            this.lapųSk = lapųSk;
            this.kiekis = kiekis;
        }
        /** Spausdinimo metodas*/
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("|    {0,-6}| {1,-6}|       {2,-8}|   {3,-5}|", formatas, kaina, lapųSk, kiekis);
            return eilute;
        }
        public double VisaKainaUžsakymo()
        {
            return (kaina / 500) * lapųSk * kiekis;
        }
        public bool ArUžtenka500()
        {
            return ((lapųSk * kiekis) <= 500);
        }
        public static bool operator >=(Bukletas Buk, Bukletas Buk2)
        {
            return (Buk.lapųSk > Buk2.lapųSk || (Buk.lapųSk == Buk2.lapųSk && Buk.kiekis > Buk2.kiekis));
        }
        /** gražina true jeigu teisingai */
        public static bool operator <=(Bukletas Buk, Bukletas Buk2)
        {
            return (Buk.lapųSk < Buk2.lapųSk || (Buk.lapųSk == Buk2.lapųSk && Buk.kiekis < Buk2.kiekis));
        }
    }
    class Spaustuvė
    {
        const int CMax = 100;           //Maksimalus bukletų skaičius
        private Bukletas[] Buk;         //bukletų duomenys
        private int n;                  //bukletų skaičius
        public Spaustuvė()
        {
            n = 0;
            Buk = new Bukletas[CMax];
        }
    /**Grąžina nurodyto indekso bukleto objektą.
    @param i - buto indeksas*/
    public Bukletas Imti(int i) { return Buk[i]; }

    /** Grąžina bukletų kiekį */
    public int Imti() { return n; }

    /** Padeda į bukletų objektų masyvą naują bukletą ir masyvo dydį padidina vienetu.
    @param šul - šulinių objektas */
    public void Dėti(Bukletas bukl) { Buk[n++] = bukl; }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Bukletas min = Buk[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Buk[j] <= min)
                    {
                        min = Buk[j];
                        im = j;
                    }
                Buk[im] = Buk[i];
                Buk[i] = min;
            }
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Bukletai\\bin\\Debug\\Duom.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Bukletai\\bin\\Debug\\Duom2.txt";
        const string CFrez = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Bukletai\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Spaustuvė spaustuvė = new Spaustuvė();
            Spaustuvė spaustuvė2= new Spaustuvė();
            Spaustuvė spaustuvė3 = new Spaustuvė();
            Spaustuvė spaustuvė4 = new Spaustuvė();
            if (File.Exists(CFrez))
                File.Delete(CFrez);
            Skaityti(ref spaustuvė, CFd);
            Skaityti(ref spaustuvė2, CFd2);
            Spausdinti(spaustuvė, CFrez, "Pirmas duomenų failas");
            Spausdinti(spaustuvė2, CFrez, "Antras duomenų failas");
            Formuoti(spaustuvė, spaustuvė3);
            Formuoti(spaustuvė2, spaustuvė3);

            SpausdintiSuUžsakymoKaina(spaustuvė3, CFrez, "Bendras bukletų sąrašas");
            SpausdintiAtsakymus(CFrez, spaustuvė3);

            Formuoti2(spaustuvė3, spaustuvė4);
            spaustuvė4.Rikiuoti();
            SpausdintiSuUžsakymoKaina(spaustuvė4, CFrez, "Užsakymai kuriems užtenka 500 lapų pakuotės");

            Console.WriteLine("Programa baigė darbą!");
        }
        static void Skaityti(ref Spaustuvė spaustuvė, string fv)
        {
            int lapųSk, kiekis;
            string formatas;
            double kaina;
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                formatas = parts[0].Trim();
                kaina = double.Parse(parts[1].Trim());
                lapųSk = int.Parse(parts[2].Trim());
                kiekis = int.Parse(parts[3].Trim());
                Bukletas Buk = new Bukletas(formatas, kaina, lapųSk, kiekis);
                spaustuvė.Dėti(Buk);
            }
        }
        static void Spausdinti(Spaustuvė spaustuvė, string fv, string antraštė)
        {
            string virsus = "--------------------------------------------- \r\n"
                + "| Formatas | Kaina | Lapų skaičius | Kiekis |\r\n"
                + "--------------------------------------------- ";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < spaustuvė.Imti(); i++)
                    fr.WriteLine("{0}", spaustuvė.Imti(i).ToString());
                fr.WriteLine("--------------------------------------------- \n\n");
            }
        }
        static void Formuoti(Spaustuvė D, Spaustuvė R)
        {
            for (int i = 0; i < D.Imti(); i++)
                R.Dėti(D.Imti(i));
        }
        static void SpausdintiSuUžsakymoKaina(Spaustuvė spaustuvė, string fv, string antraštė)
        {
            string virsus = "-------------------------------------------------------------- \r\n"
                + "| Formatas | Kaina | Lapų skaičius | Kiekis | Užsakymo kaina |\r\n"
                + "-------------------------------------------------------------- ";
            using (var fr = File.AppendText(fv))
            {
                if (spaustuvė.Imti() > 0)
                {
                    fr.WriteLine(antraštė);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < spaustuvė.Imti(); i++)
                        fr.WriteLine("{0}      {1,-10:f2}|", spaustuvė.Imti(i).ToString(), spaustuvė.Imti(i).VisaKainaUžsakymo());
                    fr.WriteLine("-------------------------------------------------------------- \n\n");
                }
                else
                    fr.WriteLine("Tokių užsakymų, kad užtektų 500 lapų pakuotės nėra ");
            }
        }
        static int MažiausioRadimas(Spaustuvė spaustuvė)
        {
            double min = spaustuvė.Imti(0).VisaKainaUžsakymo();
            int minIndex = 0;
            for (int i = 0; i < spaustuvė.Imti(); i++)
                if (min > spaustuvė.Imti(i).VisaKainaUžsakymo())
                {
                    min = spaustuvė.Imti(i).VisaKainaUžsakymo();
                    minIndex = i;
                }
            return minIndex;
        }
        static void SpausdintiAtsakymus(string fv, Spaustuvė spaustuvė)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Pigiausias bukletų užsakymas yra:");
                fr.WriteLine("{0}      {1,-10:f2}|", spaustuvė.Imti(MažiausioRadimas(spaustuvė)).ToString(), spaustuvė.Imti(MažiausioRadimas(spaustuvė)).VisaKainaUžsakymo());
                fr.WriteLine("");
            }
        }
        static void Formuoti2(Spaustuvė D, Spaustuvė R)
        {
            for (int i = 0; i < D.Imti(); i++)
                if (D.Imti(i).ArUžtenka500())
                    R.Dėti(D.Imti(i));
        }
    }
}
