using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Salė
{
    class Kėdė
    {
        private string pavadinimas;     //kėdės pavadinimas
        private double kaina;           //kėdės kaina Eurais
        private double plotas;          //kėdės užimamas plotas kvadratiniais metrais, kėdė stačiakampė
        public Kėdė(string pavadinimas, double kaina, double plotas)
        {
            this.pavadinimas = pavadinimas;
            this.kaina = kaina;
            this.plotas = plotas;
        }
        public string imtiPav() { return pavadinimas; }
        public double imtiKainą() { return kaina; }
        public double imtiPlotą() { return plotas; }
    }
    internal class Program
    {
        const string CFd = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Salė\\bin\\Debug\\Duom.txt";
        const string CFd2 = "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Salė\\bin\\Debug\\Duom2.txt";
        const string CFrez= "D:\\Programavimas2\\Objetkinis programavimas\\Objektų_rinkiniai\\Salė\\bin\\Debug\\Rez.txt";
        static void Main(string[] args)
        {
            // Pirma parduotuvė
            Kėdė[] K = new Kėdė[100];
            int kiek;
            string parduotuvė;
            Skaityti(CFd, K, out kiek, out parduotuvė);
            Console.WriteLine("Parduotuvė: {0}", parduotuvė);
            Console.WriteLine("Siūlo pirkti tokias kėdes:");
            Console.WriteLine();
            Console.WriteLine("Pavadinimas     Kaina     Plotas");
            Console.WriteLine();
            for (int i = 0; i < kiek; i++)
            {
                Console.WriteLine("{0,-16}{1,5:f2}{2,10:f2}", K[i].imtiPav(), K[i].imtiKainą(), K[i].imtiPlotą());
            }
            Console.WriteLine();
            int j;          // Brangiausios kėdės eilės numeris faile
            int k;          // Didžiausią plotą užimančios kėdės eilės numeris faile
            brangiausiaKėdė(K, kiek, out j);
            didžiausiasPlotas(K, kiek, out k);
            Console.WriteLine("Brangiausia kėdė yra: {0} ir ji kainuoja: {1,5:f2} Eurus", K[j].imtiPav(), K[j].imtiKainą());
            Console.WriteLine("Didžiausią plotą užimanti kėdė yra: {0} ir ji užima: {1,5:f2} m2", K[k].imtiPav(), K[k].imtiPlotą());
            Console.WriteLine();

            // Antra parduotuvė
            Kėdė[] K2 = new Kėdė[100];
            int kiek2;
            string parduotuvė2;
            Skaityti(CFd2, K2, out kiek2, out parduotuvė2);
            Console.WriteLine("Parduotuvė: {0}", parduotuvė2);
            Console.WriteLine("Siūlo pirkti tokias kėdes:");
            Console.WriteLine();
            Console.WriteLine("Pavadinimas     Kaina     Plotas");
            Console.WriteLine();
            for (int i = 0; i < kiek2; i++)
            {
                Console.WriteLine("{0,-16}{1,5:f2}{2,10:f2}", K2[i].imtiPav(), K2[i].imtiKainą(), K2[i].imtiPlotą());
            }
            Console.WriteLine();
            int j2;          // brangiausios kėdės eilės numeris faile
            int k2;          // Didžiausią plotą užimančios kėdės eilės numeris faile
            brangiausiaKėdė(K2, kiek2, out j2);
            didžiausiasPlotas(K2, kiek2, out k2);
            Console.WriteLine("Brangiausia kėdė yra: {0} ir ji kainuoja: {1,5:f2} Eurus", K2[j2].imtiPav(), K2[j2].imtiKainą());
            Console.WriteLine("Didžiausią plotą užimanti kėdė yra: {0} ir ji užima: {1,5:f2} m2", K2[k2].imtiPav(), K2[k2].imtiPlotą());
            Console.WriteLine();


            kuriojParduotuvėjBrangiausia(parduotuvė, parduotuvė2, K[j].imtiKainą(), K2[j2].imtiKainą()); // iškarto spausdina kurioj parduotuvėje brangiausia

            double plotųSuma = kėdžiųPlotųSuma(K, kiek);
            double plotųSuma2 = kėdžiųPlotųSuma(K2, kiek2);
            double PlotųVidurkis = plotųVidurkis(plotųSuma, plotųSuma2, kiek, kiek2);

            if (File.Exists(CFrez))
                File.Delete(CFrez);

            spausindtiViršų(CFrez);
            spausdintiVidutinėKėdė(CFrez, K, kiek, PlotųVidurkis);
            spausdintiVidutinėKėdė(CFrez, K2, kiek2, PlotųVidurkis);
            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine("---------------------------------------");
                fr.WriteLine();
            }
            Console.WriteLine("Programa baigė darbą!");
        }
        static void Skaityti(string Fd, Kėdė[] K, out int kiek, out string parduotuvė)
        {
            using (StreamReader reader = new StreamReader(Fd))
            {
                string pav; double kaina, plotas;
                string line;
                line = reader.ReadLine();
                string[] parts;
                parduotuvė = line;
                line = reader.ReadLine();
                kiek = int.Parse(line);
                for (int i = 0; i < kiek; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    kaina = double.Parse(parts[1]);
                    plotas = double.Parse(parts[2]);
                    K[i] = new Kėdė(pav, kaina, plotas);
                }
            }
        }
        /// <summary>
        /// Brangiausios kėdės radimo metodas
        /// </summary>
        /// <param name="K"></param>
        /// <param name="kiek"></param>
        /// <param name="j" eilės numerio duomenų faile radimas></param>
        static void brangiausiaKėdė(Kėdė[] K, int kiek, out int j)
        {
            j = 0;
            double kaina = 0;
            for(int i = 0;i < kiek; i++)
            {
                if(K[i].imtiKainą() > kaina)
                {
                    kaina = K[i].imtiKainą();
                    j = i;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="K"></param>
        /// <param name="kiek"></param>
        /// <param name="k"> eilės numerion duomenų faile radimas</param>
        static void didžiausiasPlotas(Kėdė[] K, int kiek, out int k)
        {
            k = 0;
            double plotas = 0;
            for (int i = 0; i < kiek; i++)
            {
                if (K[i].imtiPlotą() > plotas)
                {
                    plotas = K[i].imtiPlotą();
                    k = i;
                }
            }
        }
        static void kuriojParduotuvėjBrangiausia(string pav,string pav2,double kaina,double kaina2)
        {
            if (kaina > kaina2)
                Console.WriteLine("Brangiausia kedė yra parduotuvėje: {0} ir ji kainuoja {1,5:f2} Eurus", pav, kaina);
            else
                Console.WriteLine("Brangiausia kedė yra parduotuvėje: {0} ir ji kainuoja {1,5:f2} Eurus", pav2, kaina2);
        }
        static double kėdžiųPlotųSuma(Kėdė[] K, int kiek)
        {
            double suma = 0;
            for (int i = 0; i < kiek; i++)
                suma += K[i].imtiPlotą();
            return suma;
        }
        static double plotųVidurkis(double plotųSuma, double plotųSuma2, int kiek, int kiek2)
        {
            return (plotųSuma + plotųSuma2) / (kiek + kiek2);
        }
        static void spausindtiViršų(string fv)
        {
            const string virsus =
                "|---------------|-----------|---------|\r\n"
                + "|               |           |         | \r\n"
                + "|  Pavadinimas  |   Kaina   |  Plotas | \r\n"
                + "|               |           |         | \r\n"
                + "|---------------|-----------|---------| \r\n";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Vidutinių Kėdžių sąrašas:");
                fr.Write(virsus);
            }
        }
        static void spausdintiVidutinėKėdė(string fv, Kėdė[] K, int nkiek, double vidurkis)
        {
            using (var fr = File.AppendText(fv))
            { 
                Kėdė tarp;
                for (int i = 0; i < nkiek; i++)
                {
                    tarp = K[i];
                    if (K[i].imtiPlotą() > (vidurkis * 0.9) && K[i].imtiPlotą() < (vidurkis * 1.1))
                    fr.WriteLine("|{0,-15}| {1,7}   |   {2,4:f2}  |", tarp.imtiPav(), tarp.imtiKainą(), tarp.imtiPlotą());
                }
            }
        }
    }
}
