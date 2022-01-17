using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodai
{
    internal class Program
    {
        // primas žingsnis
        static void Main(string[] args)
        {
            char a;
            Console.Write("Nurodykite simbolį:");
            a = char.Parse(Console.ReadLine());
            Console.Clear();
            spausdinti(a);

            int b = 5;
            int c = 15;
            Console.WriteLine("Skaičiai nuo 5 iki 15 ir jų kvadratai ir jų kūbai:");
            for (int i = b; i <= c; i++)
            {
                Console.WriteLine(" {0,3:d}  {1,5:d}  {2,5:d}", i, Kvadratu(i), Kubu(i));
            }

            int x;
            int y;
            Console.Write("Įveskite x reikšmę: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("įveskite y reikšmę: ");
            y = int.Parse(Console.ReadLine());
            if (Math.Pow(x, 3) - y != 0)
            {
                Console.WriteLine(" f(x,y) = {0,8:f3}", fxy(x, y));
            }
            else
                Console.WriteLine("Dalyba iš 0 negalima");
        }
        static void spausdinti(char ch)
        {
            int b;
            int c;
            Console.Write("Nurodykite bendrą simbolių kiekį:");
            b = int.Parse(Console.ReadLine());
            Console.Write("Nurodykite vienos eilutės simbolių kiekį:");
            c = int.Parse(Console.ReadLine());
            for (int i = 1; i <= b; i++)
            {
                if (i % c == 0)
                    Console.WriteLine(ch);
                else
                    Console.Write(ch);
            }

        }

        //antras žingsnis
        static int Kvadratu(int sk1)
        {
            int kvadratu = sk1 * sk1;
            return kvadratu;
        }
        static int Kubu(int sk1)
        {
            int kubu = sk1 * sk1 * sk1;
            return kubu;
        }
        static double fxy(int sk1, int sk2)
        {
            return (Math.Pow(sk2, 2) - 2 * sk1 * sk2 + Math.Pow(sk1, 2)) / (Math.Pow(sk1, 3) - sk2);
        }
    }     
}
