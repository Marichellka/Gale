using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimaxAlgorithm
{
    class Game
    {
        public Board Board { get; private set; }
        private Minimax minimax;
        public int Size { get; }
        
        public Game(int depth)
        {
            Size = 7;
            Board = new Board(Size);
            minimax = new Minimax(Board, depth);
        }

        public Kind NewMove(int i, int j)
        {
            Board = minimax.Start(i, j);
            return Board.Win;
        }
    }
}
