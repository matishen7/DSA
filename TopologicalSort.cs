using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public class TopologicalSort
    {

        public static List<int> topologicalSort(int[][] edges, int n)
        {
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
            }
            foreach (int[] edge in edges)
            {
                int src = edge[0], dst = edge[1];
                adj[src].Add(dst);
            }
            List<int> topSort = new List<int>();
            HashSet<int> visit = new HashSet<int>();
            HashSet<int> path = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                if (!dfs(i, adj, visit, path, topSort)) return new List<int>();
            }
            topSort.Reverse();
            return topSort;
        }

        public static bool dfs(int src, Dictionary<int, List<int>> adj, HashSet<int> visit, HashSet<int> path, List<int> topSort)
        {
            if (visit.Contains(src))
                return true;

            if (path.Contains(src))
                return false;

            path.Add(src);
            foreach (int neighbor in adj[src])
            {
                if (!dfs(neighbor, adj, visit, path, topSort)) return false;
            }

            path.Remove(src);
            visit.Add(src);

            topSort.Add(src);
            return true;
        }

        public static string foreignDictionary(string[] words)
        {
            Dictionary<char, HashSet<char>> adj = new Dictionary<char, HashSet<char>>();
            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    if (!adj.ContainsKey(c))
                    {
                        adj[c] = new HashSet<char>();
                    }
                }
            }
            for (int i = 0; i < words.Length - 1; i++)
            {
                var w1 = words[i];
                var w2 = words[i + 1];
                int minLen = Math.Min(w1.Length, w2.Length);
                if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen))
                {
                    return "";
                }
                for (int j = 0; j < minLen; j++)
                {
                    if (w1[j] != w2[j])
                    {
                        adj[w1[j]].Add(w2[j]);
                        break;
                    }
                }
            }
            StringBuilder topSort = new StringBuilder();
            HashSet<char> visit = new HashSet<char>();
            HashSet<char> path = new HashSet<char>();
            foreach (var pair in adj.Keys)
            {
                if (!foreignDictionaryHelper(pair, adj, visit, path, topSort)) return string.Empty;
            }

            var annswer = new StringBuilder();
            for (int i = topSort.Length - 1; i >= 0; i--)
            {
                annswer.Append(topSort[i]);
            }

            return annswer.ToString();
        }

        public static bool foreignDictionaryHelper(char cc, Dictionary<char, HashSet<char>> adj, HashSet<char> visit, HashSet<char> path, StringBuilder topSort)
        {
            if (visit.Contains(cc))
                return true;

            if (path.Contains(cc))
                return false;

            path.Add(cc);
            if (adj.ContainsKey(cc))
                foreach (var nei in adj[cc])
                    if (!foreignDictionaryHelper(nei, adj, visit, path, topSort)) return false;

            path.Remove(cc);
            visit.Add(cc);

            topSort.Append(cc);
            return true;
        }

        private static void get(string first, string second, Dictionary<char, char> dic)
        {
            int i = 0;

            while (i < first.Length && i < second.Length)
            {
                if (!dic.ContainsKey(second[i]) && first[i] != second[i])
                    dic.Add(second[i], first[i]);
                i++;
            }
            return;
        }
    }
}
