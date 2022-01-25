using System;

namespace HabiticaPetFeeder.Logic.Util;

public static class DateTimeHelper
{
    public static string DateToString(DateTime dateTime)
    {
        return dateTime.ToString("ddd MMM dd yyyy HH:mm:ss");
    }

    public static DateTime StringToDate(string dateTimeString)
    {
        return DateTime.ParseExact(dateTimeString[..24], "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
    }
}
