﻿using Neetcode150;
using Neetcode150.LeetcodeMarch;
using Neetcode150.MetaQuestions;
using Neetcode150.ObjectOriented.ConnectFour;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

//int?[] arr = [1, 3, 2, 5, null, null, 9, 6, null, 7];
//var root1 = TreeProblems.BuildTree(arr);
//TreeProblems.PrintBST(root1);

//var node5 = new ListNode(5);
//var node4 = new ListNode(4, node5);
//var node3 = new ListNode(3, node4);
//var node2 = new ListNode(2);
//var node1 = new ListNode(1, node2);
int[] nums = [2, 1, 3, 5, 6]; int k = 5, multiplier = 2;
Console.WriteLine(SolutionMarch.GetFinalState(nums, k, multiplier));


