using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protected
{
    internal class Krepsininkas : SportoSaka
    {
        public string Pozicija { get; set; }
        public int Ugis { get; set; }
        public Krepsininkas(string vardas, int amzius, string sspavad, string pozicija, int ugis) : base(vardas, amzius, sspavad)
        {
            this.Pozicija = pozicija;
            this.Ugis = ugis;
        }
        public override string ToString()
        {
            return string.Format("{0} rungtis = {1};\n ugis = {2, 2:3d};", base.ToString(), Pozicija, Ugis);
        }
    }
}
