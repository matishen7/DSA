using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview
{
    public static class Arrays
    {
        public static bool IsUnique(string s)
        {

            var map = new Dictionary<char, object>();
            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i])) return false;
                else map.Add(s[i], new object());
            }
            return true;
        }

        public static bool CheckPermutation(string s1, string s2)
        {
            //if (s.Length != b.Length) return false;
            var dicS = new Dictionary<char, int>();
            var dicB = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++)
            {
                if (!dicS.ContainsKey(s1[i]))
                    dicS.Add(s1[i], 1);
                else
                    dicS[s1[i]]++;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (!dicB.ContainsKey(s2[i]))
                    dicB.Add(s2[i], 1);
                else
                    dicB[s2[i]]++;
            }

            foreach (var pair in dicS)
            {
                char cc = pair.Key;
                int countS = pair.Value;
                if (!dicB.ContainsKey(cc)) return false;
                var countB = dicB[cc];
                if (countS != countB) return false;
            }
            return true;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (!dic.ContainsKey(diff))
                {
                    dic.Add(nums[i], i);
                }
                else
                {
                    var ind = dic[diff];
                    if (ind < i)
                    {
                        result[0] = ind;
                        result[1] = i;
                    }
                    else
                    {
                        result[0] = i;
                        result[1] = ind;
                    }
                }
            }
            return result;
        }
    }
}
