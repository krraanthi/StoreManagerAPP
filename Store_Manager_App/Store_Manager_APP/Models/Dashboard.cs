using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace Store_Manager_APP.Models
{
    public class Dashboard
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        [JsonProperty("totalWorth")]
        public float TotalWorth { get; set; }

        [JsonProperty("totalBills")]
        public int TotalBills { get; set; }

        [JsonProperty("totalAmount")]
        public float TotalAmount { get; set; }

        [JsonProperty("monthlyBills")]
        public int MonthlyBills { get; set; }

        [JsonProperty("monthlyAmount")]
        public float MonthlyAmount { get; set; }

    }
}
