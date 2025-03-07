using Neetcode150;
using Neetcode150.MetaQuestions;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;
using Node = Neetcode150.Meta.Node;

//int?[] arr = [4, 2, 5, 1, 3];
//var root = TreeProblems.BuildTree(arr);
Node node1 = new Node(1);
Node node10 = new Node(10, node1);
Node node11 = new Node(11, node10);
Node node13 = new Node(13, node11);
Node node7 = new Node(7, node13);
node7.random = null;
node13.random = node7;
node11.random = node1;
node10.random = node11;
node1.random = node7;

Console.WriteLine(Meta.CopyRandomList(node7));
