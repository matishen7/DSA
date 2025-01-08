using CrackingTheCodingInterview;
using Neetcode150;
using Neetcode150.GraphProblems;
using Neetcode150.ObjectOriented.ConnectFour;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static Neetcode150.Intervals;
using static Neetcode150.MathAndGeometry;
using static Neetcode150.NeedCode500;
using static Neetcode150.TreeProblems;
int[][] jaggedArray = new int[][]
        {
            new int[] {3, 0, 1, 4, 2}, // Row 1
            new int[] {5, 6, 3, 2, 1}, // Row 2
            new int[] {1, 2, 0, 1, 5}, // Row 3
            new int[] {4, 1, 0, 1, 7}, // Row 4
            new int[] {1, 0, 3, 0, 5}  // Row 5
        };
var obj = new NumMatrix(jaggedArray);

Console.Write(obj.SumRegion(2, 1, 4, 3));
Console.Write(obj.SumRegion(1, 1, 2, 2));
Console.Write(obj.SumRegion(1, 2, 2, 4));
