using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sveikuju_reiksmiu_ivedimas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sveikuju reiksmiu ivedimas
            int a;
            int b;
            int suma;
            Console.WriteLine("iveskite sveikaja a reiksme");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("iveskite sveikaja b reiksme");
            b = int.Parse(Console.ReadLine());
            suma = a + b;
            Console.WriteLine("{0} + {1} = {2}", a, b, suma);
        }
    }
}
