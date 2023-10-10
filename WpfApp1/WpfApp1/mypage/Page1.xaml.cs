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
using WpfApp1.Componens;

namespace WpfApp1.mypage
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            if(App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            var services = App.db.Service.ToList();
            foreach (var service in services)
            {
                ServiceWp.Children.Add(new ServaseUserControl(new Image(), service.Title, service.Cost , service.CostTime, service.DiscountStr,service.CostVisibility));
            }
        }
    }
}
