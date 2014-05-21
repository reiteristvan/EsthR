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
        public List<KeyValuePair<string, string>> Headers { get; internal set; }

        [JsonProperty("status_code")]
        public uint StatusCode { get; internal set; }

        [JsonProperty("body")]
        public string Body { get; internal set; }

        [JsonIgnore]
        public Type ResponseType { get; internal set; }

        [JsonIgnore]
        public Func<Response, bool> ResponseCheckerFunction { get; internal set; }  

        public static Response FromConfig(string path)
        {
            return Serializer.Deserialize<Response>(File.ReadAllText(path));
        }
    }
}
