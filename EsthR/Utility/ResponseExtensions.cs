using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace EsthR.Utility
{
    public static class ResponseExtensions
    {
        public static Response FillFromHttpResponse(this Response response, HttpResponseMessage httpResponse)
        {
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
