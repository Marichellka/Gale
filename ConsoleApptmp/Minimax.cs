using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApptmp
{
    class Minimax
    {
        private Node currentNode;

        public Minimax(Board initialState)
        {
            currentNode = new Node(initialState);
        }

        public Board Start(int i, int j)
        {
            foreach (var child in currentNode.GetChilds(Kind.Red))
            {
                if(child.State.Grid[i, j].Type == Kind.Red)
                {
                    currentNode = child;
                    break;
                }
            }
            Console.WriteLine(currentNode.State.ToString());
            (int value, Node state) = Algorithm(currentNode, 4, int.MinValue, int.MaxValue, true);
            /*foreach (var child in currentNode.GetChilds(Kind.Blue))
            {
                if (child.MiniMaxValue == value)
                {
                    currentNode = child;
                    break;
                }
            }*/
            currentNode = state;
            if (!currentNode.IsWinCheked)
            {
                currentNode.State.IsWin();
                currentNode.IsWinCheked = true;
            }
            Console.WriteLine(currentNode.MiniMaxValue);
            return currentNode.State;
        }

        public (int, Node) Algorithm(Node currentState, int depth, int alpha, int beta, bool maxPlayer)
        {
            if (!currentState.IsWinCheked)
            {
                currentState.State.IsWin();
                currentState.IsWinCheked = true;
            }
            currentState.MiniMaxValue = currentState.Value;
            if (depth == 0 || currentState.State.Win != Kind.None)
            {
                return (currentState.State.Evaluate(), currentState);
            }

            if (maxPlayer)
            {
                int maxVal = int.MinValue;
                foreach (var child in currentState.GetChilds(Kind.Blue))
                {
                    (int value, Node state) = Algorithm(child, depth - 1, alpha, beta, false);
                    maxVal = Math.Max(value, maxVal);
                    alpha = Math.Max(alpha, value);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
                currentState.MiniMaxValue = maxVal;
                return (maxVal, currentState);
            }

            int minVal = int.MaxValue;
            foreach (var child in currentState.GetChilds(Kind.Red))
            {
                (int value, Node state) = Algorithm(child, depth - 1, alpha, beta, true);
                minVal = Math.Min(value, minVal);
                beta = Math.Min(beta, value);
                if (beta <= alpha)
                {
                    break;
                }
            }
            currentState.MiniMaxValue = minVal;
            return (minVal, currentState);
        }
    }
}
