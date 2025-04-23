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
    /// Логика взаимодействия для PEdit.xaml
    /// </summary>
    public partial class PEdit : Window
    {
        public PEdit()
        {
            InitializeComponent();
            FillAll();
        }

        private void FillALl()
        {
            string partnerName = DB.PartnersDBEntities1.GetContext().Partners.Where(p => p.part_id == Info.ContID.part_id).Select(p => p.part_name).FirstOrDefault();

            partChoose.SelectedItem = DB.PartnersDBEntities1.GetContext().Partners.Where(p => p.part_id == Info.ContID.part_id).Select(p => p.part_name).FirstOrDefault();
            contName.Text = Info.ContID.cont_name;
            contDate.SelectedDate = Info.ContID.cont_date;
            contDeadline.SelectedDate = Info.ContID.cont_deadline;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
