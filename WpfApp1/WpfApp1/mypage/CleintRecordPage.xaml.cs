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

namespace WpfApp1.mypage
{
    /// <summary>
    /// Логика взаимодействия для CleintRecordPage.xaml
    /// </summary>
    public partial class CleintRecordPage : Page
    {
        public CleintRecordPage(Service _service)
        {
            InitializeComponent();
            this.DataContext = _service;
        }
    }
}
