using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerService.Application.Contracts.Models.V1.Extensions
{
    public static class HttpClientExtensions



    {
        private const string _contentType = "application/json";

        static HttpClientExtensions()
        {

        }




        public static async Task<TResponse> ExecutePostAsync<TResponse>(this HttpClient httpClient, string requestUri,
            object request = null, Action<HttpRequestMessage> executeRequestAction = null,
            Action<HttpResponseMessage> executeResponseAction = null)
        {
            throw new NotImplementedException();

        }


        private static async Task<TResponse> ResponseValidation<TResponse>(HttpVerbs verbName, string requestUri,
            HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }
    }

    public enum HttpVerbs
    {
        GET,
        PUT,
        POST,
        DELETE
    }
}
