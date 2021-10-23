﻿using System;
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

namespace RegAndAuto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameClass.mainFrame = FrmMain;
            FrameClass.mainFrame.Navigate(new FirtsPage());
        }

        private void BReg_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new RegPage());
        }

        private void BAuto_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new AutoPage());
        }
    }
}
