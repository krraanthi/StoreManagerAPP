using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace Store_Manager_APP.Models
{
    public class Item
    {
        [JsonProperty("itemId")]
        public string ItemId { get; set; }

        [JsonProperty("billId")]
        public string BillId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Size { get; set; }

        public double Price { get; set; }
    }

    public class Bills
    {

        public Bills()
        {
            Id = Guid.NewGuid().ToString();
            Items = new List<Item>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("totalQuantity")]
        public int TotalQuantity { get; set; }

        [JsonProperty("amount")]
        public float Amount { get; set; }

        [JsonProperty("billDate")]
        public DateTime BillDate { get; set; }

        [JsonProperty("items")] 
        public List<Item> Items { get; set; }

    }
}
