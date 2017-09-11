using System;
using System.Collections.Generic;
using System.Linq;

namespace CountryInfo.Net.Test.CommonUtils
{
    internal static class Utils
    {

        internal static void PrintResut(IEnumerable<KeyValuePair<string, string>> dictionary, bool enumWithIntegerValue = false)
        {
            foreach (var element in dictionary)
            {
                if(enumWithIntegerValue)
                    CreateEnumWithIntegerValue(element.Key, element.Value);
                else
                    AddXmlElement(element.Key, element.Value);
            }
            
        }
        
        internal static List<string> GetEnum<T>() where T : struct
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(v => v.ToString())
                .ToList();
        }

        private static void CreateEnumWithIntegerValue(string key, string value)
        {
            AddXmlElement(key, $"{key} = {value}"
                .Replace(" ", string.Empty).Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty));
        }

        private static void AddXmlElement(string key, string value)
        {
            Console.WriteLine("/// <summary>\n" + "/// " + key + "\n/// </summary>\n" + value + ",\n");
        }
    }
}
