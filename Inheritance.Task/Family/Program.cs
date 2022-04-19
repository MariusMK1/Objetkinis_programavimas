using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mama mama = new Mama("Aldona", "Adams");
            Asmuo sunus1 = mama.Naujagimis("Jonas");
            Asmuo dukra1 = mama.Naujagimis("Rasa");
            Asmuo sunus2 = mama.Naujagimis("Titas");
            Console.WriteLine("Mama:\n{0}", mama.ToString());
        }
    }
}
