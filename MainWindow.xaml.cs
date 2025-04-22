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

namespace PartCont
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PLookEdit_Click(object sender, RoutedEventArgs e)
        {
            Partners partners = new Partners();
            partners.ShowDialog();
        }

        private void CLookEdit_Click(object sender, RoutedEventArgs e)
        {
            Contracts contracts = new Contracts();
            contracts.ShowDialog();
        }

        private void CAdd_Click(object sender, RoutedEventArgs e)
        {
            CAdd cAdd = new CAdd();
            cAdd.ShowDialog();
        }

        private void PAdd_Click(object sender, RoutedEventArgs e)
        {
            PAdd pAdd = new PAdd();
            pAdd.ShowDialog();
        }
    }
}
