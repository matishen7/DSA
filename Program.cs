using Neetcode150;
using Neetcode150.LeetcodeMarch;
using Neetcode150.MetaQuestions;
using Neetcode150.ObjectOriented.ConnectFour;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

//int?[] arr = [3, 9, 20, null, null, 15, 7];
//var root = TreeProblems.BuildTree(arr);
//TreeProblems.PrintBST(root);

//var node3 = new ListNode(2);
//var node2 = new ListNode(1, node3);
//var node1 = new ListNode(1, node2);
int[] edges = [2,0,0];int node1 = 2, node2 = 0;
Console.WriteLine(SolutionMarch.ClosestMeetingNode(edges, node1, node2));
