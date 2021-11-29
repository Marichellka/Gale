using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimaxAlgorithm
{
    class Minimax
    {
        private Node currentNode;
        private int maxDepth;

        public Minimax(Board initialState, int depth)
        {
            currentNode = new Node(initialState);
            maxDepth = depth;
        }

        public Board Start(int i, int j)
        {
            foreach (var child in currentNode.GetChilds(Kind.Purple))
            {
                if(child.State.Grid[i, j].Type == Kind.Purple)
                {
                    currentNode = child;
                    break;
                }
            }
            int value = Algorithm(currentNode, maxDepth, int.MinValue, int.MaxValue, true);
            foreach (var child in currentNode.GetChilds(Kind.Blue))
            {
                if (child.MiniMaxValue == value)
                {
                    currentNode = child;
                    break;
                }
            }
            if (!currentNode.IsWinCheked)
            {
                currentNode.State.IsWin();
                currentNode.IsWinCheked = true;
            }
            return currentNode.State;
        }

        public int Algorithm(Node currentState, int depth, int alpha, int beta, bool maxPlayer)
        {
            if (currentState.Value == int.MaxValue)
            {
                currentState.Value = currentState.State.Evaluate();
            }
            if (!currentState.IsWinCheked)
            {
                currentState.State.IsWin();
                currentState.IsWinCheked = true;
            }
            currentState.MiniMaxValue = currentState.Value;
            if(depth==0 || currentState.State.Win!= Kind.None)
            {
                return currentState.Value;
            }

            if (maxPlayer)
            {
                int maxVal = int.MinValue;
                foreach (var child in currentState.GetChilds(Kind.Blue))
                {
                    int value = Algorithm(child, depth - 1, alpha, beta, false);
                    maxVal = Math.Max(value, maxVal);
                    alpha = Math.Max(alpha, value);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
                currentState.MiniMaxValue = maxVal;
                return maxVal;
            }

            int minVal = int.MaxValue;
            foreach (var child in currentState.GetChilds(Kind.Purple))
            {
                int value = Algorithm(child, depth - 1, alpha, beta, true);
                minVal = Math.Min(value, minVal);
                beta = Math.Min(beta, value);
                if (beta <= alpha)
                {
                    break;
                }
            }
            currentState.MiniMaxValue = minVal;
            return minVal;
        }
    }
}
