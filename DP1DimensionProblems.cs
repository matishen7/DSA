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
                l = i; r = i + 1;

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

        public static int LengthOfLISHelperMemo(int i, int count, int previous, int[] nums, Dictionary<(int, int, int), int> memo)
        {
            if (i == nums.Length) return count;

            if (memo.ContainsKey((i, count, previous))) return memo[(i, count, previous)];

            int skip = LengthOfLISHelperMemo(i + 1, count, previous, nums, memo);

            int include = 0;

            if (previous < nums[i])
                include = LengthOfLISHelperMemo(i + 1, count + 1, nums[i], nums, memo);

            memo[(i, count, previous)] = Math.Max(include, skip);
            return memo[(i, count, previous)];
        }

        public static int MaxProduct(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            int maxProduct = int.MinValue;
            int max = 1;
            int min = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    max = 1;
                    min = 1;
                }

                else
                {
                    max = max * nums[i];
                    min = min * -nums[i];
                }
                maxProduct = Math.Max(min, Math.Max(max, nums[i]));

            }
            return maxProduct;
        }


        public static int MaxProductBruteForce(int[] nums)
        {
            int max = nums[0];
            if (nums.Length == 1) return nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                int max2 = nums[i];
                int product = 1;
                for (int j = i; j < nums.Length; j++)
                {
                    product *= nums[j];
                    max2 = Math.Max(max2, product);
                }
                max = Math.Max(max, max2);
            }

            return max;
        }

        public static int NumDecodings(string s)
        {
            var list = new List<string>();
            NumDecodingsHelper(0, s, list);
            return 0;
        }

        public static void NumDecodingsHelper(int i, string s, List<string> list)
        {
            if (i == s.Length)
            {
                list.Add(s);
                return;
            }

            //skip
            NumDecodingsHelper(i + 1, s, list);

            //include
            var sb = new StringBuilder(s);
            sb.Insert(i, ',');
            NumDecodingsHelper(i + 1, sb.ToString(), list);

        }


    }
}
