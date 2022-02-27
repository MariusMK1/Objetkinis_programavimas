using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Prekybos_tinklas
{
    class Kasininkas
    {
        string vardas,
               pavardė;
        int gymMet,
            kasa;
        double atlyginimas;
        public Kasininkas()
        {
            vardas = "";
            pavardė = "";
            gymMet = 0;
            kasa = 0;
            atlyginimas = 0;
        }
        public void Dėti(string vardas, string pavardė, int gymMet, int kasa)
        {
            this.vardas = vardas;
            this.pavardė = pavardė;
            this.gymMet = gymMet;
            this.kasa = kasa;
        }
        public string ImtiVardą() { return vardas; }
        public string ImtiPavardę() { return pavardė; }
        public int ImtiGymMet() { return gymMet; }
        public int ImtiKasą() { return kasa; }
        public void DėtiAtlyginimą(double atl) { atlyginimas = atl; }
        public double ImtiAtlyginimą() { return atlyginimas; }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("  {0, -9} {1, -13} {2,-13} {3,-2}", vardas, pavardė, gymMet, kasa);
            return eilute;
        }
    }
    class Parduotuvė
    {
        const int CMaxEil = 100;
        const int CMaxSt = 100;
        private Kasininkas[] Kasininkai;
        public int n { get; set; }                 //stulpelių skačius
        private double[,] P;                       //Uždirbtų pinigų duomenys
        public int m { get; set; }                 //eilučių skačius
        public Parduotuvė()
        {
            n = 0;
            Kasininkai = new Kasininkas[CMaxEil];
            m = 0;
            P = new double[CMaxEil, CMaxSt];
        }
        public void DėtiPinigus(int i, int j, double pinigai)
        {
            P[i, j] = pinigai;
        }
        public double ImtiPinigus(int i, int j)
        {
            return P[i, j];
        }
        public void Dėti(Kasininkas ob) { Kasininkai[n++] = ob; }
        public int Imti() { return n; }
        public Kasininkas Imti(int nr) { return Kasininkai[nr]; }
        public void SkaičiuotiAtlyginimą()
        {
            Kasininkas kas;
            for(int i = 0; i < n; i++)
            {
                double suma = 0;
                for(int j = 0; j < m; j++)
                {
                    suma += ImtiPinigus(j, i);
                }
                double atlyginimas = suma * 0.01;
                kas = Imti(i);
                kas.DėtiAtlyginimą(atlyginimas);
            }
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Prekybos_tinklas\\bin\\Debug\\Duom.txt";
        const string CFr = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Prekybos_tinklas\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Parduotuvė parduotuvė = new Parduotuvė();
            SkaitytiKasininkus(CFd, ref parduotuvė);
            SkaitytiPinigus(CFd, ref parduotuvė);
            SpausdintiKasininkus(CFr, parduotuvė, "Pradiniai kasininkų duomenys");
            SpausdintiPinigus(CFr, parduotuvė, "Pradiniai surinktų pinigų kasose duomenys:");
            parduotuvė.SkaičiuotiAtlyginimą();
            SpausdintiKasininkusSuAtlyginimu(CFr, parduotuvė, "Kasininkų duomenys su atlyginimu");
            SpausdintiJauniausią(CFr, parduotuvė);
            SpausdintiVyriausią(CFr, parduotuvė);
            SpausdintiMaxPardavimus(CFr, parduotuvė);

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
        static void SkaitytiKasininkus(string fd, ref Parduotuvė parduotuvė)
        {
            string vardas, pavardė, line;
            int nn, mm, gymMet, kasa;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts = line.Split(' ');
                nn = int.Parse(parts[0]);
                mm = int.Parse(parts[1]);
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    vardas = parts[0];
                    pavardė = parts[1];
                    gymMet = int.Parse(parts[2]);
                    kasa = int.Parse(parts[3]);
                    Kasininkas kas;
                    kas = new Kasininkas();
                    kas.Dėti(vardas, pavardė, gymMet, kasa);
                    parduotuvė.Dėti(kas);
                }
            }
        }
        static void SkaitytiPinigus(string fd, ref Parduotuvė parduotuvė)
        {
            double pinigai;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts = line.Split(' ');
                parduotuvė.n = int.Parse(parts[0]);
                parduotuvė.m = int.Parse(parts[1]);
                for (int z = 0; z < parduotuvė.n; z++)
                    line = reader.ReadLine();
                for (int i = 0; i < parduotuvė.m; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for (int j = 0; j < parduotuvė.n; j++)
                    {
                        pinigai = double.Parse(parts[j]);
                        parduotuvė.DėtiPinigus(i, j, pinigai);
                    }
                }
            }
        }
        static void SpausdintiKasininkus(string fv, Parduotuvė parduotuvė, string antraštė)
        {
            using (var fr = File.CreateText(fv))
            {
                string bruksnys = new string('-', 49);
                fr.Write(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr.  Vardas    Pavardė   Gymimo metai   Kasos Nr. ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < parduotuvė.n; i++)
                {
                    fr.WriteLine("{0}. {1}   ", i + 1, parduotuvė.Imti(i).ToString());
                    fr.WriteLine(bruksnys);
                }
            }
        }
        static void SpausdintiPinigus(string fv, Parduotuvė parduotuvė, string komentaras)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(komentaras);
                fr.WriteLine();
                for (int i = 0; i < parduotuvė.m; i++)
                {
                    fr.Write("{0,4:d}.  ", i + 1);
                    for (int j = 0; j < parduotuvė.n; j++)
                        fr.Write("{0,-6:f2} ", parduotuvė.ImtiPinigus(i, j));
                    fr.WriteLine();
                }
                fr.WriteLine();
            }
        }
        static void SpausdintiKasininkusSuAtlyginimu(string fv, Parduotuvė parduotuvė, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 62);
                fr.Write(antraštė);
                fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine("Nr.  Vardas    Pavardė   Gymimo metai   Kasos Nr.  Atlyginimas");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < parduotuvė.n; i++)
                {
                    fr.WriteLine("{0}. {1}        {2,6:f2} ", i + 1, parduotuvė.Imti(i).ToString(), parduotuvė.Imti(i).ImtiAtlyginimą());
                    fr.WriteLine(bruksnys);
                }
            }
        }
        static void SpausdintiJauniausią(string fv, Parduotuvė parduotuvė)
        {
            using (var fr = File.AppendText(fv))
            {
                int Index = 0;
                int jauniausias = parduotuvė.Imti(0).ImtiGymMet();
                fr.WriteLine();
                for (int i = 0; i < parduotuvė.n; i++)
                {
                    if (jauniausias < parduotuvė.Imti(i).ImtiGymMet())
                    {
                        Index = i;
                        jauniausias = parduotuvė.Imti(i).ImtiGymMet();
                    }
                }
                fr.WriteLine("Jauniausias kasininkas(ė) {0} {1} ir jo(s) atlygis {2,6:f2}", parduotuvė.Imti(Index).ImtiVardą(), parduotuvė.Imti(Index).ImtiPavardę(), parduotuvė.Imti(Index).ImtiAtlyginimą());
                fr.WriteLine();
            }
        }
        static void SpausdintiVyriausią(string fv, Parduotuvė parduotuvė)
        {
            using (var fr = File.AppendText(fv))
            {
                int Index = 0;
                int Vyriausias = parduotuvė.Imti(0).ImtiGymMet();
                fr.WriteLine();
                for (int i = 0; i < parduotuvė.n; i++)
                {
                    if (Vyriausias > parduotuvė.Imti(i).ImtiGymMet())
                    {
                        Index = i;
                        Vyriausias = parduotuvė.Imti(i).ImtiGymMet();
                    }
                }
                fr.WriteLine("Vyriausias kasininkas(ė) {0} {1} ir jo(s) atlygis {2,6:f2}", parduotuvė.Imti(Index).ImtiVardą(), parduotuvė.Imti(Index).ImtiPavardę(), parduotuvė.Imti(Index).ImtiAtlyginimą());
                fr.WriteLine();
            }
        }
        static void SpausdintiMaxPardavimus(string fv, Parduotuvė parduotuvė)
        {
            using (var fr = File.AppendText(fv))
            {
                int Index = 0;
                double max = 0;
                for (int i = 0; i < parduotuvė.m; i++)
                {
                    double suma = 0;
                    for(int j = 0; j < parduotuvė.n; j++)
                    {
                        suma += parduotuvė.ImtiPinigus(i, j);
                    }
                    if(max < suma)
                    {
                        max = suma;
                        Index = i;
                    }
                }
                fr.WriteLine("{0} dieną buvo atlikta didžiausi pardavimai, buvo parduota už {1,6:f2} eurus", Index + 1, max);
            }
        }
    }
}
