using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class DP1DimensionProblems
    {
        public static int CountSubstrings(string s)
        {
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                //odd
                int l = i, r = i;

                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    count++;
                    l--;
                    r++;
                }

                //even
                l = i;  r = i + 1;

                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    count++;
                    l--;
                    r++;
                }
            }

            return count;
        }

        public static int LengthOfLIS(int[] nums)
        {
            var memo = new Dictionary<(int, int, int), int>();
            var r = LengthOfLISHelperMemo(0, 0, -1002, nums, memo);
            return r;
        }

        public static int LengthOfLISHelper(int i, int count, int previous, int[] nums)
        {
            if (i == nums.Length) return count;

            int skip = LengthOfLISHelper(i + 1, count, previous, nums);

            int include = 0;

            if (previous < nums[i])
                include = LengthOfLISHelper(i + 1, count + 1, nums[i], nums);

            return Math.Max(include, skip);
        }

        public static int LengthOfLISHelperMemo(int i, int count, int previous, int[] nums, Dictionary<(int, int, int),int> memo)
        {
            if (i == nums.Length) return count;

            if (memo.ContainsKey((i, count, previous))) return memo[(i, count, previous)];

            int skip = LengthOfLISHelperMemo(i + 1, count, previous, nums, memo);

            int include = 0;

            if (previous < nums[i])
                include = LengthOfLISHelperMemo(i + 1, count + 1, nums[i], nums, memo);

            memo[(i,count,previous)] = Math.Max(include, skip);
            return memo[(i, count, previous)];
        }
    }
}
