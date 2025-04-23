using PartCont.DB;
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
    /// Логика взаимодействия для CEdit.xaml
    /// </summary>
    public partial class CEdit : Window
    {
        public CEdit()
        {
            InitializeComponent();
            var partnerNames = DB.PartnersDBEntities1.GetContext().Partners.Select(p => p.part_name).ToList();
            partChoose.ItemsSource = partnerNames;
            FillAll();
        }

        private void FillAll()
        {
            string partnerName = DB.PartnersDBEntities1.GetContext().Partners.Where(p => p.part_id == Info.ContID.part_id ).Select(p => p.part_name).FirstOrDefault();

            partChoose.SelectedItem = DB.PartnersDBEntities1.GetContext().Partners.Where(p => p.part_id == Info.ContID.part_id).Select(p => p.part_name).FirstOrDefault();
            contName.Text = Info.ContID.cont_name;
            contDate.SelectedDate = Info.ContID.cont_date;
            contDeadline.SelectedDate = Info.ContID.cont_deadline;
        }

        private void Editing_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string partner = partChoose.Text;
                int part_id = DB.PartnersDBEntities1.GetContext().Partners.Where(p => p.part_name == partner).Select(p => p.part_id).FirstOrDefault();

                DB.Contracts contract = new DB.Contracts()
                {
                    part_id = part_id,
                    cont_name = contName.Text,
                    cont_date = contDate.SelectedDate.Value,
                    cont_deadline = contDeadline.SelectedDate.Value,
                    st_id = 1
                };

                DB.PartnersDBEntities1.GetContext().Contracts.Add(contract);
                DB.PartnersDBEntities1.GetContext().SaveChanges();
                MessageBox.Show("Была добавлена новая запись с новыми значениями");
            }
            catch (Exception ex)
            { MessageBox.Show("Возникла ошибка" + ex); }
        }
    }
}
