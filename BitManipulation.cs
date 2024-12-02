using Microsoft.VisualBasic;
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
            int[] bits = new int[n + 1];
            bits[0] = 0;
            for (uint i = 1; i <= n; i++)
            {
                bits[i] = HammingWeight(i);
            }
            return bits;
        }

        public static uint ReverseBits(uint n)
        {
            uint[] digits = new uint[32];
            int i = 0;
            while (n > 0)
            {
                uint d = n % 2;
                digits[i] = d;
                i++;
                n = n >> 1; // same as n / 2
            }
            double reversed = 0;
            uint p = 31;
            for (int j = 0; j < digits.Length; j++)
            {
                if (digits[j] == 1)
                {
                    double g = Math.Pow(2, p);
                    reversed += g;
                }
                p--;

            }
            return (uint)reversed;
        }

        public static int MissingNumber(int[] nums)
        {
            bool[] exists = new bool[nums.Length + 1];
            int i = nums[0];
            exists[i] = true;
            int k = 1;
            while (k < nums.Length)
            {
                i = nums[i];
                exists[i] = true;
                k++;
            }

            for (int j = 0; j < exists.Length; j++)
                if (!exists[j]) return j;
            return 0;
        }

        public static int GetSum(int a, int b)
        {
            while (b != 0)
            {
                int carry = (a & b) << 1;
                a ^= b;
                b = carry;
            }
            return a;
        }

        public static int Reverse(int x)
        {
            int[] digits = new int[32];

            int i = 31;
            int pow = -1;
            bool minus = false;
            if (x < 0)
            {
                x *= -1;
                minus = true;
            }
            while (x > 0)
            {
                int d = x % 10;
                x = x / 10;
                digits[i] = d;
                i--;
                pow++;
            }
            if (pow >= 9) return 0;
            double num = 0;
            i = 31;
            while (pow >= 0)
            {
                num += digits[i] * Math.Pow(10, pow);
                pow--;
                i--;
            }
            if (minus) num *= -1;
            return (int) num;
        }

        public static int SingleNumber(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                    dic.Add(nums[i], 1);
                else dic[nums[i]]++;
            }

            foreach (var pair in dic)
            {
                if (pair.Value == 1) return pair.Key;
            }
            return 0;
        }
    }
}
