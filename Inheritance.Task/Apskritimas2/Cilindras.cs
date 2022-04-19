using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apskritimas2
{
    class Cilindras : Apskritimas
    {
        public double Aukstine { get; private set; }
        public Cilindras() : base()
        {
            Aukstine = 1;
        }
        public Cilindras(double r, double h = 1) : base(r)
        {
            Aukstine = h;
        }
        public double Turis()
        {
            return Plotas() * Aukstine;
        }
        public override string ToString()
        {
            return string.Format("{0} aukštinė = {1, 6:f2}", base.ToString(), Aukstine);
        }
    }
}
