using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Šulinių_užterštumas
{
    /** Klasė šulinio duomenims saugoti
    @class Šulinys */
    class Šulinys
    {
        private int    namoNr;              //Namo Nr gatvėje
        private string adresas,             //Sodybos adresas
                       miestas;             //Sodybis miestas
        private double gylis,               //Šulinio gylis m
                       skersmuo,            //Šulinio skersmuo m
                       nitritai;            //Nitritų kiekis

        public Šulinys()
        {
            /**Pradiniai buto duomenys*/
            namoNr = 0;
            adresas = "";
            miestas = "";
            gylis = 0;
            skersmuo = 0;
            nitritai = 0;
        }
        public Šulinys(int namoNr, string adresas, string miestas, double gylis, double skersmuo, double nitritai)
        {
            this.namoNr = namoNr;
            this.adresas = adresas;
            this.miestas = miestas;
            this.gylis = gylis;
            this.skersmuo = skersmuo;
            this.nitritai = nitritai;
        }
        /** Spausdinimo metodas*/
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("|{0,-3}{1,-17}| {2,-15}| {3,-6:f2}| {4,-7:f2}| {5,-8:f2}|",namoNr, adresas, miestas, gylis, skersmuo, nitritai);
            return eilute;
        }
        public double ImtiGyli() { return gylis; }
        public double ImtiNitritus() { return nitritai; }
        public string ImtiAdresą() { return adresas; }

        /** gražina true jeigu teisingai */
        public static bool operator <=(Šulinys Šul1, Šulinys Šul2)
        {
            return (Šul1.ImtiNitritus() > Šul2.ImtiNitritus() || (Šul1.ImtiNitritus() == Šul2.ImtiNitritus() && Šul1.ImtiGyli() < Šul2.ImtiGyli()));
        }
        /** gražina true jeigu teisingai */
        public static bool operator >=(Šulinys Šul1, Šulinys Šul2)
        {
            return (Šul1.ImtiNitritus() < Šul2.ImtiNitritus() || (Šul1.ImtiNitritus() == Šul2.ImtiNitritus() && Šul1.ImtiGyli() > Šul2.ImtiGyli()));
        }

    }
    class Sodybos
    {
        const int CMax = 100;           //Maksimalus šulinių skaičius
        private Šulinys[] Šul;         //Šulinių duomenys
        private int n;                  //Šulinių skaičius
        public Sodybos()
        {
            n = 0;
            Šul = new Šulinys[CMax];
        }
        /**Grąžina nurodyto indekso Šulinio objektą.
        @param i - buto indeksas*/
        public Šulinys Imti(int i) { return Šul[i]; }

        /** Grąžina šulinių kiekį */
        public int Imti() { return n; }

        /** Padeda į šulinių objektų masyvą naują šulinį ir masyvo dydį padidina vienetu.
        @param šul - šulinių objektas */
        public void Dėti(Šulinys bu) { Šul[n++] = bu; }

        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Šulinys min = Šul[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Šul[j] >= min)
                    {
                        //naudojamas užklotas operatorius <=
                        min = Šul[j];
                        im = j;
                    }
                Šul[im] = Šul[i];
                Šul[i] = min;
            }
        }
    }

    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Šulinių_užterštumas\\bin\\Debug\\Duom.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Šulinių_užterštumas\\bin\\Debug\\Duom2.txt";
        const string CFrez = "D:\\Programavimas2\\Objetkinis programavimas\\Konteinerinės_klasės\\Šulinių_užterštumas\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Sodybos sodybos = new Sodybos();
            Sodybos sodybos2 = new Sodybos();
            Sodybos sodybos3 = new Sodybos();
            Sodybos sodybos4 = new Sodybos();
            if (File.Exists(CFrez))
                File.Delete(CFrez);
            Skaityti(ref sodybos, CFd);
            Skaityti(ref sodybos2, CFd2);
            Spausdinti(sodybos, CFrez,"Pirmas duomenų failas");
            Spausdinti(sodybos2, CFrez,"Antras duomenų failas");
            Formuoti(sodybos, sodybos3);
            Formuoti(sodybos2, sodybos3);
            Spausdinti(sodybos3, CFrez, "Bendras šulinių sąrašas");

            int giliausioIndeksas = GiliausioŠulinioIndeksas(sodybos3);

            Console.Write("Įveskite leistiną nitritų normą:");
            double nitrintųNorma = double.Parse(Console.ReadLine());

            Console.Write("Nurodykite gatvę kurios šulinius norite atrinkti:");
            string gatvė = Console.ReadLine();

            SpausdintiAtsakymus(CFrez, sodybos3, giliausioIndeksas, nitrintųNorma);

            Formuoti2(sodybos3, sodybos4, gatvė);
            sodybos4.Rikiuoti();
            Spausdinti(sodybos4, CFrez, "Sarašas tik su tam tikra gatve");


            Console.WriteLine("Programa baigė darbą!");
        }
        static void Skaityti(ref Sodybos sodybos, string fv)
        {
            int namoNr;
            string adresas, miestas;
            double gylis, skersmuo, nitritai;
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                namoNr = int.Parse(parts[0].Trim());
                adresas = parts[1].Trim();
                miestas = parts[2].Trim();
                gylis = double.Parse(parts[3].Trim());
                skersmuo = double.Parse(parts[4].Trim());
                nitritai = double.Parse(parts[5].Trim());
                Šulinys Šul = new Šulinys(namoNr, adresas, miestas, gylis, skersmuo, nitritai);
                sodybos.Dėti(Šul);
            }
        }
        static void Spausdinti(Sodybos sodybos, string fv, string antraštė)
        {
            string virsus ="------------------------------------------------------------------ \r\n"
                + "|      Adresas       |     Miestas    |        Šulinio           |\r\n"
                + "|                    |                | Gylis |Skersmuo| Nutritai| \r\n"
                + "------------------------------------------------------------------ ";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < sodybos.Imti(); i++)
                    fr.WriteLine("{0}", sodybos.Imti(i).ToString());
                fr.WriteLine("------------------------------------------------------------------ \n\n");
            }
        }
        /// <summary>
        /// Metodas formuojantis naują konteinerį su kuriuo poto bus atliekami veiksmai
        /// </summary>
        /// <param name="D">iš kurio sodybų konteinerio paimam</param>
        /// <param name="R">Į kurį įdedam konteinerį</param>
        static void Formuoti(Sodybos D, Sodybos R)
        {
            for (int i = 0; i < D.Imti(); i++)
                R.Dėti(D.Imti(i));
        }
        /// <summary>
        /// Gilaiusio šulinio indekso radimas
        /// </summary>
        /// <param name="sodybos"></param>
        /// <returns></returns>
        static int GiliausioŠulinioIndeksas(Sodybos sodybos)
        {
            double maxGylis = 0;
            int indeksas = 0;
            for (int i = 0; i < sodybos.Imti(); i++)
            {
                if (maxGylis < sodybos.Imti(i).ImtiGyli())
                {
                    maxGylis = sodybos.Imti(i).ImtiGyli();
                    indeksas = i;
                }
            }
            return indeksas;
        }
        /// <summary>
        /// Metodas kuris randa kiek elementų viršija nitritų normą
        /// </summary>
        /// <param name="sodybos"></param>
        /// <param name="nitritųNorma">nitritų norma įvesta per Console</param>
        /// <returns></returns>
        static int NeviršijaNitritų(Sodybos sodybos, double nitritųNorma)
        {
            int kiek = 0;
            for (int i = 0; i < sodybos.Imti(); i++)
            if (sodybos.Imti(i).ImtiNitritus() > nitritųNorma)
                kiek++;
            return kiek;
        }
        /// <summary>
        /// Atsakymų spausdinimo metodas
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="sodybos"></param>
        /// <param name="giliausioIndeksas">Giliausio šulinio indeksas rastas per metodą GiliausioŠulinioIndeksas</param>
        /// <param name="nitritųNorma">Skaičius kuris pasako kiek šulinių viršiją nitrių normą gautas iš metodo NeviršijaNitritų</param>
        static void SpausdintiAtsakymus(string fv, Sodybos sodybos, int giliausioIndeksas, double nitritųNorma)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Giliausio šulinio duomenys:");
                fr.WriteLine("{0}", sodybos.Imti(giliausioIndeksas).ToString());
                fr.WriteLine("");
                if (NeviršijaNitritų(sodybos, nitritųNorma) > 0)
                    fr.WriteLine("{0} šuliniuose yra viršijama nitritų norma", NeviršijaNitritų(sodybos, nitritųNorma));
                else
                    fr.WriteLine("Nėra šulinių kurie viršytu leistiną nitritų normą");
            }
        }
        /// <summary>
        /// Metodas formuojantis naują konteinerį kur atfiltruojama pagal gatvę
        /// </summary>
        /// <param name="D">iš kurio sodybų konteinerio paimam</param>
        /// <param name="R">Į kurį įdedam konteinerį</param>
        /// <param name="gatvė">Norima gatvė įvesta per Consolę</param>
        static void Formuoti2(Sodybos D, Sodybos R, string gatvė)
        {
            for (int i = 0; i < D.Imti(); i++)
                if(gatvė == D.Imti(i).ImtiAdresą())
                    R.Dėti(D.Imti(i));
        }
    }
}
