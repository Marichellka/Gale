using Lab5.GUI;
using MinimaxAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5.Pages
{
    public partial class GamePage : Page
    {
        private Game game;
        private int minimaxDepth = 3;
        public GamePage()
        {
            InitializeComponent();
            game = new Game(minimaxDepth);
            DrawGrid();
            game.OnUpdateBoard += UpdateBoard;
            game.OnGameEnded += GameEnded;
        }

        private void DrawGrid()
        {
            GameArea.Rows = game.Size + 2;
            GameArea.Columns = game.Size + 2;
            var bc = new BrushConverter();

            for (int i = 0; i < game.Size+2; i++)
            {
                Border button = new Border();
                GameArea.Children.Add(button);
                if (i % 2 == 0) button.Background = (Brush)bc.ConvertFrom("#faebd7"); //white
                else button.Background = (Brush)bc.ConvertFrom("#6997D3"); //blue

            }
            for (int i = 0; i < game.Size; i++)
            {
                string color = "#faebd7"; //white;
                if (i % 2 == 0) color = "#a988cf"; //purple
                Border button = new Border();
                GameArea.Children.Add(button);
                button.Background = (Brush)bc.ConvertFrom(color);

                for (int j = 0; j < game.Size; j++)
                {
                    UIElement gameButton;
                    if(game.Board.Grid[i, j].Type != Kind.None)
                    {
                        gameButton = new Border();
                        ((Border)gameButton).Background = (Brush)bc.ConvertFrom(game.Board.Grid[i, j].ToString());
                    }
                    else
                    {
                        gameButton = new GameButton(i, j);
                        ((Button)gameButton).Click += PlayerMove_Click;
                    }
                    GameArea.Children.Add(gameButton);
                }
                button = new Border();
                GameArea.Children.Add(button);
                button.Background = (Brush)bc.ConvertFrom(color);
            }
            for (int i = 0; i < game.Size + 2; i++)
            {
                Border button = new Border();
                GameArea.Children.Add(button);
                if (i % 2 == 0) button.Background = (Brush)bc.ConvertFrom("#faebd7"); //white
                else button.Background = (Brush)bc.ConvertFrom("#6997D3"); //blue

            }
        }

        private void UpdateBoard()
        {
            var bc = new BrushConverter();
            int childrenCount = game.Size + 3;
            for (int i = 0; i < game.Size; i++)
            {
                for (int j = 0; j < game.Size; j++)
                {
                    UIElement cell = GameArea.Children[childrenCount];
                    if (cell.GetType() == typeof(GameButton))
                    {
                        if (game.Board.Grid[i, j].Type != Kind.None)
                        {
                            Border newElement = new Border();
                            newElement.Background = (Brush)bc.ConvertFrom(game.Board.Grid[i, j].ToString());
                            GameArea.Children.RemoveAt(childrenCount);
                            GameArea.Children.Insert(childrenCount, newElement);
                        }
                    }
                    childrenCount++;
                }
                childrenCount += 2;
            }
        }

        private void PlayerMove_Click(object sender, RoutedEventArgs e)
        {
            GameButton button = (GameButton)sender;
            game.MakeTurn(button.I, button.J);
        }

        private void GameEnded(Kind win)
        {
            MessageBox.Show($"{win} is won!");
            GameArea.Children.Clear();
            game = new Game(minimaxDepth);
            DrawGrid();
            game.OnUpdateBoard += UpdateBoard;
            game.OnGameEnded += GameEnded;
        }
    }
}
