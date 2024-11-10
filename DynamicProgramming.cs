using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class DynamicProgramming
    {
        public static int ClimbStairs(int n)
        {
            var memo = new Dictionary<int, int>();
            return ClimbStairsHelper(n, memo);
        }

        public static int ClimbStairsHelper(int n, Dictionary<int, int> memo)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            if (memo.ContainsKey(n)) return memo[n];
            memo[n] = ClimbStairsHelper(n - 1, memo) + ClimbStairsHelper(n - 2, memo);
            return memo[n];
        }

        public static int Rob(int[] nums)
        {
            int[] memo;
            memo = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                memo[i] = -1;
            }
            return Dfs(nums, 0, memo);
        }

        private static int Dfs(int[] nums, int i, int[] memo)
        {
            if (i >= nums.Length)
            {
                return memo[i % nums.Length];
            }
            if (memo[i] != -1)
            {
                return memo[i];
            }
            memo[i] = Math.Max(Dfs(nums, i + 1, memo),
                             nums[i] + Dfs(nums, i + 2, memo));
            return memo[i];
        }

        public static int MinCostClimbingStairs(int[] cost)
        {
            int sum = 0;
            MinCostClimbingStairsHelper(cost, sum, cost.Length - 1);
            return sum;
        }

        public static void MinCostClimbingStairsHelper(int[] cost, int sum, int n)
        {
            if (n <= 0) return;
            sum = cost[n] + Math.Min(cost[n - 1], cost[n - 2]);
            int i = (cost[n - 1] < cost[n - 2]) ? n - 1 : n - 2;
            MinCostClimbingStairsHelper(cost, sum, i);
        }

        public static string LongestPalindrome(string s)
        {
            return LongestPalindromeHelper(s, 0, s.Length);
        }

        public static string LongestPalindromeHelper(string s, int start, int end)
        {

            var sub = s.Substring(start, end - start);
            if (sub.Length == 1) return sub;
            if (IsPalindrome(sub)) return sub;
            var r1 = LongestPalindromeHelper(s, start, end - 1);
            var r2 = LongestPalindromeHelper(s, start + 1, end);
            return (r1.Length > r2.Length) ? r1 : r2;
        }

        private static bool IsPalindrome(string s)
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

        public static bool CanPartition(int[] nums)
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
            if (i == nums.Length) return c == 0;
            if (c < 0) return false;

            if (memo.ContainsKey((i, c))) return memo[(i, c)];

            bool result = (CanPartitionHelper(i + 1, nums, c, memo) || CanPartitionHelper(i + 1, nums, c - nums[i], memo));
            return result;

        }

        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            var memo = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    memo[i, j] = -1;
            return UniquePathsWithObstaclesHelper(obstacleGrid, 0, 0, m, n, memo);
        }

        public static int UniquePathsWithObstaclesHelper(int[][] obstacleGrid, int r, int c, int rows, int cols, int[,] cache)
        {

            if (r == rows || c == cols || obstacleGrid[r][c] == 1)
            {
                return 0;
            }
            if (cache[r, c] > 0)
            {
                return cache[r, c];
            }
            if (r == rows - 1 && c == cols - 1)
            {
                return 1;
            }
            cache[r, c] = (UniquePathsWithObstaclesHelper(obstacleGrid, r + 1, c, rows, cols, cache) +
                            UniquePathsWithObstaclesHelper(obstacleGrid, r, c + 1, rows, cols, cache));
            return cache[r, c];
        }

        public static int FindTargetSumWays(int[] nums, int target)
        {
            var memo = new Dictionary<(int, int), int>();
            return FindTargetSumWaysHelper(0, 0, nums, target, memo);
        }

        public static int FindTargetSumWaysHelper(int i, int totalSum, int[] nums, int target, Dictionary<(int, int), int> memo)
        {
            if (i == nums.Length)
            {
                if (totalSum == target) return 1;
                else return 0;
            }

            if (memo.ContainsKey((i, totalSum))) return memo[(i, totalSum)];

            memo[(i, totalSum)] = FindTargetSumWaysHelper(i + 1, totalSum + nums[i], nums, target, memo) +
            FindTargetSumWaysHelper(i + 1, totalSum - nums[i], nums, target, memo);

            return memo[(i, totalSum)];

        }

        public static int FindMaxForm(string[] strs, int m, int n)
        {
            var dic = new Dictionary<int, (int zeros, int ones)>();
            for (int i = 0; i < strs.Length; i++)
            {
                var str = strs[i];
                int zeros = 0;
                int ones = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '0') zeros++;
                    if (str[j] == '1') ones++;
                }
                dic.Add(i, (zeros, ones));
            }

            var memo = new Dictionary<(int, int, int), int>();

            return FindMaxFormHelper(0, strs, m, n, dic, memo);
        }

        public static int FindMaxFormHelper(int i, string[] strs, int m, int n, Dictionary<int, (int zeros, int ones)> dic, Dictionary<(int, int, int), int> memo)
        {
            if (i == strs.Length)
            {
                if (m == 0 && n == 0) return 1;
                else return 0;
            }
            if (memo.ContainsKey((i, m, n))) return memo[(i, m, n)];

            int skip = FindMaxFormHelper(i + 1, strs, m, n, dic, memo);

            int include = 0;
            if (m >= dic[i].zeros && n >= dic[i].ones)
            {
                var newM = m - dic[i].zeros;
                var newN = n - dic[i].ones;
                FindMaxFormHelper(i + 1, strs, newM, newN, dic, memo);
            }
            memo[(i, m, n)] = Math.Max(include, skip);
            return memo[(i, m, n)];

        }
        public static int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            var memo = new Dictionary<(int, int), int>();

            var r = CoinChangeHelper(0, coins, amount, memo);
            return (r == int.MaxValue) ? -1 : r;
        }

        public static int CoinChangeHelper(int i, int[] coins, int amount, Dictionary<(int, int), int> memo)
        {
            if (i >= coins.Length || amount < 0) return int.MaxValue;

            if (amount == 0) return 0;

            if (memo.ContainsKey((i,amount))) return memo[(i,amount)];

            memo[(i,amount)] = CoinChangeHelper(i + 1, coins, amount, memo);
            if (amount - coins[i] >= 0)
            {
                int include =  CoinChangeHelper(i, coins, amount - coins[i], memo);
                if (include != int.MaxValue) include += 1;
                memo[(i,amount)] = Math.Min(memo[(i,amount)], include);
            }

            return memo[(i, amount)];
            
        }
    }
}

