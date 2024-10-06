
using Neetcode150;
using static Neetcode150.TreeProblems;

TreeProblems bst = new TreeProblems();
int[] array = { 1, 2, 3, 4, 5, 6, 7 };
TreeNode p = bst.CreateBSTFromArray(array);
TreeNode q = bst.CreateBSTFromArray(array);
bst.PrintBST(p);
var same = bst.IsSameTree(p,q);
Console.WriteLine("----------------------");
