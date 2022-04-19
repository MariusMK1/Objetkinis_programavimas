using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazinėKlasė2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BazinėKlasė objBaz1 = new BazinėKlasė();
            objBaz1.Spausdinti();
            BazinėKlasė objBaz2 = new BazinėKlasė(200, 2.1, "@@@");
            objBaz2.Spausdinti();
            BazinėKlasė objBaz3 = new BazinėKlasė(300, 3.1);
            objBaz3.Spausdinti();
            BazinėKlasė objBaz4 = new BazinėKlasė(400);
            objBaz4.Spausdinti();
            IšvestinėKLasė objIsv1 = new IšvestinėKLasė(100, 1.1, "-----");
            objIsv1.Spausdinti();
            IšvestinėKLasė objIsv2 = new IšvestinėKLasė(100, 1.1, "-----", 200, "+++++");
            objIsv2.Spausdinti();
        }
    }
}
