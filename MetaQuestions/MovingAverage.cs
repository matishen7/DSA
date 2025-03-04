using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.MetaQuestions
{
    public class MovingAverage
    {
        private List<int> list; 
        private int cap;
        private int left;
        private int right;
        private double total;

        public MovingAverage(int size)
        {
            list = new List<int>();
            total = 0;
            left = 0;
            right = 0;
            cap = size;
        }

        public double Next(int val)
        {
            right++;
            total += val;
            list.Add(val);
            if (right > cap)
            {
                var first = list[left];
                total -= first;
                left++;
                right--;
            }
            return total / right;
        }
    }
}
