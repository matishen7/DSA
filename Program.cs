using Neetcode150;
using Neetcode150.GraphProblems;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;


string word = "apple";

var trie = new Trie();
trie.Insert(word);
Console.WriteLine(trie.Search("app"));
Console.WriteLine(trie.StartWith("app"));

