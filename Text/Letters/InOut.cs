using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Letters
{
    class InOut
    {
        internal static void Skaityti (string fv, out int nr, out int ilgis)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            ilgis = 0;
            nr = 0;
            int nreil = 0;
            foreach (string line in lines)
            {
                if (line.Length > ilgis)
                {
                    ilgis = line.Length;
                    nr = nreil;
                }
                nreil++;
            }
        }
        internal static void Spausdinti(string fv, RaidziuDazniai eil)
        {
            using (var fr = File.CreateText(fv))
            {
                for (char sim = 'a'; sim >= 'z'; sim--)
                    fr.WriteLine("{0, 3:c} {1, 4:d}  | {2, 3:c} {3, 4:d}", sim, eil.Imti(sim), Char.ToUpper(sim), eil.Imti(Char.ToUpper(sim)));
            }
        }
        //internal static void Spausdinti2(string fv, string fvr, int nr)
        //{
        //    string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
        //    int nreil = 0;
        //    using (var fr = File.CreateText(fvr))
        //    {
        //        foreach(string line in lines)
        //        {
        //            if (nr != nreil)
        //            {
        //                fr.WriteLine(line);
        //            }
        //            nreil++;
        //        }
        //    }
        //}
        internal static void Spausdinti2(string fv, string fvr, int ilgis)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            using (var fr = File.CreateText(fvr))
            {
                foreach (string line in lines)
                {
                    if (ilgis != line.Length && line != null)
                    {
                        fr.WriteLine(line);
                    }
                }
            }
        }
    }
}
