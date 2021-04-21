
using Sentral.API.DataAccess.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Sentral.API.DataAccess
{

    internal class SentralRestClient
    {

        private APIHeader headers = null;

        // The only supported MIME Type in Sentral is application/json
        internal const string ContentType = "application/json";
        internal string Uri { get; set; }
        internal APIMethod Method { get; set; }
        internal string PostData { get; set; }

        internal SentralRestClient(string uri, APIHeader header)
        {
            Uri = uri;
            Method = APIMethod.GET;
            PostData = "";
            headers = header;
        }


        internal SentralRestClient(string uri, APIHeader header, APIMethod method)
        {
            Uri = uri;
            Method = method;
            PostData = "";
            headers = header;
        }

        internal SentralRestClient(string uri, APIHeader header, APIMethod method, string postData)
        {
            Uri = uri;
            Method = method;
            PostData = postData;
            headers = header;
        }

        internal string Invoke()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(Uri);

                request.Headers.Add("X-API-KEY", headers.Key);
                request.Headers.Add("X-API-TENANT", headers.Tenant);
                
                request.Method = Method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;

                if (!string.IsNullOrEmpty(PostData) && Method == APIMethod.POST)
                {
                    var bytes = Encoding.UTF8.GetBytes(PostData);
                    request.ContentLength = bytes.Length;

                    using (var writeStream = request.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw GetRestClientException(response, null);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    return responseValue;
                }
            }
            catch (WebException webex)
            {
                throw GetRestClientException(null, webex);

            }
        }

        private RestClientException GetRestClientException(HttpWebResponse res, WebException webex)
        {
            string message = "";

            if (res == null && webex != null)
                res = (HttpWebResponse)webex.Response;
            if (res == null)
                message = "Request Failed. Error: " + webex.Message;
            else
                message = string.Format("Request Failed. Received HTTP {0}", (int)res.StatusCode);
            RestClientException ex = null;
            if (webex != null)
                ex = new RestClientException(message, webex);
            else
                ex = new RestClientException(message);
            if (res != null)
            {
                ex.Response = res;
                //ex.ErrorDetails = StringHelper.getJsonAsDictionary((new StreamReader(res.GetResponseStream())).ReadToEnd());
                //ex.ErrorDetails = (new StreamReader(res.GetResponseStream()).ReadToEnd()).ToString();
            }
            return ex;
        }

    }
}