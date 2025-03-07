using Neetcode150;
using Neetcode150.MetaQuestions;
using System;
using static Neetcode150.Intervals;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;

//int?[] arr = [4, 2, 5, 1, 3];
//var root = TreeProblems.BuildTree(arr);
int[][] intervals = [[0, 30], [5, 10], [15, 20]];
Console.WriteLine(Meta.MinMeetingRooms(intervals));
