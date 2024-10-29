using Neetcode150;
using Neetcode150.GraphProblems;
using System.Threading.Tasks;
using static Neetcode150.TreeProblems;


WordDictionary wordDictionary = new WordDictionary();
wordDictionary.AddWord("bay"); 
wordDictionary.AddWord("day");
wordDictionary.AddWord("may");
Console.WriteLine(wordDictionary.Search("...")); // return false
//Console.WriteLine(wordDictionary.Search("day")); // return true
//Console.WriteLine(wordDictionary.Search(".ay")); // return true
//Console.WriteLine(wordDictionary.Search("b..")); // return true

