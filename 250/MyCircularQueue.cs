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
    }

    /**
     * Your MyCircularQueue object will be instantiated and called as such:
     * MyCircularQueue obj = new MyCircularQueue(k);
     * bool param_1 = obj.EnQueue(value);
     * bool param_2 = obj.DeQueue();
     * int param_3 = obj.Front();
     * int param_4 = obj.Rear();
     * bool param_5 = obj.IsEmpty();
     * bool param_6 = obj.IsFull();
     */
}
