﻿using Lab5.GUI;
using Lab5.Pages;
using System.Windows;

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new ComplexityPage();
        }
    }
}
