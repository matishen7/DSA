using Neetcode150;
using Neetcode150.LeetcodeMarch;
using Neetcode150.MetaQuestions;
using Neetcode150.ObjectOriented.ConnectFour;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

int?[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, null, null, 15];
var root1 = TreeProblems.BuildTree(arr);
TreeProblems.PrintBST(root1);

//var node3 = new ListNode(2);
//var node2 = new ListNode(1, node3);
//var node1 = new ListNode(1, node2);

Console.WriteLine(SolutionMarch.IsCompleteTree(root1));
