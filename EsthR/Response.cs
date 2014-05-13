using System;
using System.Collections.Generic;
using System.IO;
using EsthR.Utility;
using Newtonsoft.Json;

namespace EsthR
{
    public class Response
    {
        public Response()
        {
            Headers = new List<KeyValuePair<string, string>>();
        }

        [JsonProperty("headers")]
        public List<KeyValuePair<string, string>> Headers { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonIgnore]
        public Type ResponseType { get; set; }

        [JsonIgnore]
        public Func<Response, bool> ResponseCheckerFunction { get; private set; }  

        public static Response FromConfig(string path)
        {
            return Serializer.Deserialize<Response>(File.ReadAllText(path));
        }

        public Response WithHeader(string key, string value)
        {
            if (Headers == null)
            {
                Headers = new List<KeyValuePair<string, string>>();
            }

            Headers.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public Response WithStatusCode(string statusCode)
        {
            StatusCode = statusCode;
            return this;
        }

        public Response WithBody(string body)
        {
            Body = body;
            return this;
        }

        public Response WithType(Type responseType)
        {
            ResponseType = responseType;
            return this;
        }

        public Response WithFunction(Func<Response, bool> function)
        {
            ResponseCheckerFunction = function;
            return this;
        }
    }
}
