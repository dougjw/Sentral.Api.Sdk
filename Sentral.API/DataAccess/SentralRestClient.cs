
using Sentral.API.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Sentral.API.DataAccess
{

    internal class SentralRestClient
    {

        private readonly ApiHeader headers = null;

        // The only supported MIME Type in Sentral is application/json
        internal const string ContentType = "application/vnd.api+json";
        internal string Uri { get; set; }
        internal ApiMethod Method { get; set; }
        internal string PostData { get; set; }
        private const int MAX_TRIES = 3;

        internal SentralRestClient(string uri, ApiHeader header)
        {
            Uri = uri;
            Method = ApiMethod.GET;
            PostData = "";
            headers = header;
        }


        internal SentralRestClient(string uri, ApiHeader header, ApiMethod method)
        {
            Uri = uri;
            Method = method;
            PostData = "";
            headers = header;
        }

        internal SentralRestClient(string uri, ApiHeader header, ApiMethod method, string postData)
        {
            Uri = uri;
            Method = method;
            PostData = postData;
            headers = header;
        }


        internal string Invoke()
        {
            return Invoke(1);
        }

        private string Invoke(int retryNumber)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(Uri);

                request.Headers.Add("X-API-KEY", headers.Key);
                request.Headers.Add("X-API-TENANT", headers.Tenant);

                request.Method = Method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;

                if (
                        !string.IsNullOrEmpty(PostData) && 
                        (
                            Method == ApiMethod.POST || Method == ApiMethod.PATCH
                        )
                )
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

                    if (
                        response.StatusCode != HttpStatusCode.OK &&
                        !( Method == ApiMethod.DELETE && response.StatusCode == HttpStatusCode.NoContent)
                    )
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

                var webResponse = (HttpWebResponse)webex.Response;

                // Max timeout tries or Error Response received.
                if (
                        webResponse == null || 
                        webResponse.StatusCode != HttpStatusCode.RequestTimeout ||
                        retryNumber > MAX_TRIES)
                {
                    throw GetRestClientException(null, webex);
                }

                // retry if timeout

                PauseExecution(retryNumber);
                return Invoke(retryNumber + 1);
            }
        }


        public byte[] InvokeBinary()
        {
            return InvokeBinary(1);
        }


        // Deal with code clones later
        private byte[] InvokeBinary(int retryNumber)
        {
            try
            {
                byte[] result = null;
                var request = (HttpWebRequest)WebRequest.Create(Uri);

                request.Headers.Add("X-API-KEY", headers.Key);
                request.Headers.Add("X-API-TENANT", headers.Tenant);

                request.Method = Method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;

                if (
                        !string.IsNullOrEmpty(PostData) &&
                        (
                            Method == ApiMethod.POST || Method == ApiMethod.PATCH
                        )
                )
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
                        {
                            byte[] buffer = new byte[4096];
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                int count = 0;
                                do
                                {
                                    count = responseStream.Read(buffer, 0, buffer.Length);
                                    memoryStream.Write(buffer, 0, count);

                                } while (count != 0);

                                result = memoryStream.ToArray();

                            }
                        }

                    }

                    return result;
                }
            }
            catch (WebException webex)
            {
                if (retryNumber > MAX_TRIES)
                {
                    throw GetRestClientException(null, webex);
                }

                PauseExecution(retryNumber);
                return InvokeBinary(retryNumber + 1);
            }
        }

        private void PauseExecution(int cycleNumber)
        {
            int exponentialBackoff =  cycleNumber ^ cycleNumber * 1000;
            Thread.Sleep(exponentialBackoff);
        }

        private RestClientException GetRestClientException(HttpWebResponse res, WebException webex)
        {
            string message;

            if (res == null && webex != null)
            {
                res = (HttpWebResponse)webex.Response;
            }

            if (res == null)
            {
                message = "Request Failed. Error: " + webex.Message;
            }
            else
            {
                message = string.Format("Request Failed. Received HTTP {0}", (int)res.StatusCode);
            }

            RestClientException ex = null;
            if (webex != null)
            {
                ex = new RestClientException(message, webex);
            }
            else
            {
                ex = new RestClientException(message);
            }

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