using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Letters
{
    internal class Program
    {
        const string CFd = "Duomenys.txt";
        const string CFr = "Rezultatai.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            char[] divaiders = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            InOutUtils.ReadAndWrite(CFd, CFr, divaiders);
        }
    }
}
