using System;
using System.Collections.Generic;
using System.Text;

namespace MinimaxAlgorithm
{
    class Board
    {
        public Cell[,] Grid { get; set; }
        private int length;

        public Board() { }

        public Board(int n)
        {
            length = n;
            Grid = new Cell[length, length];
            GetInitialBoard();
        }

        public List<Board> DeployState(Kind type)
        {
            List<Board> childsStates = new List<Board>();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (Grid[i, j].Type == Kind.None)
                    {
                        Board newBoard = this.Copy();
                        newBoard.Grid[i, j].Type = type;
                        childsStates.Add(newBoard);
                    }
                }
            }

            return childsStates;
        }

        public int Evaluate()
        {
            int minvaluePurple = int.MaxValue;
            for (int k = 0; k < length; k++)
            {
                if (Grid[k, 0].Type != Kind.Blue)
                {
                    int value = Dijkstra(Grid[k, 0], Kind.Purple);
                    minvaluePurple = Math.Min(minvaluePurple, value);
                }
            }
            return minvaluePurple;
        }

        public int Dijkstra(Cell start, Kind type)
        {
            Cell[,] way = new Cell[Grid.GetLength(0), Grid.GetLength(0)];
            PriorityQueue<Cell> openNodes = new PriorityQueue<Cell>();
            List<Cell> closed = new List<Cell>();
            openNodes.Add(start, 0);
            while (openNodes.Count > 0)
            {
                (Cell currentCell, int cost) = openNodes.Top();
                closed.Add(currentCell);
                if ((type == Kind.Blue && currentCell.I == length - 1) ||
                    (type == Kind.Purple && currentCell.J == length - 1))
                {
                    break;
                }
                List<Cell> neighbours = GetNeighbours(currentCell);

                foreach (var neighbour in neighbours)
                {
                    if ((neighbour.Type == Kind.None || neighbour.Type == type) && !closed.Contains(neighbour))
                    {
                        if (!openNodes.Contains(neighbour))
                        {
                            way[neighbour.I, neighbour.J] = currentCell;
                            int neighbourCost = cost+1;
                            openNodes.Add(neighbour, neighbourCost);
                        }
                    }
                }
            }
            int value = 0;
            Cell cell = closed[closed.Count - 1];
            while (cell != null)
            {
                if (cell.Type != type)
                    value++;
                cell = way[cell.I, cell.J];
            }
            return value;

        }

        private List<Cell> GetNeighbours(Cell cell)
        {
            List<Cell> neighbours = new List<Cell>();
            if (cell.I + 1 < length)
            {
                neighbours.Add(Grid[cell.I + 1, cell.J]);
            }
            if (cell.J + 1 < length)
            {
                neighbours.Add(Grid[cell.I, cell.J + 1]);
            }
            if (cell.J - 1 >= 0)
            {
                neighbours.Add(Grid[cell.I, cell.J - 1]);
            }
            if (cell.I - 1 >= 0)
            {
                neighbours.Add(Grid[cell.I - 1, cell.J]);
            }
            return neighbours;
        }

        public Kind IsWin()
        {
            Board tmpBoard = this.Copy();
            for (int k = 0; k < length; k++)
            {
                if (Grid[0, k].Type == Kind.Blue)
                {
                    if (Move(0, k))
                    {
                        this.Grid = tmpBoard.Grid;
                        return Kind.Blue;
                    }
                }
                if (Grid[k, 0].Type == Kind.Purple)
                {
                    if (Move(k, 0))
                    {
                        this.Grid = tmpBoard.Grid;
                        return Kind.Purple;
                    }
                }
            }
            this.Grid = tmpBoard.Grid;
            return Kind.None;
        }

        private bool Move(int i, int j)
        {
            Kind value = Grid[i, j].Type;
            Grid[i, j] = new Cell(i, j);
            if (value == Kind.Blue && i == length - 1)
                return true;
            if (value == Kind.Purple && j == length - 1)
                return true;

            bool result = false;
            List<Cell> neighbours = GetNeighbours(Grid[i, j]);
            foreach (var neighbour in neighbours)
            {
                if (!result && neighbour.Type == value)
                    result = Move(neighbour.I, neighbour.J);
            }
            return result;
        }

        private void GetInitialBoard()
        {
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                {
                    Grid[i, 0] = new Cell(i, 0);
                    for (int j = 1; j < length - 1; j += 2)
                    {
                        Grid[i, j] = new Cell(i, j, Kind.Purple);
                        Grid[i, j + 1] = new Cell(i, j + 1);
                    }
                }
                else
                {
                    for (int j = 0; j < length - 1; j += 2)
                    {
                        Grid[i, j] = new Cell(i, j, Kind.Blue);
                        Grid[i, j + 1] = new Cell(i, j + 1);
                    }
                    Grid[i, length - 1] = new Cell(i, length - 1, Kind.Blue);
                }
            }
        }

        private Board Copy()
        {
            Board newBoard = new Board();
            newBoard.Grid = new Cell[length, length];
            newBoard.length = this.length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    newBoard.Grid[i, j] = new Cell(i, j, this.Grid[i, j].Type);
                }
            }
            return newBoard;
        }

        public override string ToString()
        {
            string printed = "";
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    printed += (int)Grid[i, j].Type;
                }
                printed += '\n';
            }
            return printed;
        }
    }
}
