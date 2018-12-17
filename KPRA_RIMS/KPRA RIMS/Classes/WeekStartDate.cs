using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRA_RIMS
{
    public static class WeekSartDate
    {

        public static string weekstarts(string date)
        {

            DateTime value;
            value = Convert.ToDateTime(date);
            DayOfWeek Cday = value.DayOfWeek;
            DayOfWeek startday = DayOfWeek.Monday;
            int a = Cday - startday;
            DateTime value_2 = value.AddDays(-a);
            return value_2.ToString("yyyy-MM-dd");
        }

    }
}
