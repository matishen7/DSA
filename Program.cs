using Neetcode150;
using Neetcode150.MetaQuestions;
using System;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;

int?[] arr = [3, 5, 1, 6, 2, 0, 8, null, null, 7, 4];
var root = TreeProblems.BuildTree(arr);
var node = TreeProblems.FindNode(root,5);
Console.WriteLine(Meta.DistanceK(root, node, 2));
