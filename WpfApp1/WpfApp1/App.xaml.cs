using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Componens;
using WpfApp1.mypage;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LnggschlEntities db = new LnggschlEntities();
        public static bool isAdmin = false;
        public static MainWindow mainWindow;
        public static AddReadactPage servicePage;

    }
}
