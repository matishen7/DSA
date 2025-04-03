using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.LeetcodeMarch
{
    public class SolutionApril
    {
        public static int CountCompleteComponents(int n, int[][] edges)
        {
            var adjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                var src = edges[i][0];
                var dst = edges[i][1];
                adjList[src].Add(dst);
                adjList[dst].Add(src);
            }

            var visit = new HashSet<int>();
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                var components = new int[2];
                if (!visit.Contains(i))
                {
                    CountCompleteComponentsDFS(i, adjList, visit, components);
                    int m = components[0];
                    int edge = components[1];
                    if ((m * (m - 1)) == edge) result += 1;
                }
            }

            return result;
        }
        public static void CountCompleteComponentsDFS(int node, Dictionary<int, List<int>> adjList, HashSet<int> visit, int[] components)
        {
            visit.Add(node);
            components[0]++;
            components[1] += adjList[node].Count;
            foreach (var nei in adjList[node])
            {
                if (!visit.Contains(nei))
                {
                    CountCompleteComponentsDFS(nei, adjList, visit, components);
                }

            }
        }
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
