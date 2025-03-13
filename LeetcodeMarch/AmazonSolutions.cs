using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150.LeetcodeMarch
{

    public class AmazonSolutions
    {
        public static int ShortestPath(int[][] grid, int k)
        {
            var result = ShortestPathDFS(0, 0, 1, grid, k, grid.Length, grid[0].Length);
            return result;
        }

        public static int ShortestPathDFS(int i, int j, int sum, int[][] grid, int k, int n, int m)
        {
            if (i == grid.Length - 1 && j == grid[i].Length - 1) return sum + 1;

            if (i >= n || j >= m || j < 0 || i < 0) return sum;
            int result = 0;
            int result2 = 0;
            if (grid[i][j] == 0)
            {
                int right = ShortestPathDFS(i, j + 1, grid[i][j] + 1, grid, k, n, m);
                int left = ShortestPathDFS(i, j - 1, grid[i][j] + 1, grid, k, n, m);
                int down = ShortestPathDFS(i + 1, j, grid[i][j] + 1, grid, k, n, m);

                result = Math.Min(right, Math.Min(left, down));
            }
            else if (k > 0)
            {
                int right = ShortestPathDFS(i, j + 1, grid[i][j] + 1, grid, k - 1, n, m);
                int left = ShortestPathDFS(i, j - 1, grid[i][j] + 1, grid, k - 1, n, m);
                int down = ShortestPathDFS(i + 1, j, grid[i][j] + 1, grid, k - 1, n, m);
                result2 = Math.Min(right, Math.Min(left,  down));
            }

            return sum;
        }
        private static List<(int, int)> GetDirections()
        {
            List<(int r, int c)> directions = new List<(int, int)>();
            directions.Add((-1, 0));
            directions.Add((0, -1));
            directions.Add((0, 1));
            directions.Add((1, 0));

            return directions;
        }
        //public static IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
        //{
        //    var dict = new Dictionary<string, List<string[]>>();
        //    for (int i = 0; i < username.Length; i++)
        //    {
        //        var user = username[i];
        //        var time = timestamp[i];
        //        var web = website[i];
        //        string[] values = new string[] { time.ToString(), web };
        //        if (dict.ContainsKey(user))
        //        {
        //            dict[user].Add(values);
        //        }
        //        else
        //            dict[user] = new List<string[]>() { values };
        //    }

        //    var sortedDict = dict
        //          .Select(kvp => new
        //          {
        //              Key = kvp.Key,
        //              Values = kvp.Value.OrderBy(arr => int.Parse(arr[0])).ToList() // Sorting by integer time
        //          })
        //          .ToDictionary(x => x.Key, x => x.Values);
        //    var patterns = new Dictionary<string, int>();

        //    foreach (var pair in sortedDict)
        //    {
        //        var pattern = new StringBuilder();
        //        var value = pair.Value;
        //        int left = 0;
        //        int right = 2;
        //        while (right < )
        //        for (int i = 0; i < value.Count; i++)
        //            pattern.Append(value[i][1] + "+");

        //        if (patterns.ContainsKey(pattern.ToString())) patterns[pattern.ToString()]++;
        //        else patterns.Add(pattern.ToString(), 1);
        //    }

        //    return new List<string> { patterns.ToString() };

        //}
        public static bool HasSameDigits(string s)
        {
            while (s.Length > 2)
            {
                int left = 0;
                int right = 1;
                var sb = new StringBuilder();
                while (right < s.Length)
                {
                    int d1 = int.Parse(s[left].ToString());
                    int d2 = int.Parse(s[right].ToString());
                    int sum = (d1 + d2) % 10;
                    sb.Append(sum);
                    left++;
                    right++;
                }

                s = sb.ToString();
            }

            return (s[0] == s[1]);
        }
        public static long MaxSum(int[][] grid, int[] limits, int k)
        {
            var maxHeapTotal = new PriorityQueue<int, int>();

            for (int i = 0; i < limits.Length; i++)
            {
                var maxHeap = new PriorityQueue<int, int>();
                for (int j = 0; j < grid[i].Length; j++)
                {
                    maxHeap.Enqueue(grid[i][j], -grid[i][j]);
                }

                var limit = limits[i];
                while (maxHeap.Count > 0 && limit > 0)
                {
                    var value = maxHeap.Dequeue();
                    maxHeapTotal.Enqueue(value, -value);
                    limit--;
                }

            }

            long sum = 0;
            while (maxHeapTotal.Count > 0 && k > 0)
            {
                sum += maxHeapTotal.Dequeue();
                k--;
            }
            return sum;
        }
        public static int SetZeroesOPtimal(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }

            for (int i = 0; i < n; i++)
                if (matrix[i][0] == 0)
                    for (int j = 0; j < m; j++)
                        matrix[i][j] = 0;

            for (int j = 0; j < m; j++)
                if (matrix[0][j] == 0)
                    for (int i = 0; i < n; i++)
                        matrix[i][j] = 0;

            return 1;

        }
        public static int SetZeroes(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            var rows = new HashSet<int>();
            var cols = new HashSet<int>();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (rows.Contains(i) || cols.Contains(j))
                        matrix[i][j] = 0;

            return 1;

        }
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] <= target && target <= matrix[i][matrix[i].Length - 1])
                {
                    if (BinarySearch(matrix[i], 0, matrix[i].Length, target) != -1)
                        return true;
                }
            }

            return false;
        }
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 1) return 1;

            int left = 0;
            int right = 0;

            while (right < nums.Length)
            {
                while (right < nums.Length && nums[left] == nums[right])
                    right++;

                left++;
                if (right < nums.Length)
                    nums[left] = nums[right];
            }

            return left;

        }
        public static bool IsAnagram(string s, string t)
        {
            int[] countS = new int[26];
            int[] countT = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                countS[s[i] - 'a']++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                countT[t[i] - 'a']++;
            }

            for (int i = 0; i < countT.Length; i++)
                if (countS[i] != countT[i]) return false;

            return true;
        }
        public static int SearchRotatedArray(int[] nums, int target)
        {
            int pivot = FindPivot(nums);

            int left = 0;
            int right = nums.Length - 1;
            if (pivot == 0)
                right = pivot;
            else right = pivot - 1;

            int found = BinarySearch(nums, left, right, target);
            if (found != -1) return found;
            found = BinarySearch(nums, pivot, nums.Length - 1, target);
            return found;
        }

        public static int BinarySearch(int[] nums, int left, int right, int target)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }
        public static int FindPivot(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] > nums[nums.Length - 1])
                    left = mid + 1;
                else right = mid - 1;
            }

            return left;
        }

        public static int CountUnivalSubtrees(TreeNode root)
        {
            int count = 0;
            var list = new HashSet<TreeNode>();
            ListAllNodes(root, list);
            foreach (var node in list)
            {
                if (CountUnivalSubtreesDFS(node, node.val)) count++;
            }
            return count;
        }

        public static bool CountUnivalSubtreesDFS(TreeNode node, int parent)
        {
            if (node == null) return true;
            if (parent != node.val) return false;
            bool left = CountUnivalSubtreesDFS(node.left, node.val);
            bool right = CountUnivalSubtreesDFS(node.right, node.val);
            return (left && right);
        }

        public static void ListAllNodes(TreeNode root, HashSet<TreeNode> list)
        {
            if (root == null) return;
            if (!list.Contains(root)) list.Add(root);

            ListAllNodes(root.left, list);
            ListAllNodes(root.right, list);
        }
    }
}
