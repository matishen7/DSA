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

    }
}
