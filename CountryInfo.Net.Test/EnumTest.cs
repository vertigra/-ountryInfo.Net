using System;
using System.Collections.Generic;
using System.Linq;
using CountryInfo.Net.Test.CommonUtils;
using NUnit.Framework;

namespace CountryInfo.Net.Test
{
    [TestFixture]
    internal class EnumTest
    {
        [Test, Timeout(30000)]
        public static void Cca2Test()
        {
            List<string> listCca2= Enum.GetValues(typeof(Cca2))
                .Cast<Cca2>()
                .Select(v => v.ToString())
                .ToList();

            Assert.AreEqual(RequestToUri.GetValueWithKey("cca2").Values, listCca2);
        }

        [Test, Ignore("Fail")]
        public static void Ccn3Test()
        {
            List<string> listCcn3enum = Enum.GetValues(typeof(Ccn3))
                .Cast<Ccn3>()
                .Select(v => ((int)v).ToString())
                .ToList();

            Assert.AreEqual(RequestToUri.GetValueWithKey("ccn3").Values, 
                listCcn3enum); ;
        }
    }
}
