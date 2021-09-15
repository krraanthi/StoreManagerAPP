using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Store_Manager_APP.Models
{
    public class Inventory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("cost")]
        public double Cost { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }

}
