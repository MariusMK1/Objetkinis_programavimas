using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalygosSakinys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a;
            int b;
            int c;
            Console.Write("Nurodykite simbolį:");
            a = char.Parse(Console.ReadLine());
            Console.Write("Nurodykite bendrą simbolių kiekį:");
            b = int.Parse(Console.ReadLine());
            Console.Write("Nurodykite vienos eilutės simbolių kiekį:");
            c = int.Parse(Console.ReadLine());
            for (int i = 1; i <= b; i++)
            {
                Console.Write(a);
                if (i % c == 0)
                    Console.WriteLine("");
            };
            Console.WriteLine("");
        }
    }
}
