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
    }
}
