using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ScrapeDataFromAPI
{
    internal class HttpWebRequestApp
    {
        static void Main(string[] args)
        {
            string myAPIkey = "U5L3JCL6TC20YQW6";
            string uri = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey={myAPIkey}";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream memoryStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(memoryStream);
            string content = streamReader.ReadToEnd();
            Console.WriteLine(content);
            Console.ReadLine();
        }
    }
}
