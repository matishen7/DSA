using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150
{
    internal class BackTrackingProblems
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            return HasPathSumDfs(root, 0, targetSum);
        }

        public bool HasPathSumDfs(TreeNode root, int sum, int targetSum)
        {
            if (root == null) return false;
            sum += root.val;

            if (root.left == null && root.right == null)
            {
                if (targetSum == sum)
                    return true;
            }
            if (HasPathSumDfs(root.left, sum, targetSum))
            {
                return true;
            }
            if (HasPathSumDfs(root.right, sum, targetSum))
            {
                return true;
            }
            sum -= root.val;
            return false;
        }

        public static List<IList<int>> Subsets(int[] nums)
        {
            var subsets = new List<IList<int>>();
            var curSet = new List<int>();
            SubsetsDfsWithoutDuplicates(0, nums, curSet, subsets);
            return subsets;
        }

        public static List<List<int>> SubsetsWithDuplicates(int[] nums)
        {
            Array.Sort(nums);
            var subsets = new List<List<int>>();
            var curSet = new List<int>();
            SubsetsDfsWithDuplicates(0, nums, curSet, subsets);
            return subsets;
        }

        private static void SubsetsDfsWithoutDuplicates(int i, int[] nums, List<int> curSet, List<IList<int>> subsets)
        {
            if (i >= nums.Length)
            {
                subsets.Add(new List<int>(curSet));
                return;
            }

            curSet.Add(nums[i]);
            SubsetsDfsWithoutDuplicates(i + 1, nums, curSet, subsets);
            curSet.RemoveAt(curSet.Count - 1);
            SubsetsDfsWithoutDuplicates(i + 1, nums, curSet, subsets);
        }

        private static void SubsetsDfsWithDuplicates(int i, int[] nums, List<int> curSet, List<List<int>> subsets)
        {
            if (i >= nums.Length)
            {
                subsets.Add(new List<int>(curSet));
                return;
            }

            curSet.Add(nums[i]);
            SubsetsDfsWithDuplicates(i + 1, nums, curSet, subsets);
            curSet.RemoveAt(curSet.Count - 1);

            while (i < nums.Length - 1 && nums[i] == nums[i + 1])
            {
                i++;
            }
            SubsetsDfsWithDuplicates(i + 1, nums, curSet, subsets);
        }

        public static List<IList<int>> Combine(int n, int k)
        {
            var combs = new List<IList<int>>();
            var curSet = new List<int>();
            CombineDfs(1, n, k, curSet, combs);
            return combs;
        }

        private static void CombineDfs(int i, int n, int k, List<int> curSet, List<IList<int>> combs)
        {
            if (curSet.Count == k)
            {
                combs.Add(new List<int>(curSet));
                return;
            }
            if (i > n)
                return;

            curSet.Add(i);
            CombineDfs(i + 1, n, k, curSet, combs);
            curSet.RemoveAt(curSet.Count - 1);
            CombineDfs(i + 1, n, k, curSet, combs);
        }

        public static List<List<int>> CombinationSum(int[] nums, int target)
        {
            var combs = new List<List<int>>();
            var curSet = new List<int>();
            CombinationSumDfs(0, nums, target, 0, curSet, combs);
            return combs;
        }

        private static void CombinationSumDfs(int i, int[] nums, int target, int curSum, List<int> curSet, List<List<int>> combs)
        {
            if (curSum == target)
            {
                combs.Add(new List<int>(curSet));
                return;
            }
            if (i >= nums.Length || target < curSum)
                return;

            for (int j = i; j < nums.Length; j++)
            {
                curSum += nums[j];
                curSet.Add(nums[j]);
                CombinationSumDfs(j, nums, target, curSum, curSet, combs);
                curSet.RemoveAt(curSet.Count - 1);
                curSum -= nums[j];
            }

        }

        public static List<List<int>> CombinationSum2(int[] candidates, int target)
        {
            var combs = new List<List<int>>();
            var curSet = new List<int>();
            Array.Sort(candidates);
            CombinationSumDfs2(0, candidates, target, 0, curSet, combs);
            return combs;
        }

        private static void CombinationSumDfs2(int i, int[] nums, int target, int curSum, List<int> curSet, List<List<int>> combs)
        {
            if (curSum == target)
            {
                combs.Add(new List<int>(curSet));
                return;
            }
            if (i >= nums.Length || target < curSum)
                return;



            curSum += nums[i];
            curSet.Add(nums[i]);
            CombinationSumDfs2(i + 1, nums, target, curSum, curSet, combs);
            curSet.RemoveAt(curSet.Count - 1);
            curSum -= nums[i];

            while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                i++;

            CombinationSumDfs2(i + 1, nums, target, curSum, curSet, combs);

        }

        public static List<List<int>> Permute(int[] nums)
        {
            var resPerm = new List<List<int>>();
            resPerm.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                var next = new List<List<int>>();
                foreach (var perm in resPerm)
                {
                    for (int j = 0; j < perm.Count + 1; j++)
                    {
                        var pCopy = new List<int>();
                        pCopy.AddRange(perm);
                        pCopy.Insert(j, nums[i]);
                        next.Add(pCopy);
                    }
                }
                resPerm = next;
            }
            return resPerm;
        }

        public static List<IList<int>> Permute2Dfs(int[] nums)
        {
            Array.Sort(nums);
            var res = PermuteDfs(0, nums);
            return res;
        }

        public static List<IList<int>> Permute2(int[] nums)
        {
            Array.Sort(nums);
            var resPerm = new List<IList<int>>();
            resPerm.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                var next = new List<IList<int>>();
                foreach (var perm in resPerm)
                {
                    for (int j = 0; j < perm.Count + 1; j++)
                    {
                        var pCopy = new List<int>();

                        pCopy.AddRange(perm);
                        while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                        {
                            pCopy.Insert(j, nums[i]);
                            //j++;
                            i++;
                        }
                        pCopy.Insert(j, nums[i]);
                        next.Add(pCopy);
                    }
                }
                resPerm = next;
            }
            return resPerm;
        }

        public static List<IList<int>> PermuteDfs(int i, int[] nums)
        {
            if (i == nums.Length)
            {
                var resPerm = new List<IList<int>> { new List<int>() };
                return resPerm;
            }

            List<IList<int>> resPerms = new List<IList<int>>();
            while (i < nums.Length - 1 && nums[i] == nums[i + 1]) i++;
            List<IList<int>> perms = PermuteDfs(i + 1, nums);
            perms.RemoveAt(perms.Count - 1);
            foreach (List<int> p in perms)
            {
                for (int j = 0; j < p.Count + 1; j++)
                {
                    List<int> pCopy = new List<int>();
                    pCopy.AddRange(p);
                    pCopy.Insert(j, nums[i]);
                    resPerms.Add(pCopy);
                }
            }
            return resPerms;
        }

        public static bool WordExist(char[][] board, string word)
        {

            int rows = board.Length;
            int cols = board[0].Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    if (board[i][j] == word[0])
                        if (WordExistBFS(i, j, 0, word, board)) return true;
            }

            return false;
        }

        private static bool WordExistBFS(int i, int j, int v, string word, char[][] board)
        {
            int[][] directions = new int[][] {
            new int[] {-1, 0},
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1}};

            var result = new bool[word.Length];
            int rows = board.Length, cols = board[0].Length;
            var q = new Queue<(char character, int row, int col)>();
            q.Enqueue((board[i][j], i, j));
            var visited = new bool[rows, cols];
            while (q.Count > 0)
            {
                (char character, int row, int col) = q.Dequeue();
                visited[row, col] = true;
                if (v < word.Length)
                {
                    if (word[v] == character) result[v] = true;

                    v++;
                }

                foreach(var d in directions)
                {
                    var newRow = row + d[0];
                    var newCol = col + d[1];
                    if (newRow < 0 || newCol < 0 || newRow >= rows || newCol >= cols || visited[newRow, newCol] == true)
                        continue;
                    if (v < word.Length && word[v] == board[newRow][newCol])
                        q.Enqueue((board[newRow][newCol], newRow, newCol));
                }
            }

            foreach (var r in result)
                if (r == false) return false;
            return true;
    
        }
    }
}
