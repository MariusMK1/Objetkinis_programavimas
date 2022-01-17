using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skaiciuotuvas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a;
            char b;
            double c;
            double result;
            Console.WriteLine("Įveskite pirmajį skaičių: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite matematinės operacijos simbolį:");
            b = char.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite antrajį skaičių: ");
            c = double.Parse(Console.ReadLine());
                if (b == '+')
                {
                    result = a + c;
                    Console.WriteLine("Atsakymas = {0,8:f3}", result);
                }
                else
                    if (b == '-')
                {
                    result = a - c;
                    Console.WriteLine("Atsakymas = {0,8:f3}", result);
                }
                else
                    if (b == '*')
                {
                    result = a * c;
                    Console.WriteLine("Atsakymas = {0,8:f3}", result);
                }
                else
                    if (b == '/')
                    {
                        if (c != 0)
                        {
                        result = a / c;
                        Console.WriteLine("Atsakymas = {0,8:f3}", result);
                        }
                        else
                            Console.WriteLine("Dalyba iš 0 negalima");
            }
                else
                    Console.WriteLine("ERROR");
           
        }
    }
}
