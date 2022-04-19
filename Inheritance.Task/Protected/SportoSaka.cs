using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protected
{
    class SportoSaka : Asmuo
    {
        public string SSPavadinimas { get; private set; }
        public SportoSaka(string vardas, int amzius, string sspavad) : base(vardas, amzius)
        {
            SSPavadinimas = sspavad;
        }
        public override string ToString()
        {
            return string.Format("{0} sporto šaka = {1};\n", base.ToString(), SSPavadinimas);
        }
    }
}
