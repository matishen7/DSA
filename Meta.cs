using Neetcode150.ObjectOriented.ConnectFour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.TreeProblems;

namespace Neetcode150
{

    public class Meta
    {
        public string MinRemoveToMakeValid(string s)
        {
            int open = 0;
            int close = 0;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(')
                {
                    result.Append(c);
                    open++;
                }
                else if (c == ')')
                {
                    if (open >= close + 1)
                    {
                        result.Append(c);
                        close++;
                    }
                }
                else result.Append(c);
            }
            StringBuilder answer = new StringBuilder();
            open = 0;
            close = 0;
            for (int i = result.Length - 1; i >= 0; i--)
            {
                char c = result[i];
                if (c == ')')
                {
                    answer.Insert(0, c);
                    close++;
                }
                else if (c == '(')
                {
                    if (close >= open + 1)
                    {
                        answer.Insert(0, c);
                        open++;
                    }
                }
                else answer.Insert(0, c);
            }
            return answer.ToString();
        }
        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals.Length == 1) return true;
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var current = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
                var start = intervals[i][0];
                var end = intervals[i][1];
                if (current[1] > start) return false;
                else current = intervals[i];
            }

            return true;
        }
        public static int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 1) return 1;
            var minHeap = new PriorityQueue<int, int>();
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            for (int i = 0; i < intervals.Length; i++)
            {
                if (minHeap.Count != 0 && minHeap.Peek() <= intervals[i][0])
                    minHeap.Dequeue();
                minHeap.Enqueue(intervals[i][1], intervals[i][1]);
            }

            return minHeap.Count;
        }
        public static int ClosestValue(TreeNode root, double target)
        {
            int result = root.val;
            double currDiff = int.MaxValue;
            ClosestValueDFS(root, target, ref result, ref currDiff);
            return result;
        }

        public static void ClosestValueDFS(TreeNode root, double target, ref int result, ref double currDiff)
        {
            if (root == null) return;

            double diff = Math.Abs(target - root.val);

            if (diff < currDiff)
            {
                result = root.val;
                currDiff = diff;
            }
            else if (diff == currDiff)
                result = Math.Min(result, root.val);

            ClosestValueDFS(root.left, target, ref result, ref currDiff);
            ClosestValueDFS(root.right, target, ref result, ref currDiff);
        }
        public static int LongestOnes(int[] nums, int k)
        {
            int left = 0;
            int right = 0;
            int zeros = 0;
            int max = 0;
            while (right < nums.Length)
            {
                if (nums[right] == 0) zeros++;

                while (zeros > k)
                {
                    if (nums[left] == 0)
                        zeros--;
                    left++;
                }

                max = Math.Max(max, right - left + 1);
                right++;
            }
            return max;
        }
        public static int FindMaxConsecutiveOnes2(int[] nums)
        {
            int left = 0;
            int right = 0;
            int zeros = 0;
            int max = 0;
            while (right < nums.Length)
            {
                if (nums[right] == 0) zeros++;

                while (zeros == 2)
                {
                    if (nums[left] == 0)
                        zeros--;
                    left++;
                }

                max = Math.Max(max, right - left + 1);
                right++;
            }
            return max;
        }
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0;
            int curr = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) curr++;
                else
                {
                    max = Math.Max(max, curr);
                    curr = 0;
                }
            }
            max = Math.Max(max, curr);
            return max;
        }
        public static long KthLargestLevelSum(TreeNode root, int k)
        {
            var maxHeap = new PriorityQueue<long, long>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int currSum = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    var currNode = queue.Dequeue();
                    currSum += currNode.val;

                    if (currNode.left != null) queue.Enqueue(currNode.left);
                    if (currNode.right != null) queue.Enqueue(currNode.right);
                }
                maxHeap.Enqueue(currSum, -currSum);
                currSum = 0;
            }
            if (k > maxHeap.Count) return -1;
            for (int i = 0; i < k - 1; i++)
            {
                maxHeap.Dequeue();
            }
            return maxHeap.Dequeue();
        }
        public static int[] FindDiagonalOrder(IList<IList<int>> nums)
        {
            var result = new List<int>();
            int n = nums.Count;
            var queue = new Queue<(int row, int col)>();
            queue.Enqueue((0, 0));
            var visit = new HashSet<(int, int)>();
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                result.Add(nums[curr.row][curr.col]);

                if (!visit.Contains((curr.row + 1, curr.col)) && curr.col == 0 && curr.row + 1 < n)
                {
                    queue.Enqueue((curr.row + 1, curr.col));
                    visit.Add((curr.row + 1, curr.col));
                }
                if (!visit.Contains((curr.row, curr.col + 1)) && curr.col + 1 < nums[curr.row].Count)
                {
                    queue.Enqueue((curr.row, curr.col + 1));
                    visit.Add((curr.row, curr.col + 1));
                }
            }

            return result.ToArray();
        }
        public static int CalculateDFS(string s)
        {
            int currNum = 0;
            char operation = '+';
            int result = 0;
            var stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    currNum = (currNum * 10) + (s[i] - '0');
                }
                if (!Char.IsDigit(s[i]) && s[i] != ' ' || i == s.Length - 1)
                {
                    if (operation == '+')
                        stack.Push(currNum);
                    else if (operation == '-')
                        stack.Push(-currNum);
                    else if (operation == '*')
                    {
                        var last = stack.Pop();
                        stack.Push(currNum * last);
                    }
                    else if (operation == '/')
                    {
                        var last = stack.Pop();
                        stack.Push(last / currNum);
                    }
                    operation = s[i];
                    currNum = 0;
                }
            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
        public static IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            var adjList = new Dictionary<int, List<int>>();
            DistanceKDfs(root, -1, adjList);

            var answer = new List<int>();
            var queue = new Queue<(int val, int depth)>();
            queue.Enqueue((target.val, 0));
            var visited = new HashSet<int>();
            visited.Add(target.val);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (k == curr.depth && curr.val != -1) answer.Add(curr.val);

                foreach (var nei in adjList[curr.val])
                {
                    if (!visited.Contains(nei))
                    {
                        queue.Enqueue((nei, curr.depth + 1));
                        visited.Add(nei);
                    }
                }

            }

            return answer;
        }
        public static void DistanceKDfs(TreeNode root, int parent, Dictionary<int, List<int>> adjList)
        {
            if (root == null)
                return;
            if (adjList.ContainsKey(parent))
            {
                adjList[parent].Add(root.val);

                if (adjList.ContainsKey(root.val)) adjList[root.val].Add(parent);
                else adjList[root.val] = new List<int>() { parent };
            }
            else
            {
                adjList[parent] = new List<int>() { root.val };

                if (adjList.ContainsKey(root.val)) adjList[root.val].Add(parent);
                else adjList[root.val] = new List<int>() { parent };
            }
            DistanceKDfs(root.left, root.val, adjList);
            DistanceKDfs(root.right, root.val, adjList);
        }
        public static bool IsNumber(string s)
        {
            bool seenDigit = false, seenDot = false, seenExp = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i])) seenDigit = true;
                else if (s[i] == '+' || s[i] == '-')
                {
                    if (i == 0) continue;
                    if (s[i - 1] == 'E' || s[i - 1] == 'e') continue;
                    return false;
                }
                else if (s[i] == 'e' || s[i] == 'E')
                {
                    if (seenExp || seenDigit == false) return false;
                    seenDigit = false;
                    seenExp = true;
                }
                else if (s[i] == '.')
                {
                    if (seenDot || seenExp) return false;
                    seenDot = true;
                }
                else return false;
            }

            return seenDigit;
        }

        public static int SumNumbers(TreeNode root)
        {
            return SumNumbersDfs(root, 0);
        }

        private static int SumNumbersDfs(TreeNode root, int currSum)
        {
            if (root == null)
                return 0;

            currSum = currSum * 10 + root.val;

            // If it's a leaf node, return the current sum.
            if (root.left == null && root.right == null)
                return currSum;

            // Recursive sum of left and right subtrees.
            return SumNumbersDfs(root.left, currSum) + SumNumbersDfs(root.right, currSum);
        }

        public static int[] FindBuildings(int[] heights)
        {
            var result = new List<int>();
            int n = heights.Length;
            int max = heights[n - 1];
            result.Add(n - 1);
            for (int i = n - 2; i >= 0; i--)
            {
                if (heights[i] > max)
                {
                    result.Insert(0, i);
                    max = heights[i];
                }
            }

            return result.ToArray();
        }
        public static bool IsToeplitzMatrix(int[][] matrix)
        {
            int ROWS = matrix.Length;
            int COLS = matrix[0].Length;
            if (ROWS == 1) return true;

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));
            var visited = new HashSet<(int, int)>();
            visited.Add((0, 0));
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                if (row - 1 >= 0 && col - 1 >= 0)
                    if (matrix[row - 1][col - 1] != matrix[row][col]) return false;
                if (row + 1 < ROWS && col + 1 < COLS)
                    if (matrix[row + 1][col + 1] != matrix[row][col]) return false;

                if (row + 1 < ROWS && !visited.Contains((row + 1, col)))
                {
                    queue.Enqueue((row + 1, col));
                    visited.Add((row + 1, col));
                }
                if (col + 1 < COLS && !visited.Contains((row, col + 1)))
                {
                    queue.Enqueue((row, col + 1));
                    visited.Add((row, col + 1));
                }
            }
            return true;
        }

        private static List<(int, int)> GetDirections()
        {
            List<(int r, int c)> directions = new List<(int, int)>();
            directions.Add((-1, -1));
            directions.Add((-1, 0));
            directions.Add((-1, 1));
            directions.Add((0, -1));
            directions.Add((0, 1));
            directions.Add((1, -1));
            directions.Add((1, 0));
            directions.Add((1, 1));

            return directions;
        }
        public static int FindKthPositiveBF(int[] arr, int k)
        {
            var set = new HashSet<int>(arr);
            int count = 0;
            int max = int.MaxValue;
            for (int i = 1; i <= max; i++)
            {
                if (!set.Contains(i))
                {
                    count++;
                    if (count == k) return i;
                }
            }
            return max;
        }

        public static int FindKthPositive(int[] arr, int k)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] - mid - 1 < k)
                    left = mid + 1;
                else right = mid - 1;
            }

            return left + k;
        }
        public static int[] NextPermutation(int[] num)
        {
            int n = num.Length;
            int swap1 = -1;
            int swap2 = -1;
            int maxIndex = n - 1;

            for (int i = n - 2; i >= 0; i--)
            {
                if (num[i] < num[i + 1])
                {
                    swap1 = i;
                    int max = num[i];
                    for (int j = n - 1; j > swap1; j--)
                    {
                        if (num[j] > max)
                        {
                            //max = num[j];
                            swap2 = j;
                            break;
                        }
                    }

                    int temp = num[swap1];
                    num[swap1] = num[swap2];
                    num[swap2] = temp;

                    SortArr(num, swap1 + 1, n - 1);
                    break;
                }
            }

            int h = n - 1;
            if (swap1 == -1 && swap2 == -1)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    int temp = num[i];
                    num[i] = num[h];
                    num[h] = temp;
                    h--;
                }
            }

            return num;
        }

        public static void SortArr(int[] arr, int start, int end)
        {
            for (int write = start; write <= end; write++)
            {
                for (int sort = start; sort <= end - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        int temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
                Console.Write("{0} ", arr[write]);
            }
        }
        public static double MyPow(double x, int n)
        {
            return MyPowDfs(x, n);
        }

        public static double MyPowDfs(double x, int n)
        {
            if (n == 0) return 1;
            if (n < 0) return 1 / MyPowDfs(x, -n);
            if (n % 2 == 1)
                return x * MyPowDfs(x * x, (n - 1) / 2);
            else return MyPowDfs(x * x, n / 2);
        }

        public static int LossyAbs(int value)
        {
            if (value >= 0) return value;
            if (value == int.MinValue) return int.MaxValue;
            return -value;
        }

        public static int[] FindDiagonalOrder(int[][] mat)
        {
            if (mat == null || mat.Length == 0 || mat[0].Length == 0)
                return new int[0];

            int m = mat.Length, n = mat[0].Length;
            int[] result = new int[m * n];
            int i = 0, j = 0, index = 0;
            bool up = true;  // Direction flag: true -> up-right, false -> down-left

            while (index < m * n)
            {
                result[index++] = mat[i][j];

                if (up)
                {
                    if (j == n - 1) // If we reach the last column, move down
                    {
                        i++;
                        up = false;
                    }
                    else if (i == 0) // If we reach the first row, move right
                    {
                        j++;
                        up = false;
                    }
                    else
                    {
                        i--;
                        j++;
                    }
                }
                else
                {
                    if (i == m - 1) // If we reach the last row, move right
                    {
                        j++;
                        up = true;
                    }
                    else if (j == 0) // If we reach the first column, move down
                    {
                        i++;
                        up = true;
                    }
                    else
                    {
                        i++;
                        j--;
                    }
                }
            }

            return result;
        }

        public static string CustomSortString(string order, string s)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i])) dict[s[i]]++;
                else dict.Add(s[i], 1);
            }

            var sb = new StringBuilder();
            for (int i = 0; i < order.Length; i++)
            {
                if (dict.ContainsKey(order[i]))
                {
                    var times = dict[order[i]];
                    for (int j = 1; j <= times; j++)
                    {
                        sb.Append(order[i]);
                        dict[order[i]]--;
                    }
                }
            }

            foreach (var pair in dict)
            {
                var times = pair.Value;
                for (int j = 1; j <= times; j++)
                {
                    sb.Append(pair.Key);
                }
            }

            return sb.ToString();
        }
        public static int[] SearchRange(int[] nums, int target)
        {
            int[] range = { -1, -1 };
            var firstPos = BinarySearch(nums, target, 0, nums.Length - 1);
            if (firstPos == -1) return range;
            int startPos = firstPos, endPos = firstPos, temp1 = 0, temp2 = 0;
            while (startPos != -1)
            {
                temp1 = startPos;
                startPos = BinarySearch(nums, target, 0, startPos - 1);
            }
            startPos = temp1;

            while (endPos != -1)
            {
                temp2 = endPos;
                endPos = BinarySearch(nums, target, endPos + 1, nums.Length - 1);
            }
            endPos = temp2;

            range[0] = startPos;
            range[1] = endPos;

            return range;
        }

        public static int BinarySearch(int[] nums, int target, int start, int end)
        {
            int left = start;
            int right = end;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] <= target)
                    left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }

        public static string SimplifyPath(string path)
        {
            var stack = new Stack<string>();
            var paths = path.Split("/");
            foreach (var curr in paths)
            {
                if (curr.Equals(".."))
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else if (curr != string.Empty && !curr.Equals(".")) stack.Push(curr);
            }

            if (stack.Count == 0) return "/";
            var result = new StringBuilder();
            while (stack.Count > 0)
            {
                var curr = stack.Pop();
                result.Insert(0, "/" + curr);
            }
            return result.ToString();
        }
        public static bool ValidWordAbbreviation(string word, string abbr)
        {
            int i = 0;
            int j = 0;
            var digits = new HashSet<int>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            while (i < abbr.Length && j < word.Length)
            {
                if (!digits.Contains(abbr[i]))
                {
                    if (abbr[i] != word[j]) return false;
                    i += 1;
                    j += 1;
                }
                else
                {
                    var sb = new StringBuilder();
                    while (i < abbr.Length && digits.Contains(abbr[i]))
                    {
                        sb.Append(abbr[i]);
                        i += 1;
                    }
                    if (sb[0] == '0') return false;
                    var times = int.Parse(sb.ToString());
                    for (int k = 1; k <= times; k++)
                        j += 1;
                }
            }
            if (j == word.Length && i == abbr.Length) return true;
            return false;
        }
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return LowestCommonAncestorDfs(root, p, q);
        }

        public static TreeNode LowestCommonAncestorDfs(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q) return root;

            var l = LowestCommonAncestorDfs(root.left, p, q);
            var r = LowestCommonAncestorDfs(root.right, p, q);

            if (l != null && r != null) return root;

            else if (l == null) return r;
            else return l;
        }

        public static int MaximumSwap(int num)
        {
            int maxIndex = -1, swap1 = -1, swap2 = -1;
            char[] nums = num.ToString().ToCharArray();
            int n = nums.Length;

            for (int i = n - 1; i >= 0; i--)
            {
                if (maxIndex == -1 || nums[i] > nums[maxIndex])
                {
                    maxIndex = i;
                }
                else if (nums[i] < nums[maxIndex])
                {
                    swap1 = i;
                    swap2 = maxIndex;
                }
            }

            if (swap1 != -1 && swap2 != -1)
            {
                char temp = nums[swap1];
                nums[swap1] = nums[swap2];
                nums[swap2] = temp;
            }
            return int.Parse(new String(nums));
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int last = m + n - 1;
            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] > nums2[n - 1])
                {
                    nums1[last] = nums1[m - 1];
                    m -= 1;
                }
                else
                {
                    nums1[last] = nums2[n - 1];
                    n -= 1;
                }

                last -= 1;
            }

            while (n > 0)
            {
                nums1[last] = nums2[n - 1];
                n -= 1;
                last -= 1;
            }
        }

        public int[][] Merge(int[][] intervals)
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

        public int[][] Merge2(int[][] intervals, int[][] intervals2)
        {
            var merged = Merge(intervals);
            var merged2 = Merge(intervals2);
            var result = new List<int[]>();
            for (int i = 0; i < merged.Length; i++)
            {
                if (merged[i][1] < merged2[i][0])
                {
                    result.Add(merged[i]);
                }
                else
                {
                    int start = Math.Min(merged[i][0], merged2[i][0]);
                    int end = Math.Max(merged[i][1], merged2[i][1]);
                    var current = new int[2] { start, end };
                    result.Add(current);
                }
            }

            return result.ToArray();
        }

        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sum += nums[i];
            if (sum % 2 == 1) return false;

            int c = sum / 2;
            var memo = new Dictionary<(int, int), bool>();
            var r = CanPartitionHelper(0, nums, c, memo);
            return r;
        }

        public static bool CanPartitionHelper(int i, int[] nums, int c, Dictionary<(int, int), bool> memo)
        {
            if (c == 0) return true;  // Base case: subset sum found
            if (i == nums.Length || c < 0) return false;  // No more elements or invalid sum

            if (memo.TryGetValue((i, c), out bool result)) return result;

            // Try including nums[i] first for early exit
            result = CanPartitionHelper(i + 1, nums, c - nums[i], memo) ||
                     CanPartitionHelper(i + 1, nums, c, memo);

            memo[(i, c)] = result;
            return result;

        }
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(0, head);
            var fast = dummy.next;
            var slow = dummy;

            while (n > 0)
            {
                n--;
                fast = fast.next;
            }

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;
            return dummy.next;
        }
        public static int[] moveZerosToEnd(int[] arr)
        {
            if (arr.Length < 2) return arr;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[count] = arr[i];
                    count++;
                }
            }

            for (int i = count; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            return arr;
        }

        public static int getMaximumEatenDishCount(int N, int[] D, int K)
        {
            HashSet<int> lastKDishes = new HashSet<int>(); // Tracks last K dishes
            Queue<int> queue = new Queue<int>(); // Maintains order of last K dishes
            int count = 0;

            for (int i = 0; i < N; i++)
            {
                if (!lastKDishes.Contains(D[i]))
                {
                    count++;
                    queue.Enqueue(D[i]);
                    lastKDishes.Add(D[i]);

                    if (queue.Count > K)
                    {
                        int removedDish = queue.Dequeue();
                        lastKDishes.Remove(removedDish);
                    }
                }
            }
            return count;
        }

        public long getMinCodeEntryTime(int N, int M, int[] C)
        {
            long total = 0;
            long curr = 1;
            for (int i = 0; i < M; i++)
            {
                long left = Math.Abs(-(N - C[i]) - curr);
                long right = Math.Abs(C[i] - curr);

                curr = C[i];
                total += Math.Min(left, right);
            }

            return total;
        }

        public bool ValidPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            int c = 0;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return (Palindrome(s, left + 1, right) || Palindrome(s, left, right - 1));
                }
                else
                {
                    left++;
                    right--;
                }
            }

            return true;
        }

        public bool Palindrome(string s, int l, int r)
        {
            while (l < r)
            {
                if (s[l] != s[r])
                    return false;
                l++;
                r--;
            }
            return true;
        }

        public class SparseVector
        {
            Dictionary<int, int> arr = new Dictionary<int, int>();
            public SparseVector(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                    if (nums[i] != 0)
                        arr.Add(i, nums[i]);
            }

            public int dotProduct(SparseVector vec)
            {
                int sum = 0;

                if (arr.Count < vec.arr.Count)
                {
                    foreach (var pair in arr)
                    {
                        var ind = pair.Key;
                        var value = pair.Value;
                        if (vec.arr.ContainsKey(ind))
                            sum += value * vec.arr[ind];
                    }
                }
                else
                {
                    foreach (var pair in vec.arr)
                    {
                        var ind = pair.Key;
                        var value = pair.Value;
                        if (arr.ContainsKey(ind))
                            sum += value * arr[ind];
                    }
                }

                return sum;
            }
        }

        public static IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();
            var queue = new Queue<(int col, TreeNode node)>();
            queue.Enqueue((0, root));
            int min = 0;
            int max = 0;
            var dict = new Dictionary<int, List<int>>();
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (min > curr.col) min = curr.col;
                if (max < curr.col) max = curr.col;

                if (dict.ContainsKey(curr.col)) dict[curr.col].Add(curr.node.val);
                else dict.Add(curr.col, new List<int>() { curr.node.val });

                if (curr.node.left != null) queue.Enqueue((curr.col - 1, curr.node.left));
                if (curr.node.right != null) queue.Enqueue((curr.col + 1, curr.node.right));
            }

            var ans = new List<IList<int>>();
            for (int i = min; i <= max; i++)
            {
                var values = dict[i];
                ans.Add(values);
            }

            return ans;
        }
    }
}
