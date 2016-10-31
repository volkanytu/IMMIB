using RestSharp;
using System;
using System.Net;
namespace SRC.Library.RestClient.Interfaces
{
    public interface IRestServiceClient
    {
        RestRequestInfo<TRequest, TResult> Execute<TRequest, TResult>(RestMethod restMethod, string extUrl, TRequest query, WebHeaderCollection headerCollection);
    }
}
