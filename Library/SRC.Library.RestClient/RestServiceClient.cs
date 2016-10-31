using Newtonsoft.Json;
using RestSharp;
using SRC.Library.RestClient;
using SRC.Library.RestClient.Interfaces;
using System;
using System.Net;

namespace SAHIBINDEN.ServiceLibrary.RestClientManager
{
    public class RestServiceClient : IRestServiceClient
    {
        private string _baseUrl;

        public RestServiceClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public RestRequestInfo<TRequest, TResult> Execute<TRequest, TResult>(RestMethod restMethod, string extUrl, TRequest query, WebHeaderCollection headerCollection = null)
        {
            Method method = (Method)(int)restMethod;

            RestRequestInfo<TRequest, TResult> returnValue = new RestRequestInfo<TRequest, TResult>();
            returnValue.RequestData = query;
            returnValue.RequestDate = DateTime.Now;

            var client = new RestClient(_baseUrl);

            var request = new RestRequest(extUrl, method);

            FillHeaders(request, headerCollection);

            if (query != null)
            {
                if (method == Method.GET || method == Method.DELETE)
                {
                    request.AddObject(query);
                }
                else if (method == Method.POST)
                {
                    request.AddJsonBody(query);
                }
            }

            var response = client.Execute(request);

            returnValue.Response = response;
            returnValue.Url = response.ResponseUri.OriginalString;
            returnValue.ResultStr = response.Content;
            returnValue.StatusCode = response.StatusCode;
            returnValue.StatusDescription = response.StatusDescription;

            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
            {
                returnValue.Result = JsonConvert.DeserializeObject<TResult>(response.Content);
            }
            else
            {
                throw new Exception(returnValue.SerializedInfo);
            }

            return returnValue;
        }

        private RestRequest FillHeaders(RestRequest request, WebHeaderCollection headerCollection)
        {
            if (headerCollection == null)
            {
                return request;
            }

            foreach (string key in headerCollection.AllKeys)
            {
                request.AddHeader(key, headerCollection[key]);
            }

            return request;
        }
    }
}
