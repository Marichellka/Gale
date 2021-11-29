using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApptmp
{
    enum Kind
    {
        None,
        Blue,
        Red
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
    }
}
