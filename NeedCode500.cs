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

            memo[(i,j)] = Math.Min(first, second);
            return memo[(i, j)];
        }
    }
}
