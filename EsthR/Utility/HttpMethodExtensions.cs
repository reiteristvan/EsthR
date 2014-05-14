using System;
using System.Net.Http;

namespace EsthR.Utility
{
    public static class HttpMethodExtensions
    {
        public static HttpMethod FromString(string method)
        {
            if (string.IsNullOrEmpty(method))
            {
                throw new ArgumentException("HTTP method cannot be null or empty string!");
            }

            HttpMethod result;

            switch (method.ToUpper())
            {
                case "GET":
                    result = HttpMethod.Get;
                    break;
                case "POST":
                    result = HttpMethod.Post;
                    break;
                case "PUT":
                    result = HttpMethod.Put;
                    break;
                case "DELETE":
                    result = HttpMethod.Delete;
                    break;
                case "TRACE":
                    result = HttpMethod.Trace;
                    break;
                case "OPTIONS":
                    result = HttpMethod.Options;
                    break;
                case "HEAD":
                    result = HttpMethod.Head;
                    break;
                default:
                    throw new ArgumentException("Unknown HTTP method!");
            }

            return result;
        }
    }
}
