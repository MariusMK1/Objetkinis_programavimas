using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Aukščiausia_lyga
{
    class Komanda
    {
        string pav,
               miestas,
               pavard,
               vard;
        int taškai,
            pergalės;
        public Komanda()
        {
            pav = "";
            miestas = "";
            pavard = "";
            vard = "";
            taškai = 0;
            pergalės = 0;
        }
        public void Dėti(string pav, string miestas, string pavard, string vard)
        {
            this.pav = pav;
            this.miestas = miestas;
            this.pavard = pavard;
            this.vard = vard;
        }
        public string ImtiPav() { return pav; }
        public string ImtiMiestą() { return miestas; }
        public string ImtiPavard() { return pavard; }
        public string ImtiVardą() { return vard; }
        public void DėtiTaškus(int tašk) { taškai = tašk; }
        public int ImtiTaškus() { return taškai; }
        public void DėtiPergales(int perg) { pergalės = perg; }
        public int ImtiPergales() { return pergalės; }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("  {0, -13} {1, -12}  {2,-11}     {3,-10}", pav, miestas, pavard, vard);
            return eilute;
        }
        public static bool operator <=(Komanda pirmas, Komanda antras)
        {
            return pirmas.taškai < antras.taškai || pirmas.taškai == antras.taškai && pirmas.pergalės < antras.pergalės;
        }
        public static bool operator >=(Komanda pirmas, Komanda antras)
        {
            return pirmas.taškai > antras.taškai || pirmas.taškai == antras.taškai && pirmas.pergalės > antras.pergalės;
        }
    }
    class Turnyras
    {
        const int CMaxEil = 100;
        const int CMaxSt = 100;
        private Komanda[] Komandos;
        public int n { get; set; }                 //Eilučių skačius
        private int[,] G;                          //Įvarčių duomenys
        public int m { get; set; }                 //Stulpelių skačius

        public Turnyras()
        {
            n = 0;
            Komandos = new Komanda[CMaxEil];
            m = 0;
            G = new int[CMaxEil, CMaxSt];
        }
        public void DėtiĮvarčius(int i, int j, int įvartis)
        {
            G[i, j] = įvartis;
        }
        public int ImtiReikšmęĮvarčio(int i, int j)
        {
            return G[i, j];
        }
        public void Dėti(Komanda ob) { Komandos[n++] = ob; }
        public int Imti() { return n; }
        public Komanda Imti(int nr) { return Komandos[nr]; }
        public void TaškųSkaičiavimas()
        {
            Komanda kom;
            for (int i = 0; i < n; i++)
            {
                int taškai = 0;
                int pergalės = 0;
                for (int j = 0; j < m; j++)
                {
                    if (i != j)
                    {
                        if (ImtiReikšmęĮvarčio(i, j) > ImtiReikšmęĮvarčio(j, i))
                        {
                            taškai += 3;
                            pergalės++;
                        }
                        else if (ImtiReikšmęĮvarčio(i, j) == ImtiReikšmęĮvarčio(j, i))
                            taškai += 1;
                    }
                }
                kom = Imti(i);
                kom.DėtiTaškus(taškai);
                kom.DėtiPergales(pergalės);
            }
        }
        public int MinPralaimėjimų()
        {
            int minPral = 10;
            for (int i = 0; i < n; i++)
            {
                int suma = 0;
                for (int j = 0; j < m; j++)
                {
                    if (i != j)
                    {
                        if (ImtiReikšmęĮvarčio(i, j) < ImtiReikšmęĮvarčio(j, i))
                            suma++;
                    }
                }
                if(minPral > suma)
                    minPral = suma;
            }
            return minPral;
        }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Komanda min = Komandos[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Komandos[j] >= min)
                    {
                        //naudojamas užklotas operatorius <=
                        min = Komandos[j];
                        im = j;
                    }
                Komandos[im] = Komandos[i];
                Komandos[i] = min;
            }
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Aukščiausia_lyga\\bin\\Debug\\Duom.txt";
        const string CFr = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Aukščiausia_lyga\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Turnyras turnyras = new Turnyras();
            SkaitytiKomandas(CFd, ref turnyras);
            SkaitytiĮvarčius(CFd, ref turnyras);
            using (var fr = File.CreateText(CFr))
            {
                fr.WriteLine("    Pradiniai duomenys");
                fr.WriteLine();
                fr.WriteLine("Komandų kiekis {0}", turnyras.n);
                fr.WriteLine();
            }
            SpausdintiKomandas(CFr, turnyras, "Komandų sąrašas:");
            SpausdintiĮvarčius(CFr, turnyras, "Įvarčių lentelė");

            SpausdintiKmandasKuriosTuriMinPralaimėjimų(CFr, turnyras);
            turnyras.TaškųSkaičiavimas();
            turnyras.Rikiuoti();
            SpausdintiKomandasSuTaškais(CFr, turnyras, "Komandų sąrašas su taškais");

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
        static void SkaitytiKomandas(string fd, ref Turnyras turnyras)
        {
            string pav, miestas, vard, pavard, line;
            int nn;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                turnyras.m = nn;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    pav = parts[0];
                    miestas = parts[1];
                    pavard = parts[2];
                    vard = parts[3];
                    Komanda kom;
                    kom = new Komanda();
                    kom.Dėti(pav, miestas, pavard, vard);
                    turnyras.Dėti(kom);
                }
            }
        }
        static void SkaitytiĮvarčius(string fd, ref Turnyras turnyras)
        {
            int Įvart, nn;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                for (int z = 0; z < nn; z++)
                    line = reader.ReadLine();
                for(int i = 0; i < turnyras.n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for (int j = 0; j < nn; j++)
                    {
                        Įvart = int.Parse(parts[j]);
                        turnyras.DėtiĮvarčius(i, j, Įvart);
                    }
                }

            }
        }
        static void SpausdintiKomandas(string fv, Turnyras turnyras, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 57);
                fr.Write(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr. Pavadinimas     Miestas       Pavardė         Vardas  ");
                fr.WriteLine(bruksnys);
                fr.WriteLine("");
                for(int i = 0; i < turnyras.n; i++)
                {
                    fr.WriteLine("{0}. {1}   ", i + 1, turnyras.Imti(i).ToString());
                    fr.WriteLine(bruksnys);
                }
            }
        }
        static void SpausdintiĮvarčius(string fv, Turnyras turnyras, string komentaras)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("{0}", komentaras);
                fr.WriteLine();
                for (int i = 0; i < turnyras.n; i++)
                {
                    fr.Write("{0,4:d}.  ", i + 1);
                    for (int j = 0; j < turnyras.m; j++)
                        fr.Write("{0,3:d} ", turnyras.ImtiReikšmęĮvarčio(i, j));
                    fr.WriteLine();
                }
                fr.WriteLine();
            }
        }
        static void SpausdintiKomandasSuTaškais(string fv, Turnyras turnyras, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 68);
                fr.Write(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr. Pavadinimas     Miestas       Pavardė         Vardas     Taškai");
                fr.WriteLine(bruksnys);
                fr.WriteLine("");
                for (int i = 0; i < turnyras.n; i++)
                {
                    fr.WriteLine("{0}. {1}   {2,2:d}", i + 1, turnyras.Imti(i).ToString(), turnyras.Imti(i).ImtiTaškus());
                    fr.WriteLine(bruksnys);
                }
            }
        }
        static void SpausdintiKmandasKuriosTuriMinPralaimėjimų(string fv, Turnyras turnyras)
        {
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine("Mažiausiai pralaimėjimų turi:");
                for (int i = 0; i < turnyras.n; i++)
                {
                    int suma = 0;
                    for(int j = 0; j < turnyras.n; j++)
                    {
                        if (turnyras.ImtiReikšmęĮvarčio(i, j) < turnyras.ImtiReikšmęĮvarčio(j, i))
                            suma++;
                    }
                    if (suma == turnyras.MinPralaimėjimų())
                    {
                        fr.Write("{0} ", turnyras.Imti(i).ImtiPav());
                    }
                }
                fr.WriteLine();
                fr.WriteLine();
            }
        }
    }
}
