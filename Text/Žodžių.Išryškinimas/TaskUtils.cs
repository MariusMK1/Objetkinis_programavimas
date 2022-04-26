using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Žodžių.Išryškinimas
{
    class TaskUtils
    {
        internal static int Zodziai (string eilute, char[] skyrikliai)
        {
            string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            int sutampa = 0;
            foreach (string zodis in parts)
            {
                if ((zodis[0]) == Char.ToUpper(zodis[zodis.Length - 1]))
                {
                    sutampa++;
                }
            }
            return sutampa;
        }
        internal static int Zodziai2(string eilute, char[] skyrikliai)
        {
            string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            int sutampa = 0, n = 0;
            foreach (string zodis in parts)
            {
                for (int i = 0; i < zodis.Length / 2; i++)
                {
                    if (zodis[i] == zodis[zodis.Length - (i + 1)])
                    {
                        n++;
                    }
                    if (n == zodis.Length / 2) sutampa++;
                }
                n = 0;
            }

            return sutampa;
        }
    }
}
