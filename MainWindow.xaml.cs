﻿
using Project.ViewModels;
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


namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnClick1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page1();
            
        }

        private void btnclick2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page3();
        }
    }
}
