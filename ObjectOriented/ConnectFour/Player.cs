namespace Neetcode150.ObjectOriented.ConnectFour
{
    internal class Player
    {
        public Color color { get; set; }
        public int score { get; set; }
        public Player(Color c)
        {
            color = c;
            score = 0;
        }

        public bool Move(int col, Grid grid)
        {
            int r = 0;
            while (r >= 0 && r < grid.ROWS && grid.cells[r, col] == Color.Empty)
                ++r;
            if (r - 1 >= 0 && r - 1 < grid.ROWS)
                grid.ChangeCellColor(r - 1, col, color);
            grid.PrintGrid();

            if (grid.IsWinHorizontal(r - 1, col, color) ||
                grid.IsWinPositiveDiagonal(r - 1, col, color) ||
                grid.IsWinVertical(r - 1, col, color) ||
                grid.IsWinNegativeDiagonal(r - 1, col, color))
            {
                score++;
                return true;
            }
            return false;
        }
    }
}