using Neetcode150;
using Neetcode150.LeetcodeMarch;
using Neetcode150.MetaQuestions;
using Neetcode150.ObjectOriented.ConnectFour;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

int?[] arr = [3, 5, 1, 6, 2, 9, 8, null, null, 7, 4];
int?[] arr2 = [3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8];
var root1 = TreeProblems.BuildTree(arr);
var root2 = TreeProblems.BuildTree(arr2);
TreeProblems.PrintBST(root1);
TreeProblems.PrintBST(root2);

//var node3 = new ListNode(2);
//var node2 = new ListNode(1, node3);
//var node1 = new ListNode(1, node2);
int[][]grid =
[[0, 0, 1, 1, 0, 1, 0, 0, 1, 0], [1, 1, 0, 1, 1, 0, 1, 1, 1, 0], [1, 0, 1, 1, 1, 0, 0, 1, 1, 0], [0, 1, 1, 0, 0, 0, 0, 1, 0, 1], [0, 0, 0, 0, 0, 0, 1, 1, 1, 0], [0, 1, 0, 1, 0, 1, 0, 1, 1, 1], [1, 0, 1, 0, 1, 1, 0, 0, 0, 1], [1, 1, 1, 1, 1, 1, 0, 0, 0, 0], [1, 1, 1, 0, 0, 1, 0, 1, 0, 1], [1, 1, 1, 0, 1, 1, 0, 1, 1, 0]];
Console.WriteLine(SolutionMarch.LeafSimilar(root1, root2));
