using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    internal class RandomPointer
    {
        public DoubleNode copyRandomList(DoubleNode head)
        {
            Dictionary<DoubleNode, DoubleNode> oldToCopy = new Dictionary<DoubleNode, DoubleNode>();

            DoubleNode cur = head;
            while (cur != null)
            {
                DoubleNode copy = new DoubleNode(cur.val);
                oldToCopy[cur] = copy;
                cur = cur.next;
            }

            cur = head;
            while (cur != null)
            {
                DoubleNode copy = oldToCopy[cur];
                copy.next = cur.next != null ? oldToCopy[cur.next] : null;
                copy.random = cur.random != null ? oldToCopy[cur.random] : null;
                cur = cur.next;
            }

            return head != null ? oldToCopy[head] : null;
        }
    }

    public class DoubleNode
    {
        public int val;
        public DoubleNode next;
        public DoubleNode random;

        public DoubleNode(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
