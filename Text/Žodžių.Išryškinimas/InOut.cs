using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Žodžių.Išryškinimas
{
    class InOut
    {
        internal static int Apdoroti (string fv, char[] skyrikliai)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            int sutampa = 0;
            foreach(string line in lines)
            {
                if (line.Length > 0)
                {
                    sutampa += TaskUtils.Zodziai(line, skyrikliai);
                }
            }
            return sutampa;
        }
    }
}
