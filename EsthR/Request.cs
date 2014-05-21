using System.Collections.Generic;
using System.IO;
using EsthR.Utility;
using Newtonsoft.Json;

namespace EsthR
{
    public class Request
    {
        public Request()
        {
            Headers = new List<KeyValuePair<string, string>>();
            UrlParameters = new List<KeyValuePair<string, string>>();
            FormValues = new List<KeyValuePair<string, string>>();
        }

        [JsonProperty("uri")]
        public string Uri { get; internal set; }

        [JsonProperty("method")]
        public string Method { get; internal set; }

        [JsonProperty("headers")]
        public List<KeyValuePair<string, string>> Headers { get; internal set; }

        [JsonProperty("url_parameters")]
        public List<KeyValuePair<string, string>> UrlParameters { get; internal set; }

        [JsonProperty("form_values")]
        public List<KeyValuePair<string, string>> FormValues { get; internal set; }
        
        [JsonProperty("body")]
        public string Body { get; internal set; }

        static public Request FromConfig(string path)
        {
            return Serializer.Deserialize<Request>(File.ReadAllText(path));
        }
    }
}
