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
        public static string CustomSortString(string order, string s)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i])) dict[s[i]]++;
                else dict.Add(s[i], 1);
            }

            var sb = new StringBuilder();
            for (int i = 0; i < order.Length; i++)
            {
                if (dict.ContainsKey(order[i]))
                {
                    var times = dict[order[i]];
                    for (int j = 1; j <= times; j++)
                    {
                        sb.Append(order[i]);
                        dict[order[i]]--;
                    }
                }
            }

            foreach (var pair in dict)
            {
                var times = pair.Value;
                for (int j = 1; j <= times; j++)
                {
                    sb.Append(pair.Key);
                }
            }

            return sb.ToString();
        }
        public static int[] SearchRange(int[] nums, int target)
        {
            int[] range = { -1, -1 };
            var firstPos = BinarySearch(nums, target, 0, nums.Length - 1);
            if (firstPos == -1) return range;
            int startPos = firstPos, endPos = firstPos, temp1 = 0, temp2 = 0;
            while (startPos != -1)
            {
                temp1 = startPos;
                startPos = BinarySearch(nums, target, 0, startPos - 1);
            }
            startPos = temp1;

            while (endPos != -1)
            {
                temp2 = endPos;
                endPos = BinarySearch(nums, target, endPos + 1, nums.Length - 1);
            }
            endPos = temp2;

            range[0] = startPos;
            range[1] = endPos;

            return range;
        }

        public static int BinarySearch(int[] nums, int target, int start, int end)
        {
            int left = start;
            int right = end;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] <= target)
                    left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }

        public static string SimplifyPath(string path)
        {
            var stack = new Stack<string>();
            var paths = path.Split("/");
            foreach (var curr in paths)
            {
                if (curr.Equals(".."))
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else if (curr != string.Empty && !curr.Equals(".")) stack.Push(curr);
            }

            if (stack.Count == 0) return "/";
            var result = new StringBuilder();
            while (stack.Count > 0)
            {
                var curr = stack.Pop();
                result.Insert(0, "/" + curr);
            }
            return result.ToString();
        }
        public static bool ValidWordAbbreviation(string word, string abbr)
        {
            int i = 0;
            int j = 0;
            var digits = new HashSet<int>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            while (i < abbr.Length && j < word.Length)
            {
                if (!digits.Contains(abbr[i]))
                {
                    if (abbr[i] != word[j]) return false;
                    i += 1;
                    j += 1;
                }
                else
                {
                    var sb = new StringBuilder();
                    while (i < abbr.Length && digits.Contains(abbr[i]))
                    {
                        sb.Append(abbr[i]);
                        i += 1;
                    }
                    if (sb[0] == '0') return false;
                    var times = int.Parse(sb.ToString());
                    for (int k = 1; k <= times; k++)
                        j += 1;
                }
            }
            if (j == word.Length && i == abbr.Length) return true;
            return false;
        }
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return LowestCommonAncestorDfs(root, p, q);
        }

        public static TreeNode LowestCommonAncestorDfs(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q) return root;

            var l = LowestCommonAncestorDfs(root.left, p, q);
            var r = LowestCommonAncestorDfs(root.right, p, q);

            if (l != null && r != null) return root;

            else if (l == null) return r;
            else return l;
        }

        public static int MaximumSwap(int num)
        {
            int maxIndex = -1, swap1 = -1, swap2 = -1;
            char[] nums = num.ToString().ToCharArray();
            int n = nums.Length;

            for (int i = n - 1; i >= 0; i--)
            {
                if (maxIndex == -1 || nums[i] > nums[maxIndex])
                {
                    maxIndex = i;
                }
                else if (nums[i] < nums[maxIndex])
                {
                    swap1 = i;
                    swap2 = maxIndex;
                }
            }

            if (swap1 != -1 && swap2 != -1)
            {
                char temp = nums[swap1];
                nums[swap1] = nums[swap2];
                nums[swap2] = temp;
            }
            return int.Parse(new String(nums));
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int last = m + n - 1;
            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] > nums2[n - 1])
                {
                    nums1[last] = nums1[m - 1];
                    m -= 1;
                }
                else
                {
                    nums1[last] = nums2[n - 1];
                    n -= 1;
                }

                last -= 1;
            }

            while (n > 0)
            {
                nums1[last] = nums2[n - 1];
                n -= 1;
                last -= 1;
            }
        }

        public int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var current = intervals[0];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (current[1] < intervals[i][0])
                {
                    result.Add(current);
                    current = intervals[i];
                }
                else
                {
                    int start = Math.Min(current[0], intervals[i][0]);
                    int end = Math.Max(current[1], intervals[i][1]);
                    current = new int[2] { start, end };
                }
            }

            result.Add(current);
            return result.ToArray();
        }

        public int[][] Merge2(int[][] intervals, int[][] intervals2)
        {
            var merged = Merge(intervals);
            var merged2 = Merge(intervals2);
            var result = new List<int[]>();
            for (int i = 0; i < merged.Length; i++)
            {
                if (merged[i][1] < merged2[i][0])
                {
                    result.Add(merged[i]);
                }
                else
                {
                    int start = Math.Min(merged[i][0], merged2[i][0]);
                    int end = Math.Max(merged[i][1], merged2[i][1]);
                    var current = new int[2] { start, end };
                    result.Add(current);
                }
            }

            return result.ToArray();
        }

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
            if (root == null) return new List<IList<int>>();
            var queue = new Queue<(int col, TreeNode node)>();
            queue.Enqueue((0, root));
            int min = 0;
            int max = 0;
            var dict = new Dictionary<int, List<int>>();
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (min > curr.col) min = curr.col;
                if (max < curr.col) max = curr.col;

                if (dict.ContainsKey(curr.col)) dict[curr.col].Add(curr.node.val);
                else dict.Add(curr.col, new List<int>() { curr.node.val });

                if (curr.node.left != null) queue.Enqueue((curr.col - 1, curr.node.left));
                if (curr.node.right != null) queue.Enqueue((curr.col + 1, curr.node.right));
            }

            var ans = new List<IList<int>>();
            for (int i = min; i <= max; i++)
            {
                var values = dict[i];
                ans.Add(values);
            }

            return ans;
        }
    }
}
