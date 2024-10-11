
using Neetcode150;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

var sol = new Solution1();
int?[] values = [5, 3, 8, 1, 4, 7, 9, null, 2];
int?[] qValues = { 8, 7, 9 };
int?[] pValues = { 3, 1, 4, null, 2 };

var root = sol.BuildTree(values);
var p = sol.BuildTree(qValues);
var q = sol.BuildTree(pValues);
var res = sol.LowestCommonAncestor(root, p, q);
