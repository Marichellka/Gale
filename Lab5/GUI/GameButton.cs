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

namespace Lab5.GUI
{
    public class GameButton : Button
    {
        public int I { get; }
        public int J { get; }
        private string color; 
        public string Color
        {
            get => color;
            set
            {
                color = value;
                var bc = new BrushConverter();
                this.Background = (Brush)bc.ConvertFrom(value);
            }
        }

        public GameButton(){}
        public GameButton(int i, int j)
        {
            I = i;
            J = j;
            color = "#faebd7";
            var bc = new BrushConverter();
            this.Background = (Brush)bc.ConvertFrom(color); ;
        }
    }
}
