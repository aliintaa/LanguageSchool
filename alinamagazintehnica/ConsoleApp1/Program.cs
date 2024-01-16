using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataHadler dataHadler = new ConsoleDataHadler();
            dataHadler.HadlerData(new APIData());
            dataHadler.HadlerData(new FileData());

        }
    }
}
