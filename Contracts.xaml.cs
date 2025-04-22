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
using System.Windows.Shapes;

namespace PartCont
{
    /// <summary>
    /// Логика взаимодействия для Contracts.xaml
    /// </summary>
    public partial class Contracts : Window
    {
        public Contracts()
        {
            InitializeComponent();
        }

        private void Desc_Click(object sender, RoutedEventArgs e)
        {
            Description description = new Description();
            description.ShowDialog();
        }
    }
}
