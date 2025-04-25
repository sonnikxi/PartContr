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
    /// Логика взаимодействия для Partners.xaml
    /// </summary>
    public partial class Partners : Window
    {
        public Partners()
        {
            InitializeComponent();
            Fill();
        }
        public void Fill()
        {
            Partdata.ItemsSource = DB.CPartnersDBEntities.GetContext().Partners.ToList();
        }
        private void Pdelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var deletedPartner = Partdata.SelectedItem as DB.Partners;
                DB.CPartnersDBEntities.GetContext().Partners.Remove(deletedPartner);
                DB.CPartnersDBEntities.GetContext().SaveChanges();
                Fill();
            }
            catch (Exception ex)
            { MessageBox.Show("Возникла ошибка" + ex); }
        }
        private void Pedit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var deletedPartner = Partdata.SelectedItem as DB.Partners;
                Info.PartID = deletedPartner;

                PEdit pEdit = new PEdit();
                pEdit.ShowDialog();
                DB.CPartnersDBEntities.GetContext().Partners.Remove(deletedPartner);
                DB.CPartnersDBEntities.GetContext().SaveChanges();
                Fill();
            }
            catch (Exception ex)
            { MessageBox.Show("Возникла ошибка" + ex); }
        }
    }
}
