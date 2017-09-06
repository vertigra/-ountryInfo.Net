using System;
using System.Collections.Generic;
using System.Linq;
using CountryInfo.Net.Test.CommonUtils;
using NUnit.Framework;
using RestSharp;

namespace CountryInfo.Net.Test
{
    [TestFixture]
    internal class CCA2Test
    {
        
        [Test, Timeout(30000)]
        public static void ActualCountriesJsonEqualsWithEnumTest()
        {
            Assert.AreEqual(GetCountriesList(), GetCountriesEnumList());
        }

        private static List<string> GetCountriesList()
        {
            RequestToUri requestToUri = new RequestToUri(new RestClient("https://raw.githubusercontent.com"));

            dynamic jobject = requestToUri.GetDeserealizeObject(UriConst.mCountriesUri);
            var list = new List<string>();

            foreach (dynamic keys in jobject)
            {
                list.Add(keys.cca2.ToString());
            }

            return list;
        }

        private static List<string> GetCountriesEnumList()
        {
            return Enum.GetValues(typeof(CCA2))
                .Cast<CCA2>()
                .Select(v => v.ToString())
                .ToList();
        }
    }
}
