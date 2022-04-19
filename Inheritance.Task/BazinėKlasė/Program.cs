using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazinėKlasė
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IšvestinėKlasė objIšvKlasės = new IšvestinėKlasė("DUOMENYS", 99999);
            objIšvKlasės.Spausdinti();
            IšvestinėKlasė objIšvKlasės1 = new IšvestinėKlasė();
            objIšvKlasės1.Spausdinti();
        }
    }
}
