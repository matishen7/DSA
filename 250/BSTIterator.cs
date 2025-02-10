using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150._250
{
    public class BSTIterator
    {
        private Stack<TreeNode> stack = new Stack<TreeNode>();

        public BSTIterator(TreeNode root)
        {
            TreeNode curr = root;

            while (curr != null)
            {

                stack.Push(curr);
                curr = curr.left;
            }
        }

        public int Next()
        {
            var curr = stack.Pop();

            if (curr.right != null)
            {
                var temp = curr.right;
                while (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.left;
                }
            }

            return curr.val;
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }
    }
}
