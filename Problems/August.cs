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
    }
}
