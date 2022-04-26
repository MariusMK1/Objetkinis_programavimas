using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
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
            string insert = "Buvo palindromų";
            InOutUtils.ReadAndWrite(CFd, CFr, divaiders, insert);
        }
    }
}
