using Neetcode150;
using Neetcode150.MetaQuestions;
using System;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;

int[] arr = [4, 9, 0, 5, 1];
var root = TreeProblems.CreateBSTFromArray(arr);
Console.WriteLine(Meta.SumNumbers(root));
