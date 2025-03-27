using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.LeetcodeMarch
{
    public class BrowserHistory
    {
        private DoubleLinkedList head;
        private DoubleLinkedList current;

        public BrowserHistory(string homepage)
        {
            head = new DoubleLinkedList(homepage);
            current = head;
        }

        public void Visit(string url)
        {
            var prev = current;
            var node = new DoubleLinkedList(url);
            current.next = node;
            current = current.next;
            current.prev = prev;
        }

        public string Back(int steps)
        {
            int i = 0;
            while (i < steps && current.prev != null)
            {
                i++;
                current = current.prev;
            }

            return current.url;
        }

        public string Forward(int steps)
        {
            int i = 0;
            while (i < steps && current.next != null)
            {
                i++;
                current = current.next;
            }

            return current.url;
        }

        public class DoubleLinkedList
        {
            public string url = string.Empty;
            public DoubleLinkedList? prev = null;
            public DoubleLinkedList? next = null;

            public DoubleLinkedList(string url)
            {
                this.url = url;
            }

            public DoubleLinkedList(string url, DoubleLinkedList? next, DoubleLinkedList? prev)
            {
                this.url = url;
                this.prev = prev;
                this.next = next;
            }
        }
    }

   

    /**
     * Your BrowserHistory object will be instantiated and called as such:
     * BrowserHistory obj = new BrowserHistory(homepage);
     * obj.Visit(url);
     * string param_2 = obj.Back(steps);
     * string param_3 = obj.Forward(steps);
     */
}
