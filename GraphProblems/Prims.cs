using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.GraphProblems
{
    /// <summary>
    /// Prim's algo is used to calculate minimum spanning tree
    /// </summary>
    public class Prims
    {
        public static int MinimumSpanningTree(int n, List<List<int>> edges)
        {
            Dictionary<int, List<List<int>>> adjList = new();
            for (int i = 0; i < n; i++)
            {
                adjList[i] = new List<List<int>>();
            }

            foreach (var edge in edges)
            {
                int src = edge[0], dst = edge[1]; int w = edge[2];
                adjList[src].Add(new List<int>() { dst, w });
                adjList[dst].Add(new List<int>() { src, w });
            }

            HashSet<int> visited = new();
            var mst = new HashSet<(int, int)>();
            var pq = new PriorityQueue<(int w, int src, int dst), int>();
            int total = 0;
            foreach (var neighbor in adjList[0])
            {
                var node = neighbor[0];
                var weight = neighbor[1];
                pq.Enqueue((weight, 0, node), weight);
            }

            visited.Add(0);

            while (visited.Count < n)
            {
                if (pq.Count == 0) break;
                var curr = pq.Dequeue();
                var w = curr.w; int src = curr.src; int dst = curr.dst;

                if (visited.Contains(dst)) continue;
                mst.Add((src, dst));
                total += w;
                visited.Add(dst);
                foreach (var neighbor in adjList[dst])
                {
                    var node = neighbor[0];
                    var weight = neighbor[1];
                    if (!visited.Contains(node))
                        pq.Enqueue((weight, dst, node), weight);
                }

            };

            return (visited.Count == n) ? total : -1;
        }
    }
}
