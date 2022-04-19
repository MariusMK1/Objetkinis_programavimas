using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override
{
    public class Auto : object
    {
        public int Metai { get; private set; }
        public int Rida { get; private set; }
        public Auto(int metai = 2016, int rida = 0)
        {
            this.Metai = metai;
            this.Rida = rida;
        }
        public override string ToString()
        {
            return string.Format(" pagaminimo metai = {0, 4:d}; rida = {1, 7:d} km;", Metai, Rida);
        }
    }
}
