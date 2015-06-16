using System;

namespace DesktopClient.Extension
{
    public static class StringExtensions
    {
        public static bool IsGuid(this string guidString)
        {
            Guid guid;
            return Guid.TryParse(guidString, out guid);
        }
    }
}