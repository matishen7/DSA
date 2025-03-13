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
char[][] grid = [['X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'], ['X', '*', 'O', 'X', 'O', '#', 'O', 'X'], ['X', 'O', 'O', 'X', 'O', 'O', 'X', 'X'], ['X', 'O', 'O', 'O', 'O', '#', 'O', 'X'], ['O', 'O', 'O', 'O', 'O', 'O', 'O', 'O']];
int k = 1;
Console.WriteLine(SolutionMarch.GetFood(grid));
