using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeMap;

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

        //public bool IsSubtree(TreeNode root, TreeNode subRoot)
        //{
        //    var foundNode = BfsTraversal(root, subRoot.val);
        //    if (foundNode == null) return false;
        //    return IsSameTree(foundNode, subRoot);
        //}


        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var list = new List<IList<int>>();
            if (root == null) return list;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int levelLength = queue.Count;
                var subList = new List<int>();
                for (int i = 0; i < levelLength; i++)
                {

                    var curr = queue.Dequeue();
                    subList.Add(curr.val);
                    if (curr.left != null)
                        queue.Enqueue(curr.left);
                    if (curr.right != null)
                        queue.Enqueue(curr.right);
                }
                list.Add(subList);
            }
            return list;
        }

        public List<int> BfsTraversal(TreeNode root)
        {
            var list = new List<int>();
            if (root == null) return list;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int levelLength = queue.Count;
                for (int i = 0; i < levelLength; i++)
                {

                    var curr = queue.Dequeue();
                    list.Add(curr.val);
                    if (curr.left != null)
                        queue.Enqueue(curr.left);
                    if (curr.right != null)
                        queue.Enqueue(curr.right);
                }
            }
            return list;
        }

        public int KthSmallest(TreeNode root, int k)
        {
            var list = InOrder(root, new List<int>());
            return list[k - 1];
        }

        public List<int> InOrder(TreeNode root, List<int> list)
        {
            if (root == null) return list;
            
            InOrder(root.left, list);
            list.Add(root.val);
            InOrder(root.right, list);
            
            return list;
        }

        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            else if (root.left != null && root.left.val >= root.val) return false;
            else if (root.right != null && root.right.val <= root.val) return false;
            return (IsValidBST(root.left)&&IsValidBST(root.right));
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
