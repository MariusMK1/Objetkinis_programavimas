using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Family2
{
    class Mama : Asmuo, IEnumerable
    {
        const int CMax = 10;
        private Asmuo[] Vaikai;
        public int Kiek { get; private set; }
        public Mama() : base()
        {
            Vaikai = new Asmuo[CMax];
            Kiek = 0;
        }
        public Mama(string mamosVardas, string mamosPavardė, int mamosAmžius) : base(mamosVardas, mamosPavardė, mamosAmžius)
        {
            Vaikai = new Asmuo[CMax];
            Kiek = 0;
        }
        public Asmuo Naujagimis(string vardas, int amžius)
        {
            Vaikai[Kiek++] = new Asmuo(Vardas, Pavardė, amžius);
            return Vaikai[Kiek - 1];
        }
        public override string ToString()
        {
            string eil = string.Format("{0}\n", base.ToString());
            eil = eil + "Ir jos vaikai:\n";
            for (int i = 0; i < Kiek; i++)
                eil = eil + Vaikai[i].ToString() + "\n";
            return eil;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Kiek; i++)
            {
                yield return Vaikai[i];
            }
        }
    }
}
