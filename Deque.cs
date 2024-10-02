using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public class Deque
    {
        private List<int> queue;

        public Deque()
        {
            queue = new List<int>();
        }

        public bool isEmpty()
        {
            return queue.Count == 0;
        }

        public void append(int value)
        {
            queue.Add(value);
        }

        public void appendleft(int value)
        {
            queue.Insert(0, value);
        }

        public int pop()
        {
            if (isEmpty()) return -1;
            var last = queue.Last();
            queue.RemoveAt(queue.Count - 1);
            return last;
        }

        public int popleft()
        {
            if (isEmpty()) return -1;
            var first = queue.First();
            queue.RemoveAt(0);
            return first;
        }
    }

}
