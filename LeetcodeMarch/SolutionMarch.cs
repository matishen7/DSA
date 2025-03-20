using CrackingTheCodingInterview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.TreeProblems;

namespace Neetcode150.LeetcodeMarch
{

    public class SolutionMarch
    {
        public static int MySqrt(int x)
        {
            if (x < 2) return x;
            int left = 2;
            int right = x / 2;
            long num;
            int mid = 1;
            while (left <= right)
            {
                mid = (left + right) / 2;
                num = (long) mid * mid;
                if (num < x)
                    left = mid + 1;
                else if (num > x) right = mid - 1;
                else if (num == x) return mid;
            }
            return right;
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var curr = headA;
            var setA = new HashSet<ListNode>();
            while (curr != null)
            {
                setA.Add(curr);
                curr = curr.next;
            }

            curr = headB;
            while (curr != null)
            {
                if (setA.Contains(curr)) return curr;
                curr = curr.next;
            }

            return null;
        }
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTDFS(nums, 0, nums.Length - 1);
        }

        public static TreeNode SortedArrayToBSTDFS(int[] nums, int left, int right)
        {
            if (left > right) return null;

            int mid = (left + right) / 2;

            var node = new TreeNode(nums[mid]);

            node.left = SortedArrayToBSTDFS(nums, left, mid - 1);
            node.right = SortedArrayToBSTDFS(nums, mid + 1, right);
            return node;
        }

        public static int LongestCommonSubsequence(string text1, string text2)
        {
            var memo = new Dictionary<(int, int, int), int>();
            var result = LongestCommonSubsequenceDFS(0, 0, 0, text1, text2, memo);
            return result;
        }

        public static int LongestCommonSubsequenceDFS(int i, int j, int count, string text1, string text2, Dictionary<(int, int, int), int> memo)
        {
            if (i >= text1.Length || j >= text2.Length)
                return count;

            if (memo.ContainsKey((i, j, count))) return memo[(i, j, count)];

            int skip = 0; int include1 = 0, include2 = 0;
            if (text1[i] == text2[j])
            {
                count++;
                skip = LongestCommonSubsequenceDFS(i + 1, j + 1, count, text1, text2, memo);
            }
            else
            {
                include1 = LongestCommonSubsequenceDFS(i + 1, j, count, text1, text2, memo);
                include2 = LongestCommonSubsequenceDFS(i, j + 1, count, text1, text2, memo);
            }
            memo[(i, j, count)] = Math.Max(skip, Math.Max(include1, include2));
            return memo[(i, j, count)];
        }

        public static int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            int i = 0;
            while (i < heights.Length)
            {
                if (i == heights.Length - 1) break;
                if (heights[i] - heights[i + 1] >= 0)
                    i++;
                else if (bricks > 0 || ladders > 0)
                {
                    if (bricks - Math.Abs(heights[i] - heights[i + 1]) >= 0)
                    {
                        bricks -= Math.Abs(heights[i] - heights[i + 1]);
                        i++;
                    }
                    else if (ladders > 0)
                    {
                        ladders--;
                        i++;
                    }
                    else break;
                }
                else break;
            }

            return i;
        }
        public static int SingleNonDuplicate(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (mid % 2 == 0 && nums[mid] == nums[mid - 1])
                    left = mid + 1;
                else if (mid % 2 == 0 && nums[mid] == nums[mid + 1])
                    left = mid + 1;
                else if (mid % 2 != 0 && nums[mid] != nums[mid - 1] || nums[mid] == nums[mid + 1])
                    right = mid - 1;
                else if (mid % 2 != 0 && nums[mid] != nums[mid + 1] || nums[mid] == nums[mid - 1])
                    right = mid - 1;
                else return nums[mid];
            }

            return -1;
        }
        public static long MinimumHealth(int[] damage, int armor)
        {
            long total = 1;
            long maxSoFar = 0;
            for (int i = damage.Length - 1; i >= 0; i--)
            {
                if (damage[i] > maxSoFar)
                    maxSoFar = damage[i];
                total += damage[i];
            }
            maxSoFar = Math.Min(maxSoFar, armor);
            return total - maxSoFar;
        }
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var result = new List<bool>();
            int mx = candies[0];
            for (int i = 1; i < candies.Length; i++)
            {
                if (mx < candies[i]) mx = candies[i];
            }

            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] + extraCandies >= mx) result.Add(true);
                else result.Add(false);
            }

            return result;
        }
        public static int MinimumTime(int[] jobs, int[] workers)
        {
            PriorityQueue<int, int> maxJobs = new PriorityQueue<int, int>();
            for (int j = 0; j < jobs.Length; j++)
                maxJobs.Enqueue(jobs[j], -jobs[j]);

            PriorityQueue<int, int> maxWorkers = new PriorityQueue<int, int>();
            for (int j = 0; j < workers.Length; j++)
                maxWorkers.Enqueue(workers[j], -workers[j]);

            int max = 0;
            while (maxJobs.Count > 0)
            {
                var currJob = maxJobs.Dequeue();
                var currWorker = maxWorkers.Dequeue();

                int days = currJob / currWorker;
                if (currJob % currWorker != 0) days += 1;
                max = Math.Max(max, days);
            }

            return max;
        }
        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            PriorityQueue<(int numBox, int numUnits), int> max = new PriorityQueue<(int numBox, int numUnits), int>();
            for (int j = 0; j < boxTypes.Length; j++)
                max.Enqueue((boxTypes[j][0], boxTypes[j][1]), -boxTypes[j][1]);

            int i = 0;
            int total = 0;
            while (truckSize > 0 && max.Count > 0)
            {
                var curr = max.Dequeue();
                var numOfBox = curr.numBox;
                var numOfUnits = curr.numUnits;

                if (truckSize > numOfBox)
                {
                    total += numOfBox * numOfUnits;
                    truckSize -= numOfBox;
                }
                else
                {
                    total += truckSize * numOfUnits;
                    truckSize = 0;
                }

                i++;
            }

            return total;
        }

        public static bool IsValidPalindrome(string s, int k)
        {
            return IsValidPalindromeDSF(s, k);
        }

        public static bool IsValidPalindromeDSF(string s, int k)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    if (k <= 0)
                    {
                        return IsPalindrome(s);
                    }
                    else
                    {
                        return (IsValidPalindromeDSF(s.Substring(left, right - left), k - 1) ||
                            IsValidPalindromeDSF(s.Substring(left + 1, right - (left + 1) + 1), k - 1));
                    }
                }

                left++;
                right--;
            }

            return true;
        }
        public static bool MakePalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            int count = 0;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    count++;
                    if (count > 2)
                    {
                        return IsPalindrome(s.Substring(left, right - left + 1));
                    }
                }

                left++;
                right--;
            }

            return true;
        }

        public static bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right]) return false;
                left++;
                right--;
            }
            return true;
        }

        public static int PartitionString(string s)
        {
            int i = 0;
            int count = 0;
            while (i < s.Length)
            {
                var set = new HashSet<char>();
                while (i < s.Length && !set.Contains(s[i]))
                {
                    set.Add(s[i]);
                    i++;
                }
                count++;
            }

            return count;
        }
        public static bool IsZeroArray(int[] nums, int[][] queries)
        {
            for (int i = 0; i < queries.Length; i++)
            {
                var start = queries[i][0];
                var end = queries[i][1];
                for (int j = start; j <= end; j++)
                {
                    if (nums[j] != 0)
                        nums[j] -= 1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != 0) return false;

            return true;
        }
        public static int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            int n = nums.Length;
            int product = 1;
            int total = 0;
            int left = 0;
            int right = 0;

            while (right < n)
            {
                product *= nums[right];
                while (product >= k)
                {
                    product /= nums[left];
                    left++;
                }
                total += right - left + 1;
                right++;
            }

            return total;
        }
        public static void ReorderList(ListNode head)
        {
            LinkedList<int> deque = new LinkedList<int>();
            var curr = head;
            while (curr != null)
            {
                deque.AddLast(curr.val);
                curr = curr.next;
            }
            var dummy = new ListNode(0);
            curr = head;
            dummy.next = curr;
            var prev = dummy.next;
            int i = 0;
            while (deque.Count > 0)
            {
                if (i % 2 == 0)
                {
                    var val = deque.First.Value;
                    deque.RemoveFirst();
                    var node = new ListNode(val);
                    prev.next = node;
                    prev = prev.next;
                    i++;
                }
                else
                {
                    var val = deque.Last.Value;
                    deque.RemoveLast();
                    var node = new ListNode(val);
                    prev.next = node;
                    prev = prev.next;
                    i++;
                }
            }

            head = dummy.next.next;
        }
        public static string RankTeams(string[] votes)
        {
            var maxHeap = new PriorityQueue<(char key, int value), int>();
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < votes.Length; i++)
            {
                int pointWeight = votes[0].Length;
                for (int j = 0; j < votes[i].Length; j++)
                {
                    if (dict.ContainsKey(votes[i][j])) dict[votes[i][j]] += pointWeight;
                    else dict.Add(votes[i][j], pointWeight);

                    pointWeight--;
                }
            }

            foreach (var kvp in dict)
                maxHeap.Enqueue((kvp.Key, kvp.Value), -kvp.Value);

            var str = new StringBuilder();
            var sb = new StringBuilder();
            var p = maxHeap.Dequeue();
            (char key, int value) last = (p.key, p.value);
            sb.Append(last.key);
            while (maxHeap.Count > 0)
            {
                if (maxHeap.Peek().value == last.value)
                {
                    while (maxHeap.Count > 0 && maxHeap.Peek().value == last.value)
                    {
                        var pair1 = maxHeap.Dequeue();
                        sb.Append(pair1.key);
                        last.value = pair1.value;
                        last.key = pair1.key;
                    }
                    char[] chars = sb.ToString().ToCharArray();
                    Array.Sort(chars);
                    sb.Clear();
                    sb.Append(chars);
                    str.Append(sb);
                    sb.Clear();
                }
                else
                {
                    if (sb.Length > 0)
                    {
                        str.Append(sb);
                        sb.Clear();
                    }
                    var pair = maxHeap.Dequeue();
                    str.Append(pair.key);
                }

            }
            if (sb.Length > 0)
            {
                str.Append(sb);
                sb.Clear();
            }
            return str.ToString();
        }
        public static int GetFood(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            var data = BuildMatrix(grid);
            var copyGrid = data.matrix;
            var visited = new HashSet<(int, int)>();

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((data.i, data.j));
            visited.Add((data.i, data.j));
            while (queue.Count > 0)
            {
                (int row, int col) = queue.Dequeue();

                var directions = GetDirections();
                for (int i = 0; i < directions.Count; i++)
                {
                    (int dr, int dc) = directions[i];
                    int newRow = row + dr;
                    int newCol = col + dc;
                    if (newRow >= 0 && newCol >= 0 && newRow < rows && newCol < cols && (grid[newRow][newCol] == 'O' || grid[newRow][newCol] == '#') && !visited.Contains((newRow, newCol)))
                    {
                        copyGrid[newRow][newCol] = copyGrid[row][col] + 1;
                        queue.Enqueue((newRow, newCol));
                        visited.Add((newRow, newCol));
                    }
                }
            }

            return -1;
        }

        private static (int[][] matrix, int i, int j) BuildMatrix(char[][] grid)
        {
            int k = 0; int l = 0;
            var m = new int[grid.Length][];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new int[grid[i].Length];
            }

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                    if (grid[i][j] == '*')
                    {
                        m[i][j] = 1;
                        k = i;
                        l = j;
                    }
            return (m, k, l);
        }

        private static List<(int, int)> GetDirections()
        {
            List<(int r, int c)> directions = new List<(int, int)>();
            // directions.Add((-1, -1));
            directions.Add((-1, 0));
            //  directions.Add((-1, 1));
            directions.Add((0, -1));
            directions.Add((0, 1));
            //  directions.Add((1, -1));
            directions.Add((1, 0));
            // directions.Add((1, 1));

            return directions;
        }
        public static int CountPalindromicSubsequence(string s)
        {
            int len = 0;
            var set = new HashSet<char>();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (set.Contains(s[i]) && set.Count >= 2) count += set.Count;

                len++;
                set.Add(s[i]);
            }

            return count;
        }

        public static void CountPalindromicSubsequenceDFS(int i, string s, StringBuilder pal, HashSet<string> set)
        {
            //Console.WriteLine(pal);
            if (pal.Length == 3 && pal[0] == pal[2])
            {
                set.Add(pal.ToString());
            }
            if (i >= s.Length) return;
            var newPal = new StringBuilder(pal.ToString()) { };
            newPal.Append(s[i]);
            CountPalindromicSubsequenceDFS(i + 1, s, newPal, set);
            newPal.Remove(newPal.Length - 1, 1);
            CountPalindromicSubsequenceDFS(i + 1, s, pal, set);
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var ans = new Dictionary<string, IList<string>>();

            foreach (var s in strs)
            {
                var count = new int[26];
                foreach (var c in s)
                {
                    count[c - 'a']++;
                }

                var key = string.Join(',', count);
                if (!ans.ContainsKey(key))
                {
                    ans[key] = new List<string>();
                }

                ans[key].Add(s);
            }

            return new List<IList<string>>(ans.Values);
        }
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var answer = new List<int>();
            while (queue.Count > 0)
            {
                int levelLength = queue.Count;
                for (int i = 0; i < levelLength; i++)
                {
                    var curr = queue.Dequeue();
                    if (i == levelLength - 1)
                        answer.Add(curr.val);

                    if (curr.left != null)
                        queue.Enqueue(curr.left);
                    if (curr.right != null)
                        queue.Enqueue(curr.right);

                }
            }
            return answer;
        }
        public static string MergeAlternately(string word1, string word2)
        {
            var sb = new StringBuilder();
            int i = 0;
            while (i < word1.Length && i < word2.Length)
            {
                sb.Append(word1[i]);
                sb.Append(word2[i]);
                i++;
            }

            while (i < word1.Length)
            {
                sb.Append(word1[i]);
                i++;
            }
            while (i < word2.Length)
            {
                sb.Append(word2[i]);
                i++;
            }

            return sb.ToString();
        }
    }
}
