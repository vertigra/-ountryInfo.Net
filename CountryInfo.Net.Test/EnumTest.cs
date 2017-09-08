using System;
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
            var listCca2= Enum.GetValues(typeof(Cca2))
                .Cast<Cca2>()
                .Select(v => v.ToString())
                .ToList();

            Assert.AreEqual(RequestToUri.GetValueWithKey("cca2").Values, listCca2);
        }


        /// <summary>
        /// <code>.Where(keys => keys.Value != "")</code> because Kosovo does not have the ISO 3166-1 numeric code
        /// </summary>
        [Test, Timeout(30000)]
        public static void Ccn3Test()
        {
            var listCcn3enum = Enum.GetValues(typeof(Ccn3))
                .Cast<Ccn3>()
                .Select(v => ((int)v).ToString("000"))
                .ToList();

            var listExpected = 
                RequestToUri.GetValueWithKey("ccn3").Where(keys => keys.Value != "").Select(keys => keys.Value).ToList();

            listExpected.Sort();

            Assert.AreEqual(listExpected, listCcn3enum); 
        }


        [Test, Timeout(30000)]
        public static void Cca3Test()
        {
            var listCca2 = Enum.GetValues(typeof(Cca3))
                .Cast<Cca3>()
                .Select(v => v.ToString())
                .ToList();

            Assert.AreEqual(RequestToUri.GetValueWithKey("cca3").Values, listCca2);
        }
    }
}
