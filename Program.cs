using Neetcode150.GraphProblems;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

char[][] board = new char[][]
{
    new char[] { 'X', 'X', 'X', 'X' },
    new char[] { 'X', 'O', 'O', 'X' },
    new char[] { 'X', 'O', 'O', 'X' },
    new char[] { 'X', 'X', 'X', 'O' }
};


Graphs.Solve(board);

