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

        public static int? ToInteger<T>(this T enumString) where T : struct
        {
            //todo added

            return null;
        }
    }
}
