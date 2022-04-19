using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazinėKlasė
{
    public class BazinėKlasė : object
    {
        public string eiluteBaz { get; set; }
        public BazinėKlasė()
        {
            Console.WriteLine("Dirba bazinės klasės konstruktorius.");
        }
        public BazinėKlasė(string eilute)
        {
            Console.WriteLine("Dirba bazinės klasės konstruktorius.");
            eiluteBaz = eilute;
        }
        public void Spausdinti()
        {
            Console.WriteLine("Dirba bazinės klasės metodas Spausdinti().");
            Console.WriteLine("{0}", eiluteBaz);
        }
    }
}
