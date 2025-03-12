using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.LeetcodeMarch
{
    public class RandomizedSet
    {
        Dictionary<int, int> dict;
        List<int> list;

        public RandomizedSet()
        {
            dict = new Dictionary<int, int>();
            list = new List<int>();
        }

        public bool Insert(int val)
        {
            if (!dict.ContainsKey(val))
            {
                dict.Add(val, list.Count);
                list.Add(val);
                return true;
            }
            return false;
        }

        public bool Remove(int val)
        {
            if (dict.ContainsKey(val))
            {
                var index = dict[val];
                var last = list[list.Count - 1];
                
                list[index] = last;
                dict[last] = index;
                dict.Remove(val);
                var count = list.Count - 1;
                list.RemoveAt(count);
                return true;
            }
            return false;
        }

        public int GetRandom()
        {
            var random = new Random();
            var index = random.Next(0, list.Count);
            return list[index];
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
