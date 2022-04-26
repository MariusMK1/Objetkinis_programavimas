using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C__
{
    class InOut
    {
        internal static void Apdoroti(string fv, string fvr, string fa)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            using (var fr = File.CreateText(fvr))
            {
                using(var far = File.CreateText(fa))
                {
                    foreach(string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string nauja = line;
                            if (TaskUtils.BeKomentaru(line, out nauja))
                                far.WriteLine(line);
                            if (nauja.Length > 0) 
                                fr.WriteLine(nauja);
                        }
                        else
                            fr.WriteLine(line);
                    }    
                }
            }
        }
    }
}
