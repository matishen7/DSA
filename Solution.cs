using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.TreeProblems;

namespace Neetcode150
{
    class Solution
    {
        public static int[] ArrayOfArrayProducts(int[] arr)
        {
            Stack<char> stack = new Stack<char>();
            var prefix = new int[arr.Length];
            var postfix = new int[arr.Length];
            var result = new int[arr.Length];
            int pre = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                prefix[i] = pre * arr[i];
                pre = prefix[i];
            }
            int post = 1;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                postfix[i] = post * arr[i];
                post = postfix[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    result[i] = postfix[i + 1];
                }
                else if (i == arr.Length - 1)
                {
                    result[i] = prefix[i - 1];
                }
                else
                {
                    result[i] = prefix[i - 1] * postfix[i + 1];
                }
            }
            return result;
        }

        public static int ShipWithinDays(int[] weights, int days)
        {
            int max = 0;
            int sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                max = Math.Max(max, weights[i]);
                sum += weights[i];
            }

            int[] possibleCapacity = new int[sum - max + 1];

            int m = max;
            for (int i = 0; i < possibleCapacity.Length; i++)
            {
                possibleCapacity[i] = m;
                m++;
            }
            int left = 0;
            int right = possibleCapacity.Length - 1;
            int result = sum;

            while (left < right)
            {
                int mid = (left + right) / 2;
                int possibleDays = CalculateDays(possibleCapacity[mid], days, weights);
                if (possibleDays <= days)
                {
                    result = Math.Min(result, possibleCapacity[mid]);
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }

        private static int CalculateDays(int possibleCapacity, int targetDays, int[] weights)
        {
            int days = 1;
            int sum = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                if (sum + weights[i] <= possibleCapacity)
                {
                    sum += weights[i];
                }
                else
                {
                    days++;
                    sum = weights[i];
                }
            }

            return days;
        }

        public static bool Search(int[] nums, int target)
        {
            var pivot = FindPivot(nums);
            int left = 0;
            int right = pivot;
            int result = BinarySearch(nums, target, left, right);
            if (result != -1)
            {
                return true;
            }

            left = pivot + 1;
            right = nums.Length - 1;
            result = BinarySearch(nums, target, left, right);
            if (result != -1)
            {
                return true;
            }

            return false;
        }

        private static int BinarySearch(int[] nums, int target, int left, int right)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        private static int FindPivot(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    return i;
                }
            }

            return nums.Length - 1;
        }

        public static int SplitArray(int[] nums, int k)
        {
            int sum = 0;
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(nums[i], max);
                sum += nums[i];
            }

            int left = max, right = sum, result = sum;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int posK = CalculateSplits(mid, nums);
                if (posK <= k)
                {
                    result = Math.Min(result, mid);
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return result;

        }

        private static int CalculateSplits(int p, int[] nums)
        {
            int days = 1;
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (sum + nums[i] <= p)
                {
                    sum += nums[i];
                }
                else
                {
                    days++;
                    sum = nums[i];
                }
            }

            return days;
        }

        class MountainArray
        {
            private int[] arr;
            public MountainArray()
            {
                arr = new int[]
                {
                    1,2,3,4,5,3,1
                };
            }
            public int Get(int index)
            {
                return arr[index];
            }
            public int Length()
            {
                return arr.Length;
            }
        }

        public static int[] ReplaceElements(int[] arr)
        {
            int max = arr[arr.Length - 1];
            arr[arr.Length - 1] = -1;

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                int temp = arr[i];
                arr[i] = max;
                if (temp > max)
                {
                    max = temp;
                }

            }
            return arr;
        }

        public static int NumUniqueEmails(string[] emails)
        {
            var set = new HashSet<string>();
            for (int i = 0; i < emails.Length; i++)
            {
                var email = emails[i];
                var parts = email.Split('@');
                StringBuilder result1 = new StringBuilder();
                for (int j = 0; j < parts[0].Length; j++)
                {
                    if (parts[0][j] == '.') continue;
                    else if (parts[0][j] == '+') break;
                    else result1.Append(parts[0][j]);
                }

                set.Add(result1.ToString() + '@' + parts[1]);
            }

            return set.Count;
        }

        public static bool IsIsomorphic(string s, string t)
        {
            var set = new HashSet<char>();
            var map = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    map.Add(s[i], t[i]);
                    set.Add(t[i]);
                }
                else
                {
                    if (map[s[i]] != t[i])
                        return false;
                }
            }
            if (set.Count != map.Count) return false;
            return true;
        }

        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var adjList = new Dictionary<string, List<string>>();

            foreach (var word in wordList)
            {
                if (InterWord(beginWord, word))
                    if (adjList.ContainsKey(beginWord)) adjList[beginWord].Add(word);
                    else adjList[beginWord] = new List<string>() { word };

                if (InterWord(endWord, word))
                    if (adjList.ContainsKey(endWord)) adjList[endWord].Add(word);
                    else adjList[endWord] = new List<string>() { word };
            }

            foreach (var word in wordList)
            {
                foreach (var word2 in wordList)
                {
                    if (InterWord(word, word2))
                        if (adjList.ContainsKey(word)) adjList[word].Add(word2);
                        else adjList[word] = new List<string>() { word2 };
                }

            }


            var queue = new Queue<(string word, int depth)>();
            queue.Enqueue((beginWord, 1));
            var visit = new HashSet<string>();

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.word.Equals(endWord)) return current.depth;
                visit.Add(current.word);

                foreach (var nei in adjList[current.word])
                {
                    if (!visit.Contains(nei))
                        queue.Enqueue((nei, current.depth + 1));
                }

            }

            return 0;
        }

        private static bool InterWord(string word, string endWord)
        {
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != endWord[i]) count++;
                if (count >= 2) return false;
            }

            return true;
        }

        public static List<int> Diff(int[] arrA, int[] arrB)
        {
            var setA = new HashSet<int>(arrA);
            var setB = new HashSet<int>(arrB);

            var diff = new List<int>();
            for (int i = 0; i < arrA.Length; i++)
            {
                if (!setB.Contains(arrA[i])) diff.Add(arrA[i]);
            }
            for (int i = 0; i < arrB.Length; i++)
            {
                if (!setA.Contains(arrB[i])) diff.Add(arrB[i]);
            }

            return diff;
        }

        public static int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var current = intervals[0];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (current[1] < intervals[i][0])
                {
                    result.Add(current);
                    current = intervals[i];
                }
                else
                {
                    int start = Math.Min(current[0], intervals[i][0]);
                    int end = Math.Max(current[1], intervals[i][1]);
                    current = new int[2] { start, end };
                }
            }
            result.Add(current);
            return result.ToArray();
        }

        public static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int[] flowerbed2 = new int[flowerbed.Length + 2];

            for (int i = 0; i < flowerbed.Length; i++)
                flowerbed2[i + 1] = flowerbed[i];

            for (int i = 1; i < flowerbed2.Length - 1; i++)
            {

                if (flowerbed2[i] == 0 && flowerbed2[i - 1] == 0 && flowerbed2[i + 1] == 0)
                {
                    n--;
                    flowerbed2[i] = 1;
                }
            }

            return n <= 0;
        }

        public static int MaxNumberOfBalloons(string text)
        {
            var dic = new Dictionary<char, int>();
            dic.Add('b', 0);
            dic.Add('a', 0);
            dic.Add('l', 0);
            dic.Add('o', 0);
            dic.Add('n', 0);
            for (int i = 0; i < text.Length; i++)
            {
                if (dic.ContainsKey(text[i])) dic[text[i]]++;
            }

            dic['l'] = dic['l'] / 2;
            dic['o'] = dic['o'] / 2;
            int max = int.MaxValue;
            foreach (var pair in dic)
            {
                max = Math.Min(max, pair.Value);
            }

            return (max == int.MaxValue) ? 0 : max;
        }

        public static bool WordPattern(string pattern, string s)
        {
            var words = s.Split(' ');
            if (words.Length != pattern.Length) return false;
            var map = new Dictionary<char, string>();
            var map2 = new Dictionary<string, char>();
            int i = 0;
            foreach (var letter in pattern)
            {
                if (!map.ContainsKey(letter))
                {
                    map.Add(letter, words[i]);
                    if (map2.ContainsKey(words[i])) return false; else map2.Add(words[i], letter);
                }
                else
                {
                    var expectedWord = map[letter];
                    if (!expectedWord.Equals(words[i])) return false;
                    var expectedLetter = map2[expectedWord];
                    if (expectedLetter != letter) return false;
                }
                i++;
            }
            return true;
        }

        public static bool IsMonotonic(int[] nums)
        {
            if (nums.Length <= 1) return true;
            int[] diff = new int[nums.Length - 1];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                diff[i] = nums[i + 1] - nums[i];
            }

            bool minus = false;
            bool plus = false;

            for (int i = 0; i < diff.Length; i++)
            {
                if (diff[i] > 0) plus = true;
                if (diff[i] < 0) minus = true;

                if (minus && plus) return false;
            }

            return true;

        }

        public static int CountCharacters(string[] words, string chars)
        {
            int sum = 0;
            var dic = new Dictionary<char, int>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!dic.ContainsKey(chars[i]))
                    dic.Add(chars[i], 1);
                else dic[chars[i]]++;
            }
            for (int i = 0; i < words.Length; i++)
            {
                if (CanBeFormed(words[i], dic)) sum += words[i].Length;
            }
            return sum;
        }

        private static bool CanBeFormed(string word, Dictionary<char, int> dic)
        {
            var map = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (!map.ContainsKey(word[i]))
                    map.Add(word[i], 1);
                else map[word[i]]++;
            }

            foreach (var pair in map)
            {
                var cc = pair.Key;
                var count = pair.Value;

                if (!dic.ContainsKey(cc)) return false;
                else if (dic[cc] < count) return false;
            }
            return true;
        }

        public static IList<string> FindRepeatedDnaSequences(string s)
        {
            if (s.Length <= 10)
                return new List<string>();

            var list = new List<string>();
            var count = new Dictionary<string, int>();
            for (int i = 0; i < s.Length - 10 + 1; i++)
            {
                var sub = s.Substring(i, 10);
                if (count.ContainsKey(sub)) count[sub]++;
                else count.Add(sub, 1);
            }

            foreach (var pair in count)
            {
                if (count[pair.Key] > 1) list.Add(pair.Key);
            }

            return list;
        }

        public static bool CheckSubarraySum(int[] nums, int k)
        {
            if (nums.Length <= 1) return false;

            var map = new Dictionary<int, int>();
            map.Add(0, -1);
            int total = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                total += nums[i];
                int r = total % k;
                if (!map.ContainsKey(r)) map.Add(r, i);
                else if (i - map[r] > 1) return true;
            }
            return false;
        }

        public static string identifyAdjacent(string s, int k)
        {
            Stack<(char cc, int count)> stack = new Stack<(char, int)>();
            for (int i = 0; i < s.Length; i++)
            {
                char cc = s[i];
                if (stack.Count == 0) stack.Push((cc, 1));
                else if (stack.Peek().cc != cc) stack.Push((cc, 1));
                else
                {
                    if (stack.Peek().count == k - 1) stack.Pop();
                    else
                    {
                        var current = stack.Pop();
                        stack.Push((current.cc, current.count + 1));
                    }
                }
            }
            string result = string.Empty;
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                for (int i = 0; i < current.count; i++)
                    result = current.cc + result;
            }

            return result;
        }

        public static int[] FindLargest(int[] input, int m)
        {
            var maxheap = new PriorityQueue<int, int>();
            for (int i = 0; i < input.Length; i++)
                maxheap.Enqueue(input[i], -input[i]);

            var answer = new List<int>();
            for (int i = 1; i <= m; i++)
                answer.Insert(0, maxheap.Dequeue());

            return answer.ToArray();
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            int[] answer = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (map.ContainsKey(diff))
                {
                    answer[0] = map[diff];
                    answer[1] = i;
                    return answer;
                }
                else if (!map.ContainsKey(nums[i])) map.Add(nums[i], i);
            }

            return answer;
        }

        public static List<int> TwoSum2(int from, int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            var answer = new List<int>();

            for (int i = from; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (map.ContainsKey(diff))
                {
                    answer.Add(diff);
                    answer.Add(nums[i]);
                    return answer;
                }
                else if (!map.ContainsKey(nums[i])) map.Add(nums[i], i);
            }

            return answer;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var ans = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = -nums[i];
                var twoSumList = TwoSum2(i + 1, nums, diff);
                if (twoSumList.Count > 0)
                {
                    twoSumList.Add(nums[i]);
                    ans.Add(twoSumList);
                }
                //while (i < nums.Length - 1 && nums[i] == nums[i + 1]) i++;
            }

            return ans;

        }

        public int RangeSumBST(TreeNode root, int low, int high)
        {
            int sum = 0;

            RangeSumBSTHelper(root, low, high, ref sum);

            return sum;
        }

        public void RangeSumBSTHelper(TreeNode root, int low, int high, ref int sum)
        {
            if (root == null) return;

            if (root.val >= low && root.val <= high) sum += root.val;

            RangeSumBSTHelper(root.left, low, high, ref sum);
            RangeSumBSTHelper(root.right, low, high, ref sum);

        }

        public static int CountVowelSubstrings(string word)
        {
            var set = new HashSet<char>() { 'a','o','i','e','u'};
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (!set.Contains(word[i])) continue;
                int start = i;
                var dic = new Dictionary<char, int>();
                dic.Add('a', 0);
                dic.Add('o', 0);
                dic.Add('i', 0);
                dic.Add('e', 0);
                dic.Add('u', 0);
                while (start < word.Length && set.Contains(word[start]))
                {
                    dic[word[start]]++;
                    if (checkVowels(dic)) count++;
                    start++;
                }
            }

            return count;
        }

        public static bool checkVowels(Dictionary<char, int> dic)
        {
            if (dic['a'] >= 1 
                && dic['o'] >=1
                && dic['e'] >=1
                && dic['u'] >=1
                && dic['i'] >=1
                ) return true;
            return false;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            var minHeap = new PriorityQueue<int , int>();
            for (int i = 0; i < lists.Length; i++)
            {
                var head = lists[i];
                var current = head;
                while (current != null)
                {
                    minHeap.Enqueue(current.val, current.val);
                    current = current.next;
                }
            }

            var dummy = new ListNode(0);
            var prev = dummy;
            while (minHeap.Count > 0)
            {
                var value = minHeap.Dequeue();
                var newNode =  new ListNode(value);
                prev.next = newNode;
                prev = prev.next;
            }

            return dummy.next;
        }

        public static int FindBusiestPeriod(int[,] data)
        {
            int total = data[0, 1];
            int max = data[0, 1];
            int time = data[0, 0];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                int currTime = data[i, 0];
                int people = data[i, 1];
                int enter = data[i, 2];
                if (enter == 1)
                    total += people;
                else total -= people;
                if (max <= total)
                {
                    max = total;
                    time = currTime;
                }
            }

            return time;
        }

    }
}

