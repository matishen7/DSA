using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150.LeetcodeMarch
{
    public class AmazonSolutions
    {
        public static bool IsAnagram(string s, string t)
        {
            int[] countS = new int[26];
            int[] countT = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                countS[s[i] - 'a']++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                countT[t[i] - 'a']++;
            }

            for (int i = 0; i < countT.Length; i++)
                if (countS[i] != countT[i]) return false;

            return true;
        }
        public static int SearchRotatedArray(int[] nums, int target)
        {
            int pivot = FindPivot(nums);

            int left = 0;
            int right = nums.Length - 1;
            if (pivot == 0)
                right = pivot;
            else right = pivot - 1;

            int found = BinarySearch(nums, left, right, target);
            if (found != -1) return found;
            found = BinarySearch(nums, pivot, nums.Length - 1, target);
            return found;
        }

        public static int BinarySearch(int[] nums, int left, int right, int target)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }
        public static int FindPivot(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] > nums[nums.Length - 1])
                    left = mid + 1;
                else right = mid - 1;
            }

            return left;
        }

        public static int CountUnivalSubtrees(TreeNode root)
        {
            int count = 0;
            var list = new HashSet<TreeNode>();
            ListAllNodes(root, list);
            foreach (var node in list)
            {
                if (CountUnivalSubtreesDFS(node, node.val)) count++;
            }
            return count;
        }

        public static bool CountUnivalSubtreesDFS(TreeNode node, int parent)
        {
            if (node == null) return true;
            if (parent != node.val) return false;
            bool left = CountUnivalSubtreesDFS(node.left, node.val);
            bool right = CountUnivalSubtreesDFS(node.right, node.val);
            return (left && right);
        }

        public static void ListAllNodes(TreeNode root, HashSet<TreeNode> list)
        {
            if (root == null) return;
            if (!list.Contains(root)) list.Add(root);

            ListAllNodes(root.left, list);
            ListAllNodes(root.right, list);
        }
    }
}
