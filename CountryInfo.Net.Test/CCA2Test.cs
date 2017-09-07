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
            List<string> listCca2= Enum.GetValues(typeof(Cca2))
                .Cast<Cca2>()
                .Select(v => v.ToString())
                .ToList();

            Assert.AreEqual(RequestToUri.GetValueWithKey("cca2").Values, listCca2);
        }

        [Test]
        public static void Test()
        {
            Console.WriteLine(Ccn3.Aruba);
        }
    }
}
