using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Application.Helpers;

public static class DateConvertHelper
{
    public static double ConvertHourToDouble(string hourStr)
    {
        string[] hourToConvert = hourStr.Split(':');

        int hour = int.Parse(hourToConvert[0]);
        int minutes = int.Parse(hourToConvert[1]);

        double hourConverted = (hour * 60 + minutes) / 60.0;

        return hourConverted;
    }

    public static string ConvertDoubleToHour(double hourDouble)
    {
        DateTime hourConverted = DateTime.Today.AddHours(hourDouble);

        return hourConverted.ToString("HH:mm");
    }
}
