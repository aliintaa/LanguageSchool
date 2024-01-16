using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Avtoriz
{
    public static class Navigation
    {
        public static MainWindow mainWindow;
        private static List<PageComponent> components = new List<PageComponent>();
        public static void ClearHistory()
        {
            components.Clear();
        }
        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);
            Update(pageComponent);
        }
        public static void BackPage()

        {
            if (components.Count > 1)
            {
                components.RemoveAt(components.Count - 1);
                Update(components[components.Count - 1]);
            }
        }
        private static void Update(PageComponent pageComponent)
        {
            mainWindow.FramMW.Navigate(pageComponent.Page);
        }
    }
    
    public class PageComponent
        {
            public Page Page { get; set; }
            public string Title { get; set; }
            public PageComponent(Page page, string title)
            {
                Page = page;
                Title = title;

            }
    }
}
