using Neetcode150;
using Neetcode150.MetaQuestions;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

//int?[] arr = [4, 2, 5, 1, 3];
//var root = TreeProblems.BuildTree(arr);
int[] nums = [1, 3, 5,7,9];
RandomPickWithWeight solution = new RandomPickWithWeight(nums);
Console.WriteLine(solution.PickIndex()); // return 1. It is returning the second element (index = 1) that has a probability of 3/4.
Console.WriteLine(solution.PickIndex()); // return 1
Console.WriteLine(solution.PickIndex()); // return 1
Console.WriteLine(solution.PickIndex()); // return 1
Console.WriteLine(solution.PickIndex());
Console.WriteLine(Meta.AddStrings("99", "99"));
