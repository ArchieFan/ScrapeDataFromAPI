using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ScrapeDataFromAPI.Models
{
    public class Time_Series_Intraday
    {
        //[JsonProperty(PropertyName = "Meta Data")]
        //"Meta Data": {
        //  "1. Information": "",
        //  "2. Symbol": "",
        //  "3. Last Refreshed": "",
        //  "4. Interval": "",
        //  "5. Output Size": "",
        //  "6. Time Zone": ""
        //}
        [JsonProperty("Meta Data")]
        //public MetaData_Model MetaData { get; set; }
        public Dictionary<string, string> MetaData { get; set; }

        //[JsonProperty(PropertyName = "Time Series (5min)")]
        //"Time Series (5min)": {
        //  "2022-08-18 18:10:00": {},
        //  "2022-08-18 16:50:00": {},
        //  "2022-08-18 16:20:00": {
        //      "1. open": "139.0700",
        //      "2. high": "139.0700",
        //      "3. low": "139.0500",
        //      "4. close": "139.0500",
        //      "5. volume": "1978"
        //  }
        //}
        [JsonProperty("Time Series (5min)")]
        public Dictionary<string, TimeSeries5min_Model> TimeSeries5min { get; set; }
    }

    public class MetaData_Model
    {
        [JsonProperty(PropertyName = "1. Information")]
        public string _1Information { get; set; }
        [JsonProperty(PropertyName = "2. Symbol")]
        public string _2Symbol { get; set; }
        [JsonProperty(PropertyName = "3. Last Refreshed")]
        public string _3LastRefreshed { get; set; }
        [JsonProperty(PropertyName = "4. Interval")]
        public string _4Interval { get; set; }
        [JsonProperty(PropertyName = "5. Output Size")]
        public string _5OutputSize { get; set; }
        [JsonProperty(PropertyName = "6. Time Zone")]
        public string _6TimeZone { get; set; }
    }

    public class TimeSeries5min_Model
    {
        [JsonProperty("1. open")]
        public string _1open { get; set; }
        [JsonProperty("2. high")]
        public string _2high { get; set; }
        [JsonProperty("3. low")]
        public string _3low { get; set; }
        [JsonProperty("4. close")]
        public string _4close { get; set; }
        [JsonProperty("5. volume")]
        public string _5volume { get; set; }
    }
}
