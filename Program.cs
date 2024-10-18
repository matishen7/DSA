using Neetcode150.GraphProblems;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

List<List<int>> adjList = [[2], [1, 3], [2]];
GraphSolution g = new GraphSolution();
var node  = g.BuildGraph(adjList);
g.CloneGraph(node);

