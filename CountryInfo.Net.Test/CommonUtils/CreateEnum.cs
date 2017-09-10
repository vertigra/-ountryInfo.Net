using System;
using System.Linq;
using NUnit.Framework;

namespace CountryInfo.Net.Test.CommonUtils
{
    internal class CreateEnum
    {
        /// <summary>
        /// Code ISO 3166-1 alpha-2 create
        /// </summary>
        [Test]
        public void Cca2Create()
        {
            foreach (var keys in RequestToUri.GetValueWithKey("cca2"))
            {
                AddXmlElement(keys.Key, keys.Value);
            }
        }

        /// <summary>
        /// Сode ISO 3166-1 numeric create
        /// </summary>
        /// <code>.Where(keys => keys.Value != "")</code> because Kosovo does not have the ISO 3166-1 numeric code
        [Test]
        public void Ccn3Create()
        {
            foreach (var keys in RequestToUri.GetValueWithKey("ccn3").Where(keys => keys.Value != ""))
            {
                CreateEnumWithIntegerValue(keys.Key, keys.Value);
            }
        }

        /// <summary>
        /// Code ISO 3166-1 alpha-3 create.
        /// </summary>
        [Test]
        public void Cca3Create()
        {
            foreach (var keys in RequestToUri.GetValueWithKey("cca3"))
            {
                AddXmlElement(keys.Key, keys.Value);
            }
        }

        /// <summary>
        /// Code International Olympic Committee create
        /// </summary>
        /// <code>.Where(keys => keys.Value != "")</code> because that not all countries have the code of the Olympic Committee
        [Test]
        public void CiocCreate()
        {
            foreach (var keys in RequestToUri.GetValueWithKey("cioc").Where(keys => keys.Value != ""))
            {
                AddXmlElement(keys.Key, keys.Value);
            }
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
