using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.Problems
{
    internal class August
    {
        public static int MaxDifference(string s)
        {
            var count = new Dictionary<char, int>();
            int maxOdd = 0;
            int minEven = int.MaxValue;
            foreach (char c in s)
            {

                if (count.ContainsKey(c))
                    count[c]++;
                else
                    count.Add(c, 1);
            }
            foreach (char c in s)
                if (count[c] % 2 == 1)
                    maxOdd = Math.Max(maxOdd, count[c]);
                else minEven = Math.Min(minEven, count[c]);
            return maxOdd - minEven;
        }


        public static string KthDistinct(string[] arr, int k)
        {
            var str = new Dictionary<string, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!str.ContainsKey(arr[i]))
                    str.Add(arr[i], 1);
                else str[arr[i]]++;
            }
            var result = new List<string>();
            foreach (var s in str)
            {
                if (s.Value == 1)
                    result.Add(s.Key);
            }

            if (result.Count < k) return "";
            else return result[k - 1];
        }
    }
}
