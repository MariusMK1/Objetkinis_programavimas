using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protected
{
    class Asmuo : object
    {
        protected string Vardas { get; private set; }
        protected int Amzius { get; private set; }
        public Asmuo (string vardas, int amzius) : base()
        {
            Vardas = vardas;
            Amzius = amzius;
        }
        public override string ToString()
        {
            return string.Format(" Vardas = {0};\n amžius = {1, 2:d};\n", Vardas, Amzius);
        }

    }
}
