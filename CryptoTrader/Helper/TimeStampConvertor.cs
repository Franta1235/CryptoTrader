using System;

namespace CryptoTrader.Helper
{
    public static class TimeStampConvertor
    {
        private static readonly DateTime BaseDate = new DateTime(1970, 1, 1);

        public static int DateTimeToTimeStamp(string dateTime) {
            var myDate = DateTime.ParseExact(dateTime, "dd.MM.yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return DateTimeToTimeStamp(myDate);
        }

        public static int DateTimeToTimeStamp(DateTime dateTime) {
            var numberOfSeconds = dateTime.Subtract(BaseDate).TotalSeconds;
            return (int)numberOfSeconds;
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp) {
            // Unix timestamp is seconds past epoch
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp);
            return dateTime;
        }
    }
}