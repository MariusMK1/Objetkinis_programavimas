using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Eilučių.Redagavimas
{
    class InOut
    {
        internal static void Apdoroti(string fd, string fr, string skyrikliai, string vardas, string pavardė)
        {
            string[] lines = File.ReadAllLines(fd, Encoding.UTF8);
            using (var far = File.CreateText(fr))
            {
                foreach(string line in lines)
                {
                    StringBuilder nauja = new StringBuilder();
                    TaskUtils.Zodziai(line, skyrikliai, vardas, pavardė, nauja);
                    far.WriteLine(nauja);
                }
            }
        }
        internal static void Pašalinti(string fd, string fr, string skyrikliai, string žodis)
        {
            string[] lines = File.ReadAllLines(fd, Encoding.UTF8);
            using (var far = File.CreateText(fr))
            {
                foreach (string line in lines)
                {
                    StringBuilder nauja = new StringBuilder();
                    TaskUtils.Šalina(line, skyrikliai, žodis, nauja);
                    far.WriteLine(nauja);
                }
            }
        }
    }
}
