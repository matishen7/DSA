using CrackingTheCodingInterview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.TreeProblems;

namespace Neetcode150.LeetcodeMarch
{

    public class SolutionMarch
    {
        public static int WidthOfBinaryTree(TreeNode root)
        {
            Queue<(int no, TreeNode node)> queue = new Queue<(int no, TreeNode node)>();
            queue.Enqueue((0, root));
            int max = 0;
            int level = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                int leftmost = queue.Peek().no;
                int rightmost = int.MinValue;
                for (int i = 0; i < size; i++)
                {
                    var curr = queue.Dequeue();
                    rightmost = Math.Max(rightmost, curr.no);
                    if (curr.node.left != null)
                        queue.Enqueue((2 * curr.no + 1, curr.node.left));

                    if (curr.node.right != null)
                        queue.Enqueue((2 * curr.no + 2, curr.node.right));

                }

                max = Math.Max(max, rightmost - leftmost + 1);
            }

            return max;
        }
        public static bool IsCompleteTree(TreeNode root)
        {
            Queue<TreeNode?> queue = new Queue<TreeNode?>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                if (node != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                else
                {
                    while (queue.Count > 0)
                    {
                        if (queue.Dequeue() != null) return false;
                    }
                }
            }

            return true;

        }

        public static int MinTime(int n, int[][] edges, IList<bool> hasApple)
        {
            var adjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                var src = edges[i][0];
                var dst = edges[i][1];
                adjList[src].Add(dst);
                adjList[dst].Add(src);
            }

            var result = MinTimeDFS(0, -1, adjList, hasApple);
            return result;
        }

        public static int MinTimeDFS(int node, int parent, Dictionary<int, List<int>> adjList, IList<bool> hasApple)
        {
            int time = 0;
            foreach (var nei in adjList[node])
            {
                if (nei != parent)
                {
                    int childTime = MinTimeDFS(nei, node, adjList, hasApple);
                    if (childTime > 0 || hasApple[nei])
                        time += 2 + childTime;
                }
            }

            return time;
        }
        public static string Tree2str(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            Tree2strDFS(root, sb);
            return sb.ToString();
        }
        public static void Tree2strDFS(TreeNode root, StringBuilder result)
        {
            if (root == null) return;

            result.Append(root.val);

            if (root.left == null && root.right != null)
            {
                result.Append("()");
                result.Append("(");
                Tree2strDFS(root.right, result);
                result.Append(")");
            }

            else if (root.left != null && root.right != null)
            {
                result.Append("(");
                Tree2strDFS(root.left, result);
                result.Append(")");
                result.Append("(");
                Tree2strDFS(root.right, result);
                result.Append(")");
            }

            else if (root.left != null && root.right == null)
            {
                result.Append("(");
                Tree2strDFS(root.left, result);
                result.Append(")");
            }
        }
        public static bool EvaluateTree(TreeNode root)
        {
            return EvaluateTreeDFS(root);
        }

        public static bool EvaluateTreeDFS(TreeNode root)
        {
            if (root.left == null && root.right == null) return root.val == 1;

            if (root.val == 2)
            {
                var op = EvaluateTreeDFS(root.left) || EvaluateTreeDFS(root.right);
                return op;
            }
            else
            {
                var op = EvaluateTreeDFS(root.left) && EvaluateTreeDFS(root.right);
                return op;
            }
        }

        public static bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var list1 = new List<int>();
            LeafSimilarDFS(root1, list1);
            var list2 = new List<int>();
            LeafSimilarDFS(root2, list2);
            if (list1.Count != list2.Count) return false;
            for (int i = 0; i < list2.Count; i++)
                if (list1[i] != list2[i]) return false;
            return true;
        }
        public static void LeafSimilarDFS(TreeNode root, List<int> list)
        {
            if (root == null) return;

            if (root.left == null && root.right == null) list.Add(root.val);

            LeafSimilarDFS(root.left, list);
            LeafSimilarDFS(root.right, list);

        }
        public static TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            var node = MergeTreesDFS(root1, root2);
            return node;
        }

        public static TreeNode MergeTreesDFS(TreeNode root1, TreeNode root2)
        {
            if (root1 == null) return root2;
            if (root2 == null) return root1;

            var node = new TreeNode(root1.val + root2.val);
            node.left = MergeTreesDFS(root1.left, root2.left);
            node.right = MergeTreesDFS(root1.right, root2.right);
            return node;
        }
        public static int ClosedIsland(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int count = 0;
            PrintGrid(grid);
            Console.WriteLine("---------");
            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
            var visited = new HashSet<(int, int)>();
            for (int i = 1; i < n - 1; i++)
                for (int j = 1; j < m - 1; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));

                        while (queue.Count > 0)
                        {
                            (int row, int col) = queue.Dequeue();

                            if (!visited.Contains((row, col))) grid[row][col] = 1;
                            visited.Add((row, col));
                            if (row + 1 < n - 1 && grid[row + 1][col] == 0 && !visited.Contains((row + 1, col)))
                                queue.Enqueue((row + 1, col));
                            if (row - 1 > 0 && grid[row - 1][col] == 0 && !visited.Contains((row - 1, col)))
                                queue.Enqueue((row - 1, col));
                            if (col + 1 < m - 1 && grid[row][col + 1] == 0 && !visited.Contains((row, col + 1)))
                                queue.Enqueue((row, col + 1));
                            if (col - 1 > 0 && grid[row][col - 1] == 0 && !visited.Contains((row, col - 1)))
                                queue.Enqueue((row, col - 1));
                        }
                    }
                }

            for (int i = 1; i < n - 1; i++)
                for (int j = 1; j < m - 1; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        {
                            if ((i + 1 < n && grid[i + 1][j] == 1) &&
                                    (i - 1 >= 0 && grid[i - 1][j] == 1) &&
                                    (j - 1 >= 0 && grid[i][j - 1] == 1) &&
                                    (j + 1 < m && grid[i][j + 1] == 1)
                                ) count++;
                        }
                    }
                }
            PrintGrid(grid);
            return count;
        }

        private static void PrintGrid(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    Console.Write(grid[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static long MinimumFuelCost(int[][] roads, int seats)
        {
            var adjList = new Dictionary<long, List<long>>();

            int n = roads.Length + 1;
            for (int i = 0; i < n; i++)
                adjList.Add(i, new List<long>());

            for (int i = 0; i < roads.Length; i++)
            {
                var src = roads[i][0];
                var dst = roads[i][1];
                adjList[src].Add(dst);
                adjList[dst].Add(src);
            }

            long result = 0;
            MinimumFuelCostDFS(0, -1, seats, adjList, ref result);

            return result;
        }
        public static long MinimumFuelCostDFS(long node, long parent, int seats, Dictionary<long, List<long>> adjList, ref long result)
        {
            long passengers = 0;
            foreach (var nei in adjList[node])
            {
                if (nei != parent)
                {
                    long p = MinimumFuelCostDFS(nei, node, seats, adjList, ref result);
                    passengers += p;
                    result += (long)Math.Ceiling((double)p / seats);
                }
            }

            return passengers + 1;
        }

        public static int ClosestMeetingNode(int[] edges, int node1, int node2)
        {
            var adjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < edges.Length; i++)
            {
                adjList.Add(i, new List<int>() { });
            }
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i] != -1)
                    adjList[i].Add(edges[i]);
            }

            var queue = new Queue<(int node, int depth)>();
            queue.Enqueue((node1, 0));
            var visited = new HashSet<int>();
            var fromNode1 = new int[edges.Length];
            Array.Fill(fromNode1, -1);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                visited.Add(curr.node);
                fromNode1[curr.node] = curr.depth;

                foreach (var nei in adjList[curr.node])
                {
                    if (!visited.Contains(nei))
                    {
                        queue.Enqueue((nei, curr.depth + 1));
                    }
                }
            }

            queue.Enqueue((node2, 0));
            visited.Clear();
            var fromNode2 = new int[edges.Length];
            Array.Fill(fromNode2, -1);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                visited.Add(curr.node);
                fromNode2[curr.node] = curr.depth;

                foreach (var nei in adjList[curr.node])
                {
                    if (!visited.Contains(nei))
                    {
                        queue.Enqueue((nei, curr.depth + 1));
                    }
                }
            }
            int minDepth = int.MaxValue;
            int result = -1;
            for (int i = 0; i < edges.Length; i++)
            {
                if (fromNode1[i] != -1 && fromNode2[i] != -1)
                {
                    int dist = Math.Max(fromNode1[i], fromNode2[i]);
                    if (dist < minDepth)
                    {
                        minDepth = dist;
                        result = i;
                    }
                }
            }

            return result;
        }
        public static int MaxSubarrayLength(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            int left = 0;
            int right = 0;
            int max = 0;
            while (right < nums.Length)
            {
                if (!map.ContainsKey(nums[right]))
                {
                    map.Add(nums[right], 1);
                    right++;
                    max = Math.Max(max, right - left);
                }
                else
                {
                    map[nums[right]]++;
                    while (map[nums[right]] > k)
                    {
                        map[nums[left]]--;
                        left += 1;
                    }
                    max = Math.Max(max, right - left + 1);
                    right++;
                }


            }

            return max;
        }
        public static int MaxVowels(string s, int k)
        {
            var vowels = new HashSet<char>()
                {'a', 'o', 'i', 'e', 'u'};

            int count = 0;
            int right = 0;
            double sum = 0;
            while (right < k && right < s.Length)
            {
                if (vowels.Contains(s[right])) count++;
                right++;
            }
            int max = 0;
            max = Math.Max(count, max);
            int left = 0;
            while (right < s.Length)
            {
                if (vowels.Contains(s[right])) count++;
                if (vowels.Contains(s[left])) count--;

                max = Math.Max(count, max);
                right++;
                left++;
            }

            return max;
        }
        public static int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            int count = 0;
            int right = 0;
            double sum = 0;
            while (right < k && right < arr.Length)
            {
                sum += arr[right];
                right++;
            }

            if ((double)(sum / k) >= threshold) count++;
            int left = 0;
            while (right < arr.Length)
            {
                sum += arr[right];
                sum -= arr[left];
                if ((double)(sum / k) >= threshold) count++;

                left++;
                right++;
            }

            return count;
        }
        public static string KthLargestNumber(string[] nums, int k)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i].Length > nums[j].Length)
                    {
                        var temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                    else if (nums[i].Length == nums[j].Length)
                    {
                        if (LargestNumber(nums[i], nums[j]) == 0)
                        {
                            var temp = nums[i];
                            nums[i] = nums[j];
                            nums[j] = temp;
                        }
                    }

                }
            }

            return nums[k - 1];
        }

        private static int LargestNumber(string num1, string num2)
        {
            int i = 0;
            while (i < num1.Length)
            {
                if (num1[i] - '0' == num2[i] - '0')
                    i++;
                else if (num1[i] - '0' > num2[i] - '0') return 0;
                else return 1;
            }
            return 0;
        }

        public static IList<int> AddToArrayForm(int[] num, int k)
        {
            int carry = 0;
            int i = num.Length - 1;
            var result = new List<int>();
            var knum = new List<int>();
            while (k > 0)
            {
                int digit = k % 10;
                k /= 10;
                knum.Insert(0, digit);
            }
            int j = knum.Count - 1;
            while (i >= 0 && j >= 0)
            {
                int digit = num[i] + knum[j] + carry;
                carry = digit / 10;
                digit = digit % 10;

                result.Insert(0, digit);
                i--;
                j--;
            }
            while (i >= 0)
            {
                int digit = num[i] + carry;
                carry = digit / 10;
                digit = digit % 10;

                result.Insert(0, digit);
                i--;
            }
            while (j >= 0)
            {
                int digit = knum[j] + carry;
                carry = digit / 10;
                digit = digit % 10;

                result.Insert(0, digit);
                j--;
            }
            if (carry != 0)
                result.Insert(0, carry);
            return result;
        }

        public static IList<int> LargestValues(TreeNode root)
        {
            if (root == null) return new List<int>();
            var result = new List<int>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                int max = int.MinValue;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    if (max < node.val) max = node.val;

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                result.Add(max);
            }

            return result;
        }
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            var dummy = new ListNode(200);
            var result = dummy;
            var prev = dummy;
            var curr = head;
            while (curr != null)
            {
                if (curr.val != prev.val)
                {
                    var node = new ListNode(curr.val);
                    dummy.next = node;
                    dummy = dummy.next;
                }
                prev = curr;
                curr = curr.next;
            }
            return result.next;
        }
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                var order = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    var curr = queue.Dequeue();
                    order.Add(curr.val);

                    if (curr.left != null) queue.Enqueue(curr.left);
                    if (curr.right != null) queue.Enqueue(curr.right);
                }
                if (level % 2 == 1)
                    order.Reverse();
                result.Add(order);
                level++;
            }

            return result;
        }
        public static int MinDays(int n)
        {
            var memo = new Dictionary<(int, int), int>();
            var result = MinDaysDFS(n, 0, memo);
            return result;
        }

        public static int MinDaysDFS(int n, int days, Dictionary<(int, int), int> memo)
        {
            if (n <= 0) return days;

            if (memo.ContainsKey((n, days))) return memo[(n, days)];

            int minDays1 = int.MaxValue;
            int minDays2 = int.MaxValue;
            int minDays3 = int.MaxValue;

            if (n % 2 == 0)
                minDays1 = MinDaysDFS(n - (n / 2), days + 1, memo);
            if (n % 3 == 0)
                minDays2 = MinDaysDFS(n - (2 * (n / 3)), days + 1, memo);

            minDays3 = MinDaysDFS(n - 1, days + 1, memo);

            memo[(n, days)] = Math.Min(minDays1, Math.Min(minDays2, minDays3));
            return memo[(n, days)];
        }
        public int MaxProductDifference(int[] nums)
        {
            int biggest = 0;
            int secondBiggest = 0;
            int smallest = int.MaxValue;
            int secondSmallest = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > biggest)
                {
                    secondBiggest = biggest;
                    biggest = nums[i];
                }

                else secondBiggest = Math.Max(secondBiggest, nums[i]);

                if (smallest > nums[i])
                {
                    secondSmallest = smallest;
                    smallest = nums[i];
                }
                else secondSmallest = Math.Min(secondSmallest, nums[i]);
            }

            return (biggest * secondBiggest) - (smallest * secondSmallest);
        }
        public static string LargestGoodInteger(string num)
        {
            var list = new List<string>()
            { "999", "888","777","666","555","444","333","222","111","000",};

            foreach (var item in list)
            {
                if (num.Contains(item)) return item;
            }

            return string.Empty;

        }
        public static IList<string> FizzBuzz(int n)
        {
            var ans = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) ans.Add("FizzBuzz");
                else if (i % 3 == 0) ans.Add("Fizz");
                else if (i % 5 == 0) ans.Add("Buzz");
                else ans.Add(i.ToString());
            }

            return ans;
        }
        public static bool IsPowerOfThree(int n)
        {
            return n > 0 && 1162261467 % n == 0;
        }
        public static int HammingWeight(int n)
        {
            int w = 0;
            while (n > 0)
            {
                if (n % 2 == 1) w++;
                n /= 10;
            }
            return w;
        }
        public static int MySqrt(int x)
        {
            if (x < 2) return x;
            int left = 2;
            int right = x / 2;
            long num;
            int mid = 1;
            while (left <= right)
            {
                mid = (left + right) / 2;
                num = (long)mid * mid;
                if (num < x)
                    left = mid + 1;
                else if (num > x) right = mid - 1;
                else if (num == x) return mid;
            }
            return right;
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var curr = headA;
            var setA = new HashSet<ListNode>();
            while (curr != null)
            {
                setA.Add(curr);
                curr = curr.next;
            }

            curr = headB;
            while (curr != null)
            {
                if (setA.Contains(curr)) return curr;
                curr = curr.next;
            }

            return null;
        }
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTDFS(nums, 0, nums.Length - 1);
        }

        public static TreeNode SortedArrayToBSTDFS(int[] nums, int left, int right)
        {
            if (left > right) return null;

            int mid = (left + right) / 2;

            var node = new TreeNode(nums[mid]);

            node.left = SortedArrayToBSTDFS(nums, left, mid - 1);
            node.right = SortedArrayToBSTDFS(nums, mid + 1, right);
            return node;
        }

        public static int LongestCommonSubsequence(string text1, string text2)
        {
            var memo = new Dictionary<(int, int, int), int>();
            var result = LongestCommonSubsequenceDFS(0, 0, 0, text1, text2, memo);
            return result;
        }

        public static int LongestCommonSubsequenceDFS(int i, int j, int count, string text1, string text2, Dictionary<(int, int, int), int> memo)
        {
            if (i >= text1.Length || j >= text2.Length)
                return count;

            if (memo.ContainsKey((i, j, count))) return memo[(i, j, count)];

            int skip = 0; int include1 = 0, include2 = 0;
            if (text1[i] == text2[j])
            {
                count++;
                skip = LongestCommonSubsequenceDFS(i + 1, j + 1, count, text1, text2, memo);
            }
            else
            {
                include1 = LongestCommonSubsequenceDFS(i + 1, j, count, text1, text2, memo);
                include2 = LongestCommonSubsequenceDFS(i, j + 1, count, text1, text2, memo);
            }
            memo[(i, j, count)] = Math.Max(skip, Math.Max(include1, include2));
            return memo[(i, j, count)];
        }

        public static int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            int i = 0;
            while (i < heights.Length)
            {
                if (i == heights.Length - 1) break;
                if (heights[i] - heights[i + 1] >= 0)
                    i++;
                else if (bricks > 0 || ladders > 0)
                {
                    if (bricks - Math.Abs(heights[i] - heights[i + 1]) >= 0)
                    {
                        bricks -= Math.Abs(heights[i] - heights[i + 1]);
                        i++;
                    }
                    else if (ladders > 0)
                    {
                        ladders--;
                        i++;
                    }
                    else break;
                }
                else break;
            }

            return i;
        }
        public static int SingleNonDuplicate(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (mid % 2 == 0 && nums[mid] == nums[mid - 1])
                    left = mid + 1;
                else if (mid % 2 == 0 && nums[mid] == nums[mid + 1])
                    left = mid + 1;
                else if (mid % 2 != 0 && nums[mid] != nums[mid - 1] || nums[mid] == nums[mid + 1])
                    right = mid - 1;
                else if (mid % 2 != 0 && nums[mid] != nums[mid + 1] || nums[mid] == nums[mid - 1])
                    right = mid - 1;
                else return nums[mid];
            }

            return -1;
        }
        public static long MinimumHealth(int[] damage, int armor)
        {
            long total = 1;
            long maxSoFar = 0;
            for (int i = damage.Length - 1; i >= 0; i--)
            {
                if (damage[i] > maxSoFar)
                    maxSoFar = damage[i];
                total += damage[i];
            }
            maxSoFar = Math.Min(maxSoFar, armor);
            return total - maxSoFar;
        }
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var result = new List<bool>();
            int mx = candies[0];
            for (int i = 1; i < candies.Length; i++)
            {
                if (mx < candies[i]) mx = candies[i];
            }

            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] + extraCandies >= mx) result.Add(true);
                else result.Add(false);
            }

            return result;
        }
        public static int MinimumTime(int[] jobs, int[] workers)
        {
            PriorityQueue<int, int> maxJobs = new PriorityQueue<int, int>();
            for (int j = 0; j < jobs.Length; j++)
                maxJobs.Enqueue(jobs[j], -jobs[j]);

            PriorityQueue<int, int> maxWorkers = new PriorityQueue<int, int>();
            for (int j = 0; j < workers.Length; j++)
                maxWorkers.Enqueue(workers[j], -workers[j]);

            int max = 0;
            while (maxJobs.Count > 0)
            {
                var currJob = maxJobs.Dequeue();
                var currWorker = maxWorkers.Dequeue();

                int days = currJob / currWorker;
                if (currJob % currWorker != 0) days += 1;
                max = Math.Max(max, days);
            }

            return max;
        }
        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            PriorityQueue<(int numBox, int numUnits), int> max = new PriorityQueue<(int numBox, int numUnits), int>();
            for (int j = 0; j < boxTypes.Length; j++)
                max.Enqueue((boxTypes[j][0], boxTypes[j][1]), -boxTypes[j][1]);

            int i = 0;
            int total = 0;
            while (truckSize > 0 && max.Count > 0)
            {
                var curr = max.Dequeue();
                var numOfBox = curr.numBox;
                var numOfUnits = curr.numUnits;

                if (truckSize > numOfBox)
                {
                    total += numOfBox * numOfUnits;
                    truckSize -= numOfBox;
                }
                else
                {
                    total += truckSize * numOfUnits;
                    truckSize = 0;
                }

                i++;
            }

            return total;
        }

        public static bool IsValidPalindrome(string s, int k)
        {
            return IsValidPalindromeDSF(s, k);
        }

        public static bool IsValidPalindromeDSF(string s, int k)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    if (k <= 0)
                    {
                        return IsPalindrome(s);
                    }
                    else
                    {
                        return (IsValidPalindromeDSF(s.Substring(left, right - left), k - 1) ||
                            IsValidPalindromeDSF(s.Substring(left + 1, right - (left + 1) + 1), k - 1));
                    }
                }

                left++;
                right--;
            }

            return true;
        }
        public static bool MakePalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            int count = 0;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    count++;
                    if (count > 2)
                    {
                        return IsPalindrome(s.Substring(left, right - left + 1));
                    }
                }

                left++;
                right--;
            }

            return true;
        }

        public static bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right]) return false;
                left++;
                right--;
            }
            return true;
        }

        public static int PartitionString(string s)
        {
            int i = 0;
            int count = 0;
            while (i < s.Length)
            {
                var set = new HashSet<char>();
                while (i < s.Length && !set.Contains(s[i]))
                {
                    set.Add(s[i]);
                    i++;
                }
                count++;
            }

            return count;
        }
        public static bool IsZeroArray(int[] nums, int[][] queries)
        {
            for (int i = 0; i < queries.Length; i++)
            {
                var start = queries[i][0];
                var end = queries[i][1];
                for (int j = start; j <= end; j++)
                {
                    if (nums[j] != 0)
                        nums[j] -= 1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != 0) return false;

            return true;
        }
        public static int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            int n = nums.Length;
            int product = 1;
            int total = 0;
            int left = 0;
            int right = 0;

            while (right < n)
            {
                product *= nums[right];
                while (product >= k)
                {
                    product /= nums[left];
                    left++;
                }
                total += right - left + 1;
                right++;
            }

            return total;
        }
        public static void ReorderList(ListNode head)
        {
            LinkedList<int> deque = new LinkedList<int>();
            var curr = head;
            while (curr != null)
            {
                deque.AddLast(curr.val);
                curr = curr.next;
            }
            var dummy = new ListNode(0);
            curr = head;
            dummy.next = curr;
            var prev = dummy.next;
            int i = 0;
            while (deque.Count > 0)
            {
                if (i % 2 == 0)
                {
                    var val = deque.First.Value;
                    deque.RemoveFirst();
                    var node = new ListNode(val);
                    prev.next = node;
                    prev = prev.next;
                    i++;
                }
                else
                {
                    var val = deque.Last.Value;
                    deque.RemoveLast();
                    var node = new ListNode(val);
                    prev.next = node;
                    prev = prev.next;
                    i++;
                }
            }

            head = dummy.next.next;
        }
        public static string RankTeams(string[] votes)
        {
            var maxHeap = new PriorityQueue<(char key, int value), int>();
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < votes.Length; i++)
            {
                int pointWeight = votes[0].Length;
                for (int j = 0; j < votes[i].Length; j++)
                {
                    if (dict.ContainsKey(votes[i][j])) dict[votes[i][j]] += pointWeight;
                    else dict.Add(votes[i][j], pointWeight);

                    pointWeight--;
                }
            }

            foreach (var kvp in dict)
                maxHeap.Enqueue((kvp.Key, kvp.Value), -kvp.Value);

            var str = new StringBuilder();
            var sb = new StringBuilder();
            var p = maxHeap.Dequeue();
            (char key, int value) last = (p.key, p.value);
            sb.Append(last.key);
            while (maxHeap.Count > 0)
            {
                if (maxHeap.Peek().value == last.value)
                {
                    while (maxHeap.Count > 0 && maxHeap.Peek().value == last.value)
                    {
                        var pair1 = maxHeap.Dequeue();
                        sb.Append(pair1.key);
                        last.value = pair1.value;
                        last.key = pair1.key;
                    }
                    char[] chars = sb.ToString().ToCharArray();
                    Array.Sort(chars);
                    sb.Clear();
                    sb.Append(chars);
                    str.Append(sb);
                    sb.Clear();
                }
                else
                {
                    if (sb.Length > 0)
                    {
                        str.Append(sb);
                        sb.Clear();
                    }
                    var pair = maxHeap.Dequeue();
                    str.Append(pair.key);
                }

            }
            if (sb.Length > 0)
            {
                str.Append(sb);
                sb.Clear();
            }
            return str.ToString();
        }
        public static int GetFood(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            var data = BuildMatrix(grid);
            var copyGrid = data.matrix;
            var visited = new HashSet<(int, int)>();

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((data.i, data.j));
            visited.Add((data.i, data.j));
            while (queue.Count > 0)
            {
                (int row, int col) = queue.Dequeue();

                var directions = GetDirections();
                for (int i = 0; i < directions.Count; i++)
                {
                    (int dr, int dc) = directions[i];
                    int newRow = row + dr;
                    int newCol = col + dc;
                    if (newRow >= 0 && newCol >= 0 && newRow < rows && newCol < cols && (grid[newRow][newCol] == 'O' || grid[newRow][newCol] == '#') && !visited.Contains((newRow, newCol)))
                    {
                        copyGrid[newRow][newCol] = copyGrid[row][col] + 1;
                        queue.Enqueue((newRow, newCol));
                        visited.Add((newRow, newCol));
                    }
                }
            }

            return -1;
        }

        private static (int[][] matrix, int i, int j) BuildMatrix(char[][] grid)
        {
            int k = 0; int l = 0;
            var m = new int[grid.Length][];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new int[grid[i].Length];
            }

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                    if (grid[i][j] == '*')
                    {
                        m[i][j] = 1;
                        k = i;
                        l = j;
                    }
            return (m, k, l);
        }

        private static List<(int, int)> GetDirections()
        {
            List<(int r, int c)> directions = new List<(int, int)>();
            // directions.Add((-1, -1));
            directions.Add((-1, 0));
            //  directions.Add((-1, 1));
            directions.Add((0, -1));
            directions.Add((0, 1));
            //  directions.Add((1, -1));
            directions.Add((1, 0));
            // directions.Add((1, 1));

            return directions;
        }
        public static int CountPalindromicSubsequence(string s)
        {
            int len = 0;
            var set = new HashSet<char>();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (set.Contains(s[i]) && set.Count >= 2) count += set.Count;

                len++;
                set.Add(s[i]);
            }

            return count;
        }

        public static void CountPalindromicSubsequenceDFS(int i, string s, StringBuilder pal, HashSet<string> set)
        {
            //Console.WriteLine(pal);
            if (pal.Length == 3 && pal[0] == pal[2])
            {
                set.Add(pal.ToString());
            }
            if (i >= s.Length) return;
            var newPal = new StringBuilder(pal.ToString()) { };
            newPal.Append(s[i]);
            CountPalindromicSubsequenceDFS(i + 1, s, newPal, set);
            newPal.Remove(newPal.Length - 1, 1);
            CountPalindromicSubsequenceDFS(i + 1, s, pal, set);
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var ans = new Dictionary<string, IList<string>>();

            foreach (var s in strs)
            {
                var count = new int[26];
                foreach (var c in s)
                {
                    count[c - 'a']++;
                }

                var key = string.Join(',', count);
                if (!ans.ContainsKey(key))
                {
                    ans[key] = new List<string>();
                }

                ans[key].Add(s);
            }

            return new List<IList<string>>(ans.Values);
        }
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var answer = new List<int>();
            while (queue.Count > 0)
            {
                int levelLength = queue.Count;
                for (int i = 0; i < levelLength; i++)
                {
                    var curr = queue.Dequeue();
                    if (i == levelLength - 1)
                        answer.Add(curr.val);

                    if (curr.left != null)
                        queue.Enqueue(curr.left);
                    if (curr.right != null)
                        queue.Enqueue(curr.right);

                }
            }
            return answer;
        }
        public static string MergeAlternately(string word1, string word2)
        {
            var sb = new StringBuilder();
            int i = 0;
            while (i < word1.Length && i < word2.Length)
            {
                sb.Append(word1[i]);
                sb.Append(word2[i]);
                i++;
            }

            while (i < word1.Length)
            {
                sb.Append(word1[i]);
                i++;
            }
            while (i < word2.Length)
            {
                sb.Append(word2[i]);
                i++;
            }

            return sb.ToString();
        }
    }
}
