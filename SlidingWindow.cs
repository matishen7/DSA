using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public static class SlidingWindow
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

        //public static int CharacterReplacement(string s, int k)
        //{
        //    var charsCount = new Dictionary<char, int>();
        //    for (char c = 'A'; c <= 'Z'; c++)
        //        charsCount.Add(c, (int)c);

        //    int longest = 0;
        //    int l = 0;
        //    int mostFreqCharCount = 0;
        //    for (int r = 0; r < s.Length; r++)
        //    {
        //        charsCount[s[r]]++;
        //        mostFreqCharCount = Math.Max(mostFreqCharCount, GetMostFrequentCharacterCount(charsCount));
        //        int lettersToChange = (r - l + 1) - mostFreqCharCount;
        //        if (lettersToChange > k)
        //        {
        //            charsCount[s[l]]--;
        //            l--;
        //        }
        //        longest = Math.Max(longest, r- l + 1);
        //    }
        //    return longest;
        //}

        public static bool CheckInclusion(string s1, string s2)
        {
            int[] freq1 = new int[26];
            int[] freq2 = new int[26];

            for (int i = 0; i < s1.Length; i++)
                freq1[s1[i] - 'a']++;

            for (int i = 0; i < s1.Length; i++)
                freq2[s2[i] - 'a']++;


            int matches = 0;
            int left = 0;
            while (left + s1.Length <= s2.Length)
            {
                matches = 0;
                for (int i = 0; i < freq1.Length; i++)
                    if (freq1[i] == freq2[i]) ++matches;

                if (matches == 26) return true;
                freq2[s2[left] - 'a']--;
                freq2[s2[left + s1.Length] - 'a']++;

                left += 1;

            }
            if (matches == 26) return true;
            return false;

        }
        public static string MinWindow(string s, string t)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char x in t.ToCharArray())
            {
                if (map.ContainsKey(x))
                {
                    map[x]++;
                }
                else
                {
                    map.Add(x, 1);
                }
            }

            int matched = 0, start = 0, minLen = s.Length + 1, subStr = 0;
            for (int endWindow = 0; endWindow < s.Length; endWindow++)
            {
                char right = s[endWindow];
                if (map.ContainsKey(right))
                {
                    map[right]--;
                    if (map[right] == 0) matched++;
                }

                while (matched == map.Count)
                {
                    if (minLen > endWindow - start + 1)
                    {
                        minLen = endWindow - start + 1;
                        subStr = start;
                    }
                    char deleted = s[start++];
                    if (map.ContainsKey(deleted))
                    {
                        if (map[deleted] == 0) matched--;
                        map[deleted]++;
                    }
                }
            }
            return minLen > s.Length ? "" : s.Substring(subStr, minLen);
        }

        private static bool CheckStringIncludesAllChars(string str, Dictionary<char, int> map)
        {
            var dic2 = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!dic2.ContainsKey(str[i]))
                    dic2.Add(str[i], 1);
                else dic2[str[i]]++;
            }

            foreach (var pair in map)
            {
                char cc = pair.Key;
                int count = pair.Value;
                if (dic2.ContainsKey(cc))
                {
                    int count2 = dic2[cc];
                    if (count2 < count) return false;
                }
                else return false;
            }
            return true;
        }
    }
}
