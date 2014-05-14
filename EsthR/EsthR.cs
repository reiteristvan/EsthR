using System.Net.Http;
using EsthR.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        public void Expect(Response response)
        {
            using (var client = new HttpClient())
            {
                var result = client.SendAsync(_lastRequest).Result;

                _lastResponse = new Response();
                _lastResponse.FillFromHttpResponse(result);
            }

            CheckResponse(response, _lastResponse);
        }

        private void CheckResponse(Response expected, Response actual)
        {
            Assert.AreEqual(expected.StatusCode, actual.StatusCode, "Status code");
            Assert.IsTrue(expected.ResponseCheckerFunction == null || expected.ResponseCheckerFunction(actual), "Custom checker function failed");
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

            if (request.Method != "GET")
            {
                requestMessage.Content = BuildContent(request);
            }

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

            return string.Format("{0}{1}", request.Uri, result.TrimEnd(new[] {'&'}));
        }

        private HttpContent BuildContent(Request request)
        {
            if (string.IsNullOrEmpty(request.Body)) {  return new StringContent(string.Empty); }

            return new StringContent(request.Body);
        }

        private HttpRequestMessage _lastRequest;
        private Response _lastResponse;
    }
}
