using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class Contests
    {
        public int SubarraySum(int[] nums)
        {
            int total = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int start = Math.Max(0, i - nums[i]);
                int sum = 0;
                for (int j = start; j <= i; j++)
                {
                    sum += nums[j];
                };

                total += sum;
            }
            return total;
        }

        public static long MinMaxSubarraySum(int[] nums, int k)
        {
            int right = 0;
            int left = 0;
            long min = nums[0];
            long max = nums[0];
            long result = 0;
            while (right < nums.Length)
            {
                while (right - left + 1 <= k)
                {
                    long sum = min + max;
                    result += sum;
                    right++;
                    if (right == nums.Length) break;
                    if (max < nums[right]) max = nums[right];
                    if (min > nums[right]) min = nums[right];

                }

                left++;
                right = left;
                if (left == nums.Length) break;
                if (max < nums[left]) max = nums[left];
                if (min > nums[left]) min = nums[left];
            }

            return result;
        }

        private static long FindMinMax(int left, int right, int[] nums)
        {
            long min = nums[left];
            long max = nums[left];
            for (int i = left; i <= right; i++)
            {
                if (nums[i] > max) max = nums[i];
                if (nums[i] < min) min = nums[i];
            };

            return min + max;
        }

        public static int CountPartitions(int[] nums)
        {
            int[] prefix = new int[nums.Length];
            int sum = nums[0];
            prefix[0] = sum;
            for (int i = 1; i < prefix.Length; i++)
            {
                sum += nums[i];
                prefix[i] = sum;

            }
            int result = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int left = prefix[i];
                int right = prefix[nums.Length - 1] - left;
                if ((left - right) % 2 == 0) result++;
            }

            return result;
        }

        public static int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
        {
            PriorityQueue<IList<string>, int> queue = new PriorityQueue<IList<string>, int>();
 
            for (int i = 0; i < events.Count; i++)
            {
                queue.Enqueue(events[i], Int32.Parse(events[i][1]));
            }

            var offline = new Dictionary<int, int>();
            var mentions = new int[numberOfUsers];

            while (queue.Count > 0)
            {
                var currentEvent = queue.Dequeue();
                string eventName = currentEvent[0];
                string eventTime = currentEvent[1];
                string eventMentions = currentEvent[2];
                switch (eventName)
                {
                    case "OFFLINE":
                        {
                            if (offline.ContainsKey(int.Parse(eventMentions)))
                                offline[int.Parse(eventMentions)] = int.Parse(eventTime);
                            else
                                offline.Add(int.Parse(eventMentions), int.Parse(eventTime));
                        };
                        break;
                    default:
                    case "MESSAGE":
                        {
                            if (eventMentions.Equals("ALL"))
                            {
                                for (int i = 0; i < mentions.Length; i++)
                                {
                                    mentions[i]++;
                                }
                            }
                            else if (eventMentions.Equals("HERE"))
                            {
                                for (int i = 0; i < mentions.Length; i++)
                                {
                                    if (!offline.ContainsKey(i))
                                        mentions[i]++;
                                    else if (offline[i] + 60 <= int.Parse(eventTime))
                                    {
                                        mentions[i]++;
                                        offline.Remove(i);
                                    }
                                }
                            }
                            else
                            {
                                int[] ids = GetId(eventMentions);
                                for (int i = 0; i < ids.Length; i++)
                                {
                                    if (!offline.ContainsKey(ids[i]))
                                        mentions[ids[i]]++;
                                    else if (offline[ids[i]] + 60 <= int.Parse(eventTime))
                                    {
                                        mentions[ids[i]]++;
                                        offline.Remove(ids[i]);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            return mentions;

        }

        private static int[] GetId(string s)
        {
            string[] result = s.Split(new string[] { "id" }, StringSplitOptions.None);
            List<int> arr = new List<int>();
            for (int i = 0; result != null && i < result.Length; i++)
            {
                if (result[i] != string.Empty)
                {
                    arr.Add(int.Parse(result[i]));
                }
            }

            return arr.ToArray();
        }

    }
}
