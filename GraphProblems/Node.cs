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
            HashSet<Node> set = new HashSet<Node>();
            queue.Enqueue(node);
            set.Add(node);
            while (queue.Any())
            {
                var cur = queue.Dequeue();
                Node copy = new Node(cur.val);
                oldToCopy[cur] = copy;
                foreach (var neighbor in cur.neighbors)
                {
                    if (!set.Contains(neighbor))
                    {
                        set.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            set.Clear();
            queue.Enqueue(node);
            set.Add(node);
            while (queue.Any())
            {
                var cur = queue.Dequeue();
                Node copy = oldToCopy[cur];
                if (cur.neighbors != null || cur.neighbors.Count != 0)
                {
                    foreach (var neighbor in cur.neighbors)
                    {
                        var neighBorNode = oldToCopy[neighbor];
                        copy.neighbors.Add(neighBorNode);
                    }
                }
                foreach (var neighbor in cur.neighbors)
                {
                    if (!set.Contains(neighbor))
                    {
                        set.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return oldToCopy[node];
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
