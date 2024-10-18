using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.GraphProblems
{
    public class GraphSolution
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
        public Node CloneGraph(Node node)
        {
            if (node == null) return null;
            if (node.neighbors == null) return node;
            Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();
            Queue<Node> queue = new Queue<Node>();
            HashSet<int> set = new HashSet<int>();
            queue.Enqueue(node);
            set.Add(node.val);
            while (queue.Any())
            {
                var cur = queue.Dequeue();
                Node copy = new Node(cur.val);
                oldToCopy[cur] = copy;
                foreach (var neighbor in node.neighbors)
                {
                    if (!set.Contains(neighbor.val))
                    {
                        set.Add(neighbor.val);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return node;
        }

        public Node BuildGraph(List<List<int>> adjList)
        {
            if (adjList == null || adjList.Count == 0) return null;

            // Create a dictionary to store nodes by their value.
            Dictionary<int, Node> nodeMap = new Dictionary<int, Node>();

            // Create nodes for each value in the adjacency list.
            for (int i = 1; i <= adjList.Count; i++)
            {
                nodeMap[i] = new Node(i);
            }

            // Populate the neighbors for each node.
            for (int i = 0; i < adjList.Count; i++)
            {
                Node currentNode = nodeMap[i + 1]; // Node values start from 1.
                foreach (int neighborVal in adjList[i])
                {
                    currentNode.neighbors.Add(nodeMap[neighborVal]);
                }
            }

            // Return the first node as the starting point of the graph.
            return nodeMap[1];
        }


    }
}
