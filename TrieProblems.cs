using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150
{
    public class TrieNode
    {
        public bool isLeaf;   // isLeaf
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    }

    public class PrefixTree
    {

        TrieNode root;

        public PrefixTree()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
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
            foreach (char c in word)
            {
                if (!curr.children.ContainsKey(c))
                    return false;
                curr = curr.children[c];
            }
            return curr.isLeaf;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode curr = root;
            foreach (char c in prefix)
            {
                if (!curr.children.ContainsKey(c))
                    return false;
                curr = curr.children[c];
            }
            return true;
        }
    }
}
