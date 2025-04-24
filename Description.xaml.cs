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
    /// Логика взаимодействия для Description.xaml
    /// </summary>
    public partial class Description : Window
    {
        public Description()
        {
            InitializeComponent();
            FillRich();

        }

        private void FillRich()
        {
            int cont_id = Info.ContDescLook;
            string desc = DB.PartnersDBEntities1.GetContext().Description.Where(d => d.cont_id == cont_id).Select(d => d.descript).FirstOrDefault();
            DescText.Text = desc;
        } 
    }
}
