using CrackingTheCodingInterview;
using Neetcode150;
int[] list1 = [1, 2, 4], list2 = [1, 3, 5];
var head1 = LinkedListProblems.ArrayToLinkedList(list1);
var head2 = LinkedListProblems.ArrayToLinkedList(list2);
Console.WriteLine(LinkedListProblems.MergeTwoLists(head1, head2));
