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

namespace peresda
{
    /// <summary>
    /// Логика взаимодействия для RedakOkno.xaml
    /// </summary>
    public partial class RedakOkno : Page
    {
        Productt productts;
        public RedakOkno(Productt _productts)
        {
            InitializeComponent();
            productts = _productts;
            this.DataContext = productts;
        }

        private void sohran_Click(object sender, RoutedEventArgs e)
        {
            if (productts.SerialNumber == 0)
            App.db.Productt.Add(productts);
            App.db.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
