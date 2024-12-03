using CrackingTheCodingInterview;
using Neetcode150;
using Neetcode150.GraphProblems;
using Neetcode150.ObjectOriented.ConnectFour;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static Neetcode150.Intervals;
using static Neetcode150.MathAndGeometry;
using static Neetcode150.TreeProblems;

int[] arr = { 9,9,9 };


CountSquares countSquares = new CountSquares();
countSquares.Add([1, 1]);
countSquares.Add([2, 2]);
countSquares.Add([1, 2]);

Console.WriteLine(countSquares.Count([2, 1]));   // return 1.
Console.WriteLine(countSquares.Count([3, 3]));   // return 0.
countSquares.Add([2, 2]);     // Duplicate points are allowed.
Console.WriteLine(countSquares.Count([2, 1]));   // return 2. 


//Console.WriteLine(MathAndGeometry.SetZeroes(matrix));
