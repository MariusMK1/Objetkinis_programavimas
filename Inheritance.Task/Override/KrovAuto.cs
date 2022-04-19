using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override
{
    public class KrovAuto : Auto
    {
        public string Modelis { get; private set; }
        public double KGalia { get; private set; }
        public KrovAuto(int metai, int rida, string modelis, double galia) :base(metai, rida)
        {
            this.Modelis = modelis;
            this.KGalia = galia;
        }
        public static bool operator > (KrovAuto pirmas, KrovAuto antras)
        {
            return pirmas.Metai > antras.Metai || pirmas.Metai == antras.Metai && pirmas.KGalia > antras.KGalia;
        }
        public static bool operator <(KrovAuto pirmas, KrovAuto antras)
        {
            return pirmas.Metai < antras.Metai || pirmas.Metai == antras.Metai && pirmas.KGalia < antras.KGalia;
        }
        public override string ToString()
        {
            return string.Format(" modelis: {0}; kel. galia = {1, 6:f2}; \n{2}", Modelis, KGalia, base.ToString());
        }
    }
}
