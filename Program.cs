using Neetcode150;
using Neetcode150._250;
using Neetcode150.GraphProblems;
using Neetcode150.ObjectOriented.ConnectFour;

int[] vals = [1,2,3,4, 5];int left = 2, right = 4;
var head = LinkedListProblems.ArrayToLinkedList(vals);
Console.WriteLine(LinkedListProblems.ReverseBetween(head, left, right));
