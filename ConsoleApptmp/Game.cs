using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApptmp
{
    class Game
    {
        public Board Board { get; private set; }
        private Minimax minimax;
        
        public Game()
        {
            Board = new Board(7);
            Console.WriteLine(Board.ToString());
            minimax = new Minimax(Board);
        }

        public void Start()
        {
            while (Board.Win==Kind.None)
            {
                int i = int.Parse(Console.ReadLine());
                int j = int.Parse(Console.ReadLine());
                Board = minimax.Start(i, j);
                Console.WriteLine(Board.ToString());
                Console.WriteLine(Board.Win);
            }
        }
    }
}
