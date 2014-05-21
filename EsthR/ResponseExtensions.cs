using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace EsthR
{
    public static class ResponseExtensions
    {
        public static Response WithHeader(this Response response, string key, string value)
        {
            response.Headers.Add(new KeyValuePair<string, string>(key, value));
            return response;
        }

        public static Response WithStatusCode(this Response response, uint statusCode)
        {
            response.StatusCode = statusCode;
            return response;
        }

        public static Response WithBody(this Response response, string body)
        {
            response.Body = body;
            return response;
        }

        public static Response WithType(this Response response, Type responseType)
        {
            response.ResponseType = responseType;
            return response;
        }

        public static Response WithCondition(this Response response, Func<Response, bool> condition)
        {
            response.ResponseCheckerFunction = condition;
            return response;
        }

        public static Response FillFromHttpResponse(this Response response, HttpResponseMessage httpResponse)
        {
            if (response == null)
            {
                throw new ArgumentException("Response object is null!");
            }

            if (httpResponse == null)
            {
                throw new ArgumentException("HTTP response is null!");
            }

            response.StatusCode = (uint)httpResponse.StatusCode;
            response.Body = httpResponse.Content.ReadAsStringAsync().Result;

            foreach (var header in httpResponse.Headers)
            {
                response.Headers.Add(new KeyValuePair<string, string>(
                    header.Key, header.Value.FirstOrDefault()));
            }

            return response;
        }
    }
}
