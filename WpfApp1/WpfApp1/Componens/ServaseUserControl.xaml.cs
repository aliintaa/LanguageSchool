using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1.Componens
{
    /// <summary>
    /// Логика взаимодействия для ServaseUserControl.xaml
    /// </summary>
    public partial class ServaseUserControl : UserControl
    {
        private Service service;
        public ServaseUserControl(Service _service)
        {
            InitializeComponent();
            service = _service;
            CosTb.Text = service.Cost.ToString();
            TitleTb.Text = service.Title;
            CostTimeTb.Text = service.CostTime;
            DiscountTb.Text = service.DiscountStr;
            CosTb.Visibility = service.CostVisibility;
            ServiceImg.Source = GetImageSourse(service.MainImage);
            MainBorder.Background = service.DiscountBrush;
        }

        private BitmapImage GetImageSourse(byte[] byteImage)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                MemoryStream byteStream = new MemoryStream(byteImage);

                bitmapImage.BeginInit();
                bitmapImage.StreamSource = byteStream;
                bitmapImage.EndInit();

            }

            catch
            {
                MessageBox.Show("Error");
            }
            return bitmapImage;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (service.ClientService != null)
            {
                MessageBox.Show("Удаление запрещенно");
            }
            else
            {
                App.db.Service.Remove(service);
                App.db.SaveChanges();
            }

        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {

            Navigation.NextPage(new PageComponent(new mypage.AddReadactPage(), "Редактировать"));

        }
    }
}


