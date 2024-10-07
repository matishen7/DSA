
using Neetcode150;
using static Neetcode150.TreeProblems;

TreeProblems trees = new TreeProblems();
int[] root = [2, 1, 3], subRoot = [2, 4, 5];
var node1 = trees.CreateBSTFromArray(root);
trees.PrintBST(node1);
Console.WriteLine(trees.KthSmallest(node1, 1));
Console.ReadKey();
