using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazinėKlasė2
{
    public class IšvestinėKLasė : BazinėKlasė
    {
        public int AIsv { get; private set; }
        public string BIsv { get; private set; }
        public IšvestinėKLasė(int aB, double bB, string cB, int aI = 11, string bI = "***") : base(aB, bB, cB)
        {
            this.AIsv = aI;
            this.BIsv = bI;
            Console.WriteLine("Dirba išvestinės klasės konstruktorius");
        }
        public new void Spausdinti()
        {
            Console.WriteLine("{0, 3:d} {1, -10}", AIsv, BIsv);
            base.Spausdinti();
        }
    }
}
