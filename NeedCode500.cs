using System;
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

        public static int CombinationSum4Helper(int i, int[] nums, int target, Dictionary<int, int> memo)
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

        public static int[] GetConcatenation(int[] nums)
        {
            var ans = new int[2 * nums.Length];
            int i = 0, j = 0;
            while (i < ans.Length)
            {
                if (j >= nums.Length) j = 0;
                ans[i] = nums[j];
                i++;
                j++;
            }


            return ans;
        }

        public class NumMatrix
        {

            private List<List<int>> prefixSum = new List<List<int>>();

            public NumMatrix(int[][] matrix)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    var row = GetPrefixSum(matrix[i]);
                    prefixSum.Add(row);
                }
            }

            private List<int> GetPrefixSum(int[] grid)
            {
                List<int> prefix = new List<int>();
                int total = 0;
                for (int i = 0; i < grid.Length; i++)
                {
                    total += grid[i];
                    prefix.Add(total);
                }
                return prefix;
            }

            private int RangeSum(int row, int left, int right)
            {
                int preRight = prefixSum[row][right];
                int preLeft = 0;
                if (left > 0) preLeft = prefixSum[row][left - 1];

                return (preRight - preLeft);
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                int sum = 0;
                for (int i = row1; i <= row2; i++)
                {
                    sum += RangeSum(i, col1, col2);
                }
                return sum;
            }

            public static int MaxProfit(int[] prices)
            {
                int profit = 0;
                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] > prices[i - 1]) profit += prices[i] - prices[i - 1];
                }
                return profit;
            }


        }

        public static int SubarraySum(int[] nums, int k)
        {
            int c = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];

                    if (sum == k) c++;
                }
            }
            return c;
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                nums1[i + m] = nums2[i];
            }

            Array.Sort(nums1);
        }

        public static void Rotate(int[] nums, int k)
        {
            var arr = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                arr[(i + k) % nums.Length] = nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
                nums[i] = arr[i];

        }

        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var cache = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (cache.ContainsKey(nums[i]))
                {
                    int closestIndex = cache[nums[i]];
                    if (Math.Abs(closestIndex - i) <= k) return true;
                    else cache[nums[i]] = i;
                }
                else cache.Add(nums[i], i);
            }
            return false;
        }

        public static int MinSubArrayLen(int target, int[] nums)
        {
            int sum = 0;
            int[] prefix = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                prefix[i] = sum;
            }

            int left = 0;
            int right = 0;
            int min = int.MaxValue;
            int total = 0;
            while (right < prefix.Length)
            {
                int preleft = 0;
                if (left > 0) preleft = prefix[left - 1];
                    
                total = prefix[right] - preleft;
                if (total < target) right++;
                else
                {
                    min = Math.Min(min, right - left + 1);
                    left++;
                }
            }

            return (min == int.MaxValue) ? 0 : min;
        }
    }
}
