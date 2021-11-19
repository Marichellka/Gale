using System;

namespace ConsoleApptmp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = { 
                {1, 2, 2, 2}, 
                {1, 2, 1, 1}, 
                {2, 2, 1, 2}, 
                {0, 0, 0, 2} };
            Console.WriteLine(IsWin(board));
        }

        static int IsWin(int[,] board)
        {
            // 1 - blue, 2-red, 0-none
            for (int k = 0; k < board.GetLength(0); k++)
            {
                if (board[0,k]==1)
                {
                    if (Move(board, 0, k))
                        return 1;
                }
                if (board[k, 0]==2)
                {
                    if (Move(board, k, 0))
                        return 2;
                }
            }
            return 0;
        }

        static bool Move(int[,] board, int i, int j)
        {
            int value = board[i, j];
            board[i, j] = 0;
            if (value == 1 && i == board.GetLength(0) - 1)
                return true;
            if (value == 2 && j == board.GetLength(0) - 1)
                return true;

            bool result = false;
            if ( i + 1 < board.GetLength(0) && value == board[i + 1, j])
                result = Move(board, i + 1, j);
            if (!result && i - 1>=0 && value == board[i - 1, j])
                result = Move(board, i - 1, j);
            if ( !result && j + 1 < board.GetLength(0) && value == board[i, j+1])
                result = Move(board, i, j+1);
            if (!result && j - 1 >= 0 && value == board[i, j-1])
                result = Move(board, i, j-1);
            return result;
        }
    }
}
