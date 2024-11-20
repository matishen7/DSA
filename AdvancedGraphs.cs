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

            for (int i = 0; i < n; i++)
                if (!shortest.ContainsKey(i)) shortest.Add(i, -1);

            return shortest;
        }


        public static int NetworkDelayTime(int[][] times, int n, int k)
        {
            var adjList = new Dictionary<int, List<List<int>>>();

            for (int i = 1; i <= n; i++)
            {
                adjList.Add(i, new List<List<int>>());
            }

            foreach (var edge in times)
            {
                var s = edge[0];
                var d = edge[1];
                var w = edge[2];

                adjList[s].Add(new List<int>() { d, w });
            }

            var shortest = new Dictionary<int, int>();

            var pq = new PriorityQueue<int[], int>();

            pq.Enqueue(new int[] { 0, k }, 0);
            int secs = 0;

            while (pq.Count > 0)
            {
                var curr = pq.Dequeue();
                var w1 = curr[0];
                var node1 = curr[1];
                if (shortest.ContainsKey(node1)) continue;

                shortest.Add(node1, w1);
                secs = w1;

                foreach (var edge in adjList[node1])
                {
                    var d = edge[0];
                    var w2 = edge[1];

                    if (shortest.ContainsKey(d)) continue;

                    pq.Enqueue(new int[] { w2 + w1, d }, w1 + w2);
                }
            }



            return (shortest.Count == n) ? secs : -1;

        }

        public static int SwimInWater(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            var visit = new HashSet<(int, int)>();
            var pq = new PriorityQueue<(int h, int r, int c), int>();
            pq.Enqueue((grid[0][0], 0, 0), grid[0][0]);
            int max = grid[0][0];
            while (pq.Count > 0)
            {
                (var h, var r, var c) = pq.Dequeue();
                visit.Add((r, c));
                if (r == rows - 1 && c == cols - 1)
                {
                    max = h; break;
                }
                

                if (r - 1 >= 0 && !visit.Contains((r - 1, c))) pq.Enqueue((Math.Max(h, grid[r - 1][c]), r - 1, c), Math.Max(h, grid[r - 1][c]));
                if (c - 1 >= 0 && !visit.Contains((r , c - 1))) pq.Enqueue((Math.Max(h, grid[r][c - 1]), r , c - 1), Math.Max(h, grid[r][c - 1]));
                if (c + 1 < cols && !visit.Contains((r , c + 1))) pq.Enqueue((Math.Max(h, grid[r][c + 1]), r , c + 1), Math.Max(h, grid[r][c + 1]));
                if (r + 1 < rows && !visit.Contains((r + 1 , c))) pq.Enqueue((Math.Max(h, grid[r + 1][c]), r + 1 , c ), Math.Max(h, grid[r + 1][c]));

            }

            return max;
        }
    }
}
