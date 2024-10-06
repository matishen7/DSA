using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public class TreeProblems
    {
        public TreeNode InvertTree(TreeNode root)
        {
            return InvertTreeDFS(root);
        }

        public TreeNode InvertTreeDFS(TreeNode root)
        {
            if (root == null)
                return null;
            var temp = root.left;
            root.left = InvertTreeDFS(root.right);
            root.right = InvertTreeDFS(temp);
            return root;
        }

        public int MaxDepth(TreeNode root)
        {
            return MaxDepthDFS(root, 0);
        }
        public int MaxDepthDFS(TreeNode root, int height)
        {
            if (root == null) return 0;
            var h = 1 + Math.Max(MaxDepthDFS(root.right, height + 1), MaxDepthDFS(root.left, height + 1));
            return h;
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            else if (p == null && q != null) return false;
            else if (p != null && q == null) return false;
            else if (p.val != q.val) return false;
            else if (p.val == q.val)
            {
                var sameLeft = IsSameTree(p.left, q.left);
                var sameRight = IsSameTree(p.right, q.right);
                return sameLeft && sameRight;
            }
            return true;
        }



        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public TreeNode Insert(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }

            if (val > root.val)
            {
                root.right = Insert(root.right, val);
            }
            else if (val < root.val)
            {
                root.left = Insert(root.left, val);
            }
            return root;
        }

        public TreeNode CreateBSTFromArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return null;
            }

            // Create the root with the first element
            TreeNode root = new TreeNode(nums[0]);

            // Use a queue to assign children in level order
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int i = 1; // Index for array elements
            while (i < nums.Length)
            {
                TreeNode current = queue.Dequeue();

                // Assign the left child
                if (i < nums.Length)
                {
                    current.left = new TreeNode(nums[i++]);
                    queue.Enqueue(current.left);
                }

                // Assign the right child
                if (i < nums.Length)
                {
                    current.right = new TreeNode(nums[i++]);
                    queue.Enqueue(current.right);
                }
            }
            return root;
        }

        public void PrintBST(TreeNode root)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            // Get the height of the tree for calculating the initial spacing
            int height = GetHeight(root);

            // Initialize a queue to perform level-order traversal
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int maxLevel = height;
            int level = 1;

            // Perform level-order traversal while printing the tree
            while (queue.Count > 0)
            {
                int nodeCount = queue.Count;
                int spaces = (int)Math.Pow(2, maxLevel - level) - 1; // Calculate the spaces between nodes at the current level

                PrintSpaces(spaces); // Initial spacing for the first node at the level

                // Print all nodes at the current level
                while (nodeCount > 0)
                {
                    TreeNode current = queue.Dequeue();

                    if (current != null)
                    {
                        Console.Write(current.val.ToString());
                        queue.Enqueue(current.left);
                        queue.Enqueue(current.right);
                    }
                    else
                    {
                        Console.Write(" ");
                        queue.Enqueue(null);
                        queue.Enqueue(null);
                    }

                    nodeCount--;

                    if (nodeCount > 0)
                    {
                        PrintSpaces(2 * spaces + 1); // Space between nodes
                    }
                }

                Console.WriteLine(); // Move to the next level
                level++;
                if (level > maxLevel)
                {
                    break;
                }
            }
        }

        // Method to calculate the height of the tree
        private int GetHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
        }

        // Helper method to print a specific number of spaces
        private void PrintSpaces(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
