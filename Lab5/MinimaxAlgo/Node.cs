using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimaxAlgorithm
{
    class Node
    {
        private List<Node> childs;
        public Board State { get; internal set; }
        public int Depth { get; private set; }
        public int MiniMaxValue { get; set; }

        public bool IsWinCheked { get; set; }
        public int Value { get; set; }

        public Node(Board state)
        {
            childs = new List<Node>();
            State = state;
            Value = int.MaxValue;
            IsWinCheked = false;
        }

        public List<Node> GetChilds(Kind type)
        {
            if (childs.Count==0)
            {
                List<Board> childsStates = State.DeployState(type);
                foreach (var state in childsStates)
                {
                    childs.Add(new Node(state));
                    childs[childs.Count - 1].Depth = this.Depth + 1;
                }
            }
            return childs;
        }
    }
}
