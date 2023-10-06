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

namespace WpfApp1.Componens
{
    /// <summary>
    /// Логика взаимодействия для ServaseUserControl.xaml
    /// </summary>
    public partial class ServaseUserControl : UserControl
    {
        public ServaseUserControl(Image image, string title, decimal cost, string costTime, string discount, Visibility costVisibility)
        {
            InitializeComponent();
            CosTb.Text = cost.ToString();
            ServiceImg = image;
            TitleTb.Text = title;
            CostTimeTb.Text = costTime;
            DiscountTb.Text = discount;
            CosTb.Visibility = costVisibility;
        }
    }
}