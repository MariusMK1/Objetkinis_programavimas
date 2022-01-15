using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funkcijos_reiksmes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double fx;
            //int z;
            //Console.Write("Įveskite z reikšmę: ");
            //z = int.Parse(Console.ReadLine());
            //if (z - 1 >= 0)
            //{
            //    fx = Math.Pow(z - 1, 0.5);
            //    Console.WriteLine(" z = {0} f(x) = {1,8:f3}", z, fx);
            //}
            //else
            //    Console.WriteLine("z = {0} f -ka neegzistuoja", z);

            double fxy;
            int x;
            int y;
            Console.Write("Įveskite x reikšmę: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("įveskite y reikšmę: ");
            y = int.Parse(Console.ReadLine());
            if (Math.Pow(x, 3) - y != 0)
            {
                fxy = (Math.Pow(y, 2) - 2 * x * y + Math.Pow(x, 2)) / (Math.Pow(x, 3) - y);
                Console.WriteLine(" f(x,y) = {0,8:f3}", fxy);
            }
            else
                Console.WriteLine("Dalyba iš 0 negalima");
        }
    }
}
