using CrackingTheCodingInterview;
using Neetcode150;
using Neetcode150.GraphProblems;
using Neetcode150.ObjectOriented.ConnectFour;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;
int n = 5;
int[][] flights = [[4, 1, 1], [1, 2, 3], [0, 3, 2], [0, 4, 10], [3, 1, 1], [1, 4, 3]];
int src = 2;
int dst = 1;
int k = 1;



AdvancedGraphs.FindCheapestPrice(n, flights, src, dst, k);
