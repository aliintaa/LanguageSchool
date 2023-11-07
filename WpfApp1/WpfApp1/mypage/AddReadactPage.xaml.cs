﻿using System;
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
            App.servicePage = this;
            service = _service;
            this.DataContext = service;
            RefreshPhoto();
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
            StringBuilder errors = new StringBuilder();
            if(service.ID == 0)
            {
                if(App.db.Service.Any(x=> x.Title == service.Title))
                {
                    errors.AppendLine("Такая услуга уже имеется!");
                }
                else
                {
                    App.db.Service.Add(service);
                }
            }
            if(service.DurationInSeconds > 14400)
            {
                errors.AppendLine("Длительность не может привышать 4 часов");
            }
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString()); 
            }
            else
            {
                App.db.SaveChanges();
                MessageBox.Show("Сохранено");
                Navigation.NextPage(new PageComponent(new mypage.Page1(),"Список услуг")); 
            }
        }

        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(char.IsDigit(e.Text[0])))
            {
                e.Handled = true;
            }
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
                App.db.ServicePhoto.Add(new ServicePhoto
                {
                    ServiceID = service.ID,
                    PhotoByte = File.ReadAllBytes(openFile.FileName)
                   
        });
            RefreshPhoto();
            App.db.SaveChanges();
        }  
        public void RefreshPhoto()
        {
            PhotoWp.Children.Clear();
            foreach(var photo in App.db.ServicePhoto)
            {
                PhotoWp.Children.Add(new PhotoUserControl(photo));
            }
            BitmapImage bitmapImage = new BitmapImage();
            MemoryStream byteStream = new MemoryStream(service.MainImage);
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = byteStream; 
            bitmapImage.EndInit();
            Image.Source = bitmapImage; 
        }
    }
}
