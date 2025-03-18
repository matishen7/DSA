using CrackingTheCodingInterview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.TreeProblems;

namespace Neetcode150.LeetcodeMarch
{

    public class SolutionMarch
    {

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
