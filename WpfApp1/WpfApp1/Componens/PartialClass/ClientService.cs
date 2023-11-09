using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Componens
{
    public partial class ClientService
    {
        public string RemaningTime
        {
            get
            {
                var time = (int)(StartTime - DateTime.Now).TotalMinutes;

                return $"Часы:{time / 60} минуты:{time % 60}";
            }
        }

        public string ColorTime
        {
            get
            {
                var time = (int)(StartTime - DateTime.Now).TotalMinutes;
                if (time < 60)
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            }
        }
    }
}
