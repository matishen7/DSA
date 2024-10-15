using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class TimeMap
    {
        private Dictionary<string, List<Pair>> map;
        public TimeMap()
        {
            map = new Dictionary<string, List<Pair>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            var pair = new Pair(value, timestamp);
            if (map.ContainsKey(key))
                map[key].Add(pair);
            else map.Add(key, new List<Pair> { pair });
        }
        public string Get(string key, int timestamp)
        {
            if (map.ContainsKey(key))
            {
                var listOfPairs = map[key];
                var found = SearchPair(listOfPairs.ToArray(), timestamp);
                if (found != null) return found.value;
            }
            return "";
        }
        class Pair
        {
            public string value;
            public int timestamp;
            public Pair(string value, int timestamp)
            {
                this.value = value;
                this.timestamp = timestamp;
            }
        }

        private Pair SearchPair(Pair[] pairs, int timestamp)
        {
            int left = 0;
            int right = pairs.Length - 1;
            Pair mostRecent = null;
            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (pairs[mid].timestamp > timestamp)
                {
                    //mostRecent = pairs[mid];
                    right=mid;
                }
                else if (pairs[mid].timestamp < timestamp)
                {
                    mostRecent = pairs[mid];
                    left=mid;
                }
                else return pairs[mid];
            }
           // if (left > right) return null;
            return mostRecent;
        }
    }
}
