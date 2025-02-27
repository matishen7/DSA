using Neetcode150;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
ListNode listnode5 = new ListNode(5);
ListNode listnode4 = new ListNode(4,listnode5);
ListNode listnode3 = new ListNode(3, listnode4);
ListNode listnode2 = new ListNode(2, listnode3);
ListNode listnode1 = new ListNode(1, listnode2);

Meta.RemoveNthFromEnd(listnode1,2);
