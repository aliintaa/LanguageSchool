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

namespace proectitog
{
    /// <summary>
    /// Логика взаимодействия для OknosTabl.xaml
    /// </summary>
    public partial class OknosTabl : Page
    {
        
        public OknosTabl()
        {
            InitializeComponent();
            Refresh();
        }

       
        private void Refresh()
        {
            IEnumerable<Productt> products = App.db.Productt;
            if(SearchTb.Text.Length != 0)
            {
                products = products.Where(x => x.SerialNumber.ToString().Contains(SearchTb.Text.ToLower()));
                products = products.Where(x => x.UnitId.ToString().Contains(SearchTb.Text.ToLower()));
            }
            else if(SearchTb.Text.Length == 1)
            {
               products = products.OrderBy(x => x.Name);
            }
            else
            {
                products = products.ToList();
            }
            
            //if(SearchCb.Text != "")
            //{
            //    products = products.Where((x) => x.SerialNumber.ToString().Contains(SearchTb.Text)|| x.Name.Contains(SearchTb.Text));
            //}
            list.ItemsSource = products;
            if (SearchCb.SelectedIndex != 0)
            {
                if(SearchCb.SelectedIndex == 1)
                {
                    products = products.Where(x => x.SerialNumber == 1);
                    list.ItemsSource = products;
                }
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(list.SelectedItem != null)
            {
                App.db.Productt.Remove(list.SelectedItem as Productt);
                App.db.SaveChanges();
                Refresh();
            }
        }
        

      

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRedactPage());
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRedactPage());
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
