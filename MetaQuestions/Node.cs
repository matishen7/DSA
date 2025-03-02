using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.MetaQuestions
{
    public class Meta1
    {
        public static Node LowestCommonAncestor(Node p, Node q)
        {
            var seen = new List<int>();
            while (p != null)
            {
                seen.Add(p.val);
                p = p.parent;
            }

            while (q != null)
            {
                if (seen.Contains(q.val)) return q;
                //seen.Add(q.val);
                q = q.parent;
            }

            return q;
        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;

        public Node(int val)
        {
            this.val = val;
            this.left = null;
            this.right = null;
            this.parent = null;
        }
    }

    public class BinaryTreeBuilder
    {
        public static Node FindNode(Node root, int value)
        {
            if (root == null) return null;
            if (root.val == value) return root;

            Node leftSearch = FindNode(root.left, value);
            if (leftSearch != null) return leftSearch;

            return FindNode(root.right, value);
        }

        public static Node BuildTree(int?[] nums)
        {
            if (nums == null || nums.Length == 0 || nums[0] == null) return null;

            Node root = new Node(nums[0].Value);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int i = 1;

            while (queue.Count > 0 && i < nums.Length)
            {
                Node current = queue.Dequeue();

                if (i < nums.Length && nums[i] != null)
                {
                    current.left = new Node(nums[i].Value);
                    current.left.parent = current;
                    queue.Enqueue(current.left);
                }
                i++;

                if (i < nums.Length && nums[i] != null)
                {
                    current.right = new Node(nums[i].Value);
                    current.right.parent = current;
                    queue.Enqueue(current.right);
                }
                i++;
            }

            return root;
        }

        // Helper method for testing
        public static void PrintTree(Node root)
        {
            if (root == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                Console.Write($"{node.val} -> ");

                if (node.left != null)
                {
                    Console.Write($"L:{node.left.val} ");
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    Console.Write($"R:{node.right.val} ");
                    queue.Enqueue(node.right);
                }

                if (node.parent != null)
                {
                    Console.Write($"(P:{node.parent.val})");
                }

                Console.WriteLine();
            }
        }
    }
}
