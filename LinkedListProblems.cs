using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

namespace Neetcode150
{
    internal class LinkedListProblems
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public int MaxPathSum(TreeNode root)
        {
            int res = root.val;
            Dfs(root, ref res);
            return res;
        }

        private int Dfs(TreeNode root, ref int res)
        {
            if (root == null)
            {
                return 0;
            }

            int leftMax = Math.Max(Dfs(root.left, ref res), 0);
            int rightMax = Math.Max(Dfs(root.right, ref res), 0);

            res = Math.Max(res, root.val + leftMax + rightMax);
            return root.val + Math.Max(leftMax, rightMax);
        }

        public int GoodNodes(TreeNode root)
        {
            int res = 0;
            GoodNodesDfs(root, root.val, ref res);
            return res;
        }

        public void GoodNodesDfs(TreeNode root, int pathMax, ref int res)
        {
            if (root == null) return;
            if (pathMax <= root.val) res++;
            pathMax = Math.Max(root.val, pathMax);
            GoodNodesDfs(root.left, pathMax, ref res);
            GoodNodesDfs(root.right, pathMax, ref res);
        }

        private bool CheckPath(int val, List<int> path)
        {
            for (int i = 0; i < path.Count; i++) 
                if (path[i] > val) return false;
            return true;
        }

        public static ListNode ArrayToLinkedList(int[] arr)
        {
            if (arr.Length == 0)
            {
                return null; // Return null if the array is empty
            }

            // Initialize the head node with the first element of the array
            ListNode head = new ListNode(arr[0]);
            ListNode current = head;

            // Iterate through the array and create the linked list
            for (int i = 1; i < arr.Length; i++)
            {
                current.next = new ListNode(arr[i]); // Create the next node
                current = current.next; // Move to the next node
            }

            return head; // Return the head of the linked list
        }

        public static ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;
            int i = 0;
            ListNode currentNode = head;
            ListNode reversed = null;
            while (currentNode != null)
            {
                ListNode node = new ListNode(currentNode.val);
                if (i == 0)
                {
                    node.next = null;
                    i++;
                }
                else
                    node.next = reversed;

                reversed = node;
                currentNode = currentNode.next;
            }
            return reversed;
        }



        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode newList = new ListNode();
            ListNode tail = newList;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }

            if (list1 != null) tail.next = list1;
            else if (list2 != null) tail.next = list2;

            return newList.next;
        }

        public static int[] LinkedListToArray(ListNode head)
        {
            var list = new List<int>();
            var tail = head;
            while (tail != null)
            {
                list.Add(tail.val);
                tail = tail.next;
            }
            return list.ToArray();
        }

        public static void Reorder(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            ListNode part1 = head;
            ListNode part2 = slow.next;
            part2 = ReverseList(part2);
            // ListNode dummy = new ListNode();
            while (part2 != null && part1 != null)
            {
                ListNode temp1 = part1.next;
                ListNode temp2 = part2.next;
                part1.next = part2;
                part2.next = temp1;
                temp1.next = temp2;

                temp2 = temp2.next;
                temp1 = temp2.next;

                part1 = part1.next;
                part2 = part2.next;
            }
        }

        public static bool HasCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow) return true;
            }
            return false;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var tail1 = l1;
            var tail2 = l2;
            ListNode dummy = new ListNode(-1);
            var previous = dummy;
            int carry = 0;
            while (tail1 != null && tail2 != null)
            {
                int sum = tail1.val + tail2.val + carry;
                var newNode = new ListNode(sum % 10);
                previous.next = newNode;
                previous = previous.next;
                carry = sum / 10;
                tail1 = tail1.next;
                tail2 = tail2.next;
            }

            while (tail1 != null)
            {
                int sum = tail1.val + carry;
                var newNode = new ListNode(sum % 10);
                previous.next = newNode;
                previous = previous.next;
                carry = sum / 10;
                tail1 = tail1.next;
            }

            while (tail2 != null)
            {
                int sum = tail2.val + carry;
                var newNode = new ListNode(sum % 10);
                previous.next = newNode;
                previous = previous.next;
                carry = sum / 10;
                tail2 = tail2.next;
            }
            if (carry != 0)
            {
                var newNode = new ListNode(carry);
                previous.next = newNode;
                previous = previous.next;
            }
            return dummy.next;
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(-1, head);
            var right = head;
            while (n > 0)
            {
                right = right.next;
                n--;
            }

            var left = dummy;
            while (right != null)
            {
                left = left.next;
                right = right.next;
            }

            left.next = left.next.next;
            return dummy.next;
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            var queue = new PriorityQueue<int, int>();
            for (int i = 0; i < lists.Length; i++)
            {
                var head = lists[i];
                if (head == null) continue;
                var tail = head;
                while (tail != null)
                {
                    queue.Enqueue(tail.val, tail.val);
                    tail = tail.next;
                }
            }
            var dummy = new ListNode(int.MinValue);
            var previous = dummy;
            while (queue.Count > 0)
            {
                var value = queue.Dequeue();
                var newNode = new ListNode(value);
                previous.next = newNode;
                previous = previous.next;
            }

            return dummy.next;
        }

        public static ListNode[] ArrayToLinkedListArray(int[][] arr)
        {
            // Create an array of ListNode with the same length as the input 2D array
            ListNode[] listNodes = new ListNode[arr.Length];

            // Iterate over each sub-array in the 2D array
            for (int i = 0; i < arr.Length; i++)
            {
                // Convert each sub-array to a linked list
                if (arr[i].Length > 0)
                {
                    listNodes[i] = new ListNode(arr[i][0]); // Initialize the head
                    ListNode current = listNodes[i];

                    // Iterate through the rest of the sub-array
                    for (int j = 1; j < arr[i].Length; j++)
                    {
                        current.next = new ListNode(arr[i][j]); // Create the next node
                        current = current.next; // Move to the next node
                    }
                }
                else
                {
                    listNodes[i] = null; // If the sub-array is empty, set the linked list to null
                }
            }

            return listNodes; // Return the array of ListNode
        }
    }
}
