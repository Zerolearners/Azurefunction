namespace ai_finder_be_schedulers_donetcore.Common
{
    public static class DateTimeExtension
    {
        public static DateTime ToDateTimeFromLong(this long value)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(value);
            return dateTimeOffset.UtcDateTime;
        }

        public static string ToDateWithShortMonthName(this DateTime value)
        {
            return value.ToString("dd-MMM-yyyy");
        }

        public static string ToDateWithShortMonthNameWithTime(this DateTime value)
        {
            return value.ToString("dd MMM yyyy hh:mm tt");
        }

        public static DateTime ToIndianTime(this DateTime value)
        {
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            return TimeZoneInfo.ConvertTimeFromUtc(value, istTimeZone);
        }

        public static string ToDateWithMonthName(this DateTime value)
        {
            return value.ToString("dd MMM yyyy");
        }

    }
}