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

        private void FillAll()
        {
            partName.Text = Info.PartID.part_name;
            partContact.Text = Info.PartID.part_contact;
            partEmail.Text = Info.PartID.email;


        }

        private void Editing_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                DB.Partners partner = new DB.Partners()
                {
                    part_name = partName.Text,
                    part_contact = partContact.Text,
                    email = partEmail.Text
                };

                DB.PartnersDBEntities1.GetContext().Partners.Add(partner);
                DB.PartnersDBEntities1.GetContext().SaveChanges();
                MessageBox.Show("Была добавлена новая запись с новыми значениями");
            }
            catch (Exception ex)
            { MessageBox.Show("Возникла ошибка" + ex); }

        }
    }
}
