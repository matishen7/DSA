using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150.LeetcodeMarch
{
    public class SolutionMarch
    {
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
                    if (newRow >= 0 && newCol >= 0 && newRow < rows && newCol < cols && (grid[newRow][newCol] == 'O') && !visited.Contains((newRow,newCol)))
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
            int k = 0;int l = 0;
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
            return (m,k,l);
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
