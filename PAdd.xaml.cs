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
    /// Логика взаимодействия для PAdd.xaml
    /// </summary>
    public partial class PAdd : Window
    {
        public PAdd()
        {
            InitializeComponent();
        }

        private bool Check()
        {
            string part_name = partName.Text;
            string part_contact = partContact.Text;
            string email = partEmail.Text;

            if (string.IsNullOrEmpty(part_name))
            {
                MessageBox.Show("Пожалуйста, заполните все поля (Название).");
                return false;
            }
            else if (string.IsNullOrEmpty(part_contact))
            {
                MessageBox.Show("Пожалуйста, заполните все поля (ФИО).");
                return false;
            }
            else if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Пожалуйста, заполните все поля (Email).");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Check())
                {
                    DB.Partners partner = new DB.Partners()
                    {
                        part_name = partName.Text,
                        part_contact = partContact.Text,
                        email = partEmail.Text
                    };

                    DB.PartnersDBEntities1.GetContext().Partners.Add(partner);
                    DB.PartnersDBEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Запись успешно добавлена");
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Возникла ошибка" + ex); }
        }
    }
}
