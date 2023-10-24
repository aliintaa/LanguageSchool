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

namespace WpfApp1.mypage
{
    /// <summary>
    /// Логика взаимодействия для AddReadactPage.xaml
    /// </summary>
    public partial class AddReadactPage : Page
    {
        public AddReadactPage()
        {
            InitializeComponent();
        }

  
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent(new mypage.AddReadactPage(), "Сохранить"));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
