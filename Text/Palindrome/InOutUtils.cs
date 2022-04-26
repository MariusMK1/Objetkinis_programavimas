using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Palindrome
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
                    StringBuilder New = new StringBuilder();
                    string[] parts = line.Split(dividers, StringSplitOptions.RemoveEmptyEntries);
                    int palindromeCount = TaskUtils.CountPalindrome(parts);
                    if(palindromeCount > 0)
                    {
                        New.Append(line);
                        New.Append("\n" + insert);
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
