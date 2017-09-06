using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace CountryInfo.Net.Test.CommonUtils
{
    internal class RequestToUri
    {
        private readonly RestClient mRestClient;

        internal RequestToUri(RestClient restClient)
        {
            mRestClient = restClient;
        }

        internal dynamic GetDeserealizeObject(string uri)
        {
            RestRequest request = NewRequest(uri);
            RestResponse response = (RestResponse)NewResponse(request);

            return Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
        }

        private static RestRequest NewRequest(string uri)
        {
            return new RestRequest(uri, Method.GET);
        }

        private IRestResponse NewResponse(IRestRequest request)
        {
            IRestResponse response = mRestClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                return response;

            throw new Exception(response.StatusDescription);
        }
    }

    internal static class ObjectToList
    {
        internal const string mCountriesUri = "/mledoze/countries/master/countries.json";
    
        private static readonly RequestToUri mRequestToUri = new RequestToUri(new RestClient("https://raw.githubusercontent.com"));

        internal static List<string> GetCca2List()
        {
            dynamic jobject = mRequestToUri.GetDeserealizeObject(mCountriesUri);
            var list = new List<string>();

            foreach (dynamic keys in jobject)
            {
                list.Add(keys.cca2.ToString());
            }

            return list;
        }

        internal static Dictionary<string, string> GetCcn3List()
        {
            dynamic jobject = mRequestToUri.GetDeserealizeObject(mCountriesUri);
            var dictionary = new Dictionary<string, string>();

            foreach (dynamic keys in jobject)
            {
                dictionary.Add(keys.name.common.ToString(), keys.ccn3.ToString());  
            }

            return dictionary;
        }
    }   
}
