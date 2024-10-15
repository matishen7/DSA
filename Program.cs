
using Neetcode150;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

int?[] arr = { -15, 10, 20, null, null, 15, 5, -5 };
TreeProblems tp = new TreeProblems();
var node = tp.BuildTree(arr);
LinkedListProblems llp = new LinkedListProblems();
llp.MaxPathSum(node);

