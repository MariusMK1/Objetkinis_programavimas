using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realiuju_reiksmiu_ivedimas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pi = 3.1415;
            double H;
            double R, r;
            double V;
            Console.WriteLine("iveskite kugio aukstines reiksme");
            H = double.Parse(Console.ReadLine());
            Console.WriteLine("iveskite kugio virsutinio pagrindo spindulio reiksme");
            r = double.Parse(Console.ReadLine());
            Console.WriteLine("iveskite kugio apatinio pagrindo spindulio reiksme");
            R = double.Parse(Console.ReadLine());
            V = (1.0 / 3) * pi * H * (R * R + R * r + r * r);
            Console.WriteLine("Kugio turis = {0, 5:f2}", V);
        }
    }
}
