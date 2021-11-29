using System;

namespace ConsoleApptmp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            /*Board board = new Board(7);
            int[,] grid = new int[7, 7]
            {
                {1,2,1,2,1,2,1 },
                {1,0,1,0,1,0,1 },
                {2,2,1,2,2,2,2 },
                {1,0,1,2,1,0,1 },
                {2,2,2,2,0,2,0 },
                {1,0,1,0,1,0,1 },
                {1,2,0,2,0,2,0 }
            };
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    board.Grid[i, j] = new Cell(i, j, (Kind)grid[i, j]);
                }
            }
            Console.WriteLine(board.ToString());
            Console.WriteLine(board.IsWin());
            Console.WriteLine(board.Win);
            Console.WriteLine(board.ToString());*/

        }
    }
}
