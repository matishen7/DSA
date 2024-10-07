using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150
{
    public class TreeMap
    {
        private BinaryNode root;

        public TreeMap()
        {
            root = null;
        }

        public void Insert(int key, int val)
        {
            root = InsertDFS(root, key, val);
        }

        private BinaryNode InsertDFS(BinaryNode node, int key, int value)
        {
            if (node == null)
            {
                var pair = new Pair(key, value);
                return new BinaryNode(pair);
            }

            if (key > node.Pair.Key)
            {
                node.right = InsertDFS(node.right, key, value);
            }
            else if (key < node.Pair.Key)
            {
                node.left = InsertDFS(node.left, key, value);
            }
            return node;
        }

        public int Get(int key)
        {
            return SearchNode(root, key);
        }

        private int SearchNode(BinaryNode node, int key)
        {
            if (node == null)
            {
                return -1;
            }

            if (key > node.Pair.Key)
            {
                return SearchNode(node.right, key);
            }
            else if (key < node.Pair.Key)
            {
                return SearchNode(node.left, key);
            }
            else
            {
                return node.Pair.Value;
            }
        }

        public int GetMin()
        {
            if (root == null)  return -1;
            return BfsTraversalMin(root);
        }

        public int BfsTraversalMin(BinaryNode node)
        {
            Pair minPair = node.Pair;
            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            if (node != null)
            {
                queue.Enqueue(node);
            }
            int level = 0;
            while (queue.Count > 0)
            {
                //Console.WriteLine("level " + level + ": ");
                int levelLength = queue.Count;
                for (int i = 0; i < levelLength; i++)
                {
                    BinaryNode curr = queue.Dequeue();
                    if (curr.Pair.Key < minPair.Key) minPair = curr.Pair;
                    //Console.WriteLine(curr.Pair.Key);
                    if (curr.left != null)
                    {
                        queue.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        queue.Enqueue(curr.right);
                    }
                }
                level++;
                //Console.WriteLine();
            }
            return minPair.Value;
        }

        public int GetMax()
        {
            if (root == null) return -1;
            return BfsTraversalMax(root);
        }

        public int BfsTraversalMax(BinaryNode node)
        {
            Pair maxPair = node.Pair;
            Queue<BinaryNode> queue = new Queue<BinaryNode>();
            if (node != null)
            {
                queue.Enqueue(node);
            }
            int level = 0;
            while (queue.Count > 0)
            {
                //Console.WriteLine("level " + level + ": ");
                int levelLength = queue.Count;
                for (int i = 0; i < levelLength; i++)
                {
                    BinaryNode curr = queue.Dequeue();
                    if (curr.Pair.Key > maxPair.Key) maxPair = curr.Pair;
                    //Console.WriteLine(curr.Pair.Key);
                    if (curr.left != null)
                    {
                        queue.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        queue.Enqueue(curr.right);
                    }
                }
                level++;
                //Console.WriteLine();
            }
            return maxPair.Value;
        }

        public void Remove(int key)
        {
            RemoveDFS(root, key);
        }

        private BinaryNode MinValueNode(BinaryNode node)
        {
            BinaryNode curr = node;
            while (curr != null && curr.left != null)
            {
                curr = curr.left;
            }
            return curr;
        }

        // Remove a node and return the root of the BST.
        private BinaryNode RemoveDFS(BinaryNode node, int key)
        {
            if (node == null)
            {
                return null;
            }
            if (key > node.Pair.Key)
            {
                node.right = RemoveDFS(node.right, key);
            }
            else if (key < node.Pair.Key)
            {
                node.left = RemoveDFS(node.left, key);
            }
            else
            {
                if (node.left == null)
                {
                    return node.right;
                }
                else if (node.right == null)
                {
                    return node.left;
                }
                else
                {
                    BinaryNode minNode = MinValueNode(node.right);
                    node.Pair = minNode.Pair;
                    node.right = RemoveDFS(node.right, minNode.Pair.Key);
                }
            }
            return node;
        }

        public List<int> GetInorderKeys()
        {
            var list = new List<int>();
            return InOrder(root, list);
        }

        public List<int> InOrder(BinaryNode node, List<int> list)
        {
            if (node == null)
            {
                return list;
            }
            InOrder(node.left, list);
            list.Add(node.Pair.Key);
            InOrder(node.right, list);
            return list;
        }

        public class BinaryNode
        {
            public Pair Pair;
            public BinaryNode left;
            public BinaryNode right;
            public BinaryNode(Pair pair, BinaryNode left = null, BinaryNode right = null)
            {
                this.Pair = pair;
                this.left = left;
                this.right = right;
            }
        }

        public class Pair
        {
            public int Key;
            public int Value;
            public Pair(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

    }
}
