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
        public event Action OnUpdateBoard;
        public event Action<Kind> OnGameEnded;
        private Minimax minimax;
        private int minimaxDepth;
        public int Size { get; }
        
        public Game(int depth)
        {
            Size = 7;
            Board = new Board(Size);
            minimax = new Minimax();
            minimaxDepth = depth;
        }

        public void MakeTurn(int i, int j)
        {
            Board.Grid[i, j].Type = Kind.Purple;
            OnUpdateBoard?.Invoke();
            if (Board.IsWin() == Kind.Purple)
            {
                OnGameEnded?.Invoke(Kind.Purple);
                return;
            }
            Board = minimax.Algorithm(Board, minimaxDepth, int.MinValue, int.MaxValue, true).Item2;
            OnUpdateBoard?.Invoke();
            if (Board.IsWin() == Kind.Blue)
            {
                OnGameEnded?.Invoke(Kind.Blue);
            }
        }
    }
}
