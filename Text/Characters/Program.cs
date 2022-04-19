using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] simboliai = new char[5];
            simboliai[0] = 'L';
            simboliai[1] = 'a';
            simboliai[2] = 'b';
            simboliai[3] = 'a';
            simboliai[4] = 's';
            foreach (char c in simboliai)
                Console.Write(c + " ");
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
                Console.Write(simboliai [i] + " ");
            Console.WriteLine();

            Char.IsLower(simboliai[0]);
            char.ToLower(simboliai[0]);
            Console.WriteLine(char.ToLower(simboliai[0]));

            Console.Write("Įveskite simbolį : ");
            char sim = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Ar skaičius?: {0}", Char.IsDigit(sim));
            Console.WriteLine("Raidė ar skaičius?: {0}", Char.IsLetterOrDigit(sim));
        }
    }
}
