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
            Fill();
        }

        public void Fill()
        {
            Contdata.ItemsSource = DB.CPartnersDBEntities.GetContext().Contracts.ToList();
        }

        private void Desc_Click(object sender, RoutedEventArgs e)
        {
            var deletedContract = Contdata.SelectedItem as DB.Contracts;
            int ID = deletedContract.cont_id;
            Info.ContDescLook = ID;
            Description description = new Description();
            description.ShowDialog();
        }

        private void Cedit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var deletedContract = Contdata.SelectedItem as DB.Contracts;
                Info.ContID = deletedContract;
                
                CEdit cEdit = new CEdit();
                cEdit.ShowDialog();
                DB.CPartnersDBEntities.GetContext().Contracts.Remove(deletedContract);
                DB.CPartnersDBEntities.GetContext().SaveChanges();
                Fill();
            }
            catch (Exception ex)
            { MessageBox.Show("Возникла ошибка" + ex); }
        }

        private void Cdelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var deletedContract = Contdata.SelectedItem as DB.Contracts;
                DB.CPartnersDBEntities.GetContext().Contracts.Remove(deletedContract);
                DB.CPartnersDBEntities.GetContext().SaveChanges();
                Fill();

            }
            catch (Exception ex)
            { MessageBox.Show("Возникла ошибка" + ex); }
        }
    }
}
