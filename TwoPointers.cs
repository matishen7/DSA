using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal static class TwoPointers
    {
        public static bool IsPalindrome(string s)
        {

            if (s.Length == 0) return true;
            else if (s.Length == 1) return true;
            HashSet<char> alphanumericChars = new HashSet<char>
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
                if (alphanumericChars.Contains(s[i])) sb.Append(s[i]);
            int left = 0;
            int right = sb.Length - 1;
            var ss = sb.ToString().ToLower();
            while (left < right)
            {
                if (ss[left] != ss[right]) return false;
                left++;
                right--;
            }
            return true;
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];
            int left = 0;
            int right = numbers.Length - 1;
            int diff1 = target - numbers[left];
            int diff2 = target - numbers[right];
            while (diff1 + diff2 != target)
            {
                if (diff1 + diff2 > target) left++;
                else right--;
                diff1 = target - numbers[left];
                diff2 = target - numbers[right];
            }
            result[0] = left + 1;
            result[1] = right + 1;
            return result;
        }
        //public static List<List<int>> ThreeSum(int[] nums)
        //{
        //    Array.Sort(nums);
        //    var dups = new HashSet<int>();
        //    for (int i = 0; i < nums.Length - 1; i++)
        //    {
        //        var list = new List<int>();
        //        if (!dups.Contains(nums[i]))
        //        {
        //            var left = i + 1;
        //            var right = nums.Length - 1;
        //            var target = 0 - nums[i];
        //            var twoSum = GetTwoSum(nums, left, right, target);
        //            dups.Add(nums[i]);
        //        }
        //        else
        //        {
        //            i++;
        //        }
        //    }
        //}

        public static int[] GetTwoSum(int[] numbers, int left, int right, int target)
        {
            int[] result = new int[2];
            int diff1 = target - numbers[left];
            int diff2 = target - numbers[right];
            while (diff1 + diff2 != target)
            {
                if (diff1 + diff2 > target) left++;
                else right--;
                diff1 = target - numbers[left];
                diff2 = target - numbers[right];
            }
            result[0] = left;
            result[1] = right;
            return result;
        }

        public static int MaxArea(int[] heights)
        {
            int max = 0;
            int left = 0;
            int right = heights.Length - 1;
            while (left < right)
            {
                var currentArea = Math.Min(heights[left], heights[right]) * Math.Abs(left - right);
                if (currentArea > max) max = currentArea;
                if (heights[left] < heights[right]) left++;
                else right--;
            }
            return max;
        }

        public static int Trap(int[] height)
        {
            int[] maxLeft = new int[height.Length];
            int[] maxRight = new int[height.Length];
            int[] minLR = new int[height.Length];
            int max = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (i == 0) continue; 
                max = Math.Max(max, height[i - 1]);
                maxLeft[i] = max;
            }

            max = 0;
            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (i == height.Length - 1) continue;
                max = Math.Max(max, height[i + 1 ]);
                maxRight[i] = max;
            }

            for (int i = 0; i < minLR.Length; i++)
                minLR[i] = Math.Min(maxLeft[i], maxRight[i]);

            int waterSum = 0;
            for (int i = 0; i < minLR.Length; i++)
            {
                int water = minLR[i] - height[i];
                if (water > 0) waterSum += water; 
            }

            return waterSum;
        }

        public static int MaxProfit(int[] prices)
        {
            int result = 0;
            int[] minArr = new int[prices.Length];
            int[] maxArr = new int[prices.Length];
            int min = prices[0];
            minArr[0] = min;
            for (int i = 1; i < prices.Length; i++) 
            {
                min = Math.Min(min, prices[i]);
                minArr[i] = min;
            }

            int max = prices[prices.Length - 1];
            maxArr[prices.Length - 1] = max;
            for (int i = prices.Length - 2; i >= 0; i--)
            {
                max = Math.Max(max, prices[i]);
                maxArr[i] = max;
            }

            for (int i = 0; i < maxArr.Length;i++)
            {
                int profit = maxArr[i] - minArr[i];
                if (profit > result) result = profit;
            }

            return result;
        }
    }
}
