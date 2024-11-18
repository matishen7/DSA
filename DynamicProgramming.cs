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

            if (memo.ContainsKey((i, amount))) return memo[(i, amount)];

            memo[(i, amount)] = CoinChangeHelper(i + 1, coins, amount, memo);
            if (amount - coins[i] >= 0)
            {
                int include = CoinChangeHelper(i, coins, amount - coins[i], memo);
                if (include != int.MaxValue) include += 1;
                memo[(i, amount)] = Math.Min(memo[(i, amount)], include);
            }

            return memo[(i, amount)];

        }

        public static int CoinChange2(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            var memo = new Dictionary<(int, int), int>();
            var r = CoinChangeHelper2(0, coins, amount, memo);
            return r;
        }

        private static int CoinChangeHelper2(int i, int[] coins, int amount, Dictionary<(int, int), int> memo)
        {
            if (i >= coins.Length || amount < 0) return 0;
            if (amount == 0) return 1;

            if (memo.ContainsKey((i, amount))) return memo[(i, amount)];

            int skip = CoinChangeHelper2(i + 1, coins, amount, memo);

            int include = CoinChangeHelper2(i, coins, amount - coins[i], memo);
            memo[(i, amount)] = skip + include;
            return memo[(i, amount)];
        }

        public static int LongestCommonSubsequence(string text1, string text2)
        {
            var memo = new Dictionary<(int, int), int>();
            var r = LongestCommonSubsequenceHelper(text1, text2, 0, 0, memo);
            return r;
        }

        public static int LongestCommonSubsequenceHelper(string text1, string text2, int i1, int i2, Dictionary<(int, int), int> memo)
        {
            if (i1 == text1.Length || i2 == text2.Length) return 0;
            if (memo.ContainsKey((i1, i2))) return memo[(i1, i2)];

            if (text1[i1] == text2[i2])
            {
                memo[(i1, i2)] = 1 + LongestCommonSubsequenceHelper(text1, text2, i1 + 1, i2 + 1, memo);
            }
            else
            {
                memo[(i1, i2)] = Math.Max(LongestCommonSubsequenceHelper(text1, text2, i1 + 1, i2, memo),
                    LongestCommonSubsequenceHelper(text1, text2, i1, i2 + 1, memo));
            }
            return memo[(i1, i2)];
        }

        public static int MaxProfit(int[] prices)
        {
            var memo = new Dictionary<(int, char, int), int>();
            var r = MaxProfitHelper(0, 'b', 0, prices, memo);
            return r;
        }

        public static int MaxProfitHelper(int i, char status, int profit, int[] prices)
        {
            if (i >= prices.Length) return profit;

            int skip = MaxProfitHelper(i + 1, status, profit, prices);

            int include = 0;

            if (status == 'b')
            {
                int p = profit - prices[i];
                include = MaxProfitHelper(i + 1, 's', p, prices);
            }

            else
            {
                int p = profit + prices[i];
                include = MaxProfitHelper(i + 2, 'b', p, prices);
            }

            return Math.Max(include, skip);
        }

        public static int MaxProfitHelper(int i, char status, int profit, int[] prices, Dictionary<(int, char, int), int> memo)
        {
            if (i >= prices.Length) return profit;

            if (memo.ContainsKey((i, status, profit))) return memo[(i, status, profit)];

            memo[(i, status, profit)] = MaxProfitHelper(i + 1, status, profit, prices, memo);

            int include = 0;

            if (status == 'b')
            {
                int p = profit - prices[i];
                include = MaxProfitHelper(i + 1, 's', p, prices, memo);
            }

            else
            {
                int p = profit + prices[i];
                include = MaxProfitHelper(i + 2, 'b', p, prices, memo);
            }

            memo[(i, status, profit)] = Math.Max(include, memo[(i, status, profit)]);
            return memo[(i, status, profit)];
        }

        public static int MinDistance(string word1, string word2)
        {
            var memo = new Dictionary<(int, int), int>();
            var r = MinDistanceHelper(0, 0, word1, word2, memo);
            return r;
        }

        public static int MinDistanceHelper(int i, int j, string word, string target, Dictionary<(int, int), int> memo)
        {
            if (i == word.Length) return target.Length - j;
            if (j == target.Length) return word.Length - i;

            if (memo.ContainsKey((i, j))) return memo[(i, j)];

            int p = int.MaxValue;
            int skip = int.MaxValue;
            if (word[i] == target[j])
                skip = MinDistanceHelper(i + 1, j + 1, word, target, memo);
            else
            {

                int remove = 1 + MinDistanceHelper(i + 1, j, word, target, memo);

                int insert = 1 + MinDistanceHelper(i, j + 1, word, target, memo);

                int replace = 1 + MinDistanceHelper(i + 1, j + 1, word, target, memo);


                p = Math.Min(remove, Math.Min(insert, replace));

            }

            memo[(i, j)] = Math.Min(p, skip);
            return memo[(i, j)];

        }

        public static int NumDistinct(string s, string t)
        {
            var memo = new Dictionary<(int, string), int>();
            var r = NumDistinctHelper(0, "", s, t);
            return r;
        }

        public static int NumDistinctHelper(int i, string v, string s, string t)
        {
            if (i == s.Length)
            {
                if (v.Equals(t)) return 1;
                else return 0;
            }

            int skip = NumDistinctHelper(i + 1, v, s, t);

            var sb = new StringBuilder(v);
            sb.Append(s[i]);
            int include = NumDistinctHelper(i + 1, sb.ToString(), s, t);

            return include + skip;
        }

        public static int NumDistinctHelperMemo(int i, string v, string s, string t, Dictionary<(int, string), int> memo)
        {
            if (i == s.Length)
            {
                if (v.Equals(t)) return 1;
                else return 0;
            }

            if (memo.ContainsKey((i, v))) return memo[(i, v)];

            int skip = NumDistinctHelperMemo(i + 1, v, s, t, memo);

            var sb = new StringBuilder(v);
            sb.Append(s[i]);
            int include = NumDistinctHelperMemo(i + 1, sb.ToString(), s, t, memo);

            memo[(i, v)] = include + skip;
            return memo[(i, v)];
        }

        public static int MaxCoins(int[] nums)
        {
            var list = new List<int>() { 1 };
            list.AddRange(nums);
            list.Add(1);

            var r = MaxCoinsHelper(list);
            return r;
        }

        public static int MaxCoinsHelper(List<int> nums)
        {
            if (nums.Count == 2) return 0;
            int mxCoins = 0;
            for (int i = 1; i < nums.Count - 1; i++)
            {
                int coins = nums[i - 1] * nums[i] * nums[i + 1];

                var newNums = new List<int>(nums);
                newNums.RemoveAt(i);
                coins += MaxCoinsHelper(newNums);
                mxCoins = Math.Max(mxCoins, coins);
            }

            return mxCoins;
        }


        public static int LongestIncreasingPath(int[][] matrix)
        {
            int max = 0;
            var memo = new Dictionary<(int, int), int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                    LongestIncreasingPathHelper(i, j, -1, matrix, memo, matrix.Length, matrix[0].Length, ref max);
            }

            return max;
        }
        public static int LongestIncreasingPathHelper(int r, int c, int prev, int[][] matrix, Dictionary<(int, int), int> memo, int rows, int cols, ref int max)
        {
            if (r < 0 || c < 0 || r >= rows || c >= cols || prev >= matrix[r][c]) return 0;

            if (memo.ContainsKey((r, c))) return memo[(r, c)];

            int right = 1 + LongestIncreasingPathHelper(r, c + 1, matrix[r][c], matrix, memo, rows, cols, ref max);
            int left = 1 + LongestIncreasingPathHelper(r, c - 1, matrix[r][c], matrix, memo, rows, cols, ref max);
            int up = 1 + LongestIncreasingPathHelper(r - 1, c, matrix[r][c], matrix, memo, rows, cols, ref max);
            int down = 1 + LongestIncreasingPathHelper(r + 1, c, matrix[r][c], matrix, memo, rows, cols, ref max);

            memo[(r, c)] = Math.Max(down, Math.Max(up, Math.Max(right, left)));
            max = Math.Max(memo[(r, c)], max);
            return memo[(r, c)];

        }

    }
}

