using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class AdvancedGraphs
    {
        public static Dictionary<int, int> ShortestPath(int n, List<List<int>> edges, int src)
        {
            var adjList = new Dictionary<int, List<List<int>>>();

            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<List<int>>());
            }

            foreach (var edge in edges)
            {
                var s = edge[0];
                var d = edge[1];
                var w = edge[2];

                adjList[s].Add(new List<int>() { d, w });
            }

            var shortest = new Dictionary<int, int>();

            var pq = new PriorityQueue<int[], int>();

            pq.Enqueue(new int[] { 0, src }, 0);

            while (pq.Count > 0)
            {
                var curr = pq.Dequeue();
                var w1 = curr[0];
                var node1 = curr[1];
                if (shortest.ContainsKey(node1)) continue;

                shortest.Add(node1, w1);

                foreach (var edge in adjList[node1])
                {
                    var d = edge[0];
                    var w2 = edge[1];

                    if (shortest.ContainsKey(d)) continue;

                    pq.Enqueue(new int[] { w2 + w1, d }, w1 + w2);
                }
            }

            for (int i = 0;i< n;i++)
                if (!shortest.ContainsKey(i)) shortest.Add(i, -1);

            return shortest;
        }
    }
}
