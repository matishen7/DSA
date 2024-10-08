using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class HeapProblems
    {
        public static int LastStoneWeight(int[] stones)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            for (int i = 0; i < stones.Length; i++)
                pq.Enqueue(-1 * stones[i], -1 * stones[i]);

            while (pq.Count > 1)
            {
                var weight1 = -1 * pq.Dequeue();
                var weight2 = -1 * pq.Dequeue();
                if (weight1 > weight2)
                    pq.Enqueue(-1 * (weight1 - weight2), -1 * (weight1 - weight2));
            }
            if (pq.Count == 0) return 0;
            return -1 * pq.Peek();
        }

        public static int[][] KClosest(int[][] points, int k)
        {
            PriorityQueue<int[], double> pq = new PriorityQueue<int[], double>();
            int x2 = 0; int y2 = 0;
            for (int i = 0; i < points.Length; i++)
            {
                var coordinates = points[i];
                var x1 = coordinates[0];
                var y1 = coordinates[1];
                double distance = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                pq.Enqueue(coordinates, distance);
            }
            int j = 0;
            var answer = new int[k][];
            while (j < k)
            {
                var coordinates = pq.Dequeue();
                answer[j] = coordinates;
                j++;
            }

            return answer;
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(); //minHeap
            for (int i = 0; i < nums.Length; i++)
                pq.Enqueue(-1 * nums[i], -1 * nums[i]);
            int j = 0;
            int answer = pq.Peek();
            while (j < k)
            {
                var value = -1 * pq.Dequeue();
                answer = value;
                j++;
            }
            return answer;
        }
    }
}
