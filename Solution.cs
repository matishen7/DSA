using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    class Solution
    {
        public static int[] ArrayOfArrayProducts(int[] arr)
        {
            Stack<char> stack = new Stack<char>();
            var prefix = new int[arr.Length];
            var postfix = new int[arr.Length];
            var result = new int[arr.Length];
            int pre = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                prefix[i] = pre * arr[i];
                pre = prefix[i];
            }
            int post = 1;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                postfix[i] = post * arr[i];
                post = postfix[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    result[i] = postfix[i + 1];
                }
                else if (i == arr.Length - 1)
                {
                    result[i] = prefix[i - 1];
                }
                else
                {
                    result[i] = prefix[i - 1] * postfix[i + 1];
                }
            }
            return result;
        }

        public static int ShipWithinDays(int[] weights, int days)
        {
            int max = 0;
            int sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                max = Math.Max(max, weights[i]);
                sum += weights[i];
            }

            int[] possibleCapacity = new int[sum - max + 1];

            int m = max;
            for (int i = 0; i < possibleCapacity.Length; i++)
            {
                possibleCapacity[i] = m;
                m++;
            }
            int left = 0;
            int right = possibleCapacity.Length - 1;
            int result = sum;

            while (left < right)
            {
                int mid = (left + right) / 2;
                int possibleDays = CalculateDays(possibleCapacity[mid], days, weights);
                if (possibleDays <= days)
                {
                    result = Math.Min(result, possibleCapacity[mid]);
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }

        private static int CalculateDays(int possibleCapacity, int targetDays, int[] weights)
        {
            int days = 1; 
            int sum = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                if (sum + weights[i] <= possibleCapacity)
                {
                    sum += weights[i];
                }
                else
                {
                    days++; 
                    sum = weights[i]; 
                }
            }

            return days;
        }
    }


}
