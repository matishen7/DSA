using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class Greedy
    {
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            int max = nums[0];
            int temp = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {

                if (i == 0) max = nums[i];
                else
                {
                    temp = temp + nums[i];
                    if (temp < nums[i])
                    {
                        temp = nums[i];
                        max = Math.Max(max, temp);
                    }
                    max = Math.Max(max, Math.Max(temp, nums[i]));
                }

            }
            return max;
        }
        public static int MaxSubArray2(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            int max = nums[0];
            int temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {

                if (temp < 0) temp = 0;

                temp += nums[i];

                max = Math.Max(temp, max);

            }
            return max;
        }
        public static bool CanJump(int[] nums)
        {
            var memo = new Dictionary<int, bool>();
            return CanJumpHelper(0, nums, memo);
        }

        public static bool CanJumpHelper(int i, int[] nums, Dictionary<int, bool> memo)
        {
            if (i >= nums.Length - 1) return true;

            if (nums[i] == 0) return false;

            if (memo.ContainsKey(i)) return memo[i];

            int steps = nums[i];

            memo[i] = false;
            for (int j = 1; j <= steps; j++)
                if (CanJumpHelper(i + j, nums, memo)) memo[i] = true;
            return memo[i];
        }

        public static int Jump(int[] nums)
        {
            return JumpHelper(0, 0, nums);
        }

        public static int JumpHelper(int i, int count, int[] nums)
        {
            if (i >= nums.Length - 1) return count;

            int steps = nums[i];
            int min = int.MaxValue;
            for (int j = 1; j <= steps; j++)
                min = Math.Min(min, JumpHelper(i + j, count + 1, nums));
            return min;
        }

        public static int Jump2(int[] nums)
        {
            var memo = new Dictionary<(int, int),int>();
            return JumpHelperMemo(0, 0, nums,memo);
        }

        public static int JumpHelperMemo(int i, int count, int[] nums, Dictionary<(int, int),int> memo)
        {
            if (i >= nums.Length - 1) return count;
            if (memo.ContainsKey((i,count))) return memo[(i,count)];
            int steps = nums[i];
            int min = int.MaxValue;

            for (int j = 1; j <= steps; j++)
            {
                min = Math.Min(min, JumpHelperMemo(i + j, count + 1, nums, memo));
            }
            memo[(i,count)] = min;
            return memo[(i,count)];
        }
    }
}
