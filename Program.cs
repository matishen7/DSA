using Neetcode150;
using Neetcode150.LeetcodeMarch;
using Neetcode150.MetaQuestions;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

//int?[] arr = [5, 5, 5, 5, 5, null, 5];
//var root = TreeProblems.BuildTree(arr);
//TreeProblems.PrintBST(root);
int[][] matrix = [[-5]];
int target = -5;
Console.WriteLine(AmazonSolutions.SearchMatrix(matrix, target));
