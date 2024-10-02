using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Neetcode150
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node? Next { get; set; } = null;
    }
    public class LinkedList
    {
        private Node? root;

        public LinkedList()
        {
            root = null;
        }

        public int Get(int index)
        {
            int i = 0;
            Node? currentNode = root;

            while (i < index && currentNode != null)
            {
                currentNode = currentNode.Next;
                i++;
            }

            // Check if the node exists at the index
            if (currentNode == null)
                return -1;

            return currentNode.Value;
        }

        public void InsertHead(int val)
        {
            Node? newNode = new Node(val);
            if (root == null)
                root = newNode;
            else
            {
                Node? currentNode = root;
                newNode.Next = currentNode;
                root = newNode;
            }
        }

        public void InsertTail(int val)
        {
            Node? newNode = new Node(val);
            if (root == null)
                root = newNode;
            else
            {
                Node? currentNode = root;
                while (currentNode.Next != null)
                    currentNode = currentNode.Next;

                currentNode.Next = newNode;
            }
        }

        public bool Remove(int index)
        {
            if (root == null) return false; // Nothing to remove

            // Special case: removing the head (index 0)
            if (index == 0)
            {
                root = root.Next; // Head is removed
                return true;
            }

            Node? currentNode = root;
            Node? previousNode = null;
            int i = 0;

            // Traverse to the node just before the one to remove
            while (i < index && currentNode != null)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                i++;
            }

            // If currentNode is null, index is out of bounds
            if (currentNode == null)
                return false;

            // Remove the node by skipping it
            previousNode.Next = currentNode.Next;
            return true;

        }

        public List<int> GetValues()
        {
            var list = new List<int>();
            if (root == null) return list;
            Node? currentNode = root;
            while (currentNode != null)
            {
                list.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }
            return list;
        }
    }


}
