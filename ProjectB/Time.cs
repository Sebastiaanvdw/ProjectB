using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB
{
	class Time
	{
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("availability1")]
        public bool Availability1 { get; set; }

        [JsonProperty("availability2")]
        public bool Availability2 { get; set; }

        [JsonProperty("availability3")]
        public bool Availability3 { get; set; }
    }
    class JSONTimeList
    {
        [JsonProperty("times")]
        public List<Time> Time { get; set; }
    }
}
