using System;

namespace CountryInfo.Net
{
    public static class Extension
    {
        public static T? ToEnum<T>(this string enumString) where T : struct
        {
            if (Enum.IsDefined(typeof(T), enumString))
                return (T)Enum.Parse(typeof(T), enumString, true);

            return null;
        }
    }
}
