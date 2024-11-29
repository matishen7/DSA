using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class Intervals
    {
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();

            for (var i = 0; i < intervals.Length; i++)
            {
                if (newInterval[1] < intervals[i][0])
                {
                    result.Add(newInterval);
                    result.AddRange(
                        intervals.AsEnumerable().Skip(i).ToArray());

                    return result.ToArray();
                }
                else if (newInterval[0] > intervals[i][1])
                {
                    result.Add(intervals[i]);
                }
                else
                {
                    newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                    newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
                }
            }

            result.Add(newInterval);

            return result.ToArray();
        }

        public static int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var currentInterval = intervals[0];

            for (var i = 0; i < intervals.Length; i++)
            {
                if (currentInterval[1] >= intervals[i][0])
                {
                    currentInterval[1] = Math.Max(intervals[i][1], currentInterval[1]);
                    currentInterval[0] = Math.Min(intervals[i][0], currentInterval[0]);
                }
                else
                {
                    result.Add(currentInterval);
                    currentInterval = intervals[i];
                }
            }
            result.Add(currentInterval);
            return result.ToArray();
        }

        public static bool CanAttendMeetings(List<Interval> intervals)
        {
            if (intervals.Count <= 1) return true;
            var minH = new PriorityQueue<Interval, int>();
            for (var i = 0; i < intervals.Count; i++)
                minH.Enqueue(intervals[i], intervals[i].start);
            var current = minH.Dequeue();
            while (minH.Count > 0)
            {
                var interval = minH.Dequeue();
                if (current.end > interval.start) return false;
                current = interval;
            }

            return true;
        }

        public static int MinMeetingRooms(List<Interval> intervals)
        {
            if (intervals.Count <= 1) return 1;
            var minH = new PriorityQueue<Interval, int>();
            for (var i = 0; i < intervals.Count; i++)
                minH.Enqueue(intervals[i], intervals[i].start);
            var current = minH.Dequeue();
            var answer = new List<List<Interval>>();
            while (minH.Count > 0)
            {
                var interval = minH.Dequeue();
                var list = new List<Interval>();

                while (minH.Count > 0 && current.end <= interval.start)
                {
                    list.Add(current);
                    current = interval;
                    interval = minH.Dequeue();
                }
                list.Add(current);
                answer.Add(list);
                current = interval;
            }

            return answer.Count;
        }

        public class Interval
        {
            public int start, end;
            public Interval(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }

        public static int[] MinInterval(int[][] intervals, int[] queries)
        {
            var res = new int[queries.Length];
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            //Array.Sort(queries);
            for (int i = 0; i < queries.Length; i++)
            {
                var q = queries[i];

                var minHeap = new PriorityQueue<int, int>();
                for (int j = 0; j < intervals.Length; j++)
                {
                    if ( intervals[j][0] <= q && q <= intervals[j][1])
                        minHeap.Enqueue(intervals[j][1] - intervals[j][0] + 1, intervals[j][1] - intervals[j][0] + 1);
                }
                if (minHeap.Count > 0)
                    res[i] = minHeap.Peek();
                else res[i] = -1;
            }
            return res;
        }


    }
}
