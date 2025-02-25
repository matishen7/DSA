using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public class Meta
    {
        public static int getMaximumEatenDishCount(int N, int[] D, int K)
        {
            HashSet<int> lastKDishes = new HashSet<int>(); // Tracks last K dishes
            Queue<int> queue = new Queue<int>(); // Maintains order of last K dishes
            int count = 0;

            for (int i = 0; i < N; i++)
            {
                if (!lastKDishes.Contains(D[i]))
                {
                    count++;
                    queue.Enqueue(D[i]);
                    lastKDishes.Add(D[i]);

                    if (queue.Count > K)
                    {
                        int removedDish = queue.Dequeue();
                        lastKDishes.Remove(removedDish);
                    }
                }
            }
            return count;
        }

        public long getMinCodeEntryTime(int N, int M, int[] C)
        {
            long total = 0;
            long curr = 1;
            for (int i = 0; i < M; i++)
            {
                long left = Math.Abs(-(N - C[i]) - curr);
                long right = Math.Abs(C[i] - curr);

                curr = C[i];
                total += Math.Min(left, right);
            }

            return total;
        }

        public bool ValidPalindrome(string s)
        {
            int left = 0;
            int right = s.Length-1;
            int c = 0;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return (Palindrome(s, left + 1, right) || Palindrome(s, left, right - 1));
                }
                else
                {
                    left++;
                    right--;
                }
            }

            return true;
        }

        public bool Palindrome(string s, int l, int r)
        {
            while (l < r)
            {
                if (s[l] != s[r])
                    return false;
                l++;
                r--;
            }
            return true;
        }

        public class SparseVector
        {
            Dictionary<int, int> arr = new Dictionary<int, int>();
            public SparseVector(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                    if (nums[i] != 0)
                        arr.Add(i, nums[i]);
            }

            public int dotProduct(int[] nums)
            {
                int sum = 0;
                foreach(var pair in arr)
                {
                    var ind = pair.Key;
                    var value = pair.Value;
                    var product = value * nums[ind];
                    sum += product;
                }
                return sum;
            }
        }
    }
}
