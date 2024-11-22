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
    }
}
