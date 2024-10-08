using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public class MedianFinder
    {
        private PriorityQueue<int, int> small;
        private PriorityQueue<int, int> large;

        public MedianFinder()
        {
            small = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            large = new PriorityQueue<int, int>();
        }

        public void AddNum(int num)
        {
            small.Enqueue(num, num);

            if (large.Count != 0 && small.Peek() > large.Peek())
            {
                var val = small.Dequeue();
                large.Enqueue(val, val);
            }

            if (small.Count > large.Count + 1)
            {
                var val = small.Dequeue();
                large.Enqueue(val, val);
            }
            else if (large.Count > small.Count + 1)
            {
                var val = large.Dequeue();
                small.Enqueue(val, val);
            }

        }

        public double FindMedian()
        {
            if (small.Count > large.Count) return small.Peek();
            else if (large.Count > small.Count) return large.Peek();
            else return ((small.Peek() + large.Peek()) / 2.0);
        }
    }

    public class KthLargest
    {
        PriorityQueue<int, int> large;
        Stack<int> stack;
        private int k;
        public KthLargest(int k, int[] nums)
        {
            stack = new Stack<int>();
            this.k = k;
            large = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            for (int i = 0; i < nums.Length; i++)
                large.Enqueue(nums[i], nums[i]);
        }

        public int Add(int val)
        {
            int res = large.Peek();
            large.Enqueue(val, val);
            for (int i = 0; i < this.k; i++)
            {
                res = large.Dequeue();
                stack.Push(res);
            }
            while (stack.Count > 0)
            {
                var value = stack.Pop();
                large.Enqueue(value, value);
            }
            return res;
        }

        
    }
}
