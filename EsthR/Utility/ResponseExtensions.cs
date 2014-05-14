using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace EsthR.Utility
{
    public static class ResponseExtensions
    {
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
