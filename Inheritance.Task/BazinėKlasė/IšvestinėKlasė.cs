using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazinėKlasė
{
    public class IšvestinėKlasė : BazinėKlasė
    {
        public int skaiciusIsvesti { get; private set; }
        public IšvestinėKlasė()
        {
            Console.WriteLine("Dirba išvestinės klasės konstruktorius.");
            Console.WriteLine(" Jis kreipiasi į bazinės klasės konstruktorių base().");
        }
        public IšvestinėKlasė(string eil, int skaicius) : base(eil)
        {
            skaiciusIsvesti = skaicius;
            Console.WriteLine("Dirba išvestinės klasės konstruktorius.");
            Console.WriteLine(" Jis kreipiasi į bazinės klasės konstruktorių.");
        }
            public void Spausdinti()
        {
            Console.WriteLine("Dirba išvestinės klasės metodas Spausdinti().");
            Console.WriteLine(eiluteBaz);
            Console.WriteLine(" Jis kreipiasi į baz. klasės metodą Spausdint()");
            base.Spausdinti();
            Console.WriteLine("{0}", skaiciusIsvesti);
        }
    }
}
