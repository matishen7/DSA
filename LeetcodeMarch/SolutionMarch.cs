using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150.LeetcodeMarch
{
    public class SolutionMarch
    {
        public static int CountPalindromicSubsequence(string s)
        {
            int len = 0;
            var set = new HashSet<char>();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (set.Contains(s[i]) && set.Count >= 2) count+=set.Count;

                len++;
                set.Add(s[i]);
            }

            return count;
        }

        public static void CountPalindromicSubsequenceDFS(int i, string s, StringBuilder pal, HashSet<string> set)
        {
            //Console.WriteLine(pal);
            if (pal.Length == 3 && pal[0] == pal[2])
            {
                set.Add(pal.ToString());
            }
            if (i >= s.Length) return;
            var newPal = new StringBuilder(pal.ToString()) {};
            newPal.Append(s[i]);
            CountPalindromicSubsequenceDFS(i + 1, s, newPal, set);
            newPal.Remove(newPal.Length - 1, 1);
            CountPalindromicSubsequenceDFS(i + 1, s, pal, set);
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var ans = new Dictionary<string, IList<string>>();

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

            return new List<IList<string>>(ans.Values);
        }
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var answer = new List<int>();
            while (queue.Count > 0)
            {
                int levelLength = queue.Count;
                for (int i = 0; i < levelLength; i++)
                {
                    var curr = queue.Dequeue();
                    if (i == levelLength - 1)
                        answer.Add(curr.val);

                    if (curr.left != null)
                        queue.Enqueue(curr.left);
                    if (curr.right != null)
                        queue.Enqueue(curr.right);

                }
            }
            return answer;
        }
        public static string MergeAlternately(string word1, string word2)
        {
            var sb = new StringBuilder();
            int i = 0;
            while (i < word1.Length && i < word2.Length)
            {
                sb.Append(word1[i]);
                sb.Append(word2[i]);
                i++;
            }

            while (i < word1.Length)
            {
                sb.Append(word1[i]);
                i++;
            }
            while (i < word2.Length)
            {
                sb.Append(word2[i]);
                i++;
            }

            return sb.ToString();
        }
    }
}
