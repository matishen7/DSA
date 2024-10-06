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

        public static int Search(int[] nums, int left, int right, int target)
        {
            int l = left, r = right;

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

        public static int FindPivotInRotated(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                if (nums[left] <= nums[right])
                {
                    return left;
                }
                int mid = (left + right) / 2;
                if (nums[mid] >= nums[left])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return 0;
        }

        public static int SearchTarget(int[] nums, int target)
        {
            int result = -1;
            var pivot = FindPivotInRotated(nums);
            if (pivot == 0)
            {
                result = Search(nums, target);
                if (result != -1) return result;
            }
            else
            { 
                result = Search(nums, 0, pivot - 1, target); 
                if (result != -1) return result;
                result = Search(nums, pivot, nums.Length - 1, target);
                if (result != -1) return result;
            }
            return result;
        }
    }
}
