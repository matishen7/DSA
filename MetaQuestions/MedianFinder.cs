using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.MetaQuestions
{
    public class MedianFinder
    {
        PriorityQueue<int, int> min = new PriorityQueue<int, int>();
        PriorityQueue<int, int> max = new PriorityQueue<int, int>();

        public MedianFinder()
        {

        }

        public void AddNum(int num)
        {
            max.Enqueue(num, -num);
            
            //balancing
            var val = max.Peek();
            min.Enqueue(val, val);
            max.Dequeue();

            if (max.Count < min.Count)
            {
                max.Enqueue(min.Peek(), -min.Peek());
                min.Dequeue();
            }

        }

        public double FindMedian()
        {
            return (max.Count > min.Count) ? max.Peek(): ((double) max.Peek() + (double)min.Peek())*0.5;
        }
    }
}
