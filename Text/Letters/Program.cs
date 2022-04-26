using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Letters
{
    class Program
    {
        const string CFd = "U1.txt";
        const string CFr = "Rezultatai.txt";
        const string CFr2 = "Rezultatai2.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            RaidziuDazniai eil = new RaidziuDazniai();
            TaskUtils.Dazniai(CFd, eil);
            InOut.Spausdinti(CFr, eil);
            Char raidė = new Char();
            int max = eil.max(out raidė);
            Console.WriteLine("Dažniausiai naudota raidė yra {0}, ir ji buvo panaudota {1} kart.", raidė, max);

            int nr;
            int ilgis;
            InOut.Skaityti(CFd, out nr, out ilgis);
            InOut.Spausdinti2(CFd, CFr2, ilgis);
            Console.WriteLine("Ilgiausios eilutės nr. {0, 4:d}", nr + 1);

            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
