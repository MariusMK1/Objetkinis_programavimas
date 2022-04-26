using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters
{
    class RaidziuDazniai
    {
        private const int CMax = 256;
        private int[] Rn; // Raidžių pasikartojimai
        public string eil { get; set; }
        public RaidziuDazniai()
        {
            eil = "";
            Rn = new int[CMax];
            for (int i = 0; i < CMax; i++)
                Rn[i] = 0;
        }
        public int Imti (char sim)
        {
            return Rn[sim];
        }
        public void kiek()
        {
            for (int i = 0; i < eil.Length; i++)
            {
                if (('a' <= eil[i] && eil[i] <= 'z') || ('A' <= eil[i] && eil[i] <= 'Z'))
                    Rn[eil[i]]++;
            }
        }
        public int max(out char Raidė)
        {
            int max = int.MinValue;
            char raidė = char.MinValue;
            for (char sim = 'a'; sim <= 'z'; sim++)
            {
                if(max < Imti(sim))
                {
                    max = Imti(sim);
                    raidė = sim;
                }
            }
            for (char sim = 'A'; sim <= 'Z'; sim++)
            {
                if (max < Imti(sim))
                {
                    max = Imti(sim);
                    raidė = sim;
                }
            }
            Raidė = raidė;
            return max;
        }
    }
}
