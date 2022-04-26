using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capital.Letters
{
    internal class InOutUtils
    {
        internal static void ReadAndWrite(string fd, string fr, char[] dividers)
        {
            string[] lines = File.ReadAllLines(fd, Encoding.UTF8);
            using (var far = File.CreateText(fr))
            {
                foreach (string line in lines)
                {
                    StringBuilder New = new StringBuilder();
                    int maxLength = 0;
                    string correctWord = string.Empty;
                    int index = TaskUtils.LongestWithCapital(line, dividers, out maxLength, out correctWord);
                    string[] parts = line.Split(dividers, StringSplitOptions.RemoveEmptyEntries);
                    if (maxLength > 0 && index != 0)
                    {
                        New.Append(line);
                        New.Remove(index, maxLength);
                        New.Insert(0, correctWord + " ");
                        far.WriteLine(New);
                    }
                    else
                    {
                        New.Append(line);
                        far.WriteLine(New);
                    }
                }

            }
        }
    }
}
