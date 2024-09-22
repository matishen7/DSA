using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal static class SlidingWindow
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;

            int l = 0;
            int longest = 0;
            var set = new HashSet<char>();
            for (int r = 0; r < s.Length; r++)
            {
                while (set.Contains(s[r]))
                {
                    set.Remove(s[l]);
                    l++;
                }
                set.Add(s[r]);
                longest = Math.Max(longest, r - l + 1);
            }
            return longest;
        }

        public static int CharacterReplacement(string s, int k)
        {
            var charsCount = new Dictionary<char, int>();
            for (char c = 'A'; c <= 'Z'; c++)
                charsCount.Add(c, (int)c);

            int longest = 0;
            int l = 0;
            int mostFreqCharCount = 0;
            for (int r = 0; r < s.Length; r++)
            {
                charsCount[s[r]]++;
                mostFreqCharCount = Math.Max(mostFreqCharCount, GetMostFrequentCharacterCount(charsCount));
                int lettersToChange = (r - l + 1) - mostFreqCharCount;
                if (lettersToChange > k)
                {
                    charsCount[s[l]]--;
                    l--;
                }
                longest = Math.Max(longest, r- l + 1);
            }
            return longest;
        }

        private static int GetMostFrequentCharacterCount(Dictionary<char, int> map)
        {
            int max = 0;
            foreach (var pair in map)
            {
                int count = pair.Value;
                if (count > max)
                    max = count;
            }
            return max;
        }
    }
}
