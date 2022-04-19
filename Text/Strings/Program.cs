using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] simboliai = { 'V', 'y', 'k', 's', 't', 'a', ' ', 'p', 'a', 's', 'k', 'a', 'i', 't', 'a'};
            string eil = "sveiki!";
            string eil1 = eil;
            string eil2 = new string(simboliai);
            string eil3 = new string(simboliai, 7, 8);
            string eil4 = new string('-', 15);
            Console.WriteLine(eil);
            Console.WriteLine(eil1);
            Console.WriteLine(eil2);
            Console.WriteLine(eil3);
            Console.WriteLine(eil4);
            string eil5;
            eil5 = "" + simboliai[0];
            Console.WriteLine(eil5);
            eil5 = "" + '5';
            Console.WriteLine(eil5);
            eil = eil + " " + eil1 + " " + eil2;
            Console.WriteLine(eil);
            char simb6 = eil5[0];
        }
    }
}
