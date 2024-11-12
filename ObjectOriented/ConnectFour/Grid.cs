namespace Neetcode150.ObjectOriented.ConnectFour
{
    public class Grid
    {
        public Color[,] cells { get; private set; }
        public int ROWS { get; private set; }
        public int COLS { get; private set; }
        public Grid(int n, int m)
        {
            ROWS = n; COLS = m;
            cells = new Color[ROWS, COLS];
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                    cells[i, j] = Color.Empty;
            }
        }

        public void ChangeCellColor(int row, int col, Color color)
        {
            if (cells[row, col] == Color.Empty)
                cells[row, col] = color;
        }

        public void PrintGrid()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (cells[i, j] == Color.Red) Console.Write("x ");
                    else if (cells[i, j] == Color.Yellow) Console.Write("* ");
                    else Console.Write("o ");
                }
                Console.WriteLine();
            }
        }

        public bool IsWinHorizontal(int x, int y, Color color)
        {
            var visit = new bool[ROWS, COLS];
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            if (x >= 0 && x < ROWS && y >= 0 && y < COLS)
                queue.Enqueue((x, y));
            int count = 0;
            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                visit[r, c] = true;
                if (cells[r, c] == color)
                    count++;

                int right = c + 1;
                int left = c - 1;

                if (right >= COLS) continue;
                if (cells[r, right] == color && visit[r, right] == false) queue.Enqueue((r, right));
                if (left < 0) continue;               
                if (cells[r, left] == color && visit[r, left] == false) queue.Enqueue((r, left));
            }

            return count >= 4;
        }

        public bool IsWinVertical(int x, int y, Color color)
        {
            var visit = new bool[ROWS, COLS];
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            if (x >= 0 && x < ROWS && y >= 0 && y < COLS)
                queue.Enqueue((x, y));
            int count = 0;
            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                visit[r, c] = true;
                if (cells[r, c] == color)
                    count++;

                int down = r + 1;
                int up = r - 1;

                if (down >= ROWS) continue;
                if (cells[down, c] == color && visit[down, c] == false) queue.Enqueue((down, c));
                if (up < 0) continue;
                if (cells[up, c] == color && visit[up, c] == false) queue.Enqueue((up, c));
            }

            return count >= 4;
        }

        public bool IsWinPositiveDiagonal(int x, int y, Color color)
        {
            var visit = new bool[ROWS, COLS];
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            if (x >= 0 && x < ROWS && y >= 0 && y < COLS)
                queue.Enqueue((x, y));
            int count = 0;
            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                visit[r, c] = true;
                if (cells[r, c] == color)
                    count++;

                int newRow = r - 1;
                int newCol = c + 1;

                if (newRow >= ROWS || newRow < 0 || newCol < 0 || newCol >= COLS) continue;
                if (cells[newRow, newCol] == color && visit[newRow, newCol] == false) queue.Enqueue((newRow, newCol));

                int newRow2 = r + 1;
                int newCol2 = c - 1;

                if (newRow2 >= ROWS || newRow2 < 0 || newCol2 < 0 || newCol2 >= COLS) continue;
                if (cells[newRow2, newCol2] == color && visit[newRow2, newCol2] == false) queue.Enqueue((newRow2, newCol2));
            }

            return count >= 4;
        }

        public bool IsWinNegativeDiagonal(int x, int y, Color color)
        {
            var visit = new bool[ROWS, COLS];
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            if (x >= 0 && x < ROWS && y >= 0 && y < COLS)
                queue.Enqueue((x, y));
            int count = 0;
            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                visit[r, c] = true;
                if (cells[r, c] == color)
                    count++;

                int newRow = r + 1;
                int newCol = c + 1;

                if (newRow >= ROWS || newRow < 0 || newCol < 0 || newCol >= COLS) continue;
                if (cells[newRow, newCol] == color && visit[newRow, newCol] == false) queue.Enqueue((newRow, newCol));

                int newRow2 = r - 1;
                int newCol2 = c - 1;

                if (newRow2 >= ROWS || newRow2 < 0 || newCol2 < 0 || newCol2 >= COLS) continue;
                if (cells[newRow2, newCol2] == color && visit[newRow2, newCol2] == false) queue.Enqueue((newRow2, newCol2));
            }

            return count >= 4;
        }
    }
}