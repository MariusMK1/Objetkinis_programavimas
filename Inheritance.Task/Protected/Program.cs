using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protected
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lengvaatletis Lengv = new Lengvaatletis("Greta Greitoji", 21, "Lengvoji atletika", "100 metrų begimas", 9.99, "s");
            Console.WriteLine("Sportininkė:\n{0}", Lengv.ToString());
            Krepsininkas Kreps = new Krepsininkas("Tomas Taiklusis", 19, "Krepšinis", "Centras", 211);
            Console.WriteLine("Sportininkas:\n{0}", Kreps.ToString());
        }
    }
}
