using CrackingTheCodingInterview;
using Neetcode150;
using Neetcode150.GraphProblems;
using Neetcode150.ObjectOriented.ConnectFour;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;

var tickets = new List<List<string>>
        {
              new List<string> { "BUF", "HOU" },
            new List<string> { "HOU", "SEA" },
            new List<string> { "JFK", "BUF" } };




Prims.FindItinerary(tickets);
