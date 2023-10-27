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
using static WpfApp1.Componens.Navigation;
using WpfApp1.Componens;
using Microsoft.Win32;
using System.IO;

namespace WpfApp1.mypage
{
    /// <summary>
    /// Логика взаимодействия для AddReadactPage.xaml
    /// </summary>
    public partial class AddReadactPage : Page
    {
        private Service service;
        public AddReadactPage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
        }

  
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if(openFile.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                Image.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void SaveBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if(service.ID == 0)
            {
                App.db.Service.Add(service);
            }
            App.db.SaveChanges();
        }
    }
}
