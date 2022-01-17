using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simboliai_string
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vardas;
            Console.Write("Koks jūsų vardas: ");
            vardas = Console.ReadLine();
            Console.WriteLine(" Sveika(s), {0}!", vardas);
        }
    }
}
