using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Even.Number.Of.Characters
{
    internal class InOutUtils
    {
        internal static void ReadAndWrite(string fd, string fr, char[] dividers, string insert)
        {
            string[] lines = File.ReadAllLines(fd, Encoding.UTF8);
            using (var far = File.CreateText(fr))
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(dividers, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in parts)
                    {
                        StringBuilder New = new StringBuilder();
                        if (word.Length % 2 == 0)
                        {
                            New.Append(word + insert + " ");
                            far.Write(New);
                        }
                        else
                        {
                            New.Append(word + " ");
                            far.Write(New);
                        }
                    }
                    far.WriteLine();
                }
            }
        }
    }
}
