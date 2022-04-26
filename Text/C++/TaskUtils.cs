using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__
{
    class TaskUtils
    {
        internal static bool BeKomentaru(string line, out string nauja)
        {
            nauja = line;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '/')
                {
                    nauja = line.Remove(i);
                    return true;
                }
            }
            return false;
        }
    }
}
