using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;


namespace Test.Services.ExtensionServices
{
    public static class DateService
    {
        public static string GetDateByMetrics(this DateTime date, string metrics)
        {
            string newDate = "";
            var year = date.Year.ToString();
            var month = date.Month.ToString();
            var monthNumber = date.Month;
            var day = date.Day.ToString();
            var hours = date.Hour.ToString();
            var winter = new List<int>() { 12, 1, 2 };
            var spring = new List<int>() { 3, 4, 5 };
            var summer = new List<int>() { 6, 7, 8 };
            var autmn = new List<int>() { 9, 10, 11 };
            string quarter = winter.Contains(monthNumber)?"winter":spring.Contains(monthNumber)?"spring":summer.Contains(monthNumber)?"summer":autmn.Contains(monthNumber)?"autmn":"";
            switch (metrics)
            {
                case "hour":
                    newDate = year + "-" + month + "-" + day + "-" + " " + hours + ":" + "00";
                    break;
                case "month":
                    newDate = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber) + ", " + year + "-";
                    break;
                case "quarter":

                    newDate = year + " " + quarter;
                    break;
                case "year":
                    newDate = year ;
                    break;
            }
            return newDate;
        }
    }
}
