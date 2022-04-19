using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protected
{
    class Lengvaatletis : SportoSaka
    {
        public string Rungtis { get; private set; }
        public double Rekordas { get; private set; }
        public string Matas { get; private set; }
        public Lengvaatletis(string vardas, int amzius, string sspavad, string rungtis, double rekordas, string matas) : base(vardas, amzius, sspavad)
        {
            this.Rungtis = rungtis;
            this.Rekordas = rekordas;
            this.Matas = matas;
        }
        public override string ToString()
        {
            return string.Format("{0} rungtis = {1};\n rekordas = {2, 7:f3} {3};", base.ToString(), Rungtis, Rekordas, Matas);
        }
    }
}
