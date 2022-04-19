using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apskritimas
{
    class Apskritimas : object
    {
        public double Spindulys { get; private set; }
        public Apskritimas()
        {
            Spindulys = 1;
        }
        public Apskritimas (double r)
        {
            Spindulys = r;
        }
        public double Plotas()
        {
            return Math.PI * Spindulys * Spindulys;
        }
        public override string ToString()
        {
            return string.Format(" spindulys = {0, 6:f2}", Spindulys);
        }
    }
}
