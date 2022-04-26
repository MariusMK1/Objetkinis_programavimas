using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__
{
    internal class Program
    {
        const string CFd = "Duomenys.txt";
        const string CFr = "Rezultatai.txt";
        const string CFa = "Analize.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            InOut.Apdoroti(CFd, CFr, CFa);

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
