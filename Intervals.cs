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

    }
}
