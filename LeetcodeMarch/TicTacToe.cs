using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.LeetcodeMarch
{
    public class TicTacToe
    {
        private int[][] grid;
        public TicTacToe(int n)
        {
            grid = new int[n][];
            for (int i = 0; i < n; i++)
            {
                grid[i] = new int[n];
            }
        }

        public int Move(int row, int col, int player)
        {
            grid[row][col] = player;
            if (CheckHorizontal(row, player)
                || CheckVertical(col, player)
                || CheckDiagonalPos(col, row, player)
                || CheckDiagonalNeg(col, row, player)) return player;
            return 0;
        }

        private bool CheckHorizontal(int row, int player)
        {
            for (int i = 0; i < grid[row].Length; i++)
                if (grid[row][i] != player) return false;
            
            return true;
            
           
        }

        private bool CheckVertical(int col, int player)
        {
            for (int i = 0; i < grid.Length; i++)
                if (grid[i][col] != player) return false;

            return true;
        }

        private bool CheckDiagonalPos(int col, int row, int player)
        {
            int j = col;
            for (int i = row; i >= 0; i--)
            {
                if (grid[i][j] != player) return false;
                j++;
                if (j > grid[i].Length) break;
            }

            return true;
        }

        private bool CheckDiagonalNeg(int col, int row, int player)
        {
            int j = col;
            for (int i = row; i < grid.Length;i++ )
            {
                if (grid[i][j] != player) return false;
                j++;
            }

            return true;
        }
    }
}
