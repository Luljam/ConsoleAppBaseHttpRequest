using System;
using System.IO;
using System.Net;

namespace ConsoleAppBaseHttpRequest.Services.Integration
{
    public abstract class BaseHttpRequest
    {
        protected static string GetHttpWebRequest(WebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = string.Empty;

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Stream stream = null;
                try
                {
                    stream = webRequest.GetResponse().GetResponseStream();
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        stream = null;
                        var ret = String.Format("{0} \nResponse: {1}", ex.Message, reader.ReadToEnd());
                        return ret;
                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }
            }
            finally
            {
                responseReader.Close();
            }
            return responseData;
        }
    }
}
