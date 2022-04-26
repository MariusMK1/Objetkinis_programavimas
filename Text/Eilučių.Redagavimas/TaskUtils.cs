using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eilučių.Redagavimas
{
    class TaskUtils
    {
        internal static void Zodziai(string line, string skyrikliai, string vardas, string pavardė, StringBuilder nauja)
        {
            string papild = " " + line + " ";
            int prad = 1;
            int ind = papild.IndexOf(vardas);
            while (ind != -1)
            {
                if (skyrikliai.IndexOf(papild[ind - 1]) != -1 && skyrikliai.IndexOf(papild[ind + vardas.Length]) != -1)
                {
                    nauja.Append(papild.Substring(prad, ind + vardas.Length - prad));
                    nauja.Append(" " + pavardė);
                    prad = ind + vardas.Length;
                }
                ind = papild.IndexOf(vardas, ind + 1);
            }
            nauja.Append(line.Substring(prad - 1));
        }
        internal static void Šalina(string line, string skyrikliai, string žodis, StringBuilder nauja)
        {
            string papild = " " + line + " ";
            int prad = 1;
            int ind = papild.IndexOf(žodis);
            while (ind != -1)
            {
                if (skyrikliai.IndexOf(papild[ind - 1]) != -1 && skyrikliai.IndexOf(papild[ind + žodis.Length]) != -1)
                {
                    nauja.Remove(ind, žodis.Length);
                }
                ind = papild.IndexOf(žodis, ind + 1);
            }
            nauja.Append(line.Substring(prad - 1));
        }
    }
}
