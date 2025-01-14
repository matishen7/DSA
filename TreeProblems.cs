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

        public List<int> RightSideView(TreeNode root)
        {
            var list = new List<IList<int>>();
            if (root == null) return new List<int>();
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
                    if (curr.right != null)
                        queue.Enqueue(curr.right);
                    if (curr.left != null)
                        queue.Enqueue(curr.left);

                }
                list.Add(subList);
            }
            var answer = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                var curr = list[i];
                answer.Add(curr[0]);
            }
            return answer;
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            int res = 0;
            DFS(root, ref res);
            return res;
        }

        private int DFS(TreeNode root, ref int res)
        {
            if (root == null)
            {
                return 0;
            }
            int left = DFS(root.left, ref res);
            int right = DFS(root.right, ref res);
            res = Math.Max(res, left + right);
            return 1 + Math.Max(left, right);
        }

        public bool IsBalanced(TreeNode root)
        {
            return BalancedDFS(root, 0);
        }

        private bool BalancedDFS(TreeNode root, int height)
        {
            if (root == null)
            {
                return true;
            }
            int left = HeightDFS(root.left, height);
            int right = HeightDFS(root.right, height);

            return (Math.Abs(left - right) <= 1 && BalancedDFS(root.left, left) && BalancedDFS(root.right, right));
        }

        private int HeightDFS(TreeNode root, int height)
        {
            if (root == null)
            {
                return 0;
            }
            int left = HeightDFS(root.left, height);
            int right = HeightDFS(root.right, height);
            return 1 + Math.Max(left, right);
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
            return (IsValidBST(root.left) && IsValidBST(root.right));
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

        public TreeNode Remove(TreeNode root, int value)
        {
            return RemoveDFS(root, value);
        }

        public TreeNode RemoveDFS(TreeNode node, int val)
        {
            if (node == null) return node;
            if (val > node.val)
            {
                node.right = RemoveDFS(node.right, val);
            }
            else if (val < node.val)
            {
                node.left = RemoveDFS(node.left, val);
            }
            else
            {
                if (node.right == null) return node.left;
                if (node.left == null) return node.right;

                var cur = node.right;
                while (cur.left != null)
                {
                    cur = cur.left;
                }
                node.val = cur.val;
                node.right = RemoveDFS(node.right, node.val);
            }
            return node;
        }

        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (root == null) return null;

            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);

            if (root.val == target && root.left == null && root.right == null) return null;

            return root;
        }

        public int Rob(TreeNode root)
        {
            var result = RobDfs(root);
            return Math.Max(result.Item2, result.Item1);
        }

        public (int, int) RobDfs(TreeNode root)
        {
            if (root == null) return (0, 0);

            var leftPair = RobDfs(root.left);
            var rightPair = RobDfs(root.right);

            var withRoot = root.val + leftPair.Item2 + rightPair.Item2;
            var withoutRoot = Math.Max(leftPair.Item1, leftPair.Item2) + Math.Max(rightPair.Item1, rightPair.Item1);

            return (withRoot, withoutRoot);

        }

        public TreeNode BuildTree(int?[] values)
        {
            if (values == null || values.Length == 0 || values[0] == null)
                return null;

            TreeNode root = new TreeNode(values[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int i = 1;
            while (i < values.Length)
            {
                TreeNode current = queue.Dequeue();

                // Left child
                if (i < values.Length && values[i] != null)
                {
                    current.left = new TreeNode(values[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;

                // Right child
                if (i < values.Length && values[i] != null)
                {
                    current.right = new TreeNode(values[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
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
