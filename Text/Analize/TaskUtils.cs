using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analize
{
    class TaskUtils
    {
        internal static string Ilgiausias(string eilute, char[] skyrikliai)
        {
            string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            string ilgiaus = "";
            foreach(string zodis in parts)
            {
                if (zodis.Length > ilgiaus.Length)
                {
                    ilgiaus = zodis;
                }
            }
            return ilgiaus;
        }
       internal static StringBuilder BeBalsiu(string eilute, string balses)
        {
            StringBuilder nauja = new StringBuilder();
            for(int i = 0; i < eilute.Length; i++)
            {
                if(balses.IndexOf(eilute[i]) == -1)
                {
                    nauja.Append(eilute[i]);
                }
            }
            return nauja;
        }
    }
}
