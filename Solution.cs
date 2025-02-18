using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int[] diff  = new int[nums.Length - 1];
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
    }
}

