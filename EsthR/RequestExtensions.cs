using System.Collections.Generic;

namespace EsthR
{
    public static class RequestExtensions
    {
        public static Request WithUri(this Request request, string uri)
        {
            request.Uri = uri;
            return request;
        }

        public static Request WithMethod(this Request request, string method)
        {
            request.Method = method;
            return request;
        }

        public static Request WithHeader(this Request request , string key, string value)
        {
            request.Headers.Add(new KeyValuePair<string, string>(key, value));
            return request;
        }

        public static Request WithUriParameter(this Request request, string key, string value)
        {
            request.UrlParameters.Add(new KeyValuePair<string, string>(key, value));
            return request;
        }

        public static Request WithFormValue(this Request request, string key, string value)
        {
            request.FormValues.Add(new KeyValuePair<string, string>(key, value));
            return request;
        }

        public static Request WithBody(this Request request, string body)
        {
            request.Body = body;
            return request;
        }
    }
}
