using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimaxAlgorithm
{
    class Minimax
    {
        public (int, Board) Algorithm(Board currentState, int depth, int alpha, int beta, bool maxPlayer)
        {
            Kind win = currentState.IsWin();
            if (win == Kind.Blue)
                return (int.MaxValue, null);
            if (win == Kind.Purple)
                return (int.MinValue, null);
            if (depth==0)
                return (currentState.Evaluate(), null);

            List<Board> childs;
            Board bestBoard;
            if (maxPlayer)
            {
                int maxEval = int.MinValue;
                childs = currentState.DeployState(Kind.Blue);
                bestBoard = childs[0];
                foreach (var child in childs)
                {
                    (int value, Board board) = Algorithm(child, depth - 1, alpha, beta, false);
                        if (value > maxEval)
                    {
                        maxEval = value;
                        bestBoard = child;
                    }
                    alpha = Math.Max(alpha, value);
                    if (beta <= alpha)
                    {
                        return (maxEval, bestBoard);
                    }
                }
                return (maxEval, bestBoard);
            }

            int minEval = int.MaxValue;
            childs = currentState.DeployState(Kind.Purple);
            bestBoard = childs[0];
            foreach (var child in childs)
            {
                (int value, Board board) = Algorithm(child, depth - 1, alpha, beta, true);
                if (value < minEval)
                {
                    minEval = value;
                    bestBoard = child;
                }
                beta = Math.Min(beta, value);
                if (beta <= alpha)
                {
                    return (minEval, bestBoard);
                }
            }
            return (minEval, bestBoard);
        }
    }
}
