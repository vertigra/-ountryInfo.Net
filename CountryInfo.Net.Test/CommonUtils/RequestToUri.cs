using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CountryInfo.Net.Test.CommonUtils
{
    internal class RequestToUri
    {
        private const string mCountriesUri = "/mledoze/countries/master/countries.json";
        private static readonly RestClient mRestClient = new RestClient("https://raw.githubusercontent.com");

        /// <summary>
        /// Gets the value with key.
        /// </summary>
        /// <param name="key">Json key</param>
        /// <returns><see cref="Dictionary{TKey,TValue}">TKey is country, TValue is value key in param</see></returns>
        internal static Dictionary<string, string> GetValueWithKey(string key, bool needParseArray = false)
        {
            JArray jArray = GetDeserealizeObject(mCountriesUri);

            return jArray.Cast<JObject>().
                ToDictionary(
                    keys => keys["name"]["common"].ToString(),
                    keys => keys[key].ToString());
        }

        private static JArray GetDeserealizeObject(string uri)
        {
            RestRequest request = NewRequest(uri);
            RestResponse response = (RestResponse)NewResponse(request);

            return (JArray)JsonConvert.DeserializeObject(response.Content);
        }

        private static RestRequest NewRequest(string uri)
        {
            return new RestRequest(uri, Method.GET);
        }

        private static IRestResponse NewResponse(IRestRequest request)
        {
            IRestResponse response = mRestClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response;

            throw new Exception(response.StatusDescription);
        }
    }
}
