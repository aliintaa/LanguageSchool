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
    /// Логика взаимодействия для Okno.xaml
    /// </summary>
    public partial class Okno : Page
    {
        public Okno()
        {
            InitializeComponent();
            Refresh();
        }

      

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void pedak_Click(object sender, RoutedEventArgs e)
        {
            if(mylist.SelectedItem != null)
           NavigationService.Navigate(new RedakOkno(mylist.SelectedItem as Productt));
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (mylist.SelectedItems != null)
                App.db.Productt.Remove(mylist.SelectedItems as Productt);
                App.db.SaveChanges();
                Refresh();
        }
        public void Refresh()
        {
            IEnumerable<Productt> productts = App.db.Productt.ToList();
                
                if (sort.SelectedIndex != 0)
                {
                productts = productts.Where(x => x.UnitId == sort.SelectedIndex);
                }
                if(poisk.Text != null)
                {
                productts = productts.Where(x => x.SerialNumber.ToString().Contains(poisk.Text)|| x.Name.Contains(poisk.Text));
                }
            mylist.ItemsSource = productts.ToList();
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RedakOkno(new Productt()));
        }

        private void sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
