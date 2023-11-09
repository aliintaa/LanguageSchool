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
using System.Windows.Threading;

namespace WpfApp1.mypage
{
    /// <summary>
    /// Логика взаимодействия для UpcimongEntriesPage.xaml
    /// </summary>
    public partial class UpcimongEntriesPage : Page
    {
        DateTime endDate = DateTime.Today.AddDays(2);
        public UpcimongEntriesPage()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Start();
            EntriesList.ItemsSource = App.db.ClientService.ToList();
            App.db.ClientService.Where(x => x.StartTime >= DateTime.Now && x.StartTime < endDate).OrderBy(x => x.StartTime).ToList();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            EntriesList.ItemsSource = App.db.ClientService.Where(x => x.StartTime >= DateTime.Now && x.StartTime < endDate).OrderBy(x => x.StartTime).ToList();
        }
    }
}

