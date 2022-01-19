using System;
using System.Globalization;
using Xunit;

namespace HabiticaPetFeeder.Tests;

public class DateTimeParseTest
{
    [Fact]
    public void DateTimeParse_ShouldExtractCorrectDateFromRateLimitHeader()
    {
        const string input = "Wed Jan 19 2022 08:01:54 GMT+0000 (Coordinated Universal Time)";
        const string format = "ddd MMM dd yyyy hh:mm:ss";

        var splitInput = input[..24];

        DateTime expected = new DateTime(2022, 1, 19, 08, 01, 54);

        var actual = DateTime.ParseExact(splitInput, format, CultureInfo.InvariantCulture);

        Assert.Equal(expected, actual);
    }
}
