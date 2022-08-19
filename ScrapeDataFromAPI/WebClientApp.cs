using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

// -------------------------------------------------------------------------
// if using .NET Framework
// https://docs.microsoft.com/en-us/dotnet/api/system.web.script.serialization.javascriptserializer?view=netframework-4.8
// This requires including the reference to System.Web.Extensions in your project
//using System.Web.Script.Serialization;
using Newtonsoft.Json;
using ScrapeDataFromAPI.Models;
// -------------------------------------------------------------------------
// if using .Net Core
// https://docs.microsoft.com/en-us/dotnet/api/system.text.json?view=net-5.0
//using System.Text.Json;


namespace ScrapeDataFromAPI
{
    internal static class WebClientApp
    {
        static void Main(string[] args)
        {

            // replace the "demo" apikey below with your own key from https://www.alphavantage.co/support/#api-key
            // It seems that you are already a registered user. As a reminder, your API key is: U5L3JCL6TC20YQW6. Thank you!
            string demo = "U5L3JCL6TC20YQW6";
            string QUERY_URL = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey={demo}";
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
                // -------------------------------------------------------------------------
                // if using .NET Framework (System.Web.Script.Serialization)

                //JavaScriptSerializer js = new JavaScriptSerializer();
                //dynamic json_data = js.Deserialize(client.DownloadString(queryUri), typeof(object));
                var json_data = JsonConvert.DeserializeObject<Time_Series_Intraday>(client.DownloadString(queryUri));

                // -------------------------------------------------------------------------
                // if using .NET Core (System.Text.Json)
                // using .NET Core libraries to parse JSON is more complicated. For an informative blog post
                // https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-apis/

                //dynamic json_data = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));

                // -------------------------------------------------------------------------
                Console.ReadLine();
                // do something with the json_data
            }
        }
    }
}
