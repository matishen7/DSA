using Neetcode150;
using Neetcode150.LeetcodeMarch;
using Neetcode150.MetaQuestions;
using Neetcode150.ObjectOriented.ConnectFour;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

//int?[] arr = [5, 5, 5, 5, 5, null, 5];
//var root = TreeProblems.BuildTree(arr);
//TreeProblems.PrintBST(root);
//int[] nums = [1, 0, 1];int[][] queries = [[0, 2]];
int[][] boxTypes = [[5, 10], [2, 5], [4, 7], [3, 9]]; int truckSize = 4;
Console.WriteLine(SolutionMarch.MaximumUnits(boxTypes, 10));
