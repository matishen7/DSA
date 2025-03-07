using Neetcode150;
using Neetcode150.MetaQuestions;
using System;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;

int?[] arr = [4, 2, 5, 1, 3];
var root = TreeProblems.BuildTree(arr);
Console.WriteLine(Meta.ClosestValue(root, 3.714286));
