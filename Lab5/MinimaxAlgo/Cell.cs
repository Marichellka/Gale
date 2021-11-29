using System;
using System.Collections.Generic;
using System.Text;

namespace MinimaxAlgorithm
{
    public enum Kind 
    {
        None,
        Blue,
        Purple
    }
    
    class Cell
    {
        public Kind Type { get; set; }
        public int I { get; }
        public int J { get; }

        public Cell(int i, int j)
        {
            I = i;
            J = j;
            Type = Kind.None;
        }

        public Cell(int i, int j, Kind type)
        {
            I = i;
            J = j;
            Type = type;
        }

        public override string ToString()
        {
            if (Type == Kind.Blue) return "#6997D3";
            if (Type == Kind.Purple) return "#a988cf";
            return "#faebd7";
        }
    }
}
