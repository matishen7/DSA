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
            int [] result = new int[2];
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
            result[0] = left ;
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

        }
    }
}
