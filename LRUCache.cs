using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeMap;

namespace Neetcode150
{
    public class LRUCache
    {
        private int capacity;
        private Queue<Dictionary<int, int>> cache = new Queue<Dictionary<int, int>>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            bool containsKey = cache.Any(dict => dict.ContainsKey(key));
            if (containsKey)
            {
                var pair = cache.FirstOrDefault(dict => dict.ContainsKey(key));
                int value = pair[key];
                //if (cache.Count >= capacity)
                cache.Dequeue();
                cache.Enqueue(pair);
                return value;
            }
            else return -1;
        }

        public void Put(int key, int value)
        {
            bool containsKey = cache.Any(dict => dict.ContainsKey(key));
            if (containsKey)
            {
                var pair = cache.FirstOrDefault(dict => dict.ContainsKey(key));
                pair[key] = value;
                //if (cache.Count >= capacity)
                cache.Dequeue();
                cache.Enqueue(pair);
            }
            else
            {
                var pair = new Dictionary<int, int>();
                pair.Add(key, value);
                if (cache.Count >= capacity)
                    cache.Dequeue();
                cache.Enqueue(pair);
            }
        }
    }
}
