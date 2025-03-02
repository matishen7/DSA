using Neetcode150;
using Neetcode150.MetaQuestions;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;

int?[] nums = [1, 2, 3, 4, 10, 9, 11, null, 5, null, null, null, null, null, null, null, 6];
var root = TreeProblems.BuildTree(nums);
Console.WriteLine(Meta.VerticalTraversal(root));
