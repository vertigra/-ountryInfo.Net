using System;
using System.Collections.Generic;
using System.Linq;
using CountryInfo.Net.Test.CommonUtils;
using NUnit.Framework;

namespace CountryInfo.Net.Test
{
    [TestFixture]
    internal class CCA2Test
    {
        
        [Test, Timeout(30000)]
        public static void ActualCountriesJsonEqualsWithEnumTest()
        {
            Assert.AreEqual(ObjectToList.GetCca2List(), GetCountriesEnumList());
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
