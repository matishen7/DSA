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
    }
}
