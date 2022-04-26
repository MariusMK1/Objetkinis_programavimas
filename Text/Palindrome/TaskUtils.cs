using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    internal class TaskUtils
    {
        internal static int CountPalindrome(string[] parts)
        {
            int sum = 0;
            foreach(string word in parts)
            {
                for (int i = 0; i < word.Length / 2; i++)
                {
                    if (word[i] == word[word.Length - (i + 1)])
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
    }
}
