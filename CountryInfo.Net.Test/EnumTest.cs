using System;
using System.Linq;
using CountryInfo.Net.Test.CommonUtils;
using NUnit.Framework;

namespace CountryInfo.Net.Test
{
    [TestFixture]
    internal class EnumTest
    {
        /// <summary>
        /// Code ISO 3166-1 alpha-2 test
        /// </summary>
        [Test, Timeout(30000)]
        public static void Cca2Test()
        {
            var listCca2 = Utils.GetEnum<Cca2>();
            var listCca2expected = RequestToUri.GetValueWithKey("cca2");

            Utils.PrintResut(listCca2expected);

            Assert.AreEqual(listCca2expected.Values, listCca2);
        }

        /// <summary>
        /// Сode ISO 3166-1 numeric test.
        /// </summary>
        /// <code>.Where(keys => keys.Value != "")</code> because Kosovo does not have the ISO 3166-1 numeric code
        [Test, Timeout(30000)]
        public static void Ccn3Test()
        {
            var listCcn3enum = Enum.GetValues(typeof(Ccn3))
                .Cast<Ccn3>()
                .Select(v => ((int)v).ToString("000"))
                .ToList();
            var listCcn3Expected = RequestToUri.GetValueWithKey("ccn3").Where(keys => keys.Value != "");

            Utils.PrintResut(listCcn3Expected, true);

            var listExpected = listCcn3Expected.Where(keys => keys.Value != "").Select(keys => keys.Value).ToList();

            listExpected.Sort();
            
            Assert.AreEqual(listExpected, listCcn3enum); 
        }

        /// <summary>
        /// Code ISO 3166-1 alpha-3 test.
        /// </summary>
        [Test, Timeout(30000)]
        public static void Cca3Test()
        {
            var listCca2 = Utils.GetEnum<Cca3>();
            var listCca3Expected = RequestToUri.GetValueWithKey("cca3");

            Utils.PrintResut(listCca3Expected);

            Assert.AreEqual(listCca3Expected.Values, listCca2);
        }

        /// <summary>
        /// Code International Olympic Committee test
        /// </summary>
        /// <code>.Where(keys => keys.Value != "")</code> because that not all countries have the code of the Olympic Committee
        [Test, Timeout(30000)]
        public static void CiocTest()
        {
            var listCca2 = Utils.GetEnum<Cioc>();
            var listCiocExpected = RequestToUri.GetValueWithKey("cioc").Where(keys => keys.Value != "");

            Utils.PrintResut(listCiocExpected);

            var listExpected = listCiocExpected.Where(keys => keys.Value != "").Select(keys => keys.Value).ToList();
            
            Assert.AreEqual(listExpected, listCca2);
        }

        /// <summary>
        /// Code International Olympic Committee test
        /// </summary>
        /// <code>.Where(keys => keys.Value != "")</code> because that not all countries have the code of the Olympic Committee
        [Test, Timeout(30000)]
        public static void TldTest()
        {
            var listCca2 = Utils.GetEnum<Cioc>();
            var listCiocExpected = RequestToUri.GetValueWithKey("tld");

            Utils.PrintResut(listCiocExpected);


            //var listExpected = listCiocExpected.Where(keys => keys.Value != "").Select(keys => keys.Value).ToList();

            //Assert.AreEqual(listExpected, listCca2);
        }
    }
}
