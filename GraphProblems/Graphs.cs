using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        visit[i,j] = true;
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
    }
}
