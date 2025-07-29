using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150.LeetcodeMarch
{
    public class SolutionApril
    {
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            int count = 0;
            for (int i = 0; i < dominoes.Length; i++)
            {
                for (int j = i + 1; j < dominoes.Length; j++)
                {
                    var a = dominoes[i][0];
                    var b = dominoes[i][1];
                    var c = dominoes[j][0];
                    var d = dominoes[j][1];

                    if ((a == c && b == d) || (a == d && b == c)) count++;
                }
            }

            return count;
        }
        public static int[] PrisonAfterNDays(int[] cells, int n)
        {
            int[] newCells = new int[cells.Length];
            int len = cells.Length;
            n = (n - 1) % 14 + 1;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < cells.Length; j++)
                {
                    if (j == 0 || j == cells.Length - 1) newCells[j] = 0;
                    else
                    {
                        if (cells[j - 1] == cells[j + 1]) newCells[j] = 1;
                        else newCells[j] = 0;
                    }
                }

                Array.Copy(newCells, cells, len);
            }

            return cells;
        }
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    result[0] = i;
                    result[1] = dic[target - nums[i]];
                    return result;
                }

                else
                {
                    if (!dic.ContainsKey(nums[i])) dic.Add(nums[i], i);
                    else dic[nums[i]] = i;
                }

            }
            return result;
        }

        public static int TwoCitySchedCost(int[][] costs)
        {
            var A = new PriorityQueue<int, int>();
            var B = new PriorityQueue<int, int>();

            for (int i = 0; i < costs.Length; i++)
            {
                A.Enqueue(costs[i][0], i);
                B.Enqueue(costs[i][1], i);

            }
            int sum = 0;
            int count = A.Count / 2;
            while (count > 0)
            {
                int a = A.Dequeue();
                sum += a;
                count--;
            }
            count = B.Count / 2;
            while (count > 0)
            {
                int b = B.Dequeue();
                // sum += b;
                count--;
            }
            count = B.Count;
            while (count > 0)
            {
                int b = B.Dequeue();
                sum += b;
                count--;
            }
            return sum;
        }
        public static int NumRollsToTarget(int n, int k, int target)
        {
            int count = 0;
            NumRollsToTargetDFS(0, n, k, target, ref count);
            return count;
        }

        public static void NumRollsToTargetDFS(int sum, int n, int k, int target, ref int count)
        {
            if (n == 0)
            {
                if (sum == target) count += 1;
            }

            for (int i = 1; i < k; i++)
            {
                NumRollsToTargetDFS(sum + 1, n - 1, k, target, ref count);
            }
        }
        public static int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            var dic1 = new Dictionary<int, int>();
            var indexes = new Dictionary<int, int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                if (dic1.ContainsKey(arr1[i])) dic1[arr1[i]]++;
                else dic1.Add(arr1[i], 1);

                if (indexes.ContainsKey(arr1[i])) indexes[arr1[i]] = i;
                else indexes.Add(arr1[i], i);
            }


            var result = new List<int>();
            for (int i = 0; i < arr2.Length; i++)
            {
                var key = arr2[i];
                int count = dic1[key];
                for (int j = 0; j < count; j++)
                {
                    result.Add(key);
                }

                dic1.Remove(key);
                indexes.Remove(key);
            }
            var minHeap = new PriorityQueue<int, int>();
            foreach (var pair in indexes)
            {
                minHeap.Enqueue(pair.Key, pair.Key);
            }
            while (minHeap.Count > 0)
            {
                var key = minHeap.Dequeue();
                int count = dic1[key];
                for (int j = 0; j < count; j++)
                {
                    result.Add(key);
                }

                dic1.Remove(key);
            }

            return result.ToArray();
        }
        public static int MinReorder(int n, int[][] connections)
        {
            var adjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<int>());
            }

            var conns = new HashSet<(int, int)>();

            for (int i = 0; i < connections.Length; i++)
            {
                var src = connections[i][0];
                var dst = connections[i][1];
                conns.Add((src, dst));
                adjList[src].Add(dst);
                adjList[dst].Add(src);
            }

            var visit = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            int count = 0;

            queue.Enqueue(0);
            visit.Add(0);

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                foreach (var nei in adjList[curr])
                {
                    if (!visit.Contains(nei))
                    {
                        // if the original edge is from curr -> nei, it's fine
                        // if it's nei -> curr, need to flip it (so check if (curr, nei) exists)
                        if (!conns.Contains((nei, curr))) count++;
                        visit.Add(nei);
                        queue.Enqueue(nei);
                    }
                }
            }
            return count;
        }



        public static int FindUnsortedSubarray(int[] nums)
        {
            int left = 0;
            int n = nums.Length;
            int max = nums[0];

            for (int i = 0; i < n; i++)
            {
                if (max > nums[i])
                {
                    left = i;
                    break;
                }

                max = nums[i];
            }
            int right = n - 1;
            max = nums[n - 1];
            for (int i = n - 1; i >= 0; i--)
            {
                if (max < nums[i])
                {
                    right = i;
                    break;
                }

                max = nums[i];
            }
            return (right - left + 1);
        }
        public static bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target)
        {
            var list = new List<int>();
            TwoSumBSTsDFS(root1, list);

            for (int i = 0; i < list.Count; i++)
            {
                var searchNode = target - list[i];
                if (FindTarget(root2, searchNode)) return true;
            }

            return false;
        }

        public static void TwoSumBSTsDFS(TreeNode root, List<int> list)
        {
            if (root == null) return;
            list.Add(root.val);
            TwoSumBSTsDFS(root.left, list);
            TwoSumBSTsDFS(root.right, list);

        }

        private static bool FindTarget(TreeNode root, int target)
        {
            if (root == null) return false;
            if (root.val == target) return true;
            return (FindTarget(root.left, target) || FindTarget(root.right, target));
        }
        public static int[] ArrayRankTransform(int[] arr)
        {

            int[] result = new int[arr.Length];
            if (arr.Length == 0) return result;
            var minHeap = new PriorityQueue<(int val, int index), int>();
            for (int i = 0; i < arr.Length; i++)
            {
                minHeap.Enqueue((arr[i], i), arr[i]);
            }

            int rank = 1;
            int prev = minHeap.Peek().val;
            while (minHeap.Count > 0)
            {
                var curr = minHeap.Dequeue();
                if (curr.val > prev) { rank++; }
                prev = curr.val;
                result[curr.index] = rank;
            }

            return result;
        }
        public static int ReverseDegree(string s)
        {
            var dic = new Dictionary<char, int>();

            dic.Add('a', 26);
            dic.Add('b', 25);
            dic.Add('c', 24);
            dic.Add('d', 23);
            dic.Add('e', 22);
            dic.Add('f', 21);
            dic.Add('g', 20);
            dic.Add('h', 19);
            dic.Add('i', 18);
            dic.Add('j', 17);
            dic.Add('k', 16);
            dic.Add('l', 15);
            dic.Add('m', 14);
            dic.Add('n', 13);
            dic.Add('o', 12);
            dic.Add('p', 11);
            dic.Add('q', 10);
            dic.Add('r', 9);
            dic.Add('s', 8);
            dic.Add('t', 7);
            dic.Add('u', 6);
            dic.Add('v', 5);
            dic.Add('w', 4);
            dic.Add('x', 3);
            dic.Add('y', 2);
            dic.Add('z', 1);

            int sum = 0;
            for (int i = 0; i < s.Length; i++)
                sum += (i + 1) * dic[s[i]];

            return sum;
        }
        public static int[] MinCosts(int[] cost)
        {
            int min = cost[0];
            var result = new int[cost.Length];
            result[0] = min;
            for (int i = 1; i < cost.Length; i++)
            {
                if (cost[i] < min) min = cost[i];
                result[i] = min;
            }
            return result;
        }
        public static int CountCompleteComponents(int n, int[][] edges)
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

            var visit = new HashSet<int>();
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                var components = new int[2];
                if (!visit.Contains(i))
                {
                    CountCompleteComponentsDFS(i, adjList, visit, components);
                    int m = components[0];
                    int edge = components[1];
                    if ((m * (m - 1)) == edge) result += 1;
                }
            }

            return result;
        }
        public static void CountCompleteComponentsDFS(int node, Dictionary<int, List<int>> adjList, HashSet<int> visit, int[] components)
        {
            visit.Add(node);
            components[0]++;
            components[1] += adjList[node].Count;
            foreach (var nei in adjList[node])
            {
                if (!visit.Contains(nei))
                {
                    CountCompleteComponentsDFS(nei, adjList, visit, components);
                }

            }
        }
        public static IList<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;
            var adjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<int>());
            }

            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                    adjList[i].Add(graph[i][j]);
            }

            var safeNodes = new List<int>();
            Dictionary<int, bool> safe = new Dictionary<int, bool>();
            for (int i = 0; i < n; i++)
                if (IsSafeNode(i, safe, adjList)) safeNodes.Add(i);

            return safeNodes;
        }

        private static bool IsSafeNode(int node, Dictionary<int, bool> safe, Dictionary<int, List<int>> adjList)
        {
            if (safe.ContainsKey(node)) return safe[node];
            safe.Add(node, false);
            foreach (var nei in adjList[node])
            {
                if (!IsSafeNode(nei, safe, adjList)) return false;
            }
            safe[node] = true;
            return true;
        }

        public static int FindChampion(int n, int[][] edges)
        {
            var adjList = new Dictionary<int, List<int>>();
            var parents = new int[n];
            Array.Fill(parents, -1);
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                var src = edges[i][0];
                var dst = edges[i][1];

                adjList[src].Add(dst);
            }



            for (int i = 0; i < n; i++)
            {
                foreach (var nei in adjList[i])
                {
                    parents[nei] = i;
                }
            }
            var re = new List<int>();
            for (int i = 0; i < parents.Length; i++)
                if (parents[i] == -1)
                {
                    re.Add(i);
                    if (re.Count > 2) return -1;
                }
            return re[0];
        }



    }
}
