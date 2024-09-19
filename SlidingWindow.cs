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
                longest = Math.Max(longest, r - l + 1 );
            }
            return longest;
        }
    }
}
