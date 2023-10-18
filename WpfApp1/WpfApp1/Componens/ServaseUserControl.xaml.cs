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

namespace WpfApp1.Componens
{
    /// <summary>
    /// Логика взаимодействия для ServaseUserControl.xaml
    /// </summary>
    public partial class ServaseUserControl : UserControl
    {
        public ServaseUserControl(byte[] image, string title, decimal cost, string costTime, string discount, Visibility costVisibility)
        {
            InitializeComponent();
            CosTb.Text = cost.ToString();
            TitleTb.Text = title;
            CostTimeTb.Text = costTime;
            DiscountTb.Text = discount;
            CosTb.Visibility = costVisibility;
            ServiceImg.Source = GetImageSourse(image);
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
    }
}


