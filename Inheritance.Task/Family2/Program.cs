using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mama mama = new Mama("Aldona", "Adams", 50);
            Asmuo sunus1 = mama.Naujagimis("Jonas", 12);
            Asmuo dukra1 = mama.Naujagimis("Rasa", 15);
            Asmuo sunus2 = mama.Naujagimis("Titas", 19);
            Console.WriteLine("Mama:\n{0}", mama.ToString());

            Console.WriteLine();
            Console.WriteLine("Vaikai:");
            foreach (Asmuo vaikas in mama)
                Console.WriteLine(vaikas.Vardas);
        }
    }
}
