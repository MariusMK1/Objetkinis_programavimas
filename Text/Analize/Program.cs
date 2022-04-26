using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analize
{
    internal class Program
    {
        const string CFd = "Duom.txt";
        const string CFr = "Rezultatai.txt";
        const string CFa = "Analize.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            const string balses = "AEIYOUaeiyouAąĘęĖėĮįŲųŪū";
            InOut.Apdoroti(CFd, CFr, CFa, skyrikliai, balses);

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
