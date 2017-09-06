using System;
using NUnit.Framework;

namespace CountryInfo.Net.Test.CommonUtils
{
    internal class CreateEnum
    {
        [Test]
        public void Ccn3Create()
        {
            foreach (var keys in ObjectToList.GetCcn3List())
            {
                Console.WriteLine("/// <summary>\n" + "/// " + keys.Key + "\n/// </summary>\n" + keys.Value);
            }
        }

    }
}
