using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace WebServer.ExternalRequests
{
    public class ExternalRequests
    {
        public static string Get(string uri, string apiKey)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            string getAnswer = "";
            request.Headers.Add("apikey", apiKey);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                getAnswer = reader.ReadToEnd();
            }
            catch
            {
                getAnswer = "Server error (exhausted number of requests)";
            }
            return getAnswer;
        }

        public static string GetValidPhone(string phoneNumber)
        {
            phoneNumber = phoneNumber.Replace("%2B", "+");
            string apiKey = "cpJWvQjOx2mz3DDvGKPkz1gFIisHTDlx";//пожалуйста не используйте.. если слоучайно нашли мое решение
            var ans = Get("https://api.apilayer.com/number_verification/validate?number=" + phoneNumber, apiKey);
            return ans;
        }
    }
}
