using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150._250
{

    public class MyCircularQueue
    {
        private Node root = null;
        private int k;
        private int count = 0;
        public MyCircularQueue(int k)
        {
            this.k = k;
        }

        public bool EnQueue(int value)
        {
            var newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
                count++;
                return true;
            }

            Node? current = root;

            if (count < k)
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                count++;
                return true;
            }
            return false;
        }

        public bool DeQueue()
        {
            if (root == null) { return false; }

            root = root.Next;
            count--;
            return true;


        }

        public int Front()
        {
            return (root == null) ? -1 : root.Value;
        }

        public int Rear()
        {
            if (root == null) return -1;

            Node node = root;
            while (node.Next != null)
                node = node.Next;
            return node.Value;
        }

        public bool IsEmpty()
        {
            return (root == null);
        }

        public bool IsFull()
        {
            return count == k;
        }

        public static string DecodeString(string s)
        {
            Stack<char> stack = new Stack<char>();
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ']') stack.Push(s[i]);
                else
                {
                    string current = "";
                    while (stack.Count > 0 && stack.Peek() != '[')
                    {
                        char cc = stack.Pop();
                        current = cc + current;
                    }
                    string number = "";
                    while (stack.Count > 0 && stack.Peek() == '[') stack.Pop();
                    while (stack.Count > 0 && Char.IsNumber(stack.Peek()))
                        number = stack.Pop() + number;
                    string str = "";
                    int times = int.Parse(number);
                    for (int j = 1; j <= times; j++)
                        str = current + str;

                    for (int k = 0; k < str.Length; k++)
                        stack.Push(str[k]);
                }
            }

            while (stack.Count > 0)
                result = stack.Pop() + result;

            return result;
        }

        public static string LongestDiverseString(int a, int b, int c)
        {
            PriorityQueue<(char cc, int count), int> queue = new PriorityQueue<(char cc, int count), int>();
            if (a > 0)
                queue.Enqueue(('a', a), -a);
            if (b > 0)
                queue.Enqueue(('b', b), -b);
            if (c > 0)
                queue.Enqueue(('c', c), -c);

            string result = "";

            while (queue.Count > 0)
            {
                var first = queue.Dequeue();
                if (result.Length > 1 && result[result.Length - 1] == first.cc && result[result.Length - 2] == first.cc)
                {
                    if (queue.Count == 0) break;
                    var second = queue.Dequeue();
                    result = result + second.cc;
                    int newCount2 = second.count - 1;
                    if (newCount2 > 0)
                        queue.Enqueue((second.cc, newCount2), -newCount2);
                    queue.Enqueue((first.cc, first.count), -first.count);
                }
                else
                {
                    result = result + first.cc;
                    int newCount = first.count - 1;
                    if (newCount > 0)
                        queue.Enqueue((first.cc, newCount), -newCount);
                }

            }
            return result;
        }

        public static string ReorganizeString(string s)
        {
            var freq = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!freq.ContainsKey(s[i]))
                    freq.Add(s[i], 1);
                else freq[s[i]]++;
            }
            PriorityQueue<(char cc, int count), int> queue = new PriorityQueue<(char cc, int count), int>();
            foreach (var pair in freq)
            {
                var count = pair.Value;
                var character = pair.Key;
                queue.Enqueue((character, count), -count);
            }

            StringBuilder res = new StringBuilder();
            while (queue.Count > 0)
            {
                var first = queue.Dequeue();
                if (res.Length > 0 && res[res.Length - 1] == first.cc)
                {
                    if (queue.Count == 0) break;
                    var second = queue.Dequeue();
                    res.Append(second.cc);
                    int newCount2 = second.count - 1;
                    if (newCount2 > 0)
                        queue.Enqueue((second.cc, newCount2), -newCount2);
                    queue.Enqueue((first.cc, first.count), -first.count);
                }
                else
                {
                    res.Append(first.cc);
                    int newCount = first.count - 1;
                    if (newCount > 0)
                        queue.Enqueue((first.cc, newCount), -newCount);
                }
            }
            return (s.Length == res.Length) ? res.ToString() : "";
        }

        public static bool CarPooling(int[][] trips, int capacity)
        {
            int[] arr = new int[1001];
            for (int i = 0; i < trips.Length; i++)
            {
                var from = trips[i][1];
                var to = trips[i][2];
                var passenger = trips[i][0];
                arr[from] += passenger;
                arr[to] -= passenger;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0)
                    arr[i] += arr[i - 1];
                if (arr[i] > capacity) return false;
            }

            return true;
        }

        public static int[] GetOrder(int[][] tasks)
        {
            List<int> result = new List<int>();
            PriorityQueue<(int index, int enqTime, int procTime), int> available = new PriorityQueue<(int index, int enqTime, int procTime), int>();
            PriorityQueue<(int index, int enqTime, int procTime), int> pending = new PriorityQueue<(int index, int enqTime, int procTime), int>();
            for (int i = 0; i < tasks.Length; i++)
            {
                pending.Enqueue((i, tasks[i][0], tasks[i][1]), tasks[i][0]);
            }

            int time = 0;
            while (pending.Count > 0 || available.Count > 0)
            {
                while (pending.Count > 0 && pending.Peek().enqTime <= time)
                {

                    var task = pending.Dequeue();
                    available.Enqueue(task, task.procTime);

                }

                if (available.Count == 0)
                {
                    time = pending.Peek().enqTime;
                    continue;
                }

                var avtask = available.Dequeue();
                time += avtask.procTime;
                result.Add(avtask.index);
            }

            return result.ToArray();
        }

        public static int FindMaximizedCapital(int k, int w, int[] profits, int[] capitals)
        {
            PriorityQueue<(int capital, int profit), int> minCapitalHeap = new PriorityQueue<(int capital, int profit), int>();
            PriorityQueue<(int capital, int profit), int> maxProfitHeap = new PriorityQueue<(int capital, int profit), int>();

            for (int i = 0; i < profits.Length; i++)
            {
                minCapitalHeap.Enqueue((capitals[i], profits[i]), capitals[i]);
            }
            int count = 0;
            while (count < k)
            {
                while (minCapitalHeap.Count > 0 && minCapitalHeap.Peek().capital <= w)
                {
                    var minProject = minCapitalHeap.Dequeue();
                    maxProfitHeap.Enqueue(minProject, -minProject.profit);
                }

                if (maxProfitHeap.Count == 0) break;

                var project = maxProfitHeap.Dequeue();
                count++;
                w += project.profit;

            }
            return w;
        }

        public static int NumRescueBoats(int[] people, int limit)
        {
            int result = 0;
            Array.Sort(people);
            int left = 0;
            int right = people.Length - 1;
            while (left <= right)
            {
                int remain = limit - people[right];
                right--;
                if (left <= right && remain >= people[left])
                {
                    left++;
                }
               
                result++;

            }
            return result;

        }

    }
}
