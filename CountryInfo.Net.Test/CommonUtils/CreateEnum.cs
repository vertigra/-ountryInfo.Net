using System;
using System.Linq;
using NUnit.Framework;

namespace CountryInfo.Net.Test.CommonUtils
{
    internal class CreateEnum
    {
        [Test]
        public void Cca2Create()
        {
            foreach (var keys in RequestToUri.GetValueWithKey("cca2"))
            {
                AddXmlElement(keys.Key, keys.Value);
            }
        }

        [Test]
        public void Ccn3Create()
        {
            foreach (var keys in RequestToUri.GetValueWithKey("ccn3").Where(keys => keys.Value != ""))
            {
                CreateEnumWithIntegerValue(keys.Key, keys.Value);
            }
        }

        private static void CreateEnumWithIntegerValue(string key, string value)
        {
            AddXmlElement(key, $"{key} = {value}"
                .Replace(" ", string.Empty).Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty));        
        }

        private static void AddXmlElement(string key, string value)
        {
            Console.WriteLine("/// <summary>\n" + "/// " + key + "\n/// </summary>\n" + value + ",");
        } 
    }
}
