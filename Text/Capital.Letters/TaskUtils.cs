using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Letters
{
    internal class TaskUtils
    {
        // finds longest word that starts with a captial letter in line
        internal static int LongestWithCapital(string line, char[] dividers, out int maxLength, out string correctWord)
        {
            string[] parts = line.Split(dividers, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            correctWord = string.Empty;
            maxLength = 0;
            foreach (string word in parts)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (Char.IsUpper(word[0]) && word.Length >= maxLength)
                    {
                        maxLength = word.Length;
                        index = line.IndexOf(word);
                        correctWord = word;
                    }
                }
            }
            return index;
        }
    }
}
