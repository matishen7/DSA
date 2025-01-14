using Neetcode150._250;
using Neetcode150.GraphProblems;
List<List<string>> accounts = [["John", "johnsmith@mail.com", "john_newyork@mail.com"], ["John", "johnsmith@mail.com", "john00@mail.com"], ["Mary", "mary@mail.com"], ["John", "johnnybravo@mail.com"]];
int[][] edges = [[3, 0], [3, 1], [3, 2], [3, 4], [5, 4]];
Graphs.FindMinHeightTrees(6, edges);
