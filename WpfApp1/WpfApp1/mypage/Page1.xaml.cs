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
using WpfApp1.Componens;
using static WpfApp1.Componens.Navigation;

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
            if (App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Service> services = App.db.Service;
            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                    services = services.OrderBy(x => x.TotalCost);
                else
                    services = services.OrderByDescending(x => x.TotalCost);
            }

            if (DiscountFilterCb.SelectedIndex != 0)
            {
                if (DiscountFilterCb.SelectedIndex == 1)
                {
                    services = services.Where(x => x.Discount < 5 | x.Discount == null);
                }
                else if (DiscountFilterCb.SelectedIndex == 2)
                {
                    services = services.Where(x => (int)x.Discount > 5 & (int)x.Discount < 15);
                }
                else if (DiscountFilterCb.SelectedIndex == 3)
                {
                    services = services.Where(x => (int)x.Discount > 15 & (int)x.Discount < 30);
                }
                else if (DiscountFilterCb.SelectedIndex == 4)
                {
                    services = services.Where(x => (int)x.Discount > 30 & (int)x.Discount < 70);
                }
                else if (DiscountFilterCb.SelectedIndex == 5)
                {
                    services = services.Where(x => (int)x.Discount > 70 & (int)x.Discount < 100);
                }
            }
            if (SearchTb.Text != null)
            {
                services = services.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower()) ||
                x.Description.ToLower().Contains(SearchTb.Text.ToLower()));
            }
            ServiceWp.Children.Clear();
            foreach (var service in services)
            {
                ServiceWp.Children.Add(new ServaseUserControl(service));
            }
        }

        private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }



        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }




        private void SortCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            Navigation.NextPage(new PageComponent(new mypage.AddReadactPage(), "Добавить услугу"));

        }
    }
}

