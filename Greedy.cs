using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class Greedy
    {
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            int max = nums[0];
            int temp = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {

                if (i == 0) max = nums[i];
                else
                {
                    temp = temp + nums[i];
                    if (temp < nums[i])
                    {
                        temp = nums[i];
                        max = Math.Max(max, temp);
                    }
                    max = Math.Max(max, Math.Max(temp, nums[i]));
                }

            }
            return max;
        }
        public static int MaxSubArray2(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            int max = nums[0];
            int temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {

                if (temp < 0) temp = 0;

                temp += nums[i];

                max = Math.Max(temp, max);

            }
            return max;
        }
        public static bool CanJump(int[] nums)
        {
            var memo = new Dictionary<int, bool>();
            return CanJumpHelper(0, nums, memo);
        }

        public static bool CanJumpHelper(int i, int[] nums, Dictionary<int, bool> memo)
        {
            if (i >= nums.Length - 1) return true;

            if (nums[i] == 0) return false;

            if (memo.ContainsKey(i)) return memo[i];

            int steps = nums[i];

            memo[i] = false;
            for (int j = 1; j <= steps; j++)
                if (CanJumpHelper(i + j, nums, memo)) memo[i] = true;
            return memo[i];
        }

        public static int Jump(int[] nums)
        {
            return JumpHelper(0, 0, nums);
        }

        public static int JumpHelper(int i, int count, int[] nums)
        {
            if (i >= nums.Length - 1) return count;

            int steps = nums[i];
            int min = int.MaxValue;
            for (int j = 1; j <= steps; j++)
                min = Math.Min(min, JumpHelper(i + j, count + 1, nums));
            return min;
        }

        public static int Jump2(int[] nums)
        {
            var memo = new Dictionary<(int, int), int>();
            return JumpHelperMemo(0, 0, nums, memo);
        }

        public static int JumpHelperMemo(int i, int count, int[] nums, Dictionary<(int, int), int> memo)
        {
            if (i >= nums.Length - 1) return count;
            if (memo.ContainsKey((i, count))) return memo[(i, count)];
            int steps = nums[i];
            int min = int.MaxValue;

            for (int j = 1; j <= steps; j++)
            {
                min = Math.Min(min, JumpHelperMemo(i + j, count + 1, nums, memo));
            }
            memo[(i, count)] = min;
            return memo[(i, count)];
        }

        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int[] diff = new int[gas.Length];

            for (int i = 0; i < gas.Length; i++)
                diff[i] = gas[i] - cost[i];
            int res = -1;
            for (int i = 0; i < diff.Length; i++)
            {
                int total = 0;
                if (diff[i] < 0) continue;
                int j = i + 1;
                total = diff[i];
                while (j % diff.Length != i)
                {
                    total += diff[j % diff.Length];
                    if (total < 0) break;
                    j++;
                }
                res = i;
                break;
            }

            return res;
        }

        public static bool CheckValidString(string s)
        {
            var memo = new Dictionary<(int, int), bool>();
            return CheckValidStringHelperMemo(0, 0, s, memo);
        }

        public static bool CheckValidStringHelper(int i, int open, string s)
        {
            if (open < 0) return false;

            if (i >= s.Length) return open == 0;

            if (s[i] == '(') return CheckValidStringHelper(i + 1, open + 1, s);

            else if (s[i] == ')') return CheckValidStringHelper(i + 1, open - 1, s);

            else
            {
                return (
                    CheckValidStringHelper(i + 1, open, s) ||
                    CheckValidStringHelper(i + 1, open + 1, s) ||
                    CheckValidStringHelper(i + 1, open - 1, s));
            }
        }
        public static bool CheckValidStringHelperMemo(int i, int open, string s, Dictionary<(int, int), bool> memo)
        {
            if (open < 0) return false;

            if (i >= s.Length) return open == 0;

            if (memo.ContainsKey((i, open))) return memo[(i, open)];

            if (s[i] == '(')
            {
                memo[(i, open)] = CheckValidStringHelperMemo(i + 1, open + 1, s, memo);
            }
            else if (s[i] == ')')
            {
                memo[(i, open)] = CheckValidStringHelperMemo(i + 1, open - 1, s, memo);
            }

            else
            {
                memo[(i, open)] = (
                    CheckValidStringHelperMemo(i + 1, open, s, memo) ||
                    CheckValidStringHelperMemo(i + 1, open + 1, s, memo) ||
                    CheckValidStringHelperMemo(i + 1, open - 1, s, memo));
            }

            return memo[(i, open)];

        }

        public static bool IsNStraightHand(int[] hand, int groupSize)
        {
            if (hand.Length % groupSize != 0) return false;
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            Dictionary<int, int> count = new Dictionary<int, int>();
            for (int i = 0; i < hand.Length; i++)
            {
                queue.Enqueue(hand[i], hand[i]);

                if (!count.ContainsKey(hand[i])) count.Add(hand[i], 1);
                else count[hand[i]]++;
            }
            var ans = new List<List<int>>();
            while (queue.Count > 0)
            {
                var list = new List<int>();
                var min = queue.Peek();
                for (int i = min; i < groupSize; i++)
                {
                    if (!count.ContainsKey(i)) return false;
                    else
                    {
                        count[i]--;
                        if (count[i] == 0)
                        {
                            if (i != queue.Peek()) return false;
                            list.Add(queue.Dequeue());
                        }
                    }
                }
                ans.Add(list);
            }

            return true;
        }

        public static List<int> PartitionLabels(string s)
        {
            var lastIndex = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!lastIndex.ContainsKey(s[i]))
                    lastIndex.Add(s[i], i);
                else lastIndex[s[i]] = i;
            }
            List<int> answer = new List<int>();
            int size = 0; int end = lastIndex[s[0]];
            for (int i = 0; i < s.Length; i++)
            {
                var lastInd = lastIndex[s[i]];
                size++;
                end = Math.Max(end, lastInd);
                if (i == end)
                {
                    answer.Add(size);
                    size = 0;
                }

            }
            return answer;
        }

        public static bool MergeTriplets(int[][] triplets, int[] target)
        {
            int max0 = triplets[0][0], max1 = triplets[0][1], max2 = triplets[0][2];
            for (int i = 0; i < triplets.Length; i++)
            {
                if (triplets[i][0] > target[0] || triplets[i][1] > target[1] || triplets[i][2] > target[2]) continue;

                max0 = Math.Max(max0, triplets[i][0]);
                max1 = Math.Max(max1, triplets[i][1]);
                max2 = Math.Max(max2, triplets[i][2]);
            }

            return (max0 == target[0] && max1 == target[1] && max2 == target[2]);
        }
    }
}
