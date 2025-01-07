﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class NeedCode500
    {
        public static int SpecialArray(int[] nums)
        {
            for (int i = 0; i <= nums.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] >= i) count++;
                }

                if (count == i) return count;
            }

            return -1;
        }

        public static int ArrangeCoins(int n)
        {
            if (n == 1) return 0;
            int row = 1;
            while (n > row)
            {
                n = n - row;
                row++;
            }

            return row - 1;
        }

        public static bool IsAlienSorted(string[] words, string order)
        {
            for (int i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];
                int k = 0;
                while (k < Math.Min(word1.Length, word2.Length) && word1[k] == word2[k]) k++;
                if (k == word2.Length && word1.Length > k) return false;
                for (int m = k; m < word1.Length; m++)
                {
                    char w1 = word1[m];
                    char w2 = word2[m];
                    var index1 = order.IndexOf(w1);
                    var index2 = order.IndexOf(w2);
                    if (index1 < index2) break;
                    else return false;
                }

            }

            return true;
        }

        public static int MinimumTotal(List<List<int>> triangle)
        {
            var memo = new Dictionary<(int, int), int>();
            int answer = MinimumTotalHelper(0, 0, triangle, memo);
            return answer;
        }

        public static int MinimumTotalHelper(int i, int j, List<List<int>> triangle, Dictionary<(int, int), int> memo)
        {
            if (i >= triangle.Count) return 0;

            if (memo.ContainsKey((i, j))) return memo[(i, j)];

            int first = triangle[i][j] + MinimumTotalHelper(i + 1, j, triangle, memo);
            int second = int.MaxValue;
            if (j < i)
                second = triangle[i][j + 1] + MinimumTotalHelper(i + 1, j + 1, triangle, memo);

            memo[(i, j)] = Math.Min(first, second);
            return memo[(i, j)];
        }

        public static double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node)
        {
            var adjList = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                adjList[i] = new List<int>();
            }

            for (int i = 0; i < edges.Length; i++)
            {
                var src = edges[i][0];
                var dst = edges[i][1];
                //var weight = succProb[i];
                adjList[src].Add(dst);
                adjList[dst].Add(src);
            }

            double max = 0;

            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            queue.Enqueue(start_node);
            visited.Add(start_node);
            double probSoFar = succProb[start_node];
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                visited.Add(curr);
                probSoFar *= succProb[curr];
                if (curr == end_node) max = Math.Max(max, probSoFar);
                foreach (var nei in adjList[curr])
                {
                    if (!visited.Contains(nei))
                        queue.Enqueue(nei);
                }
            }
            return max;
        }

        public static int ShortestPathBinaryMatrix(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            if (grid.Length == 1 && grid[0][0] == 0) return 1;
            if (grid.Length == 1 && grid[0][0] == 1) return -1;

            if (grid[0][0] == 1 || grid[rows - 1][cols - 1] == 1) return -1;

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));
            grid[0][0] = 1;
            while (queue.Count > 0)
            {
                (int row, int col) = queue.Dequeue();

                var directions = GetDirections();
                for (int i = 0; i < directions.Count; i++)
                {
                    (int dr, int dc) = directions[i];
                    int newRow = row + dr;
                    int newCol = col + dc;
                    if (newRow >= 0 && newCol >= 0 && newRow < rows && newCol < cols && grid[newRow][newCol] == 0)
                    {
                        grid[newRow][newCol] = grid[row][col] + 1;
                        if (newRow == rows - 1 && newCol == cols - 1) return grid[newRow][newCol];

                        queue.Enqueue((newRow, newCol));
                    }
                }
            }

            return -1;
        }

        private static List<(int, int)> GetDirections()
        {
            List<(int r, int c)> directions = new List<(int, int)>();
            directions.Add((-1, -1));
            directions.Add((-1, 0));
            directions.Add((-1, 1));
            directions.Add((0, -1));
            directions.Add((0, 1));
            directions.Add((1, -1));
            directions.Add((1, 0));
            directions.Add((1, 1));

            return directions;
        }

        public static int CalPoints(string[] operations)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == "C") stack.Pop();
                else if (operations[i] == "+")
                {
                    int prev1 = stack.Pop();
                    int prev2 = stack.Pop();
                    int res = prev1 + prev2;
                    stack.Push(prev2);
                    stack.Push(prev1);
                    stack.Push(res);

                }
                else if (operations[i] == "D")
                {
                    int prev1 = stack.Pop();
                    int res = prev1 * 2;
                    stack.Push(prev1);
                    stack.Push(res);
                }
                else stack.Push(int.Parse(operations[i]));
            }

            int sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }
            return sum;
        }

        public static string MakeGood(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (stack.Count == 0) stack.Push(s[i]);

                else
                {
                    var cc = stack.Peek();
                    if (Math.Abs(cc - s[i]) == 32) stack.Pop();
                    else stack.Push(s[i]);
                }
            }
            string res = "";
            while (stack.Count > 0)
            {
                res = stack.Pop() + res;
            }

            return res;
        }

        public static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            int j = 0;
            var stack = new Stack<int>();
            int i = 0;
            while (i < pushed.Length || j < popped.Length)
            {
                if (stack.Count == 0 || stack.Peek() != popped[j])
                {
                    stack.Push(pushed[i]);
                    i++;
                }
                else
                {
                    while (stack.Count != 0 && j < popped.Length && stack.Peek() == popped[j])
                    {
                        stack.Pop();
                        j++;
                    }
                }
            }

            return stack.Count == 0;
        }

        public class StockSpanner
        {
            private Stack<int> prices;

            public StockSpanner()
            {
                prices = new Stack<int>();
            }

            public int Next(int price)
            {
                prices.Push(price);
                int res = 0;
                var temp = new Stack<int>();
                while (prices.Count > 0 && price >= prices.Peek())
                {
                    res++;
                    temp.Push(prices.Pop());
                }

                while (temp.Count > 0)
                {
                    prices.Push(temp.Pop());
                }

                return res;
            }
        }

        public static int CombinationSum4(int[] nums, int target)
        {
            var memo = new Dictionary<int, int>();
            int comb = CombinationSum4Helper(0, nums, target, memo);
            return comb;
        }

        public static int CombinationSum4Helper(int i, int[] nums, int target,Dictionary<int, int> memo)
        {
            if (target == 0) return 1;
            if (target < 0) return 0;

            if (memo.ContainsKey(target)) return memo[target];

            int ways = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                ways += CombinationSum4Helper(nums[j], nums, target - nums[j], memo);
            }

            memo[target] = ways;
            return ways;
        }
    }
}
