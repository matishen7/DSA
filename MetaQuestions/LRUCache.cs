using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.MetaQuestions
{
    public class LRUCache
    {
        private int cap;
        private Queue<int> queue;
        private Dictionary<int, int> dict;
        public LRUCache(int capacity)
        {
            cap = capacity;
            queue = new Queue<int>();
            dict = new Dictionary<int, int>();
        }

        public int Get(int key)
        {
            if (dict.ContainsKey(key))
            {
                if (queue.Count < cap)
                {
                    queue.Enqueue(key);
                }
                else
                {
                    var toBeDeleted = queue.Dequeue();
                    dict.Remove(toBeDeleted);
                    queue.Enqueue(key);
                }
                return dict[key]; 
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
                if (queue.Count < cap)
                {
                    queue.Enqueue(key);
                }
                else
                {
                    var toBeDeleted = queue.Dequeue();
                    dict.Remove(toBeDeleted);
                    queue.Enqueue(key);
                }
            }
            else
            {
                dict.Add(key, value);
                if (queue.Count < cap)
                {
                    queue.Enqueue(key);
                }
                else
                {
                    var toBeDeleted = queue.Dequeue();
                    dict.Remove(toBeDeleted);
                    queue.Enqueue(key);
                }
            }
        }
    }
}
