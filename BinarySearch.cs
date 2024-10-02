using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class BinarySearch
    {
        public static int Search(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;

            while (l <= r)
            {
                int m = l + ((r - l) / 2);
                if (nums[m] > target)
                {
                    r = m - 1;
                }
                else if (nums[m] < target)
                {
                    l = m + 1;
                }
                else
                {
                    return m;
                }
            }
            return -1;
        }

        public static bool SearchMatrix(int[][] matrix, int target)
        {
            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] <= target && target <= matrix[i][matrix[i].Length - 1])
                {
                    index = i; break;
                }
            }

            int[] possibleMatrix = matrix[index];

            int result = Search(possibleMatrix, target);
            return result != -1 ? true : false;
        }

        //public static int MinEatingSpeed(int[] piles, int h)
        //{

        //}
    }
}
