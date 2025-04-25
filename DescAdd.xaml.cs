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
    /// Логика взаимодействия для DescAdd.xaml
    /// </summary>
    public partial class DescAdd : Window
    {
        public DescAdd()
        {
            InitializeComponent();
        }
        private void DescAdding_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument document = Desc.Document;
            TextRange textRange = new TextRange(document.ContentStart, document.ContentEnd);
            string text = textRange.Text;
            try
            {
                DB.Description description = new DB.Description()
                {
                    cont_id = Info.ContDesc.cont_id,
                    descript = text
                };
                DB.CPartnersDBEntities.GetContext().Description.Add(description);
                DB.CPartnersDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Описание добавлено!");
            }
            catch (Exception ex)
            { MessageBox.Show("Возникла ошибка" + ex); }
        }
    }
}
