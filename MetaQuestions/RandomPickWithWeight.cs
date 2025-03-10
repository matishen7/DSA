using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.MetaQuestions
{
    public class RandomPickWithWeight
    {
        private int[] prefix;
        private Random rnd = new Random();

        public RandomPickWithWeight(int[] w)
        {
            prefix = new int[w.Length];
            prefix[0] = w[0];
            for (int i = 1; i < w.Length; i++)
            {
                prefix[i] = prefix[i - 1] + w[i];
            }
        }

        public int PickIndex()
        {
            int sum = prefix[prefix.Length - 1];
            int num = rnd.Next(1, sum + 1);
            int index = BinarySearch(prefix, 0, prefix.Length - 1, num);
            return index;
        }

        private int BinarySearch(int[] prefix, int left, int right, int target)
        {

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (target > prefix[mid])
                    left = mid + 1;
                else right = mid;
            }
            return left;
        }
    }
}
