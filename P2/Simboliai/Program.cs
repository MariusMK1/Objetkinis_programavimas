using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simboliai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (char ch = 'a'; ch <= 'z'; ch++)
                Console.Write("{0} ", ch);
            Console.WriteLine();

            for (char ch = 'a'; ch <= 'z'; ch++)
                Console.Write("{0} - {1} ", ch, (int)ch);
            Console.WriteLine();

            char pr, pb;
            Console.Write("Įveskite raidę raidžių intervalo pradžiai: ");
            pr = Console.ReadLine()[0];
            Console.Write("Įveskite raidę raidžių intervalo pabaigai: ");
            pb = (char)Console.Read();
            for (char ch = pr; ch <= pb; ch++)
                Console.WriteLine("{0} - {1}", ch, (int)ch);
        }
    }
}
