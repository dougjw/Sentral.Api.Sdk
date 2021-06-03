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
            return Invoke(1, StringResponseMethod);
        }

        public byte[] InvokeBinary()
        {
            return Invoke(1, BinaryResponseMethod);
        }

        private delegate T DelReturnType<T>(Stream steam);

        // Deal with code clones later
        private T Invoke<T>(int retryNumber, DelReturnType<T> streamMethod)
        {
            try
            {
                T result = default;
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

                    ValiateResponse(response);

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            return streamMethod(responseStream);
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
                return Invoke(retryNumber + 1, streamMethod);
            }
        }

        private void ValiateResponse(HttpWebResponse response)
        {
            if (
                    (Method == ApiMethod.DELETE && response.StatusCode != HttpStatusCode.NoContent)
                    ||
                    (Method != ApiMethod.DELETE && response.StatusCode != HttpStatusCode.OK)
            )
            {
                throw GetRestClientException(response, null);
            }
        }

        private byte[] BinaryResponseMethod(Stream stream)
        {
            byte[] buffer = new byte[4096];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int count = 0;
                do
                {
                    count = stream.Read(buffer, 0, buffer.Length);
                    memoryStream.Write(buffer, 0, count);

                } while (count != 0);

                return memoryStream.ToArray();
            }

        }

        private string StringResponseMethod(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private void PauseExecution(int cycleNumber)
        {
            int exponentialBackoff =  cycleNumber ^ cycleNumber * 1000;
            Thread.Sleep(exponentialBackoff);
        }

        private RestClientException GetRestClientException(HttpWebResponse response, WebException webEx)
        {
            string message;

            if (response == null && webEx != null)
            {
                response = (HttpWebResponse)webEx.Response;
            }

            if (response == null)
            {
                message = "Request Failed. Error: " + webEx.Message;
            }
            else
            {
                message = string.Format("Request Failed. Received HTTP {0}", (int)response.StatusCode);
            }

            RestClientException ex;
            if (webEx != null)
            {
                ex = new RestClientException(message, webEx);
            }
            else
            {
                ex = new RestClientException(message);
            }

            if (response != null)
            {
                ex.Response = response;
                ex.ErrorDetails = new Dictionary<string, object>();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    ex.ErrorDetails["Response Message"] = reader.ReadToEnd();
                }
            }
            return ex;
        }

    }
}