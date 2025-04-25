using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для CAdd.xaml
    /// </summary>
    public partial class CAdd : Window
    {
        public CAdd()
        {
            InitializeComponent();
            AddComboBox();
        }

        
        private void AddComboBox()
        {
            var partnerNames = DB.CPartnersDBEntities.GetContext().Partners.Select(p => p.part_name).ToList();
            partChoose.ItemsSource = partnerNames;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Check())
                {
                    string partner = partChoose.Text;
                    int part_id = DB.CPartnersDBEntities.GetContext().Partners.Where(p => p.part_name == partner)
                        .Select(p => p.part_id).FirstOrDefault();

                    DB.Contracts contract = new DB.Contracts()
                    {
                        part_id = part_id,
                        cont_name = contName.Text,
                        cont_date = contDate.SelectedDate.Value,
                        cont_deadline = contDeadline.SelectedDate.Value
                    };

                    DB.CPartnersDBEntities.GetContext().Contracts.Add(contract);
                    DB.CPartnersDBEntities.GetContext().SaveChanges();

                    MessageBoxResult result = MessageBox.Show("Запись успешно добавлена. " +
                        "\nХотите добавить подробное описание контракта?", "Подтверждение",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Info.ContDesc = contract;
                        DescAdd descAdd = new DescAdd();   
                        descAdd.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Возникла ошибка" + ex); }
        }
        private bool Check()
        {
            string part_name = partChoose.Text;
            string cont_name = contName.Text;
            DateTime? cont_date = contDate.SelectedDate;
            DateTime? cont_deadline = contDeadline.SelectedDate;

            if (string.IsNullOrEmpty(part_name))
            {
                MessageBox.Show("Пожалуйста, заполните все поля (Партнёр).");
                return false;
            }
            else if (string.IsNullOrEmpty(cont_name))
            {
                MessageBox.Show("Пожалуйста, заполните все поля (Наименование).");
                return false;
            }
            else if (!cont_date.HasValue)
            {
                MessageBox.Show("Пожалуйста, заполните все поля (Дата составления).");
                return false;
            }
            else if (!cont_deadline.HasValue)
            {
                MessageBox.Show("Пожалуйста, заполните все поля (Дедлайн).");
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
