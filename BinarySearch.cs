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

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] arr = new int[nums1.Length + nums2.Length];
            int i = 0;
            while (i < nums1.Length)
            {
                arr[i] = nums1[i];
                i++;
            }
            int j = 0;
            while (j < nums2.Length)
            {
                arr[i] = nums2[j];
                i++;
                j++;
            }
            Array.Sort(arr);
            if (arr.Length % 2 == 0)
            {
                double sum = arr[arr.Length / 2] + arr[arr.Length / 2 - 1];
                return sum / 2.0;
            }
            return arr[arr.Length / 2];

        }

        public static int MinEatingSpeed(int[] piles, int h)
        {
            int max = piles.Max();
            int l = 1;
            int r = max;
            int minK = max;

            while (l <= r)
            {
                int k = (l + r) / 2;
                int hours = 0;
                for (int i = 0; i < piles.Length;i++)
                    hours += (int)Math.Ceiling((double)piles[i] / k);

                if (h >= hours)
                {
                    minK = k;
                    r = k - 1;
                }
                else
                {
                    l = k + 1;
                }
            }
            return minK;
        }

        public static int calculateHours(int[] arr, int k)
        {
            int total = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var a = arr[i] / k;
                var b = arr[i] % k;
                if (b != 0) a += 1;
                total += a;
            }
            return total;
        }
    }
}
