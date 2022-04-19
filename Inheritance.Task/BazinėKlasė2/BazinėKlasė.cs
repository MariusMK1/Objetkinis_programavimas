using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazinėKlasė2
{
    public class BazinėKlasė
    {
        public int ABaz { get; private set; }
        public double BBaz  { get; private set; }
        public string CBaz { get; private set; }
        public BazinėKlasė(int a = 1, double b = 0.001, string c = "###")
        {
            Console.WriteLine("Dirba bazin4s klas4s konstruktorius.");
            this.ABaz = a;
            this.BBaz = b;
            this.CBaz = c;
        }
        public void Spausdinti()
        {
            Console.WriteLine("{0, 3:d} {1, 12:f5} {2, -10 }", ABaz, BBaz, CBaz);
        }
    }
}
