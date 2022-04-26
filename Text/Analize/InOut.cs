using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Analize
{
    class InOut
    {
        internal static void Apdoroti(string fd, string fr, string fa, char[] skyrikliai, string balses)
        {
            string[] lines = File.ReadAllLines(fd, Encoding.UTF8);
            string eilute = new string('-', 38);
            using(var far = File.CreateText(fr))
            {
                using(var faa = File.CreateText(fa))
                {
                    faa.WriteLine(eilute);
                    faa.WriteLine("| Ilgiausias žodis | Pradžia | Ilgis |");
                    faa.WriteLine(eilute);
                    foreach(string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string ilgiaus = TaskUtils.Ilgiausias(line, skyrikliai);
                            string ilgiausBe = TaskUtils.BeBalsiu(ilgiaus, balses).ToString();
                            faa.WriteLine("| {0,-16} | {1, 7:d} | {2, 5:d} |", ilgiaus, line.IndexOf(ilgiaus), ilgiaus.Length);
                            string nauja = line.Replace(ilgiaus, ilgiausBe);
                            far.WriteLine(nauja);
                        }
                        else
                            far.WriteLine(line);
                        faa.WriteLine(eilute);
                    }
                }
            }
        }
    }
}
