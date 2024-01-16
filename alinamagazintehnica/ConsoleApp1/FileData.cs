using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FileData : IDataProvider

    {
        public string GetData()
        {
            return("Данные из файла");
        }
    }
}
