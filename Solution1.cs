using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150
{
    internal class Solution1
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            while (true)
            {
                if (root.val < p.val && root.val < q.val)
                {
                    root = root.right;
                }
                else if (root.val > p.val && root.val > q.val)
                {
                    root = root.left;
                }
                else
                {
                    return root;
                }
            }
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

        public void PrintTree(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                Console.Write(node.val + " ");

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }

    }
}
