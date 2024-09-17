using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static List<List<string>> GroupAnagrams(string[] strs)
        {
            var ans = new Dictionary<string, List<string>>();

            foreach (var s in strs)
            {
                var count = new int[26];
                foreach (var c in s)
                {
                    count[c - 'a']++;
                }

                var key = string.Join(',', count);
                if (!ans.ContainsKey(key))
                {
                    ans[key] = new List<string>();
                }

                ans[key].Add(s);
            }

            return new List<List<string>>(ans.Values);
        }

        public static int SumOfString(string s)
        {
            int count = 0;
            foreach (char cc in s)
                count = count + cc;
            return count;
        }

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var a1 = s.ToCharArray();
            var a2 = t.ToCharArray();
            Array.Sort(a1);
            Array.Sort(a2);
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i]) return false;
            }
            return true;
        }

        public static int[] TopKFrequent(int[] nums, int k)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                    dic.Add(nums[i], 1);
                else dic[nums[i]]++;
            }

            var sorted = dic.OrderByDescending(x => x.Value).ToArray();
            var result = new int[k];
            for (int i = 0; i < k; i++)
                result[i] = sorted[i].Key;
            return result;
        }

        public static string Encode(IList<string> strs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var str in strs)
            {
                sb.Append(str.Length + "#" + str);
            }
            return sb.ToString();
        }

        public static List<string> Decode(string s)
        {
            var result = new List<string>();
            int i = 0;
            while (i < s.Length)
            {
                int j = i;
                while (s[j] != '#')
                {
                    ++j; ;
                }
                int.TryParse(s.Substring(i, j - i), out var len);
                j++;
                result.Add(s.Substring(j, len));
                i = j + len;
            }

            return result;
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] prefix = new int[nums.Length];
            int[] defix = new int[nums.Length];
            int product = 1;
            for (int i = 0; i < nums.Length; ++i)
            {
                product *= nums[i];
                prefix[i] = product;
            }
            product = 1;
            for (int i = nums.Length - 1; i >= 0; --i)
            {

                product *= nums[i];
                defix[i] = product;
            }

            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; ++i)
            {
                if (i == 0) result[i] = defix[i + 1];
                else if (i == nums.Length - 1) result[i] = prefix[i - 1];
                else result[i] = prefix[i - 1] * defix[i + 1];
            }
            return result;
        }

        public static bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < board.Length; ++i)
            {

                var dic = new Dictionary<char, object>();
                for (int j = 0; j < board[i].Length; ++j)
                {
                    if (board[i][j] != '.')
                        if (!dic.ContainsKey(board[i][j]))
                            dic.Add(board[i][j], new object());
                        else return false;
                }
            }
            for (int j = 0; j < board.Length; ++j)
            {

                var dic = new Dictionary<char, object>();
                for (int i = 0; i < board[j].Length; ++i)
                {
                    if (board[i][j] != '.')
                        if (!dic.ContainsKey(board[i][j]))
                            dic.Add(board[i][j], new object());
                        else return false;
                }
            }

            var box = new Dictionary<string, HashSet<char>>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var key = string.Join(',', i / 3, j / 3);
                    if (board[i][j] == '.') continue;
                    if (box.ContainsKey(key))
                    {
                        var set = box[key];
                        if (set.Contains(board[i][j]))
                            return false;
                        else set.Add(board[i][j]);
                    }
                    else
                    {
                        box.Add(key, new HashSet<char>() { board[i][j] });
                    }
                }
            }

            return true;
        }
        public static int LongestConsecutive(int[] nums)
        {
            HashSet<int> numSet = new HashSet<int>(nums);
            int longest = 0;

            foreach (int n in numSet)
            {
                if (!numSet.Contains(n - 1))
                {
                    int length = 1;
                    while (numSet.Contains(n + length))
                    {
                        length++;
                    }
                    longest = Math.Max(length, longest);
                }
            }
            return longest;
        }

    }
}
