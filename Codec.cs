using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeMap;
using static Neetcode150.TreeProblems;

namespace Neetcode150
{
    public class Codec
    {

        public static string serialize(TreeNode root)
        {
            var inorder = InOrder(root, new StringBuilder());
            var preorder = PreOrder(root, new StringBuilder());
            return inorder.ToString() + "+" + preorder.ToString();
        }

        // Decodes your encoded data to tree.
        public static TreeNode deserialize(string data)
        {
            int length = data.Length;
            var arr = data.Split("+");
            var inorder = arr[0].Split(".");
            var preorder = arr[1].Split(".");
            inorder = inorder.SkipLast(1).ToArray();
            preorder = preorder.SkipLast(1).ToArray();
            List<int> inorderList = new List<int>();
            List<int> preorderList = new List<int>();

            foreach ( var number in inorder)
            {
                int.TryParse(number, out var result);
                inorderList.Add(result);
            }

            foreach (var number in preorder)
            {
                int.TryParse(number, out var result);
                preorderList.Add(result);
            }

            return BuildTree(preorderList.ToArray(), inorderList.ToArray());
        }

        public static StringBuilder PreOrder(TreeNode node, StringBuilder list)
        {
            if (node == null)
            {
                return list;
            }
            list.Append(node.val + ".");
            PreOrder(node.left, list);
            PreOrder(node.right, list);
            return list;
        }

        public static StringBuilder InOrder(TreeNode node, StringBuilder list)
        {
            if (node == null)
            {
                return list;
            }
            InOrder(node.left, list);
            list.Append(node.val + ".");
            InOrder(node.right, list);
            return list;
        }

        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0 || inorder.Length == 0)
            {
                return null;
            }

            TreeNode root = new TreeNode(preorder[0]);
            int mid = Array.IndexOf(inorder, preorder[0]);
            root.left = BuildTree(preorder.Skip(1).Take(mid).ToArray(), inorder.Take(mid).ToArray());
            root.right = BuildTree(preorder.Skip(mid + 1).ToArray(), inorder.Skip(mid + 1).ToArray());
            return root;
        }

      
    }
}
