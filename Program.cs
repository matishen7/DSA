using CrackingTheCodingInterview;
using Neetcode150;
using Neetcode150.GraphProblems;
using Neetcode150.ObjectOriented.ConnectFour;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;
int n = 5;
List<List<int>> edges = new List<List<int>>
        {
            new List<int> { 0, 1, 10 },
            new List<int> { 0, 2, 3 },
            new List<int> { 1, 3, 2 },
            new List<int> { 2, 1, 4 },
            new List<int> { 2, 3, 8 },
            new List<int> { 2, 4, 2 },
            new List<int> { 3, 4, 5 }
        };
int src = 0;

AdvancedGraphs.ShortestPath(n, edges, src);

