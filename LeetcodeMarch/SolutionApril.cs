using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.LeetcodeMarch
{
    public class SolutionApril
    {
        public static IList<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;
            var adjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<int>());
            }

            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                    adjList[i].Add(graph[i][j]);
            }

            var safeNodes = new List<int>();
            Dictionary<int, bool> safe = new Dictionary<int, bool>();
            for (int i = 0; i < n; i++)
                if (IsSafeNode(i, safe, adjList)) safeNodes.Add(i);

            return safeNodes;
        }

        private static bool IsSafeNode(int node, Dictionary<int, bool> safe, Dictionary<int, List<int>> adjList)
        {
            if (safe.ContainsKey(node)) return safe[node];
            safe.Add(node, false);
            foreach (var nei in adjList[node])
            {
                if (!IsSafeNode(nei, safe, adjList)) return false;
            }
            safe[node] = true;
            return true;
        }

        public static int FindChampion(int n, int[][] edges)
        {
            var adjList = new Dictionary<int, List<int>>();
            var parents = new int[n];
            Array.Fill(parents, -1);
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                var src = edges[i][0];
                var dst = edges[i][1];

                adjList[src].Add(dst);
            }



            for (int i = 0; i < n; i++)
            {
                foreach (var nei in adjList[i])
                {
                    parents[nei] = i;
                }
            }
            var re = new List<int>();
            for (int i = 0; i < parents.Length; i++)
                if (parents[i] == -1)
                {
                    re.Add(i);
                    if (re.Count > 2) return -1;
                }
            return re[0];
        }



    }
}
