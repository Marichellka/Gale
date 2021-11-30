using Lab5.Pages;
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
    /// <summary>
    /// Логика взаимодействия для ComplexityPage.xaml
    /// </summary>
    public partial class ComplexityPage : Page
    {
        public ComplexityPage()
        {
            InitializeComponent();
        }

        private void ComplexityButton_Click(object sender, RoutedEventArgs e)
        {
            int depth = 1 + Convert.ToInt32(((Button)sender).GetValue(Grid.RowProperty));
            NavigationService.Navigate(new GamePage(depth));
        }
    }
}
