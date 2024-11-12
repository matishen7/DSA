using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neetcode150.ObjectOriented.ConnectFour
{
    internal class ConnectFourGame
    {
        private Player[] players { get; set; } = new Player[2];
        private Grid grid { get; set; }
        private int currentPlayerIndex { get; set; }
        private Player winnerPlayer { get; set; }

        private int targetScore { get; set; }
        public ConnectFourGame()
        {
            players[0] = new Player(Color.Yellow);
            players[1] = new Player(Color.Red);
            targetScore = 2;
            grid = new Grid(6, 7);
            currentPlayerIndex = 0;
        }

        public ConnectFourGame(Player player1, Player player2, int ts, int n, int m)
        {
            players[0] = player1;
            players[1] = player2;
            targetScore = ts;
            grid = new Grid(n, m);
            currentPlayerIndex = 0;
        }

        public void Start()
        {
            try
            {
                while (players[0].score != targetScore && players[1].score != targetScore)
                {
                    Player currentPlayer = players[currentPlayerIndex];
                    Console.WriteLine(currentPlayer.color.ToString() + " player's move: ");
                    int col = 0;

                    do
                    {
                        int.TryParse(Console.ReadLine(), out col);
                    }

                    while (col < 0 || col >= grid.COLS);
                    if (currentPlayer.Move(col, grid))
                    {
                        Console.Clear();
                        if (currentPlayer.score >= targetScore) winnerPlayer = currentPlayer;
                        Console.WriteLine($"Round ended! Current Score : {players[0].score} - {players[1].score}");

                        grid = new Grid(grid.ROWS, grid.COLS);
                        currentPlayerIndex = 0;
                        currentPlayer = players[currentPlayerIndex];
                    }
                    else
                    {
                        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
                        currentPlayer = players[currentPlayerIndex];
                    }
                }

                Console.WriteLine(winnerPlayer.color.ToString() + $" player wins!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Game stopped : error " + ex.Message);
            }
        }
    }
}
