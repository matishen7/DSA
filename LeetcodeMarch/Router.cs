using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.LeetcodeMarch
{
    public class Router
    {
        private Queue<(int s, int d, int t)> queue = new Queue<(int, int, int)>();
        private Dictionary<int, List<int>> destinations = new Dictionary<int, List<int>>();
        private int capacity;
        private HashSet<(int, int, int)> set = new HashSet<(int, int, int)>();
        public Router(int memoryLimit)
        {
            capacity = memoryLimit;
        }

        public bool AddPacket(int source, int destination, int timestamp)
        {
            if (set.Contains((source, destination, timestamp))) return false;

            if (queue.Count == capacity)
            {
                var curr = queue.Dequeue();
                set.Remove(curr);
                destinations[curr.d].Remove(curr.t);
            }
            queue.Enqueue((source, destination, timestamp));

            if (destinations.ContainsKey(destination)) destinations[destination].Add(timestamp);
            else destinations.Add(destination, new List<int>() { timestamp });

            set.Add((source, destination, timestamp));
            return true;

        }

        public int[] ForwardPacket()
        {
            if (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                int[] data = new int[3];
                data[0] = curr.s; data[1] = curr.d; data[2] = curr.t;

                set.Remove(curr);
                destinations[curr.d].Remove(curr.t);

                return data;

            }
            return new int[0];
        }

        public int GetCount(int destination, int startTime, int endTime)
        {
            int count = 0;
            foreach (var t in destinations[destination])
                if (t >= startTime && t <= endTime) count++;

            return count;
        }
    }
}
