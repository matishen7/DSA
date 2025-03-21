using Neetcode150;
using Neetcode150.LeetcodeMarch;
using Neetcode150.MetaQuestions;
using Neetcode150.ObjectOriented.ConnectFour;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

int?[] arr = [3, 9, 20, null, null, 15, 7];
var root = TreeProblems.BuildTree(arr);
TreeProblems.PrintBST(root);


Console.WriteLine(SolutionMarch.ZigzagLevelOrder(root));
