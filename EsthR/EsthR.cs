using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EsthR.Utility;

namespace EsthR
{
    public class EsthR
    {
        #region Singleton

        private static EsthR _instance;

        public static EsthR Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EsthR();
                }

                return _instance;
            }
        }

        #endregion

        public EsthR Send(Request request)
        {
            _lastRequest = BuildRequest(request);
            return this;
        }

        public EsthR Expect(Response response)
        {
            using (var client = new HttpClient())
            {
                var result = client.SendAsync(_lastRequest).Result;

                //_lastResponse = new Response
                //{
                //    StatusCode = result.StatusCode.ToString(),
                //    Body = result.Content.ReadAsStringAsync().Result,
                //    Headers = new List<KeyValuePair<string, string>>(
                //        result.Headers.Select(
                //        header => new KeyValuePair<string, string>(header.Key, header.Value.Select(val => ))))
                //};
            }

            return this;
        }

        private HttpRequestMessage BuildRequest(Request request)
        {
            var requestMessage = new HttpRequestMessage(
                HttpMethodExtensions.FromString(request.Method),
                BuildUrl(request));

            foreach (var header in request.Headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            requestMessage.Content = BuildContent(request);

            return requestMessage;
        }

        private string BuildUrl(Request request)
        {
            if (request.UrlParameters == null || request.UrlParameters.Count == 0)
            {
                return "";
            }

            string result = "?";

            foreach (var urlParameter in request.UrlParameters)
            {
                result += string.Format("{0}={1}&", urlParameter.Key, urlParameter.Value);
            }

            return result.TrimEnd(new[] {'&'});
        }

        private HttpContent BuildContent(Request request)
        {
            return new StringContent(request.Body);
        }

        private HttpRequestMessage _lastRequest;
        private Response _lastResponse;
    }
}
