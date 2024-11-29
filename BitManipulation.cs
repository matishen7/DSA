using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class BitManipulation
    {
        public static int HammingWeight(uint n)
        {
            int count = 0;
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    count++;
                }
                n = n >> 1; // same as n / 2
            }
            return count;

        }

        public static int[] CountBits(int n)
        {
            int [] bits = new int[n + 1];
            bits[0] = 0;
            for (uint i = 1; i <= n; i++)
            {
                bits[i] = HammingWeight(i);
            }
            return bits;
        }
    }
}
