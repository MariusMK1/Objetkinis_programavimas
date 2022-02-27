using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Darbo_birža
{
    class Miestas
    {
        string pav;
        int gyv,
            jaunimas,
            mėnesioNedarbas;
        public Miestas()
        {
            pav = "";
            gyv = 0;
            jaunimas = 0;
            mėnesioNedarbas = 0;
        }
        public void Dėti(string pav, int gyv, int jaunimas)
        {
            this.pav = pav;
            this.gyv = gyv;
            this.jaunimas = jaunimas;
        }
        public string ImtiPav() { return pav; }
        public int ImtiGyv() { return gyv; }
        public int ImtiJaunimą() { return jaunimas; }
        public void DėtiMėnesioNedarbą(int mėnNe) { mėnesioNedarbas = mėnNe; }
        public int ImtiMėnesioNedarbą() { return mėnesioNedarbas; }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("  {0, -12} {1, -13} {2,-10}", pav, gyv, jaunimas);
            return eilute;
        }
        public static bool operator <=(Miestas pirmas, Miestas antras)
        {
            return pirmas.jaunimas < antras.jaunimas || pirmas.jaunimas == antras.jaunimas && pirmas.gyv < antras.gyv;
        }
        public static bool operator >=(Miestas pirmas, Miestas antras)
        {
            return pirmas.jaunimas > antras.jaunimas || pirmas.jaunimas == antras.jaunimas && pirmas.gyv > antras.gyv;
        }
    }
    class Birža
    {
        const int CMaxEil = 100;
        const int CMaxSt = 100;
        private Miestas[] Miestai;
        public int n { get; set; }                 //stulpelių skačius
        private int[,] N;                          //Nedarbingumo duomenys
        public int m { get; set; }                 //eilučių skačius
        private double[,] SN;
        public Birža()
        {
            n = 0;
            Miestai = new Miestas[CMaxEil];
            m = 0;  
            N = new int[CMaxEil, CMaxSt];
            SN = new double[CMaxEil, CMaxSt];
        }
        public void DėtiNedarbą(int i, int j, int nedarbas)
        {
            N[i, j] = nedarbas;
        }
        public int ImtiNedarbą(int i, int j)
        {
            return N[i, j];
        }
        public void DėtiSantykinįNedarbingumą(int i, int j, double santykis)
        {
            SN[i, j] = santykis;
        }
        public double ImtiSantykinįNedarbingumą(int i, int j)
        {
            return SN[i, j];
        }
        public void Dėti(Miestas ob) { Miestai[n++] = ob; }
        public int Imti() { return n; }
        public Miestas Imti(int nr) { return Miestai[nr]; }
        public void SkaičiuotiMėnesioNedarbingumą()
        {
            Miestas miest;
            for (int i = 0; i < m; i++)
            {
                int suma = 0;
                for (int j = 0; j < n; j++)
                {
                    suma += ImtiNedarbą(i, j);
                }
                miest = Imti(i);
                miest.DėtiMėnesioNedarbą(suma);
            }
        }
        public double MinSantykinisNedarboLygis()
        {
            double min = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (min > ImtiSantykinįNedarbingumą(i, j))
                        min = ImtiSantykinįNedarbingumą(i, j);
                }
            }
            return min;
        }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Miestas min = Miestai[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Miestai[j] >= min)
                    {
                        //naudojamas užklotas operatorius >=
                        min = Miestai[j];
                        im = j;
                    }
                Miestai[im] = Miestai[i];
                Miestai[i] = min;
            }
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Darbo_birža\\bin\\Debug\\Duom.txt";
        const string CFr = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Darbo_birža\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Birža birža = new Birža();
            SkaitytiMiestus(CFd, ref birža);
            SkaitytiNedarbingumą(CFd, ref birža);
            SpausdintiMiestus(CFr, birža, "Pradiniai miestų duomenys:");
            SpausdintiNedarbingumą(CFr, birža, "Pradiniai nedarbinguo duomenys:");
            birža.SkaičiuotiMėnesioNedarbingumą();
            SpausdintiMėnSuMaxNedarbu(CFr, birža);
            PildytiSantykinįNedarbingumą(birža);
            SpausdintiSantykinįNedarbingumą(CFr, birža, "Santykinis nedarbingumas");
            SpausdintiMėnSuMinSantykiniuNedarbu(CFr, birža);
            birža.Rikiuoti();
            SpausdintiSurikiuotusMiestus(CFr, birža, "Surikiuoti miestų duomenys:");

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
        static void SkaitytiMiestus(string fd, ref Birža birža)
        {
            string pav, line;
            int nn, mm, gyv, jaunimas;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts = line.Split(';');
                nn = int.Parse(parts[0]);
                mm = int.Parse(parts[1]);
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    gyv = int.Parse(parts[1]);
                    jaunimas = int.Parse(parts[2]);
                    Miestas miest;
                    miest = new Miestas();
                    miest.Dėti(pav, gyv, jaunimas);
                    birža.Dėti(miest);
                }
            }
        }
        static void SkaitytiNedarbingumą(string fd, ref Birža birža)
        {
            int nedarbas;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts = line.Split(';');
                birža.n = int.Parse(parts[0]);
                birža.m = int.Parse(parts[1]);
                for (int z = 0; z < birža.n; z++)
                    line = reader.ReadLine();
                for (int i = 0; i < birža.m; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < birža.n; j++)
                    {
                        nedarbas = int.Parse(parts[j]);
                        birža.DėtiNedarbą(i, j, nedarbas);
                    }
                }
            }
        }
        static void SpausdintiMiestus(string fv, Birža birža, string antraštė)
        {
            using (var fr = File.CreateText(fv))
            {
                string bruksnys = new string('-', 43);
                fr.Write(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr.  Miestas    Gyventojai   Jaunimas 19-25 ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < birža.n; i++)
                {
                    fr.WriteLine("{0}. {1}   ", i + 1, birža.Imti(i).ToString());
                    fr.WriteLine(bruksnys);
                }
            }
        }
        static void SpausdintiNedarbingumą(string fv, Birža birža, string komentaras)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(komentaras);
                fr.WriteLine();
                for (int i = 0; i < birža.m; i++)
                {
                    fr.Write("{0,4:d}.  ", i + 1);
                    for (int j = 0; j < birža.n; j++)
                        fr.Write("{0,-6:d} ", birža.ImtiNedarbą(i, j));
                    fr.WriteLine();
                }
                fr.WriteLine();
            }
        }
        static int MaxMėnesioNedarbingumas(Birža birža)
        {
            int max = 0;
            for (int i = 0; i < birža.m; i++)
            {
                if (max < birža.Imti(i).ImtiMėnesioNedarbą())
                {
                    max = birža.Imti(i).ImtiMėnesioNedarbą();
                }
            }
            return max;
        }
        static void SpausdintiMėnSuMaxNedarbu(string fv, Birža birža)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                fr.WriteLine("Mėnesiai su didžiausiu nedarbingumu jaunimo tarpe");
                for (int i = 0; i < birža.m; i++)
                {
                    if (birža.Imti(i).ImtiMėnesioNedarbą() == MaxMėnesioNedarbingumas(birža))
                    {
                        fr.Write("{0} ", i + 1);
                    }
                }
                fr.WriteLine();
            }
        }
        static void SpausdintiMėnSuMinSantykiniuNedarbu(string fv, Birža birža)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                fr.WriteLine("Miestai ir mėnesiai su mažiausiu santykiniu nedarbingumu:");
                for (int i = 0; i < birža.m; i++)
                {
                    for (int j = 0; j < birža.n; j++)
                    {
                        if (birža.ImtiSantykinįNedarbingumą(i, j) == birža.MinSantykinisNedarboLygis())
                        {
                            fr.WriteLine("{0} santkinis nedarbingumas mažiausias {1} mėnesį", birža.Imti(j).ImtiPav(), i + 1);
                        }
                    }
                }
                fr.WriteLine();
            }
        }
        static void PildytiSantykinįNedarbingumą(Birža birža)
        {
            for (int i = 0; i < birža.m; i++)
            {
                for (int j = 0; j < birža.n; j++)
                {
                    double santykis = (double)birža.ImtiNedarbą(i, j) / (double)birža.Imti(j).ImtiJaunimą();
                    birža.DėtiSantykinįNedarbingumą(i, j, santykis);
                }
            }
        }
        static void SpausdintiSantykinįNedarbingumą(string fv, Birža birža, string komentaras)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(komentaras);
                fr.WriteLine();
                for (int i = 0; i < birža.m; i++)
                {
                    fr.Write("{0,4:d}.  ", i + 1);
                    for (int j = 0; j < birža.n; j++)
                        fr.Write("{0,-2:f2} ", birža.ImtiSantykinįNedarbingumą(i, j));
                    fr.WriteLine();
                }
                fr.WriteLine();
            }
        }
        static void SpausdintiSurikiuotusMiestus(string fv, Birža birža, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 43);
                fr.Write(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr.  Miestas    Gyventojai   Jaunimas 19-25 ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < birža.n; i++)
                {
                    fr.WriteLine("{0}. {1}   ", i + 1, birža.Imti(i).ToString());
                    fr.WriteLine(bruksnys);
                }
            }
        }
    }
}