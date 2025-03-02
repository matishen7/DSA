using Neetcode150;
using Neetcode150.MetaQuestions;
using static Neetcode150.LinkedListProblems;
using static Neetcode150.Meta;

int?[] nums = [3,5,1,6,2,0,8,null,null,7,4];
var root = TreeProblems.BuildTree(nums);
var p = TreeProblems.FindNode(root, 5);
var q = TreeProblems.FindNode(root, 4);
Console.WriteLine(Meta.LowestCommonAncestor(root, p, q));
