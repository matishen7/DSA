using Neetcode150;
using Neetcode150.GraphProblems;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

char[][] board = new char[][]
{
    new char[] { 'a', 'b', 'c', 'd' },
    new char[] { 's', 'a', 'a', 't' },
    new char[] { 'a', 'c', 'k', 'e' },
    new char[] { 'a', 'c', 'd', 'n' }
};
string[] words = ["bat", "cat", "back", "backend", "stack"];
BackTrackingProblems.FindWords(board, words);

