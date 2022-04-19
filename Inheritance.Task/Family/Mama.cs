using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family
{
    internal class Mama : Asmuo
    {
        const int CMax = 10;
        private Asmuo[] Vaikai;
        public int Kiek { get; private set; }
        public Mama() : base()
        {
            Vaikai = new Asmuo[CMax];
            Kiek = 0;
        }
        public Mama(string mamosVardas, string mamosPavardė) : base(mamosVardas, mamosPavardė)
        {
            Vaikai = new Asmuo[CMax];
            Kiek = 0;
        }
        public Asmuo Naujagimis(string vardas)
        {
            Vaikai[Kiek++] = new Asmuo(Vardas, Pavardė);
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
    }
}
