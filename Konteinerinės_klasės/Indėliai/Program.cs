using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Indėliai
{
    class Indėlis
    {
        private int indėlis,                        //Įdėta suma eurais
                    terminas;                       //Terminas mėnesiais
        private string kaipSkaičiuojama;            //Kas kiek laiko skaičiuojamos palūkanos
        private double palūkanos;                   //Kasmetinės palūkanos %


        public Indėlis()
        {
            /**Pradiniai indėlio duomenys*/
            indėlis = 0;
            kaipSkaičiuojama = "";
            terminas = 0;
            palūkanos = 0;
        }
        public Indėlis(int indėlis, int terminas,double palūkanos, string kaipSkaičiuojama)
        {
            this.indėlis = indėlis;
            this.terminas = terminas;
            this.palūkanos = palūkanos;
            this.kaipSkaičiuojama = kaipSkaičiuojama;
        }
        /** Spausdinimo metodas*/
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("|{0,-9}|    {1,-6}|    {2,-7}|          {3,-22}|", indėlis, terminas, palūkanos, kaipSkaičiuojama);
            return eilute;
        }
        public int ImtiTerminą() { return terminas; }
        public int ImtiIndėlį() { return indėlis; }
        public string ImtiKaipSkaičiuojama() { return kaipSkaičiuojama; }

        public double kasMėnesį()
        {
            double galutinėSuma = indėlis;
            for (int i = 0; i < terminas; i++)
            {
                galutinėSuma += (galutinėSuma * (palūkanos / 100));
            }
            return galutinėSuma;
        }
        public double kasMetus()
        {
            double galutinėSuma = indėlis;
            for (int i = 0; i < terminas/12; i++)
            {
                galutinėSuma += (galutinėSuma * (palūkanos / 100));
            }
            return galutinėSuma;
        }
        public double terminoPabaigoje()
        {
            double galutinėSuma = indėlis;
            double susikaupusios = palūkanos;
            for (int i = 0; i < terminas / 12; i++)
            {
                susikaupusios += (galutinėSuma * (palūkanos / 100));
            }
            return galutinėSuma + susikaupusios;
        }
        /** gražina true jeigu teisingai */
        public static bool operator >=(Indėlis Ind, Indėlis Ind2)
        {
            return (Ind.terminas > Ind2.terminas || (Ind.terminas == Ind2.terminas && Ind.indėlis > Ind2.indėlis));
        }
        /** gražina true jeigu teisingai */
        public static bool operator <=(Indėlis Ind, Indėlis Ind2)
        {
            return (Ind.terminas < Ind2.terminas || (Ind.terminas == Ind2.terminas && Ind.indėlis < Ind2.indėlis));
        }
    }
    class Bankas
    {
        const int CMax = 100;           //Maksimalus indėlių skaičius
        private Indėlis[] Ind;          //Indėlių duomenys
        private int n;                  //Indėlių skaičius
        public Bankas()
        {
            n = 0;
            Ind = new Indėlis[CMax];
        }
        /**Grąžina nurodyto indekso Indėlio objektą.
        @param i - buto indeksas*/
        public Indėlis Imti(int i) { return Ind[i]; }

        /** Grąžina Indėlių kiekį */
        public int Imti() { return n; }

        /** Padeda į indėlių objektų masyvą naują indėlį ir masyvo dydį padidina vienetu.
        @param šul - šulinių objektas */
        public void Dėti(Indėlis indel) { Ind[n++] = indel; }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Indėlis min = Ind[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Ind[j] >= min)
                    {
                        //naudojamas užklotas operatorius <=
                        min = Ind[j];
                        im = j;
                    }
                Ind[im] = Ind[i];
                Ind[i] = min;
            }
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Indėliai\\bin\\Debug\\Duom.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Indėliai\\bin\\Debug\\Duom2.txt";
        const string CFrez = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Indėliai\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Bankas bankas = new Bankas();
            Bankas bankas2 = new Bankas();
            Bankas bankas3 = new Bankas();
            Bankas bankas4 = new Bankas();
            if (File.Exists(CFrez))
                File.Delete(CFrez);
            Skaityti(ref bankas, CFd);
            Skaityti(ref bankas2, CFd2);
            Spausdinti(bankas, CFrez, "Pirmas duomenų failas");
            Spausdinti(bankas2, CFrez, "Antras duomenų failas");

            Formuoti(bankas, bankas3);
            Formuoti(bankas2, bankas3);
            SpausdintiSuGalutineSuma(bankas3, CFrez, "Bendras indėlių sąrašas");
            SpausdintiAtsakymus(CFrez, bankas3);

            Console.Write("Nurodykite Palūkanų apskaičiavimo būdą:");
            string palūkanųApskaičiavimoBūdas = Console.ReadLine();
            Formuoti2(bankas3, bankas4, palūkanųApskaičiavimoBūdas);
            bankas4.Rikiuoti();
            SpausdintiSuGalutineSuma(bankas4, CFrez, "Indėlių sąrašas išfiltruotas pagal norimą palūkanų apskaičiavimo būdą");

            Console.WriteLine("Programa baigė darbą!");
        }
        static void Skaityti(ref Bankas bankas, string fv)
        {
            int indėlis, terminas;
            string kaipSkaičiuojama;
            double palūkanos;
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                indėlis = int.Parse(parts[0].Trim());
                terminas = int.Parse(parts[1].Trim());
                palūkanos = double.Parse(parts[2].Trim());
                kaipSkaičiuojama = parts[3].Trim();
                Indėlis Ind = new Indėlis(indėlis, terminas, palūkanos, kaipSkaičiuojama);
                bankas.Dėti(Ind);
            }
        }
        static void Spausdinti(Bankas bankas, string fv, string antraštė)
        {
            string virsus = "------------------------------------------------------------------- \r\n"
                + "| Indėlis | Terminas | Palūkanos | Kas kiek laiko perskaičiuojama |\r\n"
                + "------------------------------------------------------------------- ";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < bankas.Imti(); i++)
                    fr.WriteLine("{0}", bankas.Imti(i).ToString());
                fr.WriteLine("------------------------------------------------------------------- \n\n");
            }
        }
        static void Formuoti(Bankas D, Bankas R)
        {
            for (int i = 0; i < D.Imti(); i++)
                R.Dėti(D.Imti(i));
        }
        static double tikrinaKadaPerskaičiuoja(Bankas bankas, int i)
        {
                if (bankas.Imti(i).ImtiKaipSkaičiuojama() == "Kas mėnesį")
                    return bankas.Imti(i).kasMėnesį();
                else if (bankas.Imti(i).ImtiKaipSkaičiuojama() == "Kas metus")
                    return bankas.Imti(i).kasMetus();
                else
                    return bankas.Imti(i).terminoPabaigoje();
        }
        static void SpausdintiSuGalutineSuma(Bankas bankas, string fv, string antraštė)
        {
            string virsus = "------------------------------------------------------------------------------------------------------- \r\n"
                + "| Indėlis | Terminas | Palūkanos | Kas kiek laiko perskaičiuojama | Galutinė suma po termino pabaigos |\r\n"
                + "------------------------------------------------------------------------------------------------------- ";
            using (var fr = File.AppendText(fv))
            {
                if (bankas.Imti() > 0)
                {
                    fr.WriteLine(antraštė);
                    fr.WriteLine(virsus);
                    for (int i = 0; i < bankas.Imti(); i++)
                        fr.WriteLine("{0}               {1,-20:f2}|", bankas.Imti(i).ToString(), tikrinaKadaPerskaičiuoja(bankas, i));
                    fr.WriteLine("------------------------------------------------------------------------------------------------------- \n\n");
                }
                else
                    fr.WriteLine("Tokio palūkanų apskaičiavimo būdo nėra");
            }
        }
        static int didžiuasioRadimas(Bankas bankas)
        {
            double max = 0;
            int maxIndex = 0;
            for (int i = 0; i < bankas.Imti(); i++)
                if(max < tikrinaKadaPerskaičiuoja(bankas, i))
                {
                    max = tikrinaKadaPerskaičiuoja(bankas, i);
                    maxIndex = i;
                }
            return maxIndex;
        }
        static void SpausdintiAtsakymus(string fv, Bankas bankas)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Didžiausias indėlis yra:");
                fr.WriteLine("{0}               {1,-20:f2}|", bankas.Imti(didžiuasioRadimas(bankas)).ToString(), tikrinaKadaPerskaičiuoja(bankas, didžiuasioRadimas(bankas)));
                fr.WriteLine("");
                fr.Write("Bendra suma kurią bankas turės išmokėti:");
                fr.WriteLine(" {0,8:f2} Eurai", bendraSumaKuriąIšmokėti(bankas));
                fr.WriteLine("");
            }
        }
        static double bendraSumaKuriąIšmokėti(Bankas bankas)
        {
            double suma = 0;
            for (int i = 0;i < bankas.Imti(); i++)
            {
                suma += tikrinaKadaPerskaičiuoja(bankas, i) - bankas.Imti(i).ImtiIndėlį();
            }
            return suma;
        }
        static void Formuoti2(Bankas D, Bankas R, string palūkanųApskaičiavimoBūdas)
        {
            for (int i = 0; i < D.Imti(); i++)
                if (palūkanųApskaičiavimoBūdas == D.Imti(i).ImtiKaipSkaičiuojama())
                    R.Dėti(D.Imti(i));
        }
    }
}
