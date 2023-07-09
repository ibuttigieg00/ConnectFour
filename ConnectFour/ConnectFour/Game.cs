using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConnectFour.Grid;

namespace ConnectFour
{
    internal class Game
    {
        Grid Grid { get; set; }
        int ConnectN { get; set; }
        int TargetScore { get; set; }
        private Player[] players;
        private Dictionary<string, int> score;

        public Game (Grid grid, int connectN, int targetScore)
        {
            Grid = grid;
            ConnectN = connectN;
            TargetScore = targetScore;

            players = new Player[]
            {
                new Player("Izaak", Grid.GridPosition.YELLOW),
                new Player("Cherise", Grid.GridPosition.RED)
            };

            score = new Dictionary<string, int>();
            foreach (Player player in players)
            {
                score.Add(player.Name, 0);
            }
        }

        private void PrintBoard()
        {
            Console.WriteLine("Board:");
            int[,] grid = Grid.getGrid();

            for(int i = 0; i < grid.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int piece = grid[i, j];
                    if (piece == (int)GridPosition.EMPTY)
                    {
                        row += "0 ";
                    }
                    else if (piece == (int)GridPosition.YELLOW)
                    {
                        row += "Y ";
                    }
                    else if (piece == (int)GridPosition.RED)
                    {
                        row += "R ";
                    }
                }
                Console.WriteLine(row);
            }
        }

        public int [] PlayMove(Player player)
        {
            PrintBoard();
            Console.WriteLine($"It is {player.Name}'s turn");

            Console.WriteLine($"Choose a column where you want to insert piece between 0 - {Grid.getColumnCount() - 1}.");

            string text = Console.ReadLine();
            int column = int.Parse(text);
            int row = Grid.PlaceDisc(column, player.Piece);

            return new int[] {row, column};
        }

        private Player PlayRound()
        {
            while(true)
            {
                foreach(Player player in players)
                {
                    int[] position = PlayMove(player);
                    int row = position[0];
                    int column = position[1];

                    if (Grid.checkWin(ConnectN, row, column, player.Piece))
                    {
                        return player;
                    }
                }
            }
        }

        public void Play()
        {
            int maxScore = 0;
            int currentScore = 0;
            Player winner = null;

            while (maxScore < TargetScore)
            {
                winner = PlayRound();
                Console.WriteLine($"{winner.Name} won the round");

                maxScore = Math.Max(score[winner.Name], maxScore);
                Grid.initGrid();
            }
            Console.WriteLine($"{winner.Name} won the game!!");
        }

    }
}
