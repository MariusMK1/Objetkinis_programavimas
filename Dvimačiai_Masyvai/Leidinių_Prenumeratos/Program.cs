using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace Leidinių_Prenumeratos
{
    class Leidinys
    {
        string pav,
               bank,
               sąskaita;
        int kaina,
               užsakymai,
               nebuvoUžsakymų;
        double procentai;
        public Leidinys()
        {
            pav = "";
            kaina = 0;
            bank = "";
            sąskaita = "";
            procentai = 0;
            užsakymai = 0;
            nebuvoUžsakymų = 0;
        }
        public void Dėti(string pav, int kaina, string bank, string sąskaita, double procentai)
        {
            this.pav = pav;
            this.kaina = kaina;
            this.bank = bank;
            this.sąskaita = sąskaita;
            this.procentai = procentai;
        }
        public string ImtiPav() { return pav; }
        public int ImtiKainą() { return kaina; }
        public string ImtiSąskaitą() { return sąskaita; }
        public string ImtiBanką() { return bank; }
        public double imtiProcentus() { return procentai; }
        public void DėtiUžsakymus(int užs) { užsakymai = užs; }
        public int ImtiUžsakymus() { return užsakymai; }
        public void DėtiNebvoUžsakymų(int neUžs) { nebuvoUžsakymų = neUžs; }
        public int ImtiNebuvoUžsakymų() { return nebuvoUžsakymų; }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("  {0, -22} {1, -4} {2,-10} {3,-18} {4,-4}", pav, kaina, bank, sąskaita, procentai);
            return eilute;
        }
    }
    class Prenumeratos
    {
        const int CMaxEil = 100;
        const int CMaxSt = 100;
        private Leidinys[] Leidiniai;
        public int n { get; set; }                 //stulpelių skačius
        private int[,] U;                          //Užsakymų duomenys
        public int m { get; set; }                 //eilučių skačius
        public Prenumeratos()
        {
            n = 0;
            Leidiniai = new Leidinys[CMaxEil];
            m = 0;
            U = new int[CMaxEil, CMaxSt];
        }
        public void DėtiUžsakymus(int i, int j, int užsakymas)
        {
            U[i, j] = užsakymas;
        }
        public int ImtiReikšmęUžsakymo(int i, int j)
        {
            return U[i, j];
        }
        public void Dėti(Leidinys ob) { Leidiniai[n++] = ob; }
        public int Imti() { return n; }
        public Leidinys Imti(int nr) { return Leidiniai[nr]; }
        public void UžsakymųSkaičiavimas()
        {
            Leidinys leid;
            for (int i = 0; i < n; i++)
            {
                int užsakymai = 0;
                for (int j = 0; j < m; j++)
                {
                    užsakymai += ImtiReikšmęUžsakymo(j, i);
                }
                leid = Imti(i);
                leid.DėtiUžsakymus(užsakymai);
            }
        }
        public int MaxUžsakymų()
        {
            Leidinys leid;
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                leid = Imti(i);
                if (max < leid.ImtiUžsakymus())
                {
                    max = leid.ImtiUžsakymus();
                }
            }
            return max;
        }
        public void KiekNebuvoUžsakymų()
        {
            Leidinys leid;
            for (int i = 0; i < n; i++)
            {
                int užsakymai = 0;
                for (int j = 0; j < m; j++)
                {
                    if (ImtiReikšmęUžsakymo(j, i) == 0)
                    {
                        užsakymai++;
                    }
                }
                leid = Imti(i);
                leid.DėtiNebvoUžsakymų(užsakymai);
            }
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Leidinių_Prenumeratos\\bin\\Debug\\Duom.txt";
        const string CFr = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Leidinių_Prenumeratos\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Prenumeratos prenumeratos = new Prenumeratos();

            SkaitytiLeidinius(CFd, ref prenumeratos);
            SkaitytiUžsakymus(CFd, ref prenumeratos);
            SpausdintiLeidinius(CFr, prenumeratos, "Pradiniai leidinių duomenys:");
            SpausdintiUžsakymus(CFr, prenumeratos, "Pradiniai užsakymų duomenys");
            prenumeratos.UžsakymųSkaičiavimas();
            SpausdintiLeidiniusSuUžsakymais(CFr, prenumeratos, "Leidiniai su užsakymais:");
            SpausdintiLyderius(CFr, prenumeratos);
            prenumeratos.KiekNebuvoUžsakymų();
            SpausdintiNeturėjoUžsakymų(CFr, prenumeratos);
            SpausdintiPavedimųSąrašą(CFr, prenumeratos);


            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
        static void SkaitytiLeidinius(string fd, ref Prenumeratos prenumeratos)
        {
            string pav, bank, sąskaita, line;
            int nn, mm, kaina, procentai;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    kaina = int.Parse(parts[1]);
                    bank = parts[2];
                    sąskaita = parts[3];
                    procentai = int.Parse(parts[1]);
                    Leidinys leid;
                    leid = new Leidinys();
                    leid.Dėti(pav, kaina, bank, sąskaita, procentai);
                    prenumeratos.Dėti(leid);
                }
            }
        }
        static void SkaitytiUžsakymus(string fd, ref Prenumeratos prenumeratos)
        {
            int užsakymas;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                prenumeratos.n = int.Parse(line);
                line = reader.ReadLine();
                prenumeratos.m = int.Parse(line);
                for (int z = 0; z < prenumeratos.n; z++)
                    line = reader.ReadLine();
                for (int i = 0; i < prenumeratos.m; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for (int j = 0; j < prenumeratos.n; j++)
                    {
                        užsakymas = int.Parse(parts[j]);
                        prenumeratos.DėtiUžsakymus(i, j, užsakymas);
                    }
                }
            }
        }
        static void SpausdintiLeidinius(string fv, Prenumeratos prenumeratos, string antraštė)
        {
            using (var fr = File.CreateText(fv))
            {
                string bruksnys = new string('-', 68);
                fr.Write(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr.      Pavadinimas       Kaina  Bankas       Sąskaita    Procentai ");
                fr.WriteLine(bruksnys);
                fr.WriteLine("");
                for (int i = 0; i < prenumeratos.n; i++)
                {
                    fr.WriteLine("{0}. {1}   ", i + 1, prenumeratos.Imti(i).ToString());
                    fr.WriteLine(bruksnys);
                }
            }
        }
        static void SpausdintiUžsakymus(string fv, Prenumeratos prenumeratos, string komentaras)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("{0}", komentaras);
                fr.WriteLine();
                for (int i = 0; i < prenumeratos.m; i++)
                {
                    fr.Write("{0,4:d}.  ", i + 1);
                    for (int j = 0; j < prenumeratos.n; j++)
                        fr.Write("{0,3:d} ", prenumeratos.ImtiReikšmęUžsakymo(i, j));
                    fr.WriteLine();
                }
                fr.WriteLine();
            }
        }
        static void SpausdintiLeidiniusSuUžsakymais(string fv, Prenumeratos prenumeratos, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 79);
                fr.Write(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr.      Pavadinimas       Kaina  Bankas       Sąskaita    Procentai  Užsakymai");
                fr.WriteLine(bruksnys);
                fr.WriteLine("");
                for (int i = 0; i < prenumeratos.n; i++)
                {
                    fr.WriteLine("{0}. {1}      {2} ", i + 1, prenumeratos.Imti(i).ToString(), prenumeratos.Imti(i).ImtiUžsakymus());
                    fr.WriteLine(bruksnys);
                }
            }
        }
        static void SpausdintiLyderius(string fv, Prenumeratos prenumeratos)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                fr.WriteLine("Lyderiaujantys leidiniai:");
                for (int i = 0; i < prenumeratos.n; i++)
                {
                    if (prenumeratos.Imti(i).ImtiUžsakymus() == prenumeratos.MaxUžsakymų())
                        fr.Write("({0}) ", prenumeratos.Imti(i).ImtiPav());
                }
                fr.WriteLine();
            }
        }
        static int NeturėjoUžsakymų(Prenumeratos prenumeratos)
        {
            int kiek = 0;
            for (int i = 0; i < prenumeratos.n; i++)
            {
                if (prenumeratos.Imti(i).ImtiNebuvoUžsakymų() > 1)
                    kiek++;
            }
            return kiek;
        }
        static void SpausdintiNeturėjoUžsakymų(string fv, Prenumeratos prenumeratos)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                if(NeturėjoUžsakymų(prenumeratos) > 0)
                    fr.WriteLine("Leidinių kurie nebuvo užsakyti daugiau negu vieną dieną yra: {0}", NeturėjoUžsakymų(prenumeratos));
                else
                    fr.WriteLine("Leidinių kurie nebuvo užsakomi daugiau negu vieną dieną nėra");
                fr.WriteLine();
            }
        }
        static void SpausdintiPavedimųSąrašą(string fv, Prenumeratos prenumeratos)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                for (int i = 0; i < prenumeratos.n; i++)
                {
                    fr.WriteLine("{0} {1} {2} turi būti pervesta {3,5:f2}", prenumeratos.Imti(i).ImtiPav(), prenumeratos.Imti(i).ImtiBanką(), prenumeratos.Imti(i).ImtiSąskaitą(), prenumeratos.Imti(i).ImtiKainą() * prenumeratos.Imti(i).ImtiUžsakymus() * (prenumeratos.Imti(i).imtiProcentus()/100));
                }
                fr.WriteLine();
            }
        }
    }
}
