using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class TaskScheduler
    {
        public static int LeastInterval(char[] tasks, int n)
        {
            var count = new Dictionary<char, int>();
            for (int i = 0; i < tasks.Length; i++)
                if (!count.ContainsKey(tasks[i]))
                    count.Add(tasks[i], 1);
                else count[tasks[i]]++;

            var interval = new Dictionary<char, int>();
            foreach (var pair in count)
                interval.Add(pair.Key, 0);

            PriorityQueue<char, int> pq = new PriorityQueue<char, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            foreach (var pair in count)
                pq.Enqueue(pair.Key, pair.Value);

            int answer = 0;
            while (pq.Count > 0)
            {
                answer++;
                var cc = pq.Dequeue();
                if (interval[cc] < n)
                {
                    count[cc]--;
                    Console.WriteLine("->" + cc);
                }
                foreach(var pair in interval)
                {
                    var key = pair.Key;
                    interval[key]++;
                    if (interval[key] > n) interval[key] = 0;
                };

                if (count[cc] != 0) pq.Enqueue(cc, count[cc]);
            }

            return answer;
        }
    }
}
