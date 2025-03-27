using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.LinkedListProblems;

namespace Neetcode150.LeetcodeMarch
{
    public class MyLinkedList
    {
        private ListNode? head;
        private ListNode? tail;
        private int count;
        public MyLinkedList()
        {
            head = null;
            tail = head;
            count = -1;
        }

        public int Get(int index)
        {
            if (index >= count) return -1;

            int i = 0;
            var current = head;
            while (i < count && current.next != null)
            {
                current = current.next;
                i++;
            }
            return current.val;
        }

        public void AddAtHead(int val)
        {
            var node = new ListNode(val);
            node.next = head;
            head = node;
            count += 1;
        }

        public void AddAtTail(int val)
        {
            var node = new ListNode(val);
            var curr = head;
            while (curr.next != null)
            {
                curr = curr.next;
            }
            curr.next = node;
            count += 1;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index >= count) return;
            var node = new ListNode(val);
            int i = 0;
            var prev = head;
            var current = head;
            while (i < count && current.next != null)
            {
                prev = current;
                current = current.next;
                i++;
            }

            prev.next = node;
            node.next = current;
            count += 1;
        }

        public void DeleteAtIndex(int index)
        {
            if (index >= count) return;
            int i = 0;
            var prev = head;
            var current = head;
            while (i < count && current.next != null)
            {
                prev = current;
                current = current.next;
                i++;
            }

            prev.next = current.next;
            count -= 1;
        }
    }

    /**
     * Your MyLinkedList object will be instantiated and called as such:
     * MyLinkedList obj = new MyLinkedList();
     * int param_1 = obj.Get(index);
     * obj.AddAtHead(val);
     * obj.AddAtTail(val);
     * obj.AddAtIndex(index,val);
     * obj.DeleteAtIndex(index);
     */
}
