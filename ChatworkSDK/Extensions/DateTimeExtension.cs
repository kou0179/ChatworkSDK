using System;
using System.Collections.Generic;
using System.Text;

namespace ChatworkSDK.Extensions
{
    public static class DateTimeExtension
    {
        private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            var utcTime = dateTime.ToUniversalTime();
            var elapsedTime = utcTime - UNIX_EPOCH;
            return (long)elapsedTime.TotalSeconds;
        }
    }
}
