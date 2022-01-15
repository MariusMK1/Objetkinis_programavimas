using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciklas
{
    internal class Programa
    {
        static void Main(string[] args)
        {
            // 1 žingsnis
            Console.WriteLine("Skaičiai nuo 1 iki 10 ir jų kvadratai:");
            for (int i = 1; i <= 10; i++)
                Console.WriteLine(" {0,3:d}  {1,5:d}",i, i * i);
            // 2 - 5 žingsniai
            int a = 5;
            int b = 15;
            int j = 0;
            Console.WriteLine("Skaičiai nuo 5 iki 15 ir jų kvadratai ir jų kūbai:");
            for (int i = a; i <= b; i++)
            {
                j++;
                Console.WriteLine(" {0,3:d}  {1,5:d}  {2,5:d}  {3}{4,2:d}", i, i * i, i * i * i, " buvo skaičiuota = ", j);
            }
            // 6 žingsnis
            int c;
            int d;
            int k = 0;
            Console.Write("Įveskite intervalo pradžią:");
            c = int.Parse(Console.ReadLine());
            Console.Write("Įveskite intervalo pabaigą:");
            d = int.Parse(Console.ReadLine());
            Console.WriteLine("Skaičiai nuo {0}  iki {1} ir jų kvadratai ir jų kūbai:", c, d);
            for (int i = c; i <= d; i++)
            {
                k++;
                Console.WriteLine(" {0,3:d}  {1,5:d}  {2,5:d}  {3}{4,2:d}", i, i * i, i * i * i, " buvo skaičiuota = ", k);
            }
        }
    }
}
