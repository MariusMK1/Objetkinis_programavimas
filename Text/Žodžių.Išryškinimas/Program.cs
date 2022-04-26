using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Žodžių.Išryškinimas
{
    internal class Program
    {
        const string CFd = "Duomenys.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            Console.WriteLine("Sutampančių žodžių {0, 3:d}", InOut.Apdoroti(CFd, skyrikliai));

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
