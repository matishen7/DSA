using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Neetcode150.GraphProblems.GraphSolution;

namespace Neetcode150.GraphProblems
{
    public class Graphs
    {
        static int[][] directions = new int[][] {
            new int[] {-1, 0},
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1}};
        public static int NumIslands(char[][] grid)
        {

            int ROWS = grid.Length; int COLS = grid[0].Length;
            int numOfIslands = 0;
            bool[,] visit = new bool[ROWS, COLS];
            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                {
                    if (grid[i][j] == '1' && visit[i, j] == false)
                    {
                        numOfIslands++;
                        NumberOfIslandsBfs(i, j, ROWS, COLS, ref grid, ref visit);
                    }
                }
            return numOfIslands;
        }

        private static void NumberOfIslandsBfs(int i, int j, int ROWS, int COLS, ref char[][] grid, ref bool[,] visit)
        {
            Queue<(int row, int col)> q = new Queue<(int row, int col)>();
            q.Enqueue((i, j));
            while (q.Any())
            {
                (int row, int col) = q.Dequeue();
                if (row < 0 || row >= ROWS || col < 0 || col >= COLS || visit[row, col] == true)
                    continue;

                grid[row][col] = '0';
                visit[row, col] = true;
                for (int k = 0; k < directions.Length; k++)
                {
                    var direction = directions[k];
                    var nextRow = row + direction[0];
                    var nextCol = col + direction[1];
                    if (nextRow < 0 || nextRow >= ROWS || nextCol < 0 || nextCol >= COLS || visit[nextRow, nextCol] == true)
                        continue;

                    if (grid[nextRow][nextCol] == '1')
                        q.Enqueue((nextRow, nextCol));

                }
            }
        }
        public static int MaxAreaOfIsland(int[][] grid)
        {
            int ROWS = grid.Length; int COLS = grid[0].Length;
            bool[,] visit = new bool[ROWS, COLS];
            int max = 0;
            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                {
                    if (grid[i][j] == 1 && visit[i, j] == false)
                    {
                        MaxAreaOfIslandBfs(i, j, ROWS, COLS, ref grid, ref visit, ref max);
                    }
                }
            return max;
        }

        private static void MaxAreaOfIslandBfs(int i, int j, int ROWS, int COLS, ref int[][] grid, ref bool[,] visit, ref int max)
        {
            Queue<(int row, int col)> q = new Queue<(int row, int col)>();
            q.Enqueue((i, j));
            int currentArea = 0;
            while (q.Any())
            {
                (int row, int col) = q.Dequeue();
                if (row < 0 || row >= ROWS || col < 0 || col >= COLS || visit[row, col] == true)
                    continue;

                grid[row][col] = 0;
                currentArea++;
                visit[row, col] = true;
                for (int k = 0; k < directions.Length; k++)
                {
                    var direction = directions[k];
                    var nextRow = row + direction[0];
                    var nextCol = col + direction[1];
                    if (nextRow < 0 || nextRow >= ROWS || nextCol < 0 || nextCol >= COLS || visit[nextRow, nextCol] == true)
                        continue;

                    if (grid[nextRow][nextCol] == 1)
                        q.Enqueue((nextRow, nextCol));
                }
            }
            max = Math.Max(currentArea, max);
        }

        public static void islandsAndTreasure(int[][] grid)
        {
            int ROWS = grid.Length; int COLS = grid[0].Length;
            var queue = new Queue<(int row, int col)>();
            bool[,] visit = new bool[ROWS, COLS];
            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                    }
                }

            while (queue.Count > 0)
            {
                var coordinates = queue.Dequeue();
                int row = coordinates.row;
                int col = coordinates.col;

                for (int k = 0; k < directions.Length; k++)
                {
                    int newRow = row + directions[k][0];
                    int newCol = col + directions[k][1];
                    if (newRow < 0 ||
                        newCol < 0 ||
                        newRow >= ROWS ||
                        newCol >= COLS ||
                        grid[newRow][newCol] == -1 ||
                        grid[newRow][newCol] == 0 ||
                        visit[newRow, newCol] == true)
                        continue;

                    visit[newRow, newCol] = true;
                    grid[newRow][newCol] = Math.Min(grid[row][col] + 1, grid[newRow][newCol]);
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        public static int OrangesRotting(int[][] grid)
        {
            int ROWS = grid.Length; int COLS = grid[0].Length;
            var queue = new Queue<(int row, int col)>();
            int freshOranges = 0;
            bool[,] visit = new bool[ROWS, COLS];
            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                        visit[i, j] = true;
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshOranges++;
                    }
            int min = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                bool newRotten = false;
                for (int i = 0; i < size; i++)
                {
                    var coordinates = queue.Dequeue();
                    int row = coordinates.row;
                    int col = coordinates.col;
                    for (int k = 0; k < directions.Length; k++)
                    {
                        int newRow = row + directions[k][0];
                        int newCol = col + directions[k][1];
                        if (newRow >= 0 && newCol >= 0 && newRow < ROWS && newCol < COLS &&
                        grid[newRow][newCol] == 1 && !visit[newRow, newCol])
                        {
                            // Mark the orange as rotten
                            grid[newRow][newCol] = 2;
                            visit[newRow, newCol] = true;
                            queue.Enqueue((newRow, newCol));
                            freshOranges--;
                            newRotten = true;
                        }

                    }
                }
                if (newRotten) min++;
            }
            return freshOranges == 0 ? min : -1;
        }

        public static void Solve(char[][] board)
        {
            int ROWS = board.Length; int COLS = board[0].Length;
            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                    if (board[i][j] == 'O' && (i == 0 || j == 0 || i == ROWS - 1 || j == COLS - 1))
                    {
                        Capture(i, j, board);
                    }

            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                    if (board[i][j] == 'O') board[i][j] = 'X';

            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                    if (board[i][j] == 'T') board[i][j] = 'O';
        }
        public static void Capture(int row, int col, char[][] board)
        {
            if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length || board[row][col] != 'O') return;
            board[row][col] = 'T';
            Capture(row + 1, col, board);
            Capture(row - 1, col, board);
            Capture(row, col + 1, board);
            Capture(row, col - 1, board);
        }

        public static int[] CanFinish(int numCourses, int[][] prerequisites)
        {
            // Step 1: Build the adjacency list and in-degree array
            Dictionary<int, List<int>> adjList = new();
            int[] inDegree = new int[numCourses]; // Track how many prerequisites each course has

            foreach (var pre in prerequisites)
            {
                int src = pre[1], dst = pre[0];

                if (!adjList.ContainsKey(src))
                    adjList[src] = new List<int>();

                adjList[src].Add(dst);
                inDegree[dst]++; // Increment in-degree for the destination course
            }

            // Step 2: Initialize the queue with courses having no prerequisites (in-degree 0)
            Queue<int> q = new();
            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                    q.Enqueue(i);
            }
            var list = new List<int>();
            // Step 3: Process the courses using BFS
            int completedCourses = 0;
            while (q.Any())
            {
                int course = q.Dequeue();
                list.Add(course);
                completedCourses++;

                // Reduce the in-degree of neighboring courses
                if (adjList.ContainsKey(course))
                {
                    foreach (var neighbor in adjList[course])
                    {
                        inDegree[neighbor]--;

                        // If in-degree becomes 0, add to the queue
                        if (inDegree[neighbor] == 0)
                            q.Enqueue(neighbor);
                    }
                }
            }

            // Step 4: Check if all courses have been completed
            return (completedCourses == numCourses) ? list.ToArray() : new List<int>().ToArray();
        }

        public static int CountComponents(int n, int[][] edges)
        {
            if (n == 1) return 1;
            // Step 1: Build the adjacency list.
            Dictionary<int, List<int>> adjList = new();
            for (int i = 0; i < n; i++)
            {
                adjList[i] = new List<int>(); // Ensure all nodes are in the graph, even if isolated.
            }

            foreach (var edge in edges)
            {
                int src = edge[0], dst = edge[1];

                adjList[src].Add(dst);
                adjList[dst].Add(src);
            }

            int component = 0;
            HashSet<int> visited = new();

            for (int i = 0; i < n; i++)
            {
                if (!visited.Contains(i))
                {
                    component++;
                    CountComponentsDfs(adjList, visited, i);
                }
            }

            return component;
        }

        private static void CountComponentsDfs(Dictionary<int, List<int>> adjList, HashSet<int> visited, int start)
        {
            if (visited.Contains(start)) return;
            visited.Add(start);
            var neighbors = adjList[start];
            foreach (var neighbor in neighbors)
                CountComponentsDfs(adjList, visited, neighbor);
        }

        public static bool ValidTree(int n, int[][] edges)
        {
            Dictionary<int, List<int>> adjList = new();
            for (int i = 0; i < n; i++)
            {
                adjList[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                int src = edge[0], dst = edge[1];

                adjList[src].Add(dst);
                adjList[dst].Add(src);
            }

            HashSet<int> visited = new HashSet<int>();
            if (!ValidTreeDFS(adjList.Keys.ElementAt(0), -1, visited, adjList)) return false;
            return visited.Count == n;
        }

        private static bool ValidTreeDFS(int currNode, int parent, HashSet<int> visited, Dictionary<int, List<int>> adjList)
        {
            if (visited.Contains(currNode)) return false;
            visited.Add(currNode);
            foreach (var nei in adjList[currNode])
            {
                if (nei == parent)
                {
                    continue;
                }
                if (!ValidTreeDFS(nei, currNode, visited, adjList))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<List<string>> AccountsMerge(List<List<string>> accounts)
        {
            var adjList = new Dictionary<string, List<string>>();

            for (int i = 0; i < accounts.Count; i++)
            {
                for (int j = 1; j < accounts[i].Count; j++)
                {
                    var email = accounts[i][j];
                    if (!adjList.ContainsKey(email))
                        adjList.Add(email, new List<string>());
                }
            }

            return null;
        }

        public static List<int> FindMinHeightTrees(int n, int[][] edges)
        {
            var adjList = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
                adjList[i] = new List<int>();

            for (int i = 0; i < edges.Length; i++)
            {
                var src = edges[i][0];
                var dst = edges[i][1];
                adjList[src].Add(dst);
                adjList[dst].Add(src);
            }

            var answer = new List<int>();

            int min = n;
            var heights = new int[n];

            for (int i = 0; i < n; i++)
            {
                int curHgt = HeightDfs(i, -1, adjList);
                if (curHgt == min)
                {
                    answer.Add(i);
                }
                else if (curHgt < min)
                {
                    answer = new List<int>();
                    answer.Add(i);
                    min = curHgt;
                }
            }

            return answer;
        }

        private static int HeightDfs(int node, int parent, Dictionary<int, List<int>> adjList)
        {
            int height = 0;
            foreach (var nei in adjList[node])
            {
                if (nei == parent) continue;
                height = Math.Max(height, 1 + HeightDfs(nei, node, adjList));
            }
            return height;
        }
    }
}
