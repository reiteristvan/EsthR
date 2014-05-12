using System.Collections.Generic;
using System.IO;
using EsthR.Utility;
using Newtonsoft.Json;

namespace EsthR
{
    public class Request
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("headers")]
        public List<KeyValuePair<string, string>> Headers { get; set; }

        [JsonProperty("url_parameters")]
        public List<KeyValuePair<string, string>> UrlParameters { get; set; }

        [JsonProperty("form_values")]
        public List<KeyValuePair<string, string>> FormValues { get; set; }
        
        [JsonProperty("body")]
        public string Body { get; set; }

        static public Request FromConfig(string path)
        {
            return Serializer.Deserialize<Request>(File.ReadAllText(path));
        }

        public Request WithUri(string uri)
        {
            Uri = uri;
            return this;
        }

        public Request WithMethod(string method)
        {
            Method = method;
            return this;
        }

        public Request WithHeader(string key, string value)
        {
            if (Headers == null) {  Headers = new List<KeyValuePair<string, string>>(); }

            Headers.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public Request WithUrlParameter(string key, string value)
        {
            if (UrlParameters == null) { UrlParameters = new List<KeyValuePair<string, string>>(); }

            UrlParameters.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public Request WithFormValue(string key, string value)
        {
            if (FormValues == null) { FormValues = new List<KeyValuePair<string, string>>(); }

            FormValues.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public Request WithBody(string body)
        {
            Body = body;
            return this;
        }
    }
}
