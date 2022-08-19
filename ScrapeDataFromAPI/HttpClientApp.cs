using Newtonsoft.Json;
using ScrapeDataFromAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeDataFromAPI
{
    internal class HttpClientApp
    {

        static async Task Main()
        {
            var clientapp = new HttpClientApp();
            var responseBody = await clientapp.GetResponse();
            //var jsonString = "{\n    \"Meta Data\": {\n        \"1. Information\": \"Intraday (5min) open, high, low, close prices and volume\",\n        \"2. Symbol\": \"IBM\",\n        \"3. Last Refreshed\": \"2022-08-18 18:10:00\"\n  }}";
            //Console.WriteLine(responseBody);
            var data = JsonConvert.DeserializeObject<Time_Series_Intraday>(responseBody);
            //Console.WriteLine(data.MetaData._1Information);
            //Console.WriteLine(data.MetaData._2Symbol);
            //Console.WriteLine(data.MetaData._3LastRefreshed);
            //Console.WriteLine(data.MetaData._4Interval);
            //Console.WriteLine(data.MetaData._5OutputSize);
            foreach (var item in data.MetaData)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
            foreach (var item in data.TimeSeries5min)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value._1open);
                Console.WriteLine(item.Value._2high);
                Console.WriteLine(item.Value._3low);
                Console.WriteLine(item.Value._4close);
                Console.WriteLine(item.Value._5volume);
            }
            Console.ReadLine();

        }

        private async Task<string> GetResponse()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.alphavantage.co/");
            string myAPIkey = "U5L3JCL6TC20YQW6";
            client.DefaultRequestHeaders.Add("accept", "application/json");
            var response = await client.GetAsync(
                $"query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey={myAPIkey}");
            var responsebody = await response.Content.ReadAsStringAsync();
            return responsebody;
        }
    }
}
