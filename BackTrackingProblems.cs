using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150
{
    internal class BackTrackingProblems
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            return HasPathSumDfs(root, 0, targetSum);
        }

        public bool HasPathSumDfs(TreeNode root, int sum, int targetSum)
        {
            if (root==null) return false;
            sum += root.val;

            if (root.left == null && root.right == null)
            {
                if (targetSum == sum)
                    return true;
            }
            if (HasPathSumDfs(root.left, sum, targetSum))
            {
                return true;
            }
            if (HasPathSumDfs(root.right, sum, targetSum))
            {
                return true;
            }
            sum -= root.val;
            return false;
        }
    }
}
