using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eilučių.Redagavimas
{
    internal class Program
    {
        const string CFd = "Duomenys.txt";
        const string CFr = "Rezultatai.txt";
        const string CFr2 = "Rezultatai2.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string skyr = " .,!?:;()\t'";
            string vardas = "Arvydas";
            string pavardė = "Sabonis";
            InOut.Apdoroti(CFd, CFr, skyr, vardas, pavardė);
            InOut.Pašalinti(CFd, CFr2, skyr, vardas);

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
