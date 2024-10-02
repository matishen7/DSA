using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
