using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public class WordDictionary
    {
        TrieNode root;
        public WordDictionary()
        {
            root = new TrieNode();
        }

        public void AddWord(string word)
        {
            TrieNode curr = root;
            foreach (char c in word)
            {
                if (!curr.children.ContainsKey(c))
                {
                    curr.children.Add(c, new TrieNode());
                }
                curr = curr.children[c];
            }
            curr.isLeaf = true;
        }

        public bool Search(string word)
        {
            TrieNode curr = root;
            return SearchDfs(0, word, curr);
        }

        public bool SearchDfs(int j, string word, TrieNode root)
        {
            var curr = root;
            for (int i = j; i < word.Length; i++)
            {
                var c = word[i];
                if (c == '.')
                {
                    foreach (var child in curr.children.Values)
                    {
                        if (child != null && SearchDfs(i + 1, word, child)) return true;
                    }
                    return false;
                }
                else
                {
                    if (!curr.children.ContainsKey(c))
                        return false;
                    curr = curr.children[c];
                }
            }
            return curr.isLeaf;
        }
    }
}
