using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Šeimos_išlaidos
{
    class Asmuo
    {
        private string vardas;
        private double pinigai;

        public Asmuo(string vardas, double pinigai)
        {
            this.vardas = vardas;
            this.pinigai = pinigai;
        }
        public string ImtiVardą() { return vardas; }
        public double ImtiPinigus() { return pinigai; }
    }
    class Matrica
    {
        const int CMaxEil = 100;                    //Didžiausias galimas savaičių skaičius
        const int CMaxSt = 7;                       //Didžiausias galimas stulpelių skaičius
        private Asmuo[,] A;                         //Duomenų matrica
        public int n { get; set; }                 //Eilučių skačius
        public int m { get; set; }                  //Stulpelių skaičius

        public Matrica()
        {
            n = 0;
            m = 0;
            A = new Asmuo[CMaxEil, CMaxSt];
        }
        public void Dėti(int i, int j, Asmuo asmuo) 
        {
            A[i, j] = asmuo;
        }
        public Asmuo ImtiReiksme(int i, int j)
        {
            return A[i, j];
        }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Šeimos_išlaidos\\bin\\Debug\\Duom.txt";
        const string CFr = "D:\\Programavimas2\\Objetkinis programavimas\\Dvimačiai_Masyvai\\Šeimos_išlaidos\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            Matrica seimosIslaidos = new Matrica();
            Skaityti(CFd, ref seimosIslaidos);
            if (File.Exists(CFr))
                File.Delete(CFr);
            Spausdinti(CFr, seimosIslaidos, "Pradininiai duomenys");

            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine("Rezultatai");
                fr.WriteLine();
                fr.WriteLine("Viso išleista: {0,5:c2}.", VisosIslaidos(seimosIslaidos));
                fr.WriteLine();
                fr.WriteLine("Antradienių bendros išlaidos {0,5:c2},",IslaidosSavaitesDienaX(seimosIslaidos,2));
                fr.WriteLine();
                fr.WriteLine("Šeštadienių bendros išlaidos {0,5:c2},", IslaidosSavaitesDienaX(seimosIslaidos, 6));
                fr.WriteLine();
                int savaite, diena;
                Asmuo a;
                DienaMaxIslaidos(seimosIslaidos, out savaite, out diena);
                fr.Write("Daugiausia išleista {0} sav. {1} dieną.", savaite, diena);
                a = seimosIslaidos.ImtiReiksme(savaite - 1, diena - 1);
                fr.WriteLine("Pinigus išleido {0}: {1,5:c2}.", a.ImtiVardą(), a.ImtiPinigus());
                fr.WriteLine();
            }

            IslaidosSavaitemis(CFr, ref seimosIslaidos);

                Console.WriteLine("Duomenys išspausdinti faile: {0}", CFr);
            Console.WriteLine("Programa baigė darbą!");
        }
        static void Skaityti(string fd, ref Matrica seimosIslaiddos)
        {
            int nn, mm;
            double pinigai;
            string line, vardas;
            Asmuo asmuo;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                seimosIslaiddos.n = nn;
                seimosIslaiddos.m = mm;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < mm; j++)
                    {
                        vardas = parts[2 * j];
                        pinigai = double.Parse(parts[2 * j + 1]);
                        asmuo = new Asmuo(vardas, pinigai);
                        seimosIslaiddos.Dėti(i, j, asmuo);
                    }
                }
            }
        }
        static void Spausdinti(string fv, Matrica seimosIslaidos, string antraštė)
        {
            Asmuo asmuo;
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine("Savaičių kiekis {0}", seimosIslaidos.n);
                fr.WriteLine("Dienų kiekis {0}", seimosIslaidos.m);
                fr.WriteLine();

                for (int j = 0; j < seimosIslaidos.m; j++)
                    fr.Write("{0}-dienis        ", j + 1);
                fr.WriteLine();

                for(int i = 0; i < seimosIslaidos.n; i++)
                {
                    for (int j = 0; j < seimosIslaidos.m; j++)
                    {
                        asmuo = seimosIslaidos.ImtiReiksme(i, j);
                        fr.Write("{0} {1,6:f2}  ", asmuo.ImtiVardą(), asmuo.ImtiPinigus());
                    }
                    fr.WriteLine();
                }
            }
        }
        static decimal VisosIslaidos(Matrica A)
        {
            Asmuo asmuo;
            double suma = 0;
            for (int i = 0; i < A.n; i++)
            {
                for(int j = 0; j < A.m; j++)
                {
                    asmuo = A.ImtiReiksme(i, j);
                    suma = suma + asmuo.ImtiPinigus();
                }
            }
            return (decimal)suma;
        }
        static void IslaidosSavaitemis(string fv, ref Matrica A)
        {
            using (var fr = File.AppendText(fv))
            {
                for (int i = 0; i < A.n; i++)
                {
                    double suma = 0;
                    for (int j = 0; j < A.m; j++)
                    {
                        Asmuo x = A.ImtiReiksme(i, j);
                        suma = suma + x.ImtiPinigus();
                    }
                    fr.WriteLine("Savaitės nr. {0} išlaidos {1,5:c2}.", i + 1, (decimal)suma);
                }
            }
        }
        static decimal IslaidosSavaitesDienaX(Matrica A, int nr)
        {
            double suma = 0;
            for (int i = 0; i < A.n; i++)
            {
                Asmuo x = A.ImtiReiksme(i, nr - 1);
                suma = suma + x.ImtiPinigus();
            }
            return (decimal)suma;
        }
        static void DienaMaxIslaidos(Matrica A, out int eilNr, out int stNr)
        {
            eilNr = -1;
            stNr = -1;
            double max = 0;
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    double x = A.ImtiReiksme(i, j).ImtiPinigus();
                    if (x > max)
                    {
                        max = x;
                        eilNr = i + 1;
                        stNr = j + 1; 
                    }
                }
            }
        }
    }
}
