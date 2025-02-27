using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.TreeProblems;

namespace Neetcode150
{
    public class Meta
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sum += nums[i];
            if (sum % 2 == 1) return false;

            int c = sum / 2;
            var memo = new Dictionary<(int, int), bool>();
            var r = CanPartitionHelper(0, nums, c, memo);
            return r;
        }

        public static bool CanPartitionHelper(int i, int[] nums, int c, Dictionary<(int, int), bool> memo)
        {
            if (c == 0) return true;  // Base case: subset sum found
            if (i == nums.Length || c < 0) return false;  // No more elements or invalid sum

            if (memo.TryGetValue((i, c), out bool result)) return result;

            // Try including nums[i] first for early exit
            result = CanPartitionHelper(i + 1, nums, c - nums[i], memo) ||
                     CanPartitionHelper(i + 1, nums, c, memo);

            memo[(i, c)] = result;
            return result;

        }
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(0, head);
            var fast = dummy.next;
            var slow = dummy;

            while (n > 0)
            {
                n--;
                fast = fast.next;
            }

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;
            return dummy.next;
        }
        public static int[] moveZerosToEnd(int[] arr)
        {
            if (arr.Length < 2) return arr;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[count] = arr[i];
                    count++;
                }
            }

            for (int i = count; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            return arr;
        }

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
            int right = s.Length - 1;
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

            public int dotProduct(SparseVector vec)
            {
                int sum = 0;

                if (arr.Count < vec.arr.Count)
                {
                    foreach (var pair in arr)
                    {
                        var ind = pair.Key;
                        var value = pair.Value;
                        if (vec.arr.ContainsKey(ind))
                            sum += value * vec.arr[ind];
                    }
                }
                else
                {
                    foreach (var pair in vec.arr)
                    {
                        var ind = pair.Key;
                        var value = pair.Value;
                        if (arr.ContainsKey(ind))
                            sum += value * arr[ind];
                    }
                }

                return sum;
            }
        }

        public static IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            int r = 0;
            int c = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            VerticalTraversal(root, r, c, dict, ref min, ref max);

            var answered = new List<IList<int>>();

            return answered;

        }

        public static void VerticalTraversal(TreeNode root, int r, int c, Dictionary<int, List<int>> dict, ref int min, ref int max)
        {
            if (root == null)
                return;

            Console.Write(r + " " + c + " " + root.val + " | ");

            min = Math.Min(min, c);
            max = Math.Max(max, c);

            if (dict.ContainsKey(c))
            {
                dict[c].Add(root.val);
            }
            else dict.Add(c, new List<int>() { root.val });

            VerticalTraversal(root.left, r + 1, c - 1, dict, ref min, ref max);
            VerticalTraversal(root.right, r + 1, c + 1, dict, ref min, ref max);
        }
    }
}
