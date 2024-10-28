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

                {
                    var visited = new bool[board.Length, board[0].Length];
                    if (WordExistDFS(i, j, 0, word, board, visited)) return true;
                }
            }

            return false;
        }

        private static bool WordExistDFS(int r, int c, int i, string word, char[][] board, bool[,] visited)
        {
            if (i == word.Length) return true;
            if (r < 0 || c < 0 || r >= board.Length || c >= board[0].Length || visited[r,c] == true || board[r][c] != word[i]) return false;
            visited[r,c] = true;
            var res = (
                WordExistDFS(r + 1, c, i + 1, word, board, visited) ||
                WordExistDFS(r - 1, c, i + 1, word, board, visited) ||
                WordExistDFS(r , c + 1, i + 1, word, board, visited) ||
                WordExistDFS(r , c - 1, i + 1, word, board, visited)
                );
            visited[r,c] = false;
            return res;
        }

        public static List<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0) return new List<string> ();
            var map = new Dictionary<char, List<char>>();
            map.Add('2', new List<char>() { 'a', 'b', 'c' });
            map.Add('3', new List<char>() { 'd', 'e', 'f' });
            map.Add('4', new List<char>() { 'g', 'h', 'i' });
            map.Add('5', new List<char>() { 'j', 'k', 'l' });
            map.Add('6', new List<char>() { 'm', 'n', 'o' });
            map.Add('7', new List<char>() { 'p', 'q', 'r' ,'s' });
            map.Add('8', new List<char>() { 't', 'u', 'v' });
            map.Add('9', new List<char>() { 'w', 'x', 'y','z' });

            var list = new List<string>();
            LetterCombinationsDfs(0,digits, new StringBuilder(), list, map);
            return list;
        }

        public static void LetterCombinationsDfs(int i, string digits, StringBuilder curr, List<string> list, Dictionary<char, List<char>> map)
        {
            if (i >= digits.Length || curr.Length == digits.Length)
            {
                string c = curr.ToString();
                list.Add(c);
                return;
            }

            var buttons = map[digits[i]];
            for (int j = 0; j < buttons.Count; j++)
            {
               StringBuilder sb = curr.Append(buttons[j]);
               LetterCombinationsDfs(i + 1, digits, sb, list, map);
               sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
